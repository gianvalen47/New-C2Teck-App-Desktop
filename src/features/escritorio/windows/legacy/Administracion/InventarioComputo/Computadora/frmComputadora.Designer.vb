<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmComputadora
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
        Dim cmbTipoComputadora_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvSoftwares_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMonCapac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoCapac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCapacitaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim MultiColumnCombo1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComputadora))
        Dim MultiColumnCombo2_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEX2_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosProcesador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosPlacaMadre_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosMemoriaRam_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosTarjetaVideo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosDiscoDuro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosLectora_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosMonitor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosCargador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosTeclado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosMouse_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosSoftware_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardarComputadora = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditarComputadora = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacerComputadora = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosComputadora = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtObservacionCom = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtComputadora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.txtIdComputadora = New System.Windows.Forms.TextBox()
        Me.lblIdPer = New System.Windows.Forms.Label()
        Me.lblComputadora = New System.Windows.Forms.Label()
        Me.cmbTipoComputadora = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.biDeshacerHardware = New System.Windows.Forms.Button()
        Me.biGrabaHardware = New System.Windows.Forms.Button()
        Me.gbFam1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbVigenteH = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarMonitor = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarCargador = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarLectora = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarDiscoDuro = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarTarjetaVideo = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarMemRam = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarPlacaMadre = New Janus.Windows.EditControls.UIButton()
        Me.biLimpiarProcesador = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarPlacaMadre = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarMemRam = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarTarjetaVideo = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarDiscoDuro = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarLectora = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarCargador = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarMonitor = New Janus.Windows.EditControls.UIButton()
        Me.btnAgregarProcesador = New Janus.Windows.EditControls.UIButton()
        Me.txtNotaHardware = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtMotivoFinUso = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtFecFinUso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniUso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMouse = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtTeclado = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnBuscarMonitor = New System.Windows.Forms.Button()
        Me.txtMonitor = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnBuscarCargador = New System.Windows.Forms.Button()
        Me.txtCargador = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnBuscarLectora = New System.Windows.Forms.Button()
        Me.txtLectora = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnBuscarDiscoDuro = New System.Windows.Forms.Button()
        Me.txtDiscoDuro = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnBuscarTarjetaVideo = New System.Windows.Forms.Button()
        Me.txtTarjetaVideo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscarMemoriaRam = New System.Windows.Forms.Button()
        Me.txtMemoriaRam = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnBuscarPlacaMadre = New System.Windows.Forms.Button()
        Me.txtPlacaMadre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnBuscarProcesador = New System.Windows.Forms.Button()
        Me.txtProcesador = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbEstudios = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarSoftware = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarSoftware = New System.Windows.Forms.Button()
        Me.txtSoftware = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvSoftwares = New Janus.Windows.GridEX.GridEX()
        Me.gbCapacitacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbMonCapac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDuracionCapac = New System.Windows.Forms.TextBox()
        Me.cbEvaluadoCapac = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDuracionCapac = New System.Windows.Forms.Label()
        Me.txtMesesEvaluarCapac = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecEvaluacionCapac = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.biDeshacerCapac = New System.Windows.Forms.Button()
        Me.biGrabarCapac = New System.Windows.Forms.Button()
        Me.txtObsCapacitacion = New System.Windows.Forms.TextBox()
        Me.txtCostoCapac = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblObsvCapac = New System.Windows.Forms.Label()
        Me.lblCostoCapac = New System.Windows.Forms.Label()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.lblProveedorCapac = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.cbProgramadoCapac = New System.Windows.Forms.CheckBox()
        Me.txtFecInicioCapac = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecInicioCapac = New System.Windows.Forms.Label()
        Me.txtFecFinalCapac = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecFinalCapac = New System.Windows.Forms.Label()
        Me.lblCursoCapac = New System.Windows.Forms.Label()
        Me.txtCursoCapac = New System.Windows.Forms.TextBox()
        Me.cmbTipoCapac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblTipoCapac = New System.Windows.Forms.Label()
        Me.dgvCapacitaciones = New Janus.Windows.GridEX.GridEX()
        Me.TabPestañas = New Janus.Windows.UI.Tab.UITab()
        Me.tpCapacitaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.MultiColumnCombo1 = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.IntegerUpDown1 = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.CalendarCombo3 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.NumericEditBox1 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.UiButton18 = New Janus.Windows.EditControls.UIButton()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CalendarCombo4 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.CalendarCombo5 = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.MultiColumnCombo2 = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.GridEX2 = New Janus.Windows.GridEX.GridEX()
        Me.tpProcesador = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarProcesador1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarProcesador1 = New System.Windows.Forms.Button()
        Me.txtProcesador1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvDatosProcesador = New Janus.Windows.GridEX.GridEX()
        Me.cmOpProcesador = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoProc = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditProc = New System.Windows.Forms.ToolStripMenuItem()
        Me.miElimProc = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActProc = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpPlacaMadre = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarPlacaMadre1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarPlacaMadre1 = New System.Windows.Forms.Button()
        Me.txtPlacaMadre1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvDatosPlacaMadre = New Janus.Windows.GridEX.GridEX()
        Me.cmOpPlacaMadre = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoPlaca = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarPlaca = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarPlaca = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarPlaca = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpMemoriaRam = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarMemoriaram1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarMemoriaram1 = New System.Windows.Forms.Button()
        Me.txtMemoriaram1 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dgvDatosMemoriaRam = New Janus.Windows.GridEX.GridEX()
        Me.cmOpMemoriaRam = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoMem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarMem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarMem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarMem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpTarjetaVideo = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox7 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarTarjetaVideo1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarTarjetaVideo1 = New System.Windows.Forms.Button()
        Me.txtTarjetaVideo1 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dgvDatosTarjetaVideo = New Janus.Windows.GridEX.GridEX()
        Me.cmOpTarjetaVideo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoTarj = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarTarj = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarTarj = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarTarj = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpDiscoDuro = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox8 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarDiscoDuro1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarDiscoDuro1 = New System.Windows.Forms.Button()
        Me.txtDiscoDuro1 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dgvDatosDiscoDuro = New Janus.Windows.GridEX.GridEX()
        Me.cmOpDiscoDuro = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoDisco = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarDisco = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarDisco = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarDisco = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpLectora = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox9 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarLectora1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarLectora1 = New System.Windows.Forms.Button()
        Me.txtLectora1 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dgvDatosLectora = New Janus.Windows.GridEX.GridEX()
        Me.cmOpLectora = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevaLectora = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarLectora = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarLectora = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarLectora = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpMonitor = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox10 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarMonitor1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarMonitor1 = New System.Windows.Forms.Button()
        Me.txtMonitor1 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dgvDatosMonitor = New Janus.Windows.GridEX.GridEX()
        Me.cmOpMonitor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoMonitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarMonitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarMonitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarMonitor = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpCargador = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox11 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarCargador1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarCargador1 = New System.Windows.Forms.Button()
        Me.txtCargador1 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dgvDatosCargador = New Janus.Windows.GridEX.GridEX()
        Me.cmOpCargador = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoCargador = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarCargador = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarCargador = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarCargador = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpTeclado = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox12 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarTeclado1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarTeclado1 = New System.Windows.Forms.Button()
        Me.txtTeclado1 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dgvDatosTeclado = New Janus.Windows.GridEX.GridEX()
        Me.cmOpTeclado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoTeclado = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarTeclado = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarTeclado = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarTeclado = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpMouse = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox13 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarMouse1 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarMouse1 = New System.Windows.Forms.Button()
        Me.txtMouse1 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dgvDatosMouse = New Janus.Windows.GridEX.GridEX()
        Me.cmOpMouse = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoMouse = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarMouse = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarMouse = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarMouse = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpSoftware = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarSoftware2 = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarSoftware2 = New System.Windows.Forms.Button()
        Me.txtSoftware2 = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.dgvDatosSoftware = New Janus.Windows.GridEX.GridEX()
        Me.cmOpSoftware = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoSoftware = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEditarSoftware = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarSoftware = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarSoftware = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosComputadora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosComputadora.SuspendLayout()
        CType(Me.cmbTipoComputadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbFam1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFam1.SuspendLayout()
        CType(Me.gbEstudios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstudios.SuspendLayout()
        CType(Me.dgvSoftwares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCapacitacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCapacitacion.SuspendLayout()
        CType(Me.cmbMonCapac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCapacitaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabPestañas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPestañas.SuspendLayout()
        Me.tpCapacitaciones.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.MultiColumnCombo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MultiColumnCombo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpProcesador.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.dgvDatosProcesador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpProcesador.SuspendLayout()
        Me.tpPlacaMadre.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.dgvDatosPlacaMadre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpPlacaMadre.SuspendLayout()
        Me.tpMemoriaRam.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDatosMemoriaRam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpMemoriaRam.SuspendLayout()
        Me.tpTarjetaVideo.SuspendLayout()
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox7.SuspendLayout()
        CType(Me.dgvDatosTarjetaVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpTarjetaVideo.SuspendLayout()
        Me.tpDiscoDuro.SuspendLayout()
        CType(Me.UiGroupBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox8.SuspendLayout()
        CType(Me.dgvDatosDiscoDuro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpDiscoDuro.SuspendLayout()
        Me.tpLectora.SuspendLayout()
        CType(Me.UiGroupBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox9.SuspendLayout()
        CType(Me.dgvDatosLectora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpLectora.SuspendLayout()
        Me.tpMonitor.SuspendLayout()
        CType(Me.UiGroupBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox10.SuspendLayout()
        CType(Me.dgvDatosMonitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpMonitor.SuspendLayout()
        Me.tpCargador.SuspendLayout()
        CType(Me.UiGroupBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox11.SuspendLayout()
        CType(Me.dgvDatosCargador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpCargador.SuspendLayout()
        Me.tpTeclado.SuspendLayout()
        CType(Me.UiGroupBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox12.SuspendLayout()
        CType(Me.dgvDatosTeclado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpTeclado.SuspendLayout()
        Me.tpMouse.SuspendLayout()
        CType(Me.UiGroupBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox13.SuspendLayout()
        CType(Me.dgvDatosMouse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpMouse.SuspendLayout()
        Me.tpSoftware.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvDatosSoftware, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpSoftware.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardarComputadora, Me.ToolStripSeparator3, Me.biEditarComputadora, Me.ToolStripSeparator7, Me.biDeshacerComputadora, Me.ToolStripSeparator4, Me.biCerrar, Me.ToolStripSeparator5})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(598, 31)
        Me.ToolStrip.TabIndex = 188
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardarComputadora
        '
        Me.biGuardarComputadora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardarComputadora.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardarComputadora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardarComputadora.Name = "biGuardarComputadora"
        Me.biGuardarComputadora.Size = New System.Drawing.Size(28, 28)
        Me.biGuardarComputadora.Text = "Grabar Cambios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEditarComputadora
        '
        Me.biEditarComputadora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditarComputadora.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditarComputadora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditarComputadora.Name = "biEditarComputadora"
        Me.biEditarComputadora.Size = New System.Drawing.Size(28, 28)
        Me.biEditarComputadora.Text = "Editar Cabecera"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacerComputadora
        '
        Me.biDeshacerComputadora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacerComputadora.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacerComputadora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacerComputadora.Name = "biDeshacerComputadora"
        Me.biDeshacerComputadora.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerComputadora.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator4.Visible = False
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosComputadora
        '
        Me.gbDatosComputadora.BackColor = System.Drawing.Color.Transparent
        Me.gbDatosComputadora.Controls.Add(Me.txtObservacionCom)
        Me.gbDatosComputadora.Controls.Add(Me.Label32)
        Me.gbDatosComputadora.Controls.Add(Me.Button1)
        Me.gbDatosComputadora.Controls.Add(Me.Button2)
        Me.gbDatosComputadora.Controls.Add(Me.txtComputadora)
        Me.gbDatosComputadora.Controls.Add(Me.Label2)
        Me.gbDatosComputadora.Controls.Add(Me.Label33)
        Me.gbDatosComputadora.Controls.Add(Me.cbVigente)
        Me.gbDatosComputadora.Controls.Add(Me.txtIdComputadora)
        Me.gbDatosComputadora.Controls.Add(Me.lblIdPer)
        Me.gbDatosComputadora.Controls.Add(Me.lblComputadora)
        Me.gbDatosComputadora.Controls.Add(Me.cmbTipoComputadora)
        Me.gbDatosComputadora.Location = New System.Drawing.Point(9, 36)
        Me.gbDatosComputadora.Name = "gbDatosComputadora"
        Me.gbDatosComputadora.Size = New System.Drawing.Size(575, 156)
        Me.gbDatosComputadora.TabIndex = 189
        Me.gbDatosComputadora.Text = "Datos de la Computadora"
        Me.gbDatosComputadora.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtObservacionCom
        '
        Me.txtObservacionCom.BackColor = System.Drawing.SystemColors.Window
        Me.txtObservacionCom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacionCom.Location = New System.Drawing.Point(107, 103)
        Me.txtObservacionCom.Multiline = True
        Me.txtObservacionCom.Name = "txtObservacionCom"
        Me.txtObservacionCom.Size = New System.Drawing.Size(455, 43)
        Me.txtObservacionCom.TabIndex = 414
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(34, 106)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(67, 13)
        Me.Label32.TabIndex = 413
        Me.Label32.Text = "Observacion"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(539, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 28)
        Me.Button1.TabIndex = 378
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(505, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 28)
        Me.Button2.TabIndex = 377
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'txtComputadora
        '
        Me.txtComputadora.BackColor = System.Drawing.SystemColors.Window
        Me.txtComputadora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComputadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComputadora.Location = New System.Drawing.Point(107, 45)
        Me.txtComputadora.Name = "txtComputadora"
        Me.txtComputadora.Size = New System.Drawing.Size(381, 20)
        Me.txtComputadora.TabIndex = 412
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(57, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 411
        Me.Label2.Text = "Nombre"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(394, 78)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(43, 13)
        Me.Label33.TabIndex = 409
        Me.Label33.Text = "Vigente"
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.BackColor = System.Drawing.Color.Transparent
        Me.cbVigente.Checked = True
        Me.cbVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVigente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVigente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.Location = New System.Drawing.Point(443, 78)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(15, 14)
        Me.cbVigente.TabIndex = 408
        Me.cbVigente.Tag = ""
        Me.cbVigente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbVigente.UseVisualStyleBackColor = False
        '
        'txtIdComputadora
        '
        Me.txtIdComputadora.BackColor = System.Drawing.Color.PowderBlue
        Me.txtIdComputadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdComputadora.Location = New System.Drawing.Point(107, 18)
        Me.txtIdComputadora.Name = "txtIdComputadora"
        Me.txtIdComputadora.ReadOnly = True
        Me.txtIdComputadora.Size = New System.Drawing.Size(75, 20)
        Me.txtIdComputadora.TabIndex = 1
        Me.txtIdComputadora.TabStop = False
        '
        'lblIdPer
        '
        Me.lblIdPer.AutoSize = True
        Me.lblIdPer.BackColor = System.Drawing.Color.Transparent
        Me.lblIdPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdPer.Location = New System.Drawing.Point(61, 21)
        Me.lblIdPer.Name = "lblIdPer"
        Me.lblIdPer.Size = New System.Drawing.Size(40, 13)
        Me.lblIdPer.TabIndex = 324
        Me.lblIdPer.Text = "Código"
        '
        'lblComputadora
        '
        Me.lblComputadora.AutoSize = True
        Me.lblComputadora.BackColor = System.Drawing.Color.Transparent
        Me.lblComputadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComputadora.Location = New System.Drawing.Point(73, 76)
        Me.lblComputadora.Name = "lblComputadora"
        Me.lblComputadora.Size = New System.Drawing.Size(28, 13)
        Me.lblComputadora.TabIndex = 316
        Me.lblComputadora.Text = "Tipo"
        '
        'cmbTipoComputadora
        '
        Me.cmbTipoComputadora.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoComputadora_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoComputadora_DesignTimeLayout.LayoutString")
        Me.cmbTipoComputadora.DesignTimeLayout = cmbTipoComputadora_DesignTimeLayout
        Me.cmbTipoComputadora.Location = New System.Drawing.Point(107, 74)
        Me.cmbTipoComputadora.Name = "cmbTipoComputadora"
        Me.cmbTipoComputadora.SelectedIndex = -1
        Me.cmbTipoComputadora.SelectedItem = Nothing
        Me.cmbTipoComputadora.Size = New System.Drawing.Size(153, 20)
        Me.cmbTipoComputadora.TabIndex = 2
        Me.cmbTipoComputadora.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'biDeshacerHardware
        '
        Me.biDeshacerHardware.BackColor = System.Drawing.Color.Transparent
        Me.biDeshacerHardware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biDeshacerHardware.Image = CType(resources.GetObject("biDeshacerHardware.Image"), System.Drawing.Image)
        Me.biDeshacerHardware.Location = New System.Drawing.Point(43, 6)
        Me.biDeshacerHardware.Name = "biDeshacerHardware"
        Me.biDeshacerHardware.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerHardware.TabIndex = 378
        Me.biDeshacerHardware.TabStop = False
        Me.biDeshacerHardware.UseVisualStyleBackColor = False
        '
        'biGrabaHardware
        '
        Me.biGrabaHardware.Image = CType(resources.GetObject("biGrabaHardware.Image"), System.Drawing.Image)
        Me.biGrabaHardware.Location = New System.Drawing.Point(9, 6)
        Me.biGrabaHardware.Name = "biGrabaHardware"
        Me.biGrabaHardware.Size = New System.Drawing.Size(28, 28)
        Me.biGrabaHardware.TabIndex = 377
        Me.biGrabaHardware.UseVisualStyleBackColor = True
        '
        'gbFam1
        '
        Me.gbFam1.BackColor = System.Drawing.Color.Transparent
        Me.gbFam1.Controls.Add(Me.Label8)
        Me.gbFam1.Controls.Add(Me.cbVigenteH)
        Me.gbFam1.Controls.Add(Me.btnLimpiarMonitor)
        Me.gbFam1.Controls.Add(Me.btnLimpiarCargador)
        Me.gbFam1.Controls.Add(Me.btnLimpiarLectora)
        Me.gbFam1.Controls.Add(Me.btnLimpiarDiscoDuro)
        Me.gbFam1.Controls.Add(Me.btnLimpiarTarjetaVideo)
        Me.gbFam1.Controls.Add(Me.btnLimpiarMemRam)
        Me.gbFam1.Controls.Add(Me.btnLimpiarPlacaMadre)
        Me.gbFam1.Controls.Add(Me.biLimpiarProcesador)
        Me.gbFam1.Controls.Add(Me.frmAgregarPlacaMadre)
        Me.gbFam1.Controls.Add(Me.frmAgregarMemRam)
        Me.gbFam1.Controls.Add(Me.frmAgregarTarjetaVideo)
        Me.gbFam1.Controls.Add(Me.frmAgregarDiscoDuro)
        Me.gbFam1.Controls.Add(Me.frmAgregarLectora)
        Me.gbFam1.Controls.Add(Me.frmAgregarCargador)
        Me.gbFam1.Controls.Add(Me.frmAgregarMonitor)
        Me.gbFam1.Controls.Add(Me.btnAgregarProcesador)
        Me.gbFam1.Controls.Add(Me.txtNotaHardware)
        Me.gbFam1.Controls.Add(Me.Label31)
        Me.gbFam1.Controls.Add(Me.txtMotivoFinUso)
        Me.gbFam1.Controls.Add(Me.Label30)
        Me.gbFam1.Controls.Add(Me.txtFecFinUso)
        Me.gbFam1.Controls.Add(Me.txtFecIniUso)
        Me.gbFam1.Controls.Add(Me.Label19)
        Me.gbFam1.Controls.Add(Me.Label20)
        Me.gbFam1.Controls.Add(Me.txtMouse)
        Me.gbFam1.Controls.Add(Me.Label28)
        Me.gbFam1.Controls.Add(Me.txtTeclado)
        Me.gbFam1.Controls.Add(Me.Label29)
        Me.gbFam1.Controls.Add(Me.btnBuscarMonitor)
        Me.gbFam1.Controls.Add(Me.txtMonitor)
        Me.gbFam1.Controls.Add(Me.Label16)
        Me.gbFam1.Controls.Add(Me.btnBuscarCargador)
        Me.gbFam1.Controls.Add(Me.txtCargador)
        Me.gbFam1.Controls.Add(Me.Label17)
        Me.gbFam1.Controls.Add(Me.btnBuscarLectora)
        Me.gbFam1.Controls.Add(Me.txtLectora)
        Me.gbFam1.Controls.Add(Me.Label14)
        Me.gbFam1.Controls.Add(Me.btnBuscarDiscoDuro)
        Me.gbFam1.Controls.Add(Me.txtDiscoDuro)
        Me.gbFam1.Controls.Add(Me.Label15)
        Me.gbFam1.Controls.Add(Me.btnBuscarTarjetaVideo)
        Me.gbFam1.Controls.Add(Me.txtTarjetaVideo)
        Me.gbFam1.Controls.Add(Me.Label12)
        Me.gbFam1.Controls.Add(Me.btnBuscarMemoriaRam)
        Me.gbFam1.Controls.Add(Me.txtMemoriaRam)
        Me.gbFam1.Controls.Add(Me.Label13)
        Me.gbFam1.Controls.Add(Me.btnBuscarPlacaMadre)
        Me.gbFam1.Controls.Add(Me.txtPlacaMadre)
        Me.gbFam1.Controls.Add(Me.Label11)
        Me.gbFam1.Controls.Add(Me.btnBuscarProcesador)
        Me.gbFam1.Controls.Add(Me.txtProcesador)
        Me.gbFam1.Controls.Add(Me.Label7)
        Me.gbFam1.Location = New System.Drawing.Point(9, 35)
        Me.gbFam1.Name = "gbFam1"
        Me.gbFam1.Size = New System.Drawing.Size(526, 415)
        Me.gbFam1.TabIndex = 0
        Me.gbFam1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 384)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 423
        Me.Label8.Text = "Vigente"
        '
        'cbVigenteH
        '
        Me.cbVigenteH.AutoSize = True
        Me.cbVigenteH.BackColor = System.Drawing.Color.Transparent
        Me.cbVigenteH.Checked = True
        Me.cbVigenteH.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVigenteH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVigenteH.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigenteH.Location = New System.Drawing.Point(97, 384)
        Me.cbVigenteH.Name = "cbVigenteH"
        Me.cbVigenteH.Size = New System.Drawing.Size(15, 14)
        Me.cbVigenteH.TabIndex = 422
        Me.cbVigenteH.Tag = ""
        Me.cbVigenteH.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbVigenteH.UseVisualStyleBackColor = False
        '
        'btnLimpiarMonitor
        '
        Me.btnLimpiarMonitor.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarMonitor.Location = New System.Drawing.Point(471, 205)
        Me.btnLimpiarMonitor.Name = "btnLimpiarMonitor"
        Me.btnLimpiarMonitor.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarMonitor.TabIndex = 421
        Me.btnLimpiarMonitor.TabStop = False
        '
        'btnLimpiarCargador
        '
        Me.btnLimpiarCargador.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarCargador.Location = New System.Drawing.Point(471, 180)
        Me.btnLimpiarCargador.Name = "btnLimpiarCargador"
        Me.btnLimpiarCargador.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarCargador.TabIndex = 420
        Me.btnLimpiarCargador.TabStop = False
        '
        'btnLimpiarLectora
        '
        Me.btnLimpiarLectora.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarLectora.Location = New System.Drawing.Point(471, 155)
        Me.btnLimpiarLectora.Name = "btnLimpiarLectora"
        Me.btnLimpiarLectora.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarLectora.TabIndex = 419
        Me.btnLimpiarLectora.TabStop = False
        '
        'btnLimpiarDiscoDuro
        '
        Me.btnLimpiarDiscoDuro.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarDiscoDuro.Location = New System.Drawing.Point(471, 128)
        Me.btnLimpiarDiscoDuro.Name = "btnLimpiarDiscoDuro"
        Me.btnLimpiarDiscoDuro.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarDiscoDuro.TabIndex = 418
        Me.btnLimpiarDiscoDuro.TabStop = False
        '
        'btnLimpiarTarjetaVideo
        '
        Me.btnLimpiarTarjetaVideo.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarTarjetaVideo.Location = New System.Drawing.Point(471, 102)
        Me.btnLimpiarTarjetaVideo.Name = "btnLimpiarTarjetaVideo"
        Me.btnLimpiarTarjetaVideo.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarTarjetaVideo.TabIndex = 417
        Me.btnLimpiarTarjetaVideo.TabStop = False
        '
        'btnLimpiarMemRam
        '
        Me.btnLimpiarMemRam.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarMemRam.Location = New System.Drawing.Point(471, 77)
        Me.btnLimpiarMemRam.Name = "btnLimpiarMemRam"
        Me.btnLimpiarMemRam.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarMemRam.TabIndex = 416
        Me.btnLimpiarMemRam.TabStop = False
        '
        'btnLimpiarPlacaMadre
        '
        Me.btnLimpiarPlacaMadre.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarPlacaMadre.Location = New System.Drawing.Point(471, 50)
        Me.btnLimpiarPlacaMadre.Name = "btnLimpiarPlacaMadre"
        Me.btnLimpiarPlacaMadre.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarPlacaMadre.TabIndex = 416
        Me.btnLimpiarPlacaMadre.TabStop = False
        '
        'biLimpiarProcesador
        '
        Me.biLimpiarProcesador.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.biLimpiarProcesador.Location = New System.Drawing.Point(471, 24)
        Me.biLimpiarProcesador.Name = "biLimpiarProcesador"
        Me.biLimpiarProcesador.Size = New System.Drawing.Size(25, 22)
        Me.biLimpiarProcesador.TabIndex = 415
        Me.biLimpiarProcesador.TabStop = False
        '
        'frmAgregarPlacaMadre
        '
        Me.frmAgregarPlacaMadre.Image = CType(resources.GetObject("frmAgregarPlacaMadre.Image"), System.Drawing.Image)
        Me.frmAgregarPlacaMadre.Location = New System.Drawing.Point(440, 50)
        Me.frmAgregarPlacaMadre.Name = "frmAgregarPlacaMadre"
        Me.frmAgregarPlacaMadre.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarPlacaMadre.TabIndex = 414
        Me.frmAgregarPlacaMadre.TabStop = False
        '
        'frmAgregarMemRam
        '
        Me.frmAgregarMemRam.Image = CType(resources.GetObject("frmAgregarMemRam.Image"), System.Drawing.Image)
        Me.frmAgregarMemRam.Location = New System.Drawing.Point(440, 77)
        Me.frmAgregarMemRam.Name = "frmAgregarMemRam"
        Me.frmAgregarMemRam.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarMemRam.TabIndex = 413
        Me.frmAgregarMemRam.TabStop = False
        '
        'frmAgregarTarjetaVideo
        '
        Me.frmAgregarTarjetaVideo.Image = CType(resources.GetObject("frmAgregarTarjetaVideo.Image"), System.Drawing.Image)
        Me.frmAgregarTarjetaVideo.Location = New System.Drawing.Point(440, 103)
        Me.frmAgregarTarjetaVideo.Name = "frmAgregarTarjetaVideo"
        Me.frmAgregarTarjetaVideo.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarTarjetaVideo.TabIndex = 412
        Me.frmAgregarTarjetaVideo.TabStop = False
        '
        'frmAgregarDiscoDuro
        '
        Me.frmAgregarDiscoDuro.Image = CType(resources.GetObject("frmAgregarDiscoDuro.Image"), System.Drawing.Image)
        Me.frmAgregarDiscoDuro.Location = New System.Drawing.Point(440, 128)
        Me.frmAgregarDiscoDuro.Name = "frmAgregarDiscoDuro"
        Me.frmAgregarDiscoDuro.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarDiscoDuro.TabIndex = 411
        Me.frmAgregarDiscoDuro.TabStop = False
        '
        'frmAgregarLectora
        '
        Me.frmAgregarLectora.Image = CType(resources.GetObject("frmAgregarLectora.Image"), System.Drawing.Image)
        Me.frmAgregarLectora.Location = New System.Drawing.Point(440, 154)
        Me.frmAgregarLectora.Name = "frmAgregarLectora"
        Me.frmAgregarLectora.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarLectora.TabIndex = 410
        Me.frmAgregarLectora.TabStop = False
        '
        'frmAgregarCargador
        '
        Me.frmAgregarCargador.Image = CType(resources.GetObject("frmAgregarCargador.Image"), System.Drawing.Image)
        Me.frmAgregarCargador.Location = New System.Drawing.Point(440, 179)
        Me.frmAgregarCargador.Name = "frmAgregarCargador"
        Me.frmAgregarCargador.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarCargador.TabIndex = 409
        Me.frmAgregarCargador.TabStop = False
        '
        'frmAgregarMonitor
        '
        Me.frmAgregarMonitor.Image = CType(resources.GetObject("frmAgregarMonitor.Image"), System.Drawing.Image)
        Me.frmAgregarMonitor.Location = New System.Drawing.Point(440, 205)
        Me.frmAgregarMonitor.Name = "frmAgregarMonitor"
        Me.frmAgregarMonitor.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarMonitor.TabIndex = 408
        Me.frmAgregarMonitor.TabStop = False
        '
        'btnAgregarProcesador
        '
        Me.btnAgregarProcesador.Image = CType(resources.GetObject("btnAgregarProcesador.Image"), System.Drawing.Image)
        Me.btnAgregarProcesador.Location = New System.Drawing.Point(440, 24)
        Me.btnAgregarProcesador.Name = "btnAgregarProcesador"
        Me.btnAgregarProcesador.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarProcesador.TabIndex = 379
        Me.btnAgregarProcesador.TabStop = False
        '
        'txtNotaHardware
        '
        Me.txtNotaHardware.Location = New System.Drawing.Point(94, 346)
        Me.txtNotaHardware.Multiline = True
        Me.txtNotaHardware.Name = "txtNotaHardware"
        Me.txtNotaHardware.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotaHardware.Size = New System.Drawing.Size(415, 30)
        Me.txtNotaHardware.TabIndex = 406
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(57, 354)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(30, 13)
        Me.Label31.TabIndex = 407
        Me.Label31.Text = "Nota"
        '
        'txtMotivoFinUso
        '
        Me.txtMotivoFinUso.Location = New System.Drawing.Point(94, 310)
        Me.txtMotivoFinUso.Multiline = True
        Me.txtMotivoFinUso.Name = "txtMotivoFinUso"
        Me.txtMotivoFinUso.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMotivoFinUso.Size = New System.Drawing.Size(415, 30)
        Me.txtMotivoFinUso.TabIndex = 404
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(10, 317)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 13)
        Me.Label30.TabIndex = 405
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
        Me.txtFecFinUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecFinUso.IsNullDate = True
        Me.txtFecFinUso.Location = New System.Drawing.Point(327, 284)
        Me.txtFecFinUso.Name = "txtFecFinUso"
        Me.txtFecFinUso.NullButtonText = "Ninguno"
        Me.txtFecFinUso.ShowNullButton = True
        Me.txtFecFinUso.Size = New System.Drawing.Size(82, 20)
        Me.txtFecFinUso.TabIndex = 399
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
        Me.txtFecIniUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecIniUso.IsNullDate = True
        Me.txtFecIniUso.Location = New System.Drawing.Point(94, 284)
        Me.txtFecIniUso.Name = "txtFecIniUso"
        Me.txtFecIniUso.NullButtonText = "Ninguno"
        Me.txtFecIniUso.Size = New System.Drawing.Size(82, 20)
        Me.txtFecIniUso.TabIndex = 398
        Me.txtFecIniUso.TodayButtonText = "Hoy"
        Me.txtFecIniUso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(254, 288)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 403
        Me.Label19.Text = "Fec. Fin Uso"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(21, 288)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 402
        Me.Label20.Text = "Fec. Ini. Uso"
        '
        'txtMouse
        '
        Me.txtMouse.BackColor = System.Drawing.SystemColors.Window
        Me.txtMouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMouse.Location = New System.Drawing.Point(94, 258)
        Me.txtMouse.Name = "txtMouse"
        Me.txtMouse.Size = New System.Drawing.Size(315, 20)
        Me.txtMouse.TabIndex = 397
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(48, 261)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 401
        Me.Label28.Text = "Mouse"
        '
        'txtTeclado
        '
        Me.txtTeclado.BackColor = System.Drawing.SystemColors.Window
        Me.txtTeclado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeclado.Location = New System.Drawing.Point(94, 232)
        Me.txtTeclado.Name = "txtTeclado"
        Me.txtTeclado.Size = New System.Drawing.Size(315, 20)
        Me.txtTeclado.TabIndex = 396
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(41, 235)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(46, 13)
        Me.Label29.TabIndex = 400
        Me.Label29.Text = "Teclado"
        '
        'btnBuscarMonitor
        '
        Me.btnBuscarMonitor.Image = CType(resources.GetObject("btnBuscarMonitor.Image"), System.Drawing.Image)
        Me.btnBuscarMonitor.Location = New System.Drawing.Point(408, 204)
        Me.btnBuscarMonitor.Name = "btnBuscarMonitor"
        Me.btnBuscarMonitor.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarMonitor.TabIndex = 394
        Me.btnBuscarMonitor.TabStop = False
        Me.btnBuscarMonitor.UseVisualStyleBackColor = True
        '
        'txtMonitor
        '
        Me.txtMonitor.BackColor = System.Drawing.Color.PowderBlue
        Me.txtMonitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonitor.Location = New System.Drawing.Point(94, 206)
        Me.txtMonitor.Name = "txtMonitor"
        Me.txtMonitor.ReadOnly = True
        Me.txtMonitor.Size = New System.Drawing.Size(308, 20)
        Me.txtMonitor.TabIndex = 393
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(45, 209)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 395
        Me.Label16.Text = "Monitor"
        '
        'btnBuscarCargador
        '
        Me.btnBuscarCargador.Image = CType(resources.GetObject("btnBuscarCargador.Image"), System.Drawing.Image)
        Me.btnBuscarCargador.Location = New System.Drawing.Point(408, 178)
        Me.btnBuscarCargador.Name = "btnBuscarCargador"
        Me.btnBuscarCargador.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarCargador.TabIndex = 391
        Me.btnBuscarCargador.TabStop = False
        Me.btnBuscarCargador.UseVisualStyleBackColor = True
        '
        'txtCargador
        '
        Me.txtCargador.BackColor = System.Drawing.Color.PowderBlue
        Me.txtCargador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargador.Location = New System.Drawing.Point(94, 180)
        Me.txtCargador.Name = "txtCargador"
        Me.txtCargador.ReadOnly = True
        Me.txtCargador.Size = New System.Drawing.Size(308, 20)
        Me.txtCargador.TabIndex = 390
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(39, 183)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 392
        Me.Label17.Text = "Cargador"
        '
        'btnBuscarLectora
        '
        Me.btnBuscarLectora.Image = CType(resources.GetObject("btnBuscarLectora.Image"), System.Drawing.Image)
        Me.btnBuscarLectora.Location = New System.Drawing.Point(408, 153)
        Me.btnBuscarLectora.Name = "btnBuscarLectora"
        Me.btnBuscarLectora.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarLectora.TabIndex = 388
        Me.btnBuscarLectora.TabStop = False
        Me.btnBuscarLectora.UseVisualStyleBackColor = True
        '
        'txtLectora
        '
        Me.txtLectora.BackColor = System.Drawing.Color.PowderBlue
        Me.txtLectora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLectora.Location = New System.Drawing.Point(94, 155)
        Me.txtLectora.Name = "txtLectora"
        Me.txtLectora.ReadOnly = True
        Me.txtLectora.Size = New System.Drawing.Size(308, 20)
        Me.txtLectora.TabIndex = 387
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(45, 158)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 389
        Me.Label14.Text = "Lectora"
        '
        'btnBuscarDiscoDuro
        '
        Me.btnBuscarDiscoDuro.Image = CType(resources.GetObject("btnBuscarDiscoDuro.Image"), System.Drawing.Image)
        Me.btnBuscarDiscoDuro.Location = New System.Drawing.Point(408, 127)
        Me.btnBuscarDiscoDuro.Name = "btnBuscarDiscoDuro"
        Me.btnBuscarDiscoDuro.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarDiscoDuro.TabIndex = 385
        Me.btnBuscarDiscoDuro.TabStop = False
        Me.btnBuscarDiscoDuro.UseVisualStyleBackColor = True
        '
        'txtDiscoDuro
        '
        Me.txtDiscoDuro.BackColor = System.Drawing.Color.PowderBlue
        Me.txtDiscoDuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscoDuro.Location = New System.Drawing.Point(94, 129)
        Me.txtDiscoDuro.Name = "txtDiscoDuro"
        Me.txtDiscoDuro.ReadOnly = True
        Me.txtDiscoDuro.Size = New System.Drawing.Size(308, 20)
        Me.txtDiscoDuro.TabIndex = 384
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(28, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 386
        Me.Label15.Text = "Disco Duro"
        '
        'btnBuscarTarjetaVideo
        '
        Me.btnBuscarTarjetaVideo.Image = CType(resources.GetObject("btnBuscarTarjetaVideo.Image"), System.Drawing.Image)
        Me.btnBuscarTarjetaVideo.Location = New System.Drawing.Point(408, 102)
        Me.btnBuscarTarjetaVideo.Name = "btnBuscarTarjetaVideo"
        Me.btnBuscarTarjetaVideo.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarTarjetaVideo.TabIndex = 382
        Me.btnBuscarTarjetaVideo.TabStop = False
        Me.btnBuscarTarjetaVideo.UseVisualStyleBackColor = True
        '
        'txtTarjetaVideo
        '
        Me.txtTarjetaVideo.BackColor = System.Drawing.Color.PowderBlue
        Me.txtTarjetaVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjetaVideo.Location = New System.Drawing.Point(94, 104)
        Me.txtTarjetaVideo.Name = "txtTarjetaVideo"
        Me.txtTarjetaVideo.ReadOnly = True
        Me.txtTarjetaVideo.Size = New System.Drawing.Size(308, 20)
        Me.txtTarjetaVideo.TabIndex = 381
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(19, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 383
        Me.Label12.Text = "Tarjeta Video"
        '
        'btnBuscarMemoriaRam
        '
        Me.btnBuscarMemoriaRam.Image = CType(resources.GetObject("btnBuscarMemoriaRam.Image"), System.Drawing.Image)
        Me.btnBuscarMemoriaRam.Location = New System.Drawing.Point(408, 76)
        Me.btnBuscarMemoriaRam.Name = "btnBuscarMemoriaRam"
        Me.btnBuscarMemoriaRam.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarMemoriaRam.TabIndex = 379
        Me.btnBuscarMemoriaRam.TabStop = False
        Me.btnBuscarMemoriaRam.UseVisualStyleBackColor = True
        '
        'txtMemoriaRam
        '
        Me.txtMemoriaRam.BackColor = System.Drawing.Color.PowderBlue
        Me.txtMemoriaRam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemoriaRam.Location = New System.Drawing.Point(94, 78)
        Me.txtMemoriaRam.Name = "txtMemoriaRam"
        Me.txtMemoriaRam.ReadOnly = True
        Me.txtMemoriaRam.Size = New System.Drawing.Size(308, 20)
        Me.txtMemoriaRam.TabIndex = 378
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 380
        Me.Label13.Text = "Memoria Ram"
        '
        'btnBuscarPlacaMadre
        '
        Me.btnBuscarPlacaMadre.Image = CType(resources.GetObject("btnBuscarPlacaMadre.Image"), System.Drawing.Image)
        Me.btnBuscarPlacaMadre.Location = New System.Drawing.Point(408, 49)
        Me.btnBuscarPlacaMadre.Name = "btnBuscarPlacaMadre"
        Me.btnBuscarPlacaMadre.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarPlacaMadre.TabIndex = 376
        Me.btnBuscarPlacaMadre.TabStop = False
        Me.btnBuscarPlacaMadre.UseVisualStyleBackColor = True
        '
        'txtPlacaMadre
        '
        Me.txtPlacaMadre.BackColor = System.Drawing.Color.PowderBlue
        Me.txtPlacaMadre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacaMadre.Location = New System.Drawing.Point(94, 51)
        Me.txtPlacaMadre.Name = "txtPlacaMadre"
        Me.txtPlacaMadre.ReadOnly = True
        Me.txtPlacaMadre.Size = New System.Drawing.Size(308, 20)
        Me.txtPlacaMadre.TabIndex = 375
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 377
        Me.Label11.Text = "Placa Madre"
        '
        'btnBuscarProcesador
        '
        Me.btnBuscarProcesador.Image = CType(resources.GetObject("btnBuscarProcesador.Image"), System.Drawing.Image)
        Me.btnBuscarProcesador.Location = New System.Drawing.Point(408, 23)
        Me.btnBuscarProcesador.Name = "btnBuscarProcesador"
        Me.btnBuscarProcesador.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarProcesador.TabIndex = 373
        Me.btnBuscarProcesador.TabStop = False
        Me.btnBuscarProcesador.UseVisualStyleBackColor = True
        '
        'txtProcesador
        '
        Me.txtProcesador.BackColor = System.Drawing.Color.PowderBlue
        Me.txtProcesador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcesador.Location = New System.Drawing.Point(94, 25)
        Me.txtProcesador.Name = "txtProcesador"
        Me.txtProcesador.ReadOnly = True
        Me.txtProcesador.Size = New System.Drawing.Size(308, 20)
        Me.txtProcesador.TabIndex = 372
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 374
        Me.Label7.Text = "Procesador"
        '
        'gbEstudios
        '
        Me.gbEstudios.BackColor = System.Drawing.Color.Transparent
        Me.gbEstudios.Controls.Add(Me.btnAgregarSoftware)
        Me.gbEstudios.Controls.Add(Me.btnBuscarSoftware)
        Me.gbEstudios.Controls.Add(Me.txtSoftware)
        Me.gbEstudios.Controls.Add(Me.Label6)
        Me.gbEstudios.Controls.Add(Me.dgvSoftwares)
        Me.gbEstudios.Location = New System.Drawing.Point(12, 8)
        Me.gbEstudios.Name = "gbEstudios"
        Me.gbEstudios.Size = New System.Drawing.Size(552, 424)
        Me.gbEstudios.TabIndex = 0
        Me.gbEstudios.Text = "Software"
        Me.gbEstudios.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarSoftware
        '
        Me.btnAgregarSoftware.Image = CType(resources.GetObject("btnAgregarSoftware.Image"), System.Drawing.Image)
        Me.btnAgregarSoftware.Location = New System.Drawing.Point(472, 38)
        Me.btnAgregarSoftware.Name = "btnAgregarSoftware"
        Me.btnAgregarSoftware.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarSoftware.TabIndex = 383
        Me.btnAgregarSoftware.TabStop = False
        '
        'btnBuscarSoftware
        '
        Me.btnBuscarSoftware.Image = CType(resources.GetObject("btnBuscarSoftware.Image"), System.Drawing.Image)
        Me.btnBuscarSoftware.Location = New System.Drawing.Point(440, 37)
        Me.btnBuscarSoftware.Name = "btnBuscarSoftware"
        Me.btnBuscarSoftware.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarSoftware.TabIndex = 381
        Me.btnBuscarSoftware.TabStop = False
        Me.btnBuscarSoftware.UseVisualStyleBackColor = True
        '
        'txtSoftware
        '
        Me.txtSoftware.BackColor = System.Drawing.Color.PowderBlue
        Me.txtSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoftware.Location = New System.Drawing.Point(126, 39)
        Me.txtSoftware.Name = "txtSoftware"
        Me.txtSoftware.ReadOnly = True
        Me.txtSoftware.Size = New System.Drawing.Size(308, 20)
        Me.txtSoftware.TabIndex = 380
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(71, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 382
        Me.Label6.Text = "Software"
        '
        'dgvSoftwares
        '
        dgvSoftwares_DesignTimeLayout.LayoutString = resources.GetString("dgvSoftwares_DesignTimeLayout.LayoutString")
        Me.dgvSoftwares.DesignTimeLayout = dgvSoftwares_DesignTimeLayout
        Me.dgvSoftwares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvSoftwares.GroupByBoxVisible = False
        Me.dgvSoftwares.Location = New System.Drawing.Point(18, 83)
        Me.dgvSoftwares.Name = "dgvSoftwares"
        Me.dgvSoftwares.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvSoftwares.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvSoftwares.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvSoftwares.Size = New System.Drawing.Size(518, 321)
        Me.dgvSoftwares.TabIndex = 336
        Me.dgvSoftwares.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbCapacitacion
        '
        Me.gbCapacitacion.BackColor = System.Drawing.Color.Transparent
        Me.gbCapacitacion.Controls.Add(Me.cmbMonCapac)
        Me.gbCapacitacion.Controls.Add(Me.Label5)
        Me.gbCapacitacion.Controls.Add(Me.txtDuracionCapac)
        Me.gbCapacitacion.Controls.Add(Me.cbEvaluadoCapac)
        Me.gbCapacitacion.Controls.Add(Me.Label4)
        Me.gbCapacitacion.Controls.Add(Me.lblDuracionCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtMesesEvaluarCapac)
        Me.gbCapacitacion.Controls.Add(Me.Label3)
        Me.gbCapacitacion.Controls.Add(Me.txtFecEvaluacionCapac)
        Me.gbCapacitacion.Controls.Add(Me.Label1)
        Me.gbCapacitacion.Controls.Add(Me.biDeshacerCapac)
        Me.gbCapacitacion.Controls.Add(Me.biGrabarCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtObsCapacitacion)
        Me.gbCapacitacion.Controls.Add(Me.txtCostoCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblObsvCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblCostoCapac)
        Me.gbCapacitacion.Controls.Add(Me.btnAgregarProveedor)
        Me.gbCapacitacion.Controls.Add(Me.lblProveedorCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtProveedor)
        Me.gbCapacitacion.Controls.Add(Me.btnBuscarProveedor)
        Me.gbCapacitacion.Controls.Add(Me.cbProgramadoCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtFecInicioCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblFecInicioCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtFecFinalCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblFecFinalCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblCursoCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtCursoCapac)
        Me.gbCapacitacion.Controls.Add(Me.cmbTipoCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblTipoCapac)
        Me.gbCapacitacion.Location = New System.Drawing.Point(12, 76)
        Me.gbCapacitacion.Name = "gbCapacitacion"
        Me.gbCapacitacion.Size = New System.Drawing.Size(575, 210)
        Me.gbCapacitacion.TabIndex = 342
        Me.gbCapacitacion.Text = "Datos de Capacitación"
        Me.gbCapacitacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbMonCapac
        '
        Me.cmbMonCapac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMonCapac_DesignTimeLayout.LayoutString = resources.GetString("cmbMonCapac_DesignTimeLayout.LayoutString")
        Me.cmbMonCapac.DesignTimeLayout = cmbMonCapac_DesignTimeLayout
        Me.cmbMonCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonCapac.Location = New System.Drawing.Point(340, 112)
        Me.cmbMonCapac.Name = "cmbMonCapac"
        Me.cmbMonCapac.SelectedIndex = -1
        Me.cmbMonCapac.SelectedItem = Nothing
        Me.cmbMonCapac.Size = New System.Drawing.Size(54, 20)
        Me.cmbMonCapac.TabIndex = 10
        Me.cmbMonCapac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMonCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(310, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 352
        Me.Label5.Text = "Mon."
        '
        'txtDuracionCapac
        '
        Me.txtDuracionCapac.BackColor = System.Drawing.SystemColors.Window
        Me.txtDuracionCapac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDuracionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracionCapac.Location = New System.Drawing.Point(77, 112)
        Me.txtDuracionCapac.Name = "txtDuracionCapac"
        Me.txtDuracionCapac.Size = New System.Drawing.Size(200, 20)
        Me.txtDuracionCapac.TabIndex = 9
        '
        'cbEvaluadoCapac
        '
        Me.cbEvaluadoCapac.AutoSize = True
        Me.cbEvaluadoCapac.BackColor = System.Drawing.Color.Transparent
        Me.cbEvaluadoCapac.Location = New System.Drawing.Point(266, 145)
        Me.cbEvaluadoCapac.Name = "cbEvaluadoCapac"
        Me.cbEvaluadoCapac.Size = New System.Drawing.Size(71, 17)
        Me.cbEvaluadoCapac.TabIndex = 13
        Me.cbEvaluadoCapac.Text = "Evaluado"
        Me.cbEvaluadoCapac.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(175, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 350
        Me.Label4.Text = "meses"
        '
        'lblDuracionCapac
        '
        Me.lblDuracionCapac.AutoSize = True
        Me.lblDuracionCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblDuracionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuracionCapac.Location = New System.Drawing.Point(24, 116)
        Me.lblDuracionCapac.Name = "lblDuracionCapac"
        Me.lblDuracionCapac.Size = New System.Drawing.Size(50, 13)
        Me.lblDuracionCapac.TabIndex = 336
        Me.lblDuracionCapac.Text = "Duración"
        '
        'txtMesesEvaluarCapac
        '
        Me.txtMesesEvaluarCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesesEvaluarCapac.Location = New System.Drawing.Point(115, 142)
        Me.txtMesesEvaluarCapac.Maximum = 90
        Me.txtMesesEvaluarCapac.MaxLength = 2
        Me.txtMesesEvaluarCapac.Name = "txtMesesEvaluarCapac"
        Me.txtMesesEvaluarCapac.Size = New System.Drawing.Size(54, 20)
        Me.txtMesesEvaluarCapac.TabIndex = 12
        Me.txtMesesEvaluarCapac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtMesesEvaluarCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 349
        Me.Label3.Text = "Evaluar dentro de"
        '
        'txtFecEvaluacionCapac
        '
        '
        '
        '
        Me.txtFecEvaluacionCapac.DropDownCalendar.Name = ""
        Me.txtFecEvaluacionCapac.DropDownCalendar.Visible = False
        Me.txtFecEvaluacionCapac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEvaluacionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecEvaluacionCapac.IsNullDate = True
        Me.txtFecEvaluacionCapac.Location = New System.Drawing.Point(464, 142)
        Me.txtFecEvaluacionCapac.Name = "txtFecEvaluacionCapac"
        Me.txtFecEvaluacionCapac.NullButtonText = "Ninguno"
        Me.txtFecEvaluacionCapac.ShowNullButton = True
        Me.txtFecEvaluacionCapac.Size = New System.Drawing.Size(82, 20)
        Me.txtFecEvaluacionCapac.TabIndex = 14
        Me.txtFecEvaluacionCapac.TodayButtonText = "Hoy"
        Me.txtFecEvaluacionCapac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(374, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 347
        Me.Label1.Text = "Fec. Evaluación"
        '
        'biDeshacerCapac
        '
        Me.biDeshacerCapac.BackColor = System.Drawing.Color.Transparent
        Me.biDeshacerCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biDeshacerCapac.Image = CType(resources.GetObject("biDeshacerCapac.Image"), System.Drawing.Image)
        Me.biDeshacerCapac.Location = New System.Drawing.Point(536, 172)
        Me.biDeshacerCapac.Name = "biDeshacerCapac"
        Me.biDeshacerCapac.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerCapac.TabIndex = 17
        Me.biDeshacerCapac.TabStop = False
        Me.biDeshacerCapac.UseVisualStyleBackColor = False
        '
        'biGrabarCapac
        '
        Me.biGrabarCapac.BackColor = System.Drawing.Color.Transparent
        Me.biGrabarCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biGrabarCapac.Image = CType(resources.GetObject("biGrabarCapac.Image"), System.Drawing.Image)
        Me.biGrabarCapac.Location = New System.Drawing.Point(502, 172)
        Me.biGrabarCapac.Name = "biGrabarCapac"
        Me.biGrabarCapac.Size = New System.Drawing.Size(28, 28)
        Me.biGrabarCapac.TabIndex = 16
        Me.biGrabarCapac.UseVisualStyleBackColor = False
        '
        'txtObsCapacitacion
        '
        Me.txtObsCapacitacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtObsCapacitacion.Location = New System.Drawing.Point(77, 172)
        Me.txtObsCapacitacion.Multiline = True
        Me.txtObsCapacitacion.Name = "txtObsCapacitacion"
        Me.txtObsCapacitacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsCapacitacion.Size = New System.Drawing.Size(413, 30)
        Me.txtObsCapacitacion.TabIndex = 15
        '
        'txtCostoCapac
        '
        Me.txtCostoCapac.DecimalDigits = 2
        Me.txtCostoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoCapac.Location = New System.Drawing.Point(461, 112)
        Me.txtCostoCapac.MaxLength = 10
        Me.txtCostoCapac.Name = "txtCostoCapac"
        Me.txtCostoCapac.Size = New System.Drawing.Size(82, 20)
        Me.txtCostoCapac.TabIndex = 11
        Me.txtCostoCapac.Text = "0.00"
        Me.txtCostoCapac.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblObsvCapac
        '
        Me.lblObsvCapac.AutoSize = True
        Me.lblObsvCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblObsvCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObsvCapac.Location = New System.Drawing.Point(4, 180)
        Me.lblObsvCapac.Name = "lblObsvCapac"
        Me.lblObsvCapac.Size = New System.Drawing.Size(67, 13)
        Me.lblObsvCapac.TabIndex = 345
        Me.lblObsvCapac.Text = "Observación"
        '
        'lblCostoCapac
        '
        Me.lblCostoCapac.AutoSize = True
        Me.lblCostoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblCostoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoCapac.Location = New System.Drawing.Point(421, 115)
        Me.lblCostoCapac.Name = "lblCostoCapac"
        Me.lblCostoCapac.Size = New System.Drawing.Size(34, 13)
        Me.lblCostoCapac.TabIndex = 343
        Me.lblCostoCapac.Text = "Costo"
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = CType(resources.GetObject("btnAgregarProveedor.Image"), System.Drawing.Image)
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(465, 82)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(23, 21)
        Me.btnAgregarProveedor.TabIndex = 8
        Me.btnAgregarProveedor.TabStop = False
        '
        'lblProveedorCapac
        '
        Me.lblProveedorCapac.AutoSize = True
        Me.lblProveedorCapac.Location = New System.Drawing.Point(18, 86)
        Me.lblProveedorCapac.Name = "lblProveedorCapac"
        Me.lblProveedorCapac.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedorCapac.TabIndex = 338
        Me.lblProveedorCapac.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.PowderBlue
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProveedor.Location = New System.Drawing.Point(77, 82)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(358, 20)
        Me.txtProveedor.TabIndex = 6
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = CType(resources.GetObject("btnBuscarProveedor.Image"), System.Drawing.Image)
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(438, 81)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 7
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'cbProgramadoCapac
        '
        Me.cbProgramadoCapac.AutoSize = True
        Me.cbProgramadoCapac.BackColor = System.Drawing.Color.Transparent
        Me.cbProgramadoCapac.Location = New System.Drawing.Point(79, 53)
        Me.cbProgramadoCapac.Name = "cbProgramadoCapac"
        Me.cbProgramadoCapac.Size = New System.Drawing.Size(83, 17)
        Me.cbProgramadoCapac.TabIndex = 3
        Me.cbProgramadoCapac.Text = "Programado"
        Me.cbProgramadoCapac.UseVisualStyleBackColor = False
        '
        'txtFecInicioCapac
        '
        '
        '
        '
        Me.txtFecInicioCapac.DropDownCalendar.Name = ""
        Me.txtFecInicioCapac.DropDownCalendar.Visible = False
        Me.txtFecInicioCapac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicioCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecInicioCapac.IsNullDate = True
        Me.txtFecInicioCapac.Location = New System.Drawing.Point(253, 52)
        Me.txtFecInicioCapac.Name = "txtFecInicioCapac"
        Me.txtFecInicioCapac.NullButtonText = "Ninguno"
        Me.txtFecInicioCapac.Size = New System.Drawing.Size(82, 20)
        Me.txtFecInicioCapac.TabIndex = 4
        Me.txtFecInicioCapac.TodayButtonText = "Hoy"
        Me.txtFecInicioCapac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblFecInicioCapac
        '
        Me.lblFecInicioCapac.AutoSize = True
        Me.lblFecInicioCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblFecInicioCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecInicioCapac.Location = New System.Drawing.Point(191, 56)
        Me.lblFecInicioCapac.Name = "lblFecInicioCapac"
        Me.lblFecInicioCapac.Size = New System.Drawing.Size(56, 13)
        Me.lblFecInicioCapac.TabIndex = 334
        Me.lblFecInicioCapac.Text = "Fec. Inicio"
        '
        'txtFecFinalCapac
        '
        '
        '
        '
        Me.txtFecFinalCapac.DropDownCalendar.Name = ""
        Me.txtFecFinalCapac.DropDownCalendar.Visible = False
        Me.txtFecFinalCapac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinalCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecFinalCapac.IsNullDate = True
        Me.txtFecFinalCapac.Location = New System.Drawing.Point(459, 52)
        Me.txtFecFinalCapac.Name = "txtFecFinalCapac"
        Me.txtFecFinalCapac.NullButtonText = "Ninguno"
        Me.txtFecFinalCapac.Size = New System.Drawing.Size(82, 20)
        Me.txtFecFinalCapac.TabIndex = 5
        Me.txtFecFinalCapac.TodayButtonText = "Hoy"
        Me.txtFecFinalCapac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblFecFinalCapac
        '
        Me.lblFecFinalCapac.AutoSize = True
        Me.lblFecFinalCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblFecFinalCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecFinalCapac.Location = New System.Drawing.Point(402, 56)
        Me.lblFecFinalCapac.Name = "lblFecFinalCapac"
        Me.lblFecFinalCapac.Size = New System.Drawing.Size(53, 13)
        Me.lblFecFinalCapac.TabIndex = 333
        Me.lblFecFinalCapac.Text = "Fec. Final"
        '
        'lblCursoCapac
        '
        Me.lblCursoCapac.AutoSize = True
        Me.lblCursoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblCursoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursoCapac.Location = New System.Drawing.Point(172, 26)
        Me.lblCursoCapac.Name = "lblCursoCapac"
        Me.lblCursoCapac.Size = New System.Drawing.Size(34, 13)
        Me.lblCursoCapac.TabIndex = 330
        Me.lblCursoCapac.Text = "Curso"
        '
        'txtCursoCapac
        '
        Me.txtCursoCapac.BackColor = System.Drawing.SystemColors.Window
        Me.txtCursoCapac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCursoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCursoCapac.Location = New System.Drawing.Point(208, 22)
        Me.txtCursoCapac.Name = "txtCursoCapac"
        Me.txtCursoCapac.Size = New System.Drawing.Size(356, 20)
        Me.txtCursoCapac.TabIndex = 2
        '
        'cmbTipoCapac
        '
        Me.cmbTipoCapac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoCapac_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoCapac_DesignTimeLayout.LayoutString")
        Me.cmbTipoCapac.DesignTimeLayout = cmbTipoCapac_DesignTimeLayout
        Me.cmbTipoCapac.Location = New System.Drawing.Point(77, 22)
        Me.cmbTipoCapac.Name = "cmbTipoCapac"
        Me.cmbTipoCapac.SelectedIndex = -1
        Me.cmbTipoCapac.SelectedItem = Nothing
        Me.cmbTipoCapac.Size = New System.Drawing.Size(82, 20)
        Me.cmbTipoCapac.TabIndex = 1
        Me.cmbTipoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTipoCapac
        '
        Me.lblTipoCapac.AutoSize = True
        Me.lblTipoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCapac.Location = New System.Drawing.Point(43, 25)
        Me.lblTipoCapac.Name = "lblTipoCapac"
        Me.lblTipoCapac.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoCapac.TabIndex = 328
        Me.lblTipoCapac.Text = "Tipo"
        '
        'dgvCapacitaciones
        '
        dgvCapacitaciones_DesignTimeLayout.LayoutString = resources.GetString("dgvCapacitaciones_DesignTimeLayout.LayoutString")
        Me.dgvCapacitaciones.DesignTimeLayout = dgvCapacitaciones_DesignTimeLayout
        Me.dgvCapacitaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvCapacitaciones.GroupByBoxVisible = False
        Me.dgvCapacitaciones.Location = New System.Drawing.Point(13, 292)
        Me.dgvCapacitaciones.Name = "dgvCapacitaciones"
        Me.dgvCapacitaciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCapacitaciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCapacitaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCapacitaciones.Size = New System.Drawing.Size(574, 163)
        Me.dgvCapacitaciones.TabIndex = 341
        Me.dgvCapacitaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TabPestañas
        '
        Me.TabPestañas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPestañas.Location = New System.Drawing.Point(12, 199)
        Me.TabPestañas.MultiLine = True
        Me.TabPestañas.Name = "TabPestañas"
        Me.TabPestañas.Size = New System.Drawing.Size(572, 490)
        Me.TabPestañas.TabIndex = 190
        Me.TabPestañas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tpCapacitaciones, Me.tpProcesador, Me.tpPlacaMadre, Me.tpMemoriaRam, Me.tpTarjetaVideo, Me.tpDiscoDuro, Me.tpLectora, Me.tpMonitor, Me.tpCargador, Me.tpTeclado, Me.tpMouse, Me.tpSoftware})
        Me.TabPestañas.TabStop = False
        Me.TabPestañas.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'tpCapacitaciones
        '
        Me.tpCapacitaciones.Controls.Add(Me.UiGroupBox3)
        Me.tpCapacitaciones.Controls.Add(Me.GridEX2)
        Me.tpCapacitaciones.Icon = CType(resources.GetObject("tpCapacitaciones.Icon"), System.Drawing.Icon)
        Me.tpCapacitaciones.Location = New System.Drawing.Point(1, 43)
        Me.tpCapacitaciones.Name = "tpCapacitaciones"
        Me.tpCapacitaciones.Size = New System.Drawing.Size(570, 466)
        Me.tpCapacitaciones.TabStop = True
        Me.tpCapacitaciones.TabVisible = False
        Me.tpCapacitaciones.Text = "CAPACITACIONES"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.Controls.Add(Me.MultiColumnCombo1)
        Me.UiGroupBox3.Controls.Add(Me.Label39)
        Me.UiGroupBox3.Controls.Add(Me.TextBox14)
        Me.UiGroupBox3.Controls.Add(Me.CheckBox2)
        Me.UiGroupBox3.Controls.Add(Me.Label40)
        Me.UiGroupBox3.Controls.Add(Me.Label41)
        Me.UiGroupBox3.Controls.Add(Me.IntegerUpDown1)
        Me.UiGroupBox3.Controls.Add(Me.Label42)
        Me.UiGroupBox3.Controls.Add(Me.CalendarCombo3)
        Me.UiGroupBox3.Controls.Add(Me.Label43)
        Me.UiGroupBox3.Controls.Add(Me.Button12)
        Me.UiGroupBox3.Controls.Add(Me.Button13)
        Me.UiGroupBox3.Controls.Add(Me.TextBox15)
        Me.UiGroupBox3.Controls.Add(Me.NumericEditBox1)
        Me.UiGroupBox3.Controls.Add(Me.Label44)
        Me.UiGroupBox3.Controls.Add(Me.Label45)
        Me.UiGroupBox3.Controls.Add(Me.UiButton18)
        Me.UiGroupBox3.Controls.Add(Me.Label46)
        Me.UiGroupBox3.Controls.Add(Me.TextBox16)
        Me.UiGroupBox3.Controls.Add(Me.Button14)
        Me.UiGroupBox3.Controls.Add(Me.CheckBox3)
        Me.UiGroupBox3.Controls.Add(Me.CalendarCombo4)
        Me.UiGroupBox3.Controls.Add(Me.Label47)
        Me.UiGroupBox3.Controls.Add(Me.CalendarCombo5)
        Me.UiGroupBox3.Controls.Add(Me.Label48)
        Me.UiGroupBox3.Controls.Add(Me.Label49)
        Me.UiGroupBox3.Controls.Add(Me.TextBox17)
        Me.UiGroupBox3.Controls.Add(Me.MultiColumnCombo2)
        Me.UiGroupBox3.Controls.Add(Me.Label50)
        Me.UiGroupBox3.Location = New System.Drawing.Point(12, 76)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(575, 210)
        Me.UiGroupBox3.TabIndex = 342
        Me.UiGroupBox3.Text = "Datos de Capacitación"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'MultiColumnCombo1
        '
        Me.MultiColumnCombo1.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        MultiColumnCombo1_DesignTimeLayout.LayoutString = resources.GetString("MultiColumnCombo1_DesignTimeLayout.LayoutString")
        Me.MultiColumnCombo1.DesignTimeLayout = MultiColumnCombo1_DesignTimeLayout
        Me.MultiColumnCombo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MultiColumnCombo1.Location = New System.Drawing.Point(340, 112)
        Me.MultiColumnCombo1.Name = "MultiColumnCombo1"
        Me.MultiColumnCombo1.SelectedIndex = -1
        Me.MultiColumnCombo1.SelectedItem = Nothing
        Me.MultiColumnCombo1.Size = New System.Drawing.Size(54, 20)
        Me.MultiColumnCombo1.TabIndex = 10
        Me.MultiColumnCombo1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.MultiColumnCombo1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(310, 115)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(31, 13)
        Me.Label39.TabIndex = 352
        Me.Label39.Text = "Mon."
        '
        'TextBox14
        '
        Me.TextBox14.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox14.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox14.Location = New System.Drawing.Point(77, 112)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(200, 20)
        Me.TextBox14.TabIndex = 9
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Location = New System.Drawing.Point(266, 145)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(71, 17)
        Me.CheckBox2.TabIndex = 13
        Me.CheckBox2.Text = "Evaluado"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(175, 146)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(37, 13)
        Me.Label40.TabIndex = 350
        Me.Label40.Text = "meses"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(24, 116)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(50, 13)
        Me.Label41.TabIndex = 336
        Me.Label41.Text = "Duración"
        '
        'IntegerUpDown1
        '
        Me.IntegerUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IntegerUpDown1.Location = New System.Drawing.Point(115, 142)
        Me.IntegerUpDown1.Maximum = 90
        Me.IntegerUpDown1.MaxLength = 2
        Me.IntegerUpDown1.Name = "IntegerUpDown1"
        Me.IntegerUpDown1.Size = New System.Drawing.Size(54, 20)
        Me.IntegerUpDown1.TabIndex = 12
        Me.IntegerUpDown1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.IntegerUpDown1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(18, 146)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(91, 13)
        Me.Label42.TabIndex = 349
        Me.Label42.Text = "Evaluar dentro de"
        '
        'CalendarCombo3
        '
        '
        '
        '
        Me.CalendarCombo3.DropDownCalendar.Name = ""
        Me.CalendarCombo3.DropDownCalendar.Visible = False
        Me.CalendarCombo3.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.CalendarCombo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarCombo3.IsNullDate = True
        Me.CalendarCombo3.Location = New System.Drawing.Point(464, 142)
        Me.CalendarCombo3.Name = "CalendarCombo3"
        Me.CalendarCombo3.NullButtonText = "Ninguno"
        Me.CalendarCombo3.ShowNullButton = True
        Me.CalendarCombo3.Size = New System.Drawing.Size(82, 20)
        Me.CalendarCombo3.TabIndex = 14
        Me.CalendarCombo3.TodayButtonText = "Hoy"
        Me.CalendarCombo3.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(374, 146)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(84, 13)
        Me.Label43.TabIndex = 347
        Me.Label43.Text = "Fec. Evaluación"
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Transparent
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.Location = New System.Drawing.Point(536, 172)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(28, 28)
        Me.Button12.TabIndex = 17
        Me.Button12.TabStop = False
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.Transparent
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.Location = New System.Drawing.Point(502, 172)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(28, 28)
        Me.Button13.TabIndex = 16
        Me.Button13.UseVisualStyleBackColor = False
        '
        'TextBox15
        '
        Me.TextBox15.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox15.Location = New System.Drawing.Point(77, 172)
        Me.TextBox15.Multiline = True
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox15.Size = New System.Drawing.Size(413, 30)
        Me.TextBox15.TabIndex = 15
        '
        'NumericEditBox1
        '
        Me.NumericEditBox1.DecimalDigits = 2
        Me.NumericEditBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericEditBox1.Location = New System.Drawing.Point(461, 112)
        Me.NumericEditBox1.MaxLength = 10
        Me.NumericEditBox1.Name = "NumericEditBox1"
        Me.NumericEditBox1.Size = New System.Drawing.Size(82, 20)
        Me.NumericEditBox1.TabIndex = 11
        Me.NumericEditBox1.Text = "0.00"
        Me.NumericEditBox1.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.NumericEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(4, 180)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(67, 13)
        Me.Label44.TabIndex = 345
        Me.Label44.Text = "Observación"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(421, 115)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(34, 13)
        Me.Label45.TabIndex = 343
        Me.Label45.Text = "Costo"
        '
        'UiButton18
        '
        Me.UiButton18.Image = CType(resources.GetObject("UiButton18.Image"), System.Drawing.Image)
        Me.UiButton18.Location = New System.Drawing.Point(465, 82)
        Me.UiButton18.Name = "UiButton18"
        Me.UiButton18.Size = New System.Drawing.Size(23, 21)
        Me.UiButton18.TabIndex = 8
        Me.UiButton18.TabStop = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(18, 86)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(56, 13)
        Me.Label46.TabIndex = 338
        Me.Label46.Text = "Proveedor"
        '
        'TextBox16
        '
        Me.TextBox16.BackColor = System.Drawing.Color.PowderBlue
        Me.TextBox16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBox16.Location = New System.Drawing.Point(77, 82)
        Me.TextBox16.MaxLength = 3
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(358, 20)
        Me.TextBox16.TabIndex = 6
        '
        'Button14
        '
        Me.Button14.Image = CType(resources.GetObject("Button14.Image"), System.Drawing.Image)
        Me.Button14.Location = New System.Drawing.Point(438, 81)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(25, 22)
        Me.Button14.TabIndex = 7
        Me.Button14.TabStop = False
        Me.Button14.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox3.Location = New System.Drawing.Point(79, 53)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(83, 17)
        Me.CheckBox3.TabIndex = 3
        Me.CheckBox3.Text = "Programado"
        Me.CheckBox3.UseVisualStyleBackColor = False
        '
        'CalendarCombo4
        '
        '
        '
        '
        Me.CalendarCombo4.DropDownCalendar.Name = ""
        Me.CalendarCombo4.DropDownCalendar.Visible = False
        Me.CalendarCombo4.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.CalendarCombo4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarCombo4.IsNullDate = True
        Me.CalendarCombo4.Location = New System.Drawing.Point(253, 52)
        Me.CalendarCombo4.Name = "CalendarCombo4"
        Me.CalendarCombo4.NullButtonText = "Ninguno"
        Me.CalendarCombo4.Size = New System.Drawing.Size(82, 20)
        Me.CalendarCombo4.TabIndex = 4
        Me.CalendarCombo4.TodayButtonText = "Hoy"
        Me.CalendarCombo4.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(191, 56)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(56, 13)
        Me.Label47.TabIndex = 334
        Me.Label47.Text = "Fec. Inicio"
        '
        'CalendarCombo5
        '
        '
        '
        '
        Me.CalendarCombo5.DropDownCalendar.Name = ""
        Me.CalendarCombo5.DropDownCalendar.Visible = False
        Me.CalendarCombo5.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.CalendarCombo5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CalendarCombo5.IsNullDate = True
        Me.CalendarCombo5.Location = New System.Drawing.Point(459, 52)
        Me.CalendarCombo5.Name = "CalendarCombo5"
        Me.CalendarCombo5.NullButtonText = "Ninguno"
        Me.CalendarCombo5.Size = New System.Drawing.Size(82, 20)
        Me.CalendarCombo5.TabIndex = 5
        Me.CalendarCombo5.TodayButtonText = "Hoy"
        Me.CalendarCombo5.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(402, 56)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(53, 13)
        Me.Label48.TabIndex = 333
        Me.Label48.Text = "Fec. Final"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(172, 26)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(34, 13)
        Me.Label49.TabIndex = 330
        Me.Label49.Text = "Curso"
        '
        'TextBox17
        '
        Me.TextBox17.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox17.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox17.Location = New System.Drawing.Point(208, 22)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(356, 20)
        Me.TextBox17.TabIndex = 2
        '
        'MultiColumnCombo2
        '
        Me.MultiColumnCombo2.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        MultiColumnCombo2_DesignTimeLayout.LayoutString = resources.GetString("MultiColumnCombo2_DesignTimeLayout.LayoutString")
        Me.MultiColumnCombo2.DesignTimeLayout = MultiColumnCombo2_DesignTimeLayout
        Me.MultiColumnCombo2.Location = New System.Drawing.Point(77, 22)
        Me.MultiColumnCombo2.Name = "MultiColumnCombo2"
        Me.MultiColumnCombo2.SelectedIndex = -1
        Me.MultiColumnCombo2.SelectedItem = Nothing
        Me.MultiColumnCombo2.Size = New System.Drawing.Size(82, 20)
        Me.MultiColumnCombo2.TabIndex = 1
        Me.MultiColumnCombo2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(43, 25)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(28, 13)
        Me.Label50.TabIndex = 328
        Me.Label50.Text = "Tipo"
        '
        'GridEX2
        '
        GridEX2_DesignTimeLayout.LayoutString = resources.GetString("GridEX2_DesignTimeLayout.LayoutString")
        Me.GridEX2.DesignTimeLayout = GridEX2_DesignTimeLayout
        Me.GridEX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GridEX2.GroupByBoxVisible = False
        Me.GridEX2.Location = New System.Drawing.Point(13, 292)
        Me.GridEX2.Name = "GridEX2"
        Me.GridEX2.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GridEX2.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX2.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.GridEX2.Size = New System.Drawing.Size(574, 163)
        Me.GridEX2.TabIndex = 341
        Me.GridEX2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tpProcesador
        '
        Me.tpProcesador.Controls.Add(Me.UiGroupBox4)
        Me.tpProcesador.Icon = CType(resources.GetObject("tpProcesador.Icon"), System.Drawing.Icon)
        Me.tpProcesador.Location = New System.Drawing.Point(1, 43)
        Me.tpProcesador.Name = "tpProcesador"
        Me.tpProcesador.Size = New System.Drawing.Size(570, 446)
        Me.tpProcesador.TabStop = True
        Me.tpProcesador.Text = "Procesador"
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox4.Controls.Add(Me.btnAgregarProcesador1)
        Me.UiGroupBox4.Controls.Add(Me.btnBuscarProcesador1)
        Me.UiGroupBox4.Controls.Add(Me.txtProcesador1)
        Me.UiGroupBox4.Controls.Add(Me.Label9)
        Me.UiGroupBox4.Controls.Add(Me.dgvDatosProcesador)
        Me.UiGroupBox4.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox4.TabIndex = 1
        Me.UiGroupBox4.Text = "Procesador"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarProcesador1
        '
        Me.btnAgregarProcesador1.Image = CType(resources.GetObject("btnAgregarProcesador1.Image"), System.Drawing.Image)
        Me.btnAgregarProcesador1.Location = New System.Drawing.Point(512, 9)
        Me.btnAgregarProcesador1.Name = "btnAgregarProcesador1"
        Me.btnAgregarProcesador1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarProcesador1.TabIndex = 383
        Me.btnAgregarProcesador1.TabStop = False
        Me.btnAgregarProcesador1.Visible = False
        '
        'btnBuscarProcesador1
        '
        Me.btnBuscarProcesador1.Image = CType(resources.GetObject("btnBuscarProcesador1.Image"), System.Drawing.Image)
        Me.btnBuscarProcesador1.Location = New System.Drawing.Point(480, 8)
        Me.btnBuscarProcesador1.Name = "btnBuscarProcesador1"
        Me.btnBuscarProcesador1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarProcesador1.TabIndex = 381
        Me.btnBuscarProcesador1.TabStop = False
        Me.btnBuscarProcesador1.UseVisualStyleBackColor = True
        Me.btnBuscarProcesador1.Visible = False
        '
        'txtProcesador1
        '
        Me.txtProcesador1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtProcesador1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcesador1.Location = New System.Drawing.Point(166, 10)
        Me.txtProcesador1.Name = "txtProcesador1"
        Me.txtProcesador1.ReadOnly = True
        Me.txtProcesador1.Size = New System.Drawing.Size(308, 20)
        Me.txtProcesador1.TabIndex = 380
        Me.txtProcesador1.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(99, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 382
        Me.Label9.Text = "Procesador"
        Me.Label9.Visible = False
        '
        'dgvDatosProcesador
        '
        Me.dgvDatosProcesador.ContextMenuStrip = Me.cmOpProcesador
        dgvDatosProcesador_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosProcesador_DesignTimeLayout.LayoutString")
        Me.dgvDatosProcesador.DesignTimeLayout = dgvDatosProcesador_DesignTimeLayout
        Me.dgvDatosProcesador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosProcesador.GroupByBoxVisible = False
        Me.dgvDatosProcesador.Location = New System.Drawing.Point(17, 29)
        Me.dgvDatosProcesador.Name = "dgvDatosProcesador"
        Me.dgvDatosProcesador.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosProcesador.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosProcesador.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosProcesador.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosProcesador.TabIndex = 336
        Me.dgvDatosProcesador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpProcesador
        '
        Me.cmOpProcesador.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoProc, Me.miEditProc, Me.miElimProc, Me.ToolStripSeparator9, Me.ToolStripSeparator10, Me.miActProc})
        Me.cmOpProcesador.Name = "cmOpciones"
        Me.cmOpProcesador.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoProc
        '
        Me.miNuevoProc.Image = CType(resources.GetObject("miNuevoProc.Image"), System.Drawing.Image)
        Me.miNuevoProc.Name = "miNuevoProc"
        Me.miNuevoProc.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoProc.Text = "Nuevo"
        Me.miNuevoProc.ToolTipText = "Nuevo Procesador"
        '
        'miEditProc
        '
        Me.miEditProc.Image = CType(resources.GetObject("miEditProc.Image"), System.Drawing.Image)
        Me.miEditProc.Name = "miEditProc"
        Me.miEditProc.Size = New System.Drawing.Size(126, 22)
        Me.miEditProc.Text = "Editar"
        Me.miEditProc.ToolTipText = "Editar Procesador"
        '
        'miElimProc
        '
        Me.miElimProc.Image = CType(resources.GetObject("miElimProc.Image"), System.Drawing.Image)
        Me.miElimProc.Name = "miElimProc"
        Me.miElimProc.Size = New System.Drawing.Size(126, 22)
        Me.miElimProc.Text = "Eliminar"
        Me.miElimProc.ToolTipText = "Eliminar Procesador"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(123, 6)
        '
        'miActProc
        '
        Me.miActProc.Image = CType(resources.GetObject("miActProc.Image"), System.Drawing.Image)
        Me.miActProc.Name = "miActProc"
        Me.miActProc.Size = New System.Drawing.Size(126, 22)
        Me.miActProc.Text = "Actualizar"
        Me.miActProc.ToolTipText = "Refrescar Procesadores"
        '
        'tpPlacaMadre
        '
        Me.tpPlacaMadre.Controls.Add(Me.UiGroupBox5)
        Me.tpPlacaMadre.Icon = CType(resources.GetObject("tpPlacaMadre.Icon"), System.Drawing.Icon)
        Me.tpPlacaMadre.Location = New System.Drawing.Point(1, 43)
        Me.tpPlacaMadre.Name = "tpPlacaMadre"
        Me.tpPlacaMadre.Size = New System.Drawing.Size(570, 446)
        Me.tpPlacaMadre.TabStop = True
        Me.tpPlacaMadre.Text = "Placa Madre"
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox5.Controls.Add(Me.btnAgregarPlacaMadre1)
        Me.UiGroupBox5.Controls.Add(Me.btnBuscarPlacaMadre1)
        Me.UiGroupBox5.Controls.Add(Me.txtPlacaMadre1)
        Me.UiGroupBox5.Controls.Add(Me.Label10)
        Me.UiGroupBox5.Controls.Add(Me.dgvDatosPlacaMadre)
        Me.UiGroupBox5.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox5.TabIndex = 2
        Me.UiGroupBox5.Text = "Placa Madre"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarPlacaMadre1
        '
        Me.btnAgregarPlacaMadre1.Image = CType(resources.GetObject("btnAgregarPlacaMadre1.Image"), System.Drawing.Image)
        Me.btnAgregarPlacaMadre1.Location = New System.Drawing.Point(509, 11)
        Me.btnAgregarPlacaMadre1.Name = "btnAgregarPlacaMadre1"
        Me.btnAgregarPlacaMadre1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarPlacaMadre1.TabIndex = 383
        Me.btnAgregarPlacaMadre1.TabStop = False
        Me.btnAgregarPlacaMadre1.Visible = False
        '
        'btnBuscarPlacaMadre1
        '
        Me.btnBuscarPlacaMadre1.Image = CType(resources.GetObject("btnBuscarPlacaMadre1.Image"), System.Drawing.Image)
        Me.btnBuscarPlacaMadre1.Location = New System.Drawing.Point(477, 10)
        Me.btnBuscarPlacaMadre1.Name = "btnBuscarPlacaMadre1"
        Me.btnBuscarPlacaMadre1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarPlacaMadre1.TabIndex = 381
        Me.btnBuscarPlacaMadre1.TabStop = False
        Me.btnBuscarPlacaMadre1.UseVisualStyleBackColor = True
        Me.btnBuscarPlacaMadre1.Visible = False
        '
        'txtPlacaMadre1
        '
        Me.txtPlacaMadre1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtPlacaMadre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacaMadre1.Location = New System.Drawing.Point(163, 12)
        Me.txtPlacaMadre1.Name = "txtPlacaMadre1"
        Me.txtPlacaMadre1.ReadOnly = True
        Me.txtPlacaMadre1.Size = New System.Drawing.Size(308, 20)
        Me.txtPlacaMadre1.TabIndex = 380
        Me.txtPlacaMadre1.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(93, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 382
        Me.Label10.Text = "Placa Madre"
        Me.Label10.Visible = False
        '
        'dgvDatosPlacaMadre
        '
        Me.dgvDatosPlacaMadre.ContextMenuStrip = Me.cmOpPlacaMadre
        dgvDatosPlacaMadre_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosPlacaMadre_DesignTimeLayout.LayoutString")
        Me.dgvDatosPlacaMadre.DesignTimeLayout = dgvDatosPlacaMadre_DesignTimeLayout
        Me.dgvDatosPlacaMadre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosPlacaMadre.GroupByBoxVisible = False
        Me.dgvDatosPlacaMadre.Location = New System.Drawing.Point(17, 31)
        Me.dgvDatosPlacaMadre.Name = "dgvDatosPlacaMadre"
        Me.dgvDatosPlacaMadre.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosPlacaMadre.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosPlacaMadre.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosPlacaMadre.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosPlacaMadre.TabIndex = 336
        Me.dgvDatosPlacaMadre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpPlacaMadre
        '
        Me.cmOpPlacaMadre.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoPlaca, Me.miEditarPlaca, Me.miEliminarPlaca, Me.ToolStripSeparator6, Me.ToolStripSeparator8, Me.miActualizarPlaca})
        Me.cmOpPlacaMadre.Name = "cmOpciones"
        Me.cmOpPlacaMadre.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoPlaca
        '
        Me.miNuevoPlaca.Image = CType(resources.GetObject("miNuevoPlaca.Image"), System.Drawing.Image)
        Me.miNuevoPlaca.Name = "miNuevoPlaca"
        Me.miNuevoPlaca.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoPlaca.Text = "Nuevo"
        Me.miNuevoPlaca.ToolTipText = "Nueva Placa Madre"
        '
        'miEditarPlaca
        '
        Me.miEditarPlaca.Image = CType(resources.GetObject("miEditarPlaca.Image"), System.Drawing.Image)
        Me.miEditarPlaca.Name = "miEditarPlaca"
        Me.miEditarPlaca.Size = New System.Drawing.Size(126, 22)
        Me.miEditarPlaca.Text = "Editar"
        Me.miEditarPlaca.ToolTipText = "Editar Placa Madre"
        '
        'miEliminarPlaca
        '
        Me.miEliminarPlaca.Image = CType(resources.GetObject("miEliminarPlaca.Image"), System.Drawing.Image)
        Me.miEliminarPlaca.Name = "miEliminarPlaca"
        Me.miEliminarPlaca.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarPlaca.Text = "Eliminar"
        Me.miEliminarPlaca.ToolTipText = "Eliminar Placa Madre"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarPlaca
        '
        Me.miActualizarPlaca.Image = CType(resources.GetObject("miActualizarPlaca.Image"), System.Drawing.Image)
        Me.miActualizarPlaca.Name = "miActualizarPlaca"
        Me.miActualizarPlaca.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarPlaca.Text = "Actualizar"
        Me.miActualizarPlaca.ToolTipText = "Refrescar Procesadores"
        '
        'tpMemoriaRam
        '
        Me.tpMemoriaRam.Controls.Add(Me.UiGroupBox6)
        Me.tpMemoriaRam.Icon = CType(resources.GetObject("tpMemoriaRam.Icon"), System.Drawing.Icon)
        Me.tpMemoriaRam.Location = New System.Drawing.Point(1, 43)
        Me.tpMemoriaRam.Name = "tpMemoriaRam"
        Me.tpMemoriaRam.Size = New System.Drawing.Size(570, 446)
        Me.tpMemoriaRam.TabStop = True
        Me.tpMemoriaRam.Text = "Memoria Ram"
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox6.Controls.Add(Me.btnAgregarMemoriaram1)
        Me.UiGroupBox6.Controls.Add(Me.btnBuscarMemoriaram1)
        Me.UiGroupBox6.Controls.Add(Me.txtMemoriaram1)
        Me.UiGroupBox6.Controls.Add(Me.Label18)
        Me.UiGroupBox6.Controls.Add(Me.dgvDatosMemoriaRam)
        Me.UiGroupBox6.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox6.TabIndex = 2
        Me.UiGroupBox6.Text = "Memoria RAM"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarMemoriaram1
        '
        Me.btnAgregarMemoriaram1.Image = CType(resources.GetObject("btnAgregarMemoriaram1.Image"), System.Drawing.Image)
        Me.btnAgregarMemoriaram1.Location = New System.Drawing.Point(524, 8)
        Me.btnAgregarMemoriaram1.Name = "btnAgregarMemoriaram1"
        Me.btnAgregarMemoriaram1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarMemoriaram1.TabIndex = 383
        Me.btnAgregarMemoriaram1.TabStop = False
        Me.btnAgregarMemoriaram1.Visible = False
        '
        'btnBuscarMemoriaram1
        '
        Me.btnBuscarMemoriaram1.Image = CType(resources.GetObject("btnBuscarMemoriaram1.Image"), System.Drawing.Image)
        Me.btnBuscarMemoriaram1.Location = New System.Drawing.Point(492, 7)
        Me.btnBuscarMemoriaram1.Name = "btnBuscarMemoriaram1"
        Me.btnBuscarMemoriaram1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarMemoriaram1.TabIndex = 381
        Me.btnBuscarMemoriaram1.TabStop = False
        Me.btnBuscarMemoriaram1.UseVisualStyleBackColor = True
        Me.btnBuscarMemoriaram1.Visible = False
        '
        'txtMemoriaram1
        '
        Me.txtMemoriaram1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtMemoriaram1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemoriaram1.Location = New System.Drawing.Point(178, 9)
        Me.txtMemoriaram1.Name = "txtMemoriaram1"
        Me.txtMemoriaram1.ReadOnly = True
        Me.txtMemoriaram1.Size = New System.Drawing.Size(308, 20)
        Me.txtMemoriaram1.TabIndex = 380
        Me.txtMemoriaram1.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(100, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 13)
        Me.Label18.TabIndex = 382
        Me.Label18.Text = "Memoria Ram"
        Me.Label18.Visible = False
        '
        'dgvDatosMemoriaRam
        '
        Me.dgvDatosMemoriaRam.ContextMenuStrip = Me.cmOpMemoriaRam
        dgvDatosMemoriaRam_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosMemoriaRam_DesignTimeLayout.LayoutString")
        Me.dgvDatosMemoriaRam.DesignTimeLayout = dgvDatosMemoriaRam_DesignTimeLayout
        Me.dgvDatosMemoriaRam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosMemoriaRam.GroupByBoxVisible = False
        Me.dgvDatosMemoriaRam.Location = New System.Drawing.Point(17, 29)
        Me.dgvDatosMemoriaRam.Name = "dgvDatosMemoriaRam"
        Me.dgvDatosMemoriaRam.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosMemoriaRam.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosMemoriaRam.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosMemoriaRam.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosMemoriaRam.TabIndex = 336
        Me.dgvDatosMemoriaRam.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpMemoriaRam
        '
        Me.cmOpMemoriaRam.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoMem, Me.miEditarMem, Me.miEliminarMem, Me.ToolStripSeparator1, Me.ToolStripSeparator11, Me.miActualizarMem})
        Me.cmOpMemoriaRam.Name = "cmOpciones"
        Me.cmOpMemoriaRam.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoMem
        '
        Me.miNuevoMem.Image = CType(resources.GetObject("miNuevoMem.Image"), System.Drawing.Image)
        Me.miNuevoMem.Name = "miNuevoMem"
        Me.miNuevoMem.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoMem.Text = "Nuevo"
        Me.miNuevoMem.ToolTipText = "Nueva Memoria Ram"
        '
        'miEditarMem
        '
        Me.miEditarMem.Image = CType(resources.GetObject("miEditarMem.Image"), System.Drawing.Image)
        Me.miEditarMem.Name = "miEditarMem"
        Me.miEditarMem.Size = New System.Drawing.Size(126, 22)
        Me.miEditarMem.Text = "Editar"
        Me.miEditarMem.ToolTipText = "Editar Memoria Ram"
        '
        'miEliminarMem
        '
        Me.miEliminarMem.Image = CType(resources.GetObject("miEliminarMem.Image"), System.Drawing.Image)
        Me.miEliminarMem.Name = "miEliminarMem"
        Me.miEliminarMem.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarMem.Text = "Eliminar"
        Me.miEliminarMem.ToolTipText = "Eliminar Memoria Ram"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarMem
        '
        Me.miActualizarMem.Image = CType(resources.GetObject("miActualizarMem.Image"), System.Drawing.Image)
        Me.miActualizarMem.Name = "miActualizarMem"
        Me.miActualizarMem.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarMem.Text = "Actualizar"
        Me.miActualizarMem.ToolTipText = "Refrescar Memoria"
        '
        'tpTarjetaVideo
        '
        Me.tpTarjetaVideo.Controls.Add(Me.UiGroupBox7)
        Me.tpTarjetaVideo.Icon = CType(resources.GetObject("tpTarjetaVideo.Icon"), System.Drawing.Icon)
        Me.tpTarjetaVideo.Location = New System.Drawing.Point(1, 43)
        Me.tpTarjetaVideo.Name = "tpTarjetaVideo"
        Me.tpTarjetaVideo.Size = New System.Drawing.Size(570, 446)
        Me.tpTarjetaVideo.TabStop = True
        Me.tpTarjetaVideo.Text = "Tarjeta Video"
        '
        'UiGroupBox7
        '
        Me.UiGroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox7.Controls.Add(Me.btnAgregarTarjetaVideo1)
        Me.UiGroupBox7.Controls.Add(Me.btnBuscarTarjetaVideo1)
        Me.UiGroupBox7.Controls.Add(Me.txtTarjetaVideo1)
        Me.UiGroupBox7.Controls.Add(Me.Label21)
        Me.UiGroupBox7.Controls.Add(Me.dgvDatosTarjetaVideo)
        Me.UiGroupBox7.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox7.Name = "UiGroupBox7"
        Me.UiGroupBox7.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox7.TabIndex = 2
        Me.UiGroupBox7.Text = "Tarjeta Video"
        Me.UiGroupBox7.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarTarjetaVideo1
        '
        Me.btnAgregarTarjetaVideo1.Image = CType(resources.GetObject("btnAgregarTarjetaVideo1.Image"), System.Drawing.Image)
        Me.btnAgregarTarjetaVideo1.Location = New System.Drawing.Point(510, 8)
        Me.btnAgregarTarjetaVideo1.Name = "btnAgregarTarjetaVideo1"
        Me.btnAgregarTarjetaVideo1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarTarjetaVideo1.TabIndex = 383
        Me.btnAgregarTarjetaVideo1.TabStop = False
        Me.btnAgregarTarjetaVideo1.Visible = False
        '
        'btnBuscarTarjetaVideo1
        '
        Me.btnBuscarTarjetaVideo1.Image = CType(resources.GetObject("btnBuscarTarjetaVideo1.Image"), System.Drawing.Image)
        Me.btnBuscarTarjetaVideo1.Location = New System.Drawing.Point(478, 8)
        Me.btnBuscarTarjetaVideo1.Name = "btnBuscarTarjetaVideo1"
        Me.btnBuscarTarjetaVideo1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarTarjetaVideo1.TabIndex = 381
        Me.btnBuscarTarjetaVideo1.TabStop = False
        Me.btnBuscarTarjetaVideo1.UseVisualStyleBackColor = True
        Me.btnBuscarTarjetaVideo1.Visible = False
        '
        'txtTarjetaVideo1
        '
        Me.txtTarjetaVideo1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtTarjetaVideo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjetaVideo1.Location = New System.Drawing.Point(164, 10)
        Me.txtTarjetaVideo1.Name = "txtTarjetaVideo1"
        Me.txtTarjetaVideo1.ReadOnly = True
        Me.txtTarjetaVideo1.Size = New System.Drawing.Size(308, 20)
        Me.txtTarjetaVideo1.TabIndex = 380
        Me.txtTarjetaVideo1.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(88, 14)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 13)
        Me.Label21.TabIndex = 382
        Me.Label21.Text = "Tarjeta Video"
        Me.Label21.Visible = False
        '
        'dgvDatosTarjetaVideo
        '
        Me.dgvDatosTarjetaVideo.ContextMenuStrip = Me.cmOpTarjetaVideo
        dgvDatosTarjetaVideo_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosTarjetaVideo_DesignTimeLayout.LayoutString")
        Me.dgvDatosTarjetaVideo.DesignTimeLayout = dgvDatosTarjetaVideo_DesignTimeLayout
        Me.dgvDatosTarjetaVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosTarjetaVideo.GroupByBoxVisible = False
        Me.dgvDatosTarjetaVideo.Location = New System.Drawing.Point(17, 30)
        Me.dgvDatosTarjetaVideo.Name = "dgvDatosTarjetaVideo"
        Me.dgvDatosTarjetaVideo.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosTarjetaVideo.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosTarjetaVideo.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosTarjetaVideo.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosTarjetaVideo.TabIndex = 336
        Me.dgvDatosTarjetaVideo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpTarjetaVideo
        '
        Me.cmOpTarjetaVideo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoTarj, Me.miEditarTarj, Me.miEliminarTarj, Me.ToolStripSeparator12, Me.ToolStripSeparator13, Me.miActualizarTarj})
        Me.cmOpTarjetaVideo.Name = "cmOpciones"
        Me.cmOpTarjetaVideo.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoTarj
        '
        Me.miNuevoTarj.Image = CType(resources.GetObject("miNuevoTarj.Image"), System.Drawing.Image)
        Me.miNuevoTarj.Name = "miNuevoTarj"
        Me.miNuevoTarj.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoTarj.Text = "Nuevo"
        Me.miNuevoTarj.ToolTipText = "Nueva Tarjeta Video"
        '
        'miEditarTarj
        '
        Me.miEditarTarj.Image = CType(resources.GetObject("miEditarTarj.Image"), System.Drawing.Image)
        Me.miEditarTarj.Name = "miEditarTarj"
        Me.miEditarTarj.Size = New System.Drawing.Size(126, 22)
        Me.miEditarTarj.Text = "Editar"
        Me.miEditarTarj.ToolTipText = "Editar Tarjeta Video"
        '
        'miEliminarTarj
        '
        Me.miEliminarTarj.Image = CType(resources.GetObject("miEliminarTarj.Image"), System.Drawing.Image)
        Me.miEliminarTarj.Name = "miEliminarTarj"
        Me.miEliminarTarj.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarTarj.Text = "Eliminar"
        Me.miEliminarTarj.ToolTipText = "Eliminar Tarjeta Video"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarTarj
        '
        Me.miActualizarTarj.Image = CType(resources.GetObject("miActualizarTarj.Image"), System.Drawing.Image)
        Me.miActualizarTarj.Name = "miActualizarTarj"
        Me.miActualizarTarj.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarTarj.Text = "Actualizar"
        Me.miActualizarTarj.ToolTipText = "Refrescar Tarjeta Video"
        '
        'tpDiscoDuro
        '
        Me.tpDiscoDuro.Controls.Add(Me.UiGroupBox8)
        Me.tpDiscoDuro.Icon = CType(resources.GetObject("tpDiscoDuro.Icon"), System.Drawing.Icon)
        Me.tpDiscoDuro.Location = New System.Drawing.Point(1, 43)
        Me.tpDiscoDuro.Name = "tpDiscoDuro"
        Me.tpDiscoDuro.Size = New System.Drawing.Size(570, 446)
        Me.tpDiscoDuro.TabStop = True
        Me.tpDiscoDuro.Text = "Disco Duro"
        '
        'UiGroupBox8
        '
        Me.UiGroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox8.Controls.Add(Me.btnAgregarDiscoDuro1)
        Me.UiGroupBox8.Controls.Add(Me.btnBuscarDiscoDuro1)
        Me.UiGroupBox8.Controls.Add(Me.txtDiscoDuro1)
        Me.UiGroupBox8.Controls.Add(Me.Label22)
        Me.UiGroupBox8.Controls.Add(Me.dgvDatosDiscoDuro)
        Me.UiGroupBox8.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox8.Name = "UiGroupBox8"
        Me.UiGroupBox8.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox8.TabIndex = 2
        Me.UiGroupBox8.Text = "Disco Duro"
        Me.UiGroupBox8.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarDiscoDuro1
        '
        Me.btnAgregarDiscoDuro1.Image = CType(resources.GetObject("btnAgregarDiscoDuro1.Image"), System.Drawing.Image)
        Me.btnAgregarDiscoDuro1.Location = New System.Drawing.Point(509, 8)
        Me.btnAgregarDiscoDuro1.Name = "btnAgregarDiscoDuro1"
        Me.btnAgregarDiscoDuro1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarDiscoDuro1.TabIndex = 383
        Me.btnAgregarDiscoDuro1.TabStop = False
        Me.btnAgregarDiscoDuro1.Visible = False
        '
        'btnBuscarDiscoDuro1
        '
        Me.btnBuscarDiscoDuro1.Image = CType(resources.GetObject("btnBuscarDiscoDuro1.Image"), System.Drawing.Image)
        Me.btnBuscarDiscoDuro1.Location = New System.Drawing.Point(477, 7)
        Me.btnBuscarDiscoDuro1.Name = "btnBuscarDiscoDuro1"
        Me.btnBuscarDiscoDuro1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarDiscoDuro1.TabIndex = 381
        Me.btnBuscarDiscoDuro1.TabStop = False
        Me.btnBuscarDiscoDuro1.UseVisualStyleBackColor = True
        Me.btnBuscarDiscoDuro1.Visible = False
        '
        'txtDiscoDuro1
        '
        Me.txtDiscoDuro1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtDiscoDuro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscoDuro1.Location = New System.Drawing.Point(163, 9)
        Me.txtDiscoDuro1.Name = "txtDiscoDuro1"
        Me.txtDiscoDuro1.ReadOnly = True
        Me.txtDiscoDuro1.Size = New System.Drawing.Size(308, 20)
        Me.txtDiscoDuro1.TabIndex = 380
        Me.txtDiscoDuro1.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(96, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 13)
        Me.Label22.TabIndex = 382
        Me.Label22.Text = "Disco Duro"
        Me.Label22.Visible = False
        '
        'dgvDatosDiscoDuro
        '
        Me.dgvDatosDiscoDuro.ContextMenuStrip = Me.cmOpDiscoDuro
        dgvDatosDiscoDuro_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosDiscoDuro_DesignTimeLayout.LayoutString")
        Me.dgvDatosDiscoDuro.DesignTimeLayout = dgvDatosDiscoDuro_DesignTimeLayout
        Me.dgvDatosDiscoDuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosDiscoDuro.GroupByBoxVisible = False
        Me.dgvDatosDiscoDuro.Location = New System.Drawing.Point(17, 31)
        Me.dgvDatosDiscoDuro.Name = "dgvDatosDiscoDuro"
        Me.dgvDatosDiscoDuro.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosDiscoDuro.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosDiscoDuro.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosDiscoDuro.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosDiscoDuro.TabIndex = 336
        Me.dgvDatosDiscoDuro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpDiscoDuro
        '
        Me.cmOpDiscoDuro.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoDisco, Me.miEditarDisco, Me.miEliminarDisco, Me.ToolStripSeparator14, Me.ToolStripSeparator15, Me.miActualizarDisco})
        Me.cmOpDiscoDuro.Name = "cmOpciones"
        Me.cmOpDiscoDuro.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoDisco
        '
        Me.miNuevoDisco.Image = CType(resources.GetObject("miNuevoDisco.Image"), System.Drawing.Image)
        Me.miNuevoDisco.Name = "miNuevoDisco"
        Me.miNuevoDisco.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoDisco.Text = "Nuevo"
        Me.miNuevoDisco.ToolTipText = "Nuevo Disco"
        '
        'miEditarDisco
        '
        Me.miEditarDisco.Image = CType(resources.GetObject("miEditarDisco.Image"), System.Drawing.Image)
        Me.miEditarDisco.Name = "miEditarDisco"
        Me.miEditarDisco.Size = New System.Drawing.Size(126, 22)
        Me.miEditarDisco.Text = "Editar"
        Me.miEditarDisco.ToolTipText = "Editar Disco"
        '
        'miEliminarDisco
        '
        Me.miEliminarDisco.Image = CType(resources.GetObject("miEliminarDisco.Image"), System.Drawing.Image)
        Me.miEliminarDisco.Name = "miEliminarDisco"
        Me.miEliminarDisco.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarDisco.Text = "Eliminar"
        Me.miEliminarDisco.ToolTipText = "Eliminar Disco Duro"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarDisco
        '
        Me.miActualizarDisco.Image = CType(resources.GetObject("miActualizarDisco.Image"), System.Drawing.Image)
        Me.miActualizarDisco.Name = "miActualizarDisco"
        Me.miActualizarDisco.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarDisco.Text = "Actualizar"
        Me.miActualizarDisco.ToolTipText = "Actualizar Disco Duro"
        '
        'tpLectora
        '
        Me.tpLectora.Controls.Add(Me.UiGroupBox9)
        Me.tpLectora.Icon = CType(resources.GetObject("tpLectora.Icon"), System.Drawing.Icon)
        Me.tpLectora.Location = New System.Drawing.Point(1, 43)
        Me.tpLectora.Name = "tpLectora"
        Me.tpLectora.Size = New System.Drawing.Size(570, 446)
        Me.tpLectora.TabStop = True
        Me.tpLectora.Text = "Lectora"
        '
        'UiGroupBox9
        '
        Me.UiGroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox9.Controls.Add(Me.btnAgregarLectora1)
        Me.UiGroupBox9.Controls.Add(Me.btnBuscarLectora1)
        Me.UiGroupBox9.Controls.Add(Me.txtLectora1)
        Me.UiGroupBox9.Controls.Add(Me.Label23)
        Me.UiGroupBox9.Controls.Add(Me.dgvDatosLectora)
        Me.UiGroupBox9.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox9.Name = "UiGroupBox9"
        Me.UiGroupBox9.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox9.TabIndex = 2
        Me.UiGroupBox9.Text = "Lectora"
        Me.UiGroupBox9.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarLectora1
        '
        Me.btnAgregarLectora1.Image = CType(resources.GetObject("btnAgregarLectora1.Image"), System.Drawing.Image)
        Me.btnAgregarLectora1.Location = New System.Drawing.Point(509, 8)
        Me.btnAgregarLectora1.Name = "btnAgregarLectora1"
        Me.btnAgregarLectora1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarLectora1.TabIndex = 383
        Me.btnAgregarLectora1.TabStop = False
        Me.btnAgregarLectora1.Visible = False
        '
        'btnBuscarLectora1
        '
        Me.btnBuscarLectora1.Image = CType(resources.GetObject("btnBuscarLectora1.Image"), System.Drawing.Image)
        Me.btnBuscarLectora1.Location = New System.Drawing.Point(477, 7)
        Me.btnBuscarLectora1.Name = "btnBuscarLectora1"
        Me.btnBuscarLectora1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarLectora1.TabIndex = 381
        Me.btnBuscarLectora1.TabStop = False
        Me.btnBuscarLectora1.UseVisualStyleBackColor = True
        Me.btnBuscarLectora1.Visible = False
        '
        'txtLectora1
        '
        Me.txtLectora1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtLectora1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLectora1.Location = New System.Drawing.Point(163, 9)
        Me.txtLectora1.Name = "txtLectora1"
        Me.txtLectora1.ReadOnly = True
        Me.txtLectora1.Size = New System.Drawing.Size(308, 20)
        Me.txtLectora1.TabIndex = 380
        Me.txtLectora1.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(96, 12)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 13)
        Me.Label23.TabIndex = 382
        Me.Label23.Text = "Lectora"
        Me.Label23.Visible = False
        '
        'dgvDatosLectora
        '
        Me.dgvDatosLectora.ContextMenuStrip = Me.cmOpLectora
        dgvDatosLectora_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosLectora_DesignTimeLayout.LayoutString")
        Me.dgvDatosLectora.DesignTimeLayout = dgvDatosLectora_DesignTimeLayout
        Me.dgvDatosLectora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosLectora.GroupByBoxVisible = False
        Me.dgvDatosLectora.Location = New System.Drawing.Point(17, 28)
        Me.dgvDatosLectora.Name = "dgvDatosLectora"
        Me.dgvDatosLectora.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosLectora.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosLectora.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosLectora.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosLectora.TabIndex = 336
        Me.dgvDatosLectora.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpLectora
        '
        Me.cmOpLectora.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevaLectora, Me.miEditarLectora, Me.miEliminarLectora, Me.ToolStripSeparator16, Me.ToolStripSeparator17, Me.miActualizarLectora})
        Me.cmOpLectora.Name = "cmOpciones"
        Me.cmOpLectora.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevaLectora
        '
        Me.miNuevaLectora.Image = CType(resources.GetObject("miNuevaLectora.Image"), System.Drawing.Image)
        Me.miNuevaLectora.Name = "miNuevaLectora"
        Me.miNuevaLectora.Size = New System.Drawing.Size(126, 22)
        Me.miNuevaLectora.Text = "Nuevo"
        Me.miNuevaLectora.ToolTipText = "Nueva Lectora"
        '
        'miEditarLectora
        '
        Me.miEditarLectora.Image = CType(resources.GetObject("miEditarLectora.Image"), System.Drawing.Image)
        Me.miEditarLectora.Name = "miEditarLectora"
        Me.miEditarLectora.Size = New System.Drawing.Size(126, 22)
        Me.miEditarLectora.Text = "Editar"
        Me.miEditarLectora.ToolTipText = "Editar Lectora"
        '
        'miEliminarLectora
        '
        Me.miEliminarLectora.Image = CType(resources.GetObject("miEliminarLectora.Image"), System.Drawing.Image)
        Me.miEliminarLectora.Name = "miEliminarLectora"
        Me.miEliminarLectora.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarLectora.Text = "Eliminar"
        Me.miEliminarLectora.ToolTipText = "Eliminar Lectora"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarLectora
        '
        Me.miActualizarLectora.Image = CType(resources.GetObject("miActualizarLectora.Image"), System.Drawing.Image)
        Me.miActualizarLectora.Name = "miActualizarLectora"
        Me.miActualizarLectora.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarLectora.Text = "Actualizar"
        Me.miActualizarLectora.ToolTipText = "Actualizar Lectora"
        '
        'tpMonitor
        '
        Me.tpMonitor.Controls.Add(Me.UiGroupBox10)
        Me.tpMonitor.Icon = CType(resources.GetObject("tpMonitor.Icon"), System.Drawing.Icon)
        Me.tpMonitor.Location = New System.Drawing.Point(1, 43)
        Me.tpMonitor.Name = "tpMonitor"
        Me.tpMonitor.Size = New System.Drawing.Size(570, 446)
        Me.tpMonitor.TabStop = True
        Me.tpMonitor.Text = "Monitor"
        '
        'UiGroupBox10
        '
        Me.UiGroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox10.Controls.Add(Me.btnAgregarMonitor1)
        Me.UiGroupBox10.Controls.Add(Me.btnBuscarMonitor1)
        Me.UiGroupBox10.Controls.Add(Me.txtMonitor1)
        Me.UiGroupBox10.Controls.Add(Me.Label24)
        Me.UiGroupBox10.Controls.Add(Me.dgvDatosMonitor)
        Me.UiGroupBox10.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox10.Name = "UiGroupBox10"
        Me.UiGroupBox10.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox10.TabIndex = 3
        Me.UiGroupBox10.Text = "Monitor"
        Me.UiGroupBox10.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarMonitor1
        '
        Me.btnAgregarMonitor1.Image = CType(resources.GetObject("btnAgregarMonitor1.Image"), System.Drawing.Image)
        Me.btnAgregarMonitor1.Location = New System.Drawing.Point(525, 9)
        Me.btnAgregarMonitor1.Name = "btnAgregarMonitor1"
        Me.btnAgregarMonitor1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarMonitor1.TabIndex = 383
        Me.btnAgregarMonitor1.TabStop = False
        Me.btnAgregarMonitor1.Visible = False
        '
        'btnBuscarMonitor1
        '
        Me.btnBuscarMonitor1.Image = CType(resources.GetObject("btnBuscarMonitor1.Image"), System.Drawing.Image)
        Me.btnBuscarMonitor1.Location = New System.Drawing.Point(493, 8)
        Me.btnBuscarMonitor1.Name = "btnBuscarMonitor1"
        Me.btnBuscarMonitor1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarMonitor1.TabIndex = 381
        Me.btnBuscarMonitor1.TabStop = False
        Me.btnBuscarMonitor1.UseVisualStyleBackColor = True
        Me.btnBuscarMonitor1.Visible = False
        '
        'txtMonitor1
        '
        Me.txtMonitor1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtMonitor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonitor1.Location = New System.Drawing.Point(179, 10)
        Me.txtMonitor1.Name = "txtMonitor1"
        Me.txtMonitor1.ReadOnly = True
        Me.txtMonitor1.Size = New System.Drawing.Size(308, 20)
        Me.txtMonitor1.TabIndex = 380
        Me.txtMonitor1.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(131, 13)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(42, 13)
        Me.Label24.TabIndex = 382
        Me.Label24.Text = "Monitor"
        Me.Label24.Visible = False
        '
        'dgvDatosMonitor
        '
        Me.dgvDatosMonitor.ContextMenuStrip = Me.cmOpMonitor
        dgvDatosMonitor_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosMonitor_DesignTimeLayout.LayoutString")
        Me.dgvDatosMonitor.DesignTimeLayout = dgvDatosMonitor_DesignTimeLayout
        Me.dgvDatosMonitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosMonitor.GroupByBoxVisible = False
        Me.dgvDatosMonitor.Location = New System.Drawing.Point(17, 29)
        Me.dgvDatosMonitor.Name = "dgvDatosMonitor"
        Me.dgvDatosMonitor.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosMonitor.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosMonitor.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosMonitor.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosMonitor.TabIndex = 336
        Me.dgvDatosMonitor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpMonitor
        '
        Me.cmOpMonitor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoMonitor, Me.miEditarMonitor, Me.miEliminarMonitor, Me.ToolStripSeparator18, Me.ToolStripSeparator19, Me.miActualizarMonitor})
        Me.cmOpMonitor.Name = "cmOpciones"
        Me.cmOpMonitor.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoMonitor
        '
        Me.miNuevoMonitor.Image = CType(resources.GetObject("miNuevoMonitor.Image"), System.Drawing.Image)
        Me.miNuevoMonitor.Name = "miNuevoMonitor"
        Me.miNuevoMonitor.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoMonitor.Text = "Nuevo"
        Me.miNuevoMonitor.ToolTipText = "Nuevo Monitor"
        '
        'miEditarMonitor
        '
        Me.miEditarMonitor.Image = CType(resources.GetObject("miEditarMonitor.Image"), System.Drawing.Image)
        Me.miEditarMonitor.Name = "miEditarMonitor"
        Me.miEditarMonitor.Size = New System.Drawing.Size(126, 22)
        Me.miEditarMonitor.Text = "Editar"
        Me.miEditarMonitor.ToolTipText = "Editar Monitor"
        '
        'miEliminarMonitor
        '
        Me.miEliminarMonitor.Image = CType(resources.GetObject("miEliminarMonitor.Image"), System.Drawing.Image)
        Me.miEliminarMonitor.Name = "miEliminarMonitor"
        Me.miEliminarMonitor.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarMonitor.Text = "Eliminar"
        Me.miEliminarMonitor.ToolTipText = "Eliminar Monitor"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarMonitor
        '
        Me.miActualizarMonitor.Image = CType(resources.GetObject("miActualizarMonitor.Image"), System.Drawing.Image)
        Me.miActualizarMonitor.Name = "miActualizarMonitor"
        Me.miActualizarMonitor.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarMonitor.Text = "Actualizar"
        Me.miActualizarMonitor.ToolTipText = "Actualizar Monitor"
        '
        'tpCargador
        '
        Me.tpCargador.Controls.Add(Me.UiGroupBox11)
        Me.tpCargador.Icon = CType(resources.GetObject("tpCargador.Icon"), System.Drawing.Icon)
        Me.tpCargador.Location = New System.Drawing.Point(1, 43)
        Me.tpCargador.Name = "tpCargador"
        Me.tpCargador.Size = New System.Drawing.Size(570, 446)
        Me.tpCargador.TabStop = True
        Me.tpCargador.Text = "Cargador"
        '
        'UiGroupBox11
        '
        Me.UiGroupBox11.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox11.Controls.Add(Me.btnAgregarCargador1)
        Me.UiGroupBox11.Controls.Add(Me.btnBuscarCargador1)
        Me.UiGroupBox11.Controls.Add(Me.txtCargador1)
        Me.UiGroupBox11.Controls.Add(Me.Label25)
        Me.UiGroupBox11.Controls.Add(Me.dgvDatosCargador)
        Me.UiGroupBox11.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox11.Name = "UiGroupBox11"
        Me.UiGroupBox11.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox11.TabIndex = 4
        Me.UiGroupBox11.Text = "Cargador"
        Me.UiGroupBox11.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarCargador1
        '
        Me.btnAgregarCargador1.Image = CType(resources.GetObject("btnAgregarCargador1.Image"), System.Drawing.Image)
        Me.btnAgregarCargador1.Location = New System.Drawing.Point(525, 9)
        Me.btnAgregarCargador1.Name = "btnAgregarCargador1"
        Me.btnAgregarCargador1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarCargador1.TabIndex = 383
        Me.btnAgregarCargador1.TabStop = False
        Me.btnAgregarCargador1.Visible = False
        '
        'btnBuscarCargador1
        '
        Me.btnBuscarCargador1.Image = CType(resources.GetObject("btnBuscarCargador1.Image"), System.Drawing.Image)
        Me.btnBuscarCargador1.Location = New System.Drawing.Point(493, 8)
        Me.btnBuscarCargador1.Name = "btnBuscarCargador1"
        Me.btnBuscarCargador1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarCargador1.TabIndex = 381
        Me.btnBuscarCargador1.TabStop = False
        Me.btnBuscarCargador1.UseVisualStyleBackColor = True
        Me.btnBuscarCargador1.Visible = False
        '
        'txtCargador1
        '
        Me.txtCargador1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtCargador1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargador1.Location = New System.Drawing.Point(179, 10)
        Me.txtCargador1.Name = "txtCargador1"
        Me.txtCargador1.ReadOnly = True
        Me.txtCargador1.Size = New System.Drawing.Size(308, 20)
        Me.txtCargador1.TabIndex = 380
        Me.txtCargador1.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(131, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(50, 13)
        Me.Label25.TabIndex = 382
        Me.Label25.Text = "Cargador"
        Me.Label25.Visible = False
        '
        'dgvDatosCargador
        '
        Me.dgvDatosCargador.ContextMenuStrip = Me.cmOpCargador
        dgvDatosCargador_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosCargador_DesignTimeLayout.LayoutString")
        Me.dgvDatosCargador.DesignTimeLayout = dgvDatosCargador_DesignTimeLayout
        Me.dgvDatosCargador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosCargador.GroupByBoxVisible = False
        Me.dgvDatosCargador.Location = New System.Drawing.Point(17, 31)
        Me.dgvDatosCargador.Name = "dgvDatosCargador"
        Me.dgvDatosCargador.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosCargador.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosCargador.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosCargador.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosCargador.TabIndex = 336
        Me.dgvDatosCargador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpCargador
        '
        Me.cmOpCargador.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoCargador, Me.miEditarCargador, Me.miEliminarCargador, Me.ToolStripSeparator20, Me.ToolStripSeparator21, Me.miActualizarCargador})
        Me.cmOpCargador.Name = "cmOpciones"
        Me.cmOpCargador.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoCargador
        '
        Me.miNuevoCargador.Image = CType(resources.GetObject("miNuevoCargador.Image"), System.Drawing.Image)
        Me.miNuevoCargador.Name = "miNuevoCargador"
        Me.miNuevoCargador.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoCargador.Text = "Nuevo"
        Me.miNuevoCargador.ToolTipText = "Nuevo Cargador"
        '
        'miEditarCargador
        '
        Me.miEditarCargador.Image = CType(resources.GetObject("miEditarCargador.Image"), System.Drawing.Image)
        Me.miEditarCargador.Name = "miEditarCargador"
        Me.miEditarCargador.Size = New System.Drawing.Size(126, 22)
        Me.miEditarCargador.Text = "Editar"
        Me.miEditarCargador.ToolTipText = "Editar Cargador"
        '
        'miEliminarCargador
        '
        Me.miEliminarCargador.Image = CType(resources.GetObject("miEliminarCargador.Image"), System.Drawing.Image)
        Me.miEliminarCargador.Name = "miEliminarCargador"
        Me.miEliminarCargador.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarCargador.Text = "Eliminar"
        Me.miEliminarCargador.ToolTipText = "Eliminar Cargador"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarCargador
        '
        Me.miActualizarCargador.Image = CType(resources.GetObject("miActualizarCargador.Image"), System.Drawing.Image)
        Me.miActualizarCargador.Name = "miActualizarCargador"
        Me.miActualizarCargador.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarCargador.Text = "Actualizar"
        Me.miActualizarCargador.ToolTipText = "Actualizar Cargador"
        '
        'tpTeclado
        '
        Me.tpTeclado.Controls.Add(Me.UiGroupBox12)
        Me.tpTeclado.Icon = CType(resources.GetObject("tpTeclado.Icon"), System.Drawing.Icon)
        Me.tpTeclado.Location = New System.Drawing.Point(1, 43)
        Me.tpTeclado.Name = "tpTeclado"
        Me.tpTeclado.Size = New System.Drawing.Size(570, 446)
        Me.tpTeclado.TabStop = True
        Me.tpTeclado.Text = "Teclado"
        '
        'UiGroupBox12
        '
        Me.UiGroupBox12.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox12.Controls.Add(Me.btnAgregarTeclado1)
        Me.UiGroupBox12.Controls.Add(Me.btnBuscarTeclado1)
        Me.UiGroupBox12.Controls.Add(Me.txtTeclado1)
        Me.UiGroupBox12.Controls.Add(Me.Label26)
        Me.UiGroupBox12.Controls.Add(Me.dgvDatosTeclado)
        Me.UiGroupBox12.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox12.Name = "UiGroupBox12"
        Me.UiGroupBox12.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox12.TabIndex = 4
        Me.UiGroupBox12.Text = "Teclado"
        Me.UiGroupBox12.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarTeclado1
        '
        Me.btnAgregarTeclado1.Image = CType(resources.GetObject("btnAgregarTeclado1.Image"), System.Drawing.Image)
        Me.btnAgregarTeclado1.Location = New System.Drawing.Point(525, 8)
        Me.btnAgregarTeclado1.Name = "btnAgregarTeclado1"
        Me.btnAgregarTeclado1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarTeclado1.TabIndex = 383
        Me.btnAgregarTeclado1.TabStop = False
        Me.btnAgregarTeclado1.Visible = False
        '
        'btnBuscarTeclado1
        '
        Me.btnBuscarTeclado1.Image = CType(resources.GetObject("btnBuscarTeclado1.Image"), System.Drawing.Image)
        Me.btnBuscarTeclado1.Location = New System.Drawing.Point(493, 7)
        Me.btnBuscarTeclado1.Name = "btnBuscarTeclado1"
        Me.btnBuscarTeclado1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarTeclado1.TabIndex = 381
        Me.btnBuscarTeclado1.TabStop = False
        Me.btnBuscarTeclado1.UseVisualStyleBackColor = True
        Me.btnBuscarTeclado1.Visible = False
        '
        'txtTeclado1
        '
        Me.txtTeclado1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtTeclado1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeclado1.Location = New System.Drawing.Point(179, 9)
        Me.txtTeclado1.Name = "txtTeclado1"
        Me.txtTeclado1.ReadOnly = True
        Me.txtTeclado1.Size = New System.Drawing.Size(308, 20)
        Me.txtTeclado1.TabIndex = 380
        Me.txtTeclado1.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(131, 12)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(46, 13)
        Me.Label26.TabIndex = 382
        Me.Label26.Text = "Teclado"
        Me.Label26.Visible = False
        '
        'dgvDatosTeclado
        '
        Me.dgvDatosTeclado.ContextMenuStrip = Me.cmOpTeclado
        dgvDatosTeclado_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosTeclado_DesignTimeLayout.LayoutString")
        Me.dgvDatosTeclado.DesignTimeLayout = dgvDatosTeclado_DesignTimeLayout
        Me.dgvDatosTeclado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosTeclado.GroupByBoxVisible = False
        Me.dgvDatosTeclado.Location = New System.Drawing.Point(17, 30)
        Me.dgvDatosTeclado.Name = "dgvDatosTeclado"
        Me.dgvDatosTeclado.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosTeclado.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosTeclado.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosTeclado.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosTeclado.TabIndex = 336
        Me.dgvDatosTeclado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpTeclado
        '
        Me.cmOpTeclado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoTeclado, Me.miEditarTeclado, Me.miEliminarTeclado, Me.ToolStripSeparator22, Me.ToolStripSeparator23, Me.miActualizarTeclado})
        Me.cmOpTeclado.Name = "cmOpciones"
        Me.cmOpTeclado.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoTeclado
        '
        Me.miNuevoTeclado.Image = CType(resources.GetObject("miNuevoTeclado.Image"), System.Drawing.Image)
        Me.miNuevoTeclado.Name = "miNuevoTeclado"
        Me.miNuevoTeclado.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoTeclado.Text = "Nuevo"
        Me.miNuevoTeclado.ToolTipText = "Nuevo Teclado"
        '
        'miEditarTeclado
        '
        Me.miEditarTeclado.Image = CType(resources.GetObject("miEditarTeclado.Image"), System.Drawing.Image)
        Me.miEditarTeclado.Name = "miEditarTeclado"
        Me.miEditarTeclado.Size = New System.Drawing.Size(126, 22)
        Me.miEditarTeclado.Text = "Editar"
        Me.miEditarTeclado.ToolTipText = "Editar Teclado"
        '
        'miEliminarTeclado
        '
        Me.miEliminarTeclado.Image = CType(resources.GetObject("miEliminarTeclado.Image"), System.Drawing.Image)
        Me.miEliminarTeclado.Name = "miEliminarTeclado"
        Me.miEliminarTeclado.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarTeclado.Text = "Eliminar"
        Me.miEliminarTeclado.ToolTipText = "Eliminar Teclado"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarTeclado
        '
        Me.miActualizarTeclado.Image = CType(resources.GetObject("miActualizarTeclado.Image"), System.Drawing.Image)
        Me.miActualizarTeclado.Name = "miActualizarTeclado"
        Me.miActualizarTeclado.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarTeclado.Text = "Actualizar"
        Me.miActualizarTeclado.ToolTipText = "Actualizar Teclado"
        '
        'tpMouse
        '
        Me.tpMouse.Controls.Add(Me.UiGroupBox13)
        Me.tpMouse.Icon = CType(resources.GetObject("tpMouse.Icon"), System.Drawing.Icon)
        Me.tpMouse.Location = New System.Drawing.Point(1, 43)
        Me.tpMouse.Name = "tpMouse"
        Me.tpMouse.Size = New System.Drawing.Size(570, 446)
        Me.tpMouse.TabStop = True
        Me.tpMouse.Text = "Mouse"
        '
        'UiGroupBox13
        '
        Me.UiGroupBox13.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox13.Controls.Add(Me.btnAgregarMouse1)
        Me.UiGroupBox13.Controls.Add(Me.btnBuscarMouse1)
        Me.UiGroupBox13.Controls.Add(Me.txtMouse1)
        Me.UiGroupBox13.Controls.Add(Me.Label27)
        Me.UiGroupBox13.Controls.Add(Me.dgvDatosMouse)
        Me.UiGroupBox13.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox13.Name = "UiGroupBox13"
        Me.UiGroupBox13.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox13.TabIndex = 4
        Me.UiGroupBox13.Text = "Mouse"
        Me.UiGroupBox13.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarMouse1
        '
        Me.btnAgregarMouse1.Image = CType(resources.GetObject("btnAgregarMouse1.Image"), System.Drawing.Image)
        Me.btnAgregarMouse1.Location = New System.Drawing.Point(524, 8)
        Me.btnAgregarMouse1.Name = "btnAgregarMouse1"
        Me.btnAgregarMouse1.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarMouse1.TabIndex = 383
        Me.btnAgregarMouse1.TabStop = False
        Me.btnAgregarMouse1.Visible = False
        '
        'btnBuscarMouse1
        '
        Me.btnBuscarMouse1.Image = CType(resources.GetObject("btnBuscarMouse1.Image"), System.Drawing.Image)
        Me.btnBuscarMouse1.Location = New System.Drawing.Point(492, 7)
        Me.btnBuscarMouse1.Name = "btnBuscarMouse1"
        Me.btnBuscarMouse1.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarMouse1.TabIndex = 381
        Me.btnBuscarMouse1.TabStop = False
        Me.btnBuscarMouse1.UseVisualStyleBackColor = True
        Me.btnBuscarMouse1.Visible = False
        '
        'txtMouse1
        '
        Me.txtMouse1.BackColor = System.Drawing.Color.PowderBlue
        Me.txtMouse1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMouse1.Location = New System.Drawing.Point(178, 9)
        Me.txtMouse1.Name = "txtMouse1"
        Me.txtMouse1.ReadOnly = True
        Me.txtMouse1.Size = New System.Drawing.Size(308, 20)
        Me.txtMouse1.TabIndex = 380
        Me.txtMouse1.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(130, 12)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 382
        Me.Label27.Text = "Mouse"
        Me.Label27.Visible = False
        '
        'dgvDatosMouse
        '
        Me.dgvDatosMouse.ContextMenuStrip = Me.cmOpMouse
        dgvDatosMouse_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosMouse_DesignTimeLayout.LayoutString")
        Me.dgvDatosMouse.DesignTimeLayout = dgvDatosMouse_DesignTimeLayout
        Me.dgvDatosMouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosMouse.GroupByBoxVisible = False
        Me.dgvDatosMouse.Location = New System.Drawing.Point(17, 29)
        Me.dgvDatosMouse.Name = "dgvDatosMouse"
        Me.dgvDatosMouse.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosMouse.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosMouse.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosMouse.Size = New System.Drawing.Size(518, 376)
        Me.dgvDatosMouse.TabIndex = 336
        Me.dgvDatosMouse.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpMouse
        '
        Me.cmOpMouse.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoMouse, Me.miEditarMouse, Me.miEliminarMouse, Me.ToolStripSeparator24, Me.ToolStripSeparator25, Me.miActualizarMouse})
        Me.cmOpMouse.Name = "cmOpciones"
        Me.cmOpMouse.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoMouse
        '
        Me.miNuevoMouse.Image = CType(resources.GetObject("miNuevoMouse.Image"), System.Drawing.Image)
        Me.miNuevoMouse.Name = "miNuevoMouse"
        Me.miNuevoMouse.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoMouse.Text = "Nuevo"
        Me.miNuevoMouse.ToolTipText = "Nuevo Mouse"
        '
        'miEditarMouse
        '
        Me.miEditarMouse.Image = CType(resources.GetObject("miEditarMouse.Image"), System.Drawing.Image)
        Me.miEditarMouse.Name = "miEditarMouse"
        Me.miEditarMouse.Size = New System.Drawing.Size(126, 22)
        Me.miEditarMouse.Text = "Editar"
        Me.miEditarMouse.ToolTipText = "Editar Mouse"
        '
        'miEliminarMouse
        '
        Me.miEliminarMouse.Image = CType(resources.GetObject("miEliminarMouse.Image"), System.Drawing.Image)
        Me.miEliminarMouse.Name = "miEliminarMouse"
        Me.miEliminarMouse.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarMouse.Text = "Eliminar"
        Me.miEliminarMouse.ToolTipText = "Eliminar Mouse"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarMouse
        '
        Me.miActualizarMouse.Image = CType(resources.GetObject("miActualizarMouse.Image"), System.Drawing.Image)
        Me.miActualizarMouse.Name = "miActualizarMouse"
        Me.miActualizarMouse.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarMouse.Text = "Actualizar"
        Me.miActualizarMouse.ToolTipText = "Actualizar Mouse"
        '
        'tpSoftware
        '
        Me.tpSoftware.Controls.Add(Me.UiGroupBox2)
        Me.tpSoftware.Icon = CType(resources.GetObject("tpSoftware.Icon"), System.Drawing.Icon)
        Me.tpSoftware.Location = New System.Drawing.Point(1, 43)
        Me.tpSoftware.Name = "tpSoftware"
        Me.tpSoftware.Size = New System.Drawing.Size(570, 446)
        Me.tpSoftware.TabStop = True
        Me.tpSoftware.Text = "Software"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.btnAgregarSoftware2)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarSoftware2)
        Me.UiGroupBox2.Controls.Add(Me.txtSoftware2)
        Me.UiGroupBox2.Controls.Add(Me.Label38)
        Me.UiGroupBox2.Controls.Add(Me.dgvDatosSoftware)
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 10)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(552, 424)
        Me.UiGroupBox2.TabIndex = 0
        Me.UiGroupBox2.Text = "Software"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarSoftware2
        '
        Me.btnAgregarSoftware2.Image = CType(resources.GetObject("btnAgregarSoftware2.Image"), System.Drawing.Image)
        Me.btnAgregarSoftware2.Location = New System.Drawing.Point(465, 30)
        Me.btnAgregarSoftware2.Name = "btnAgregarSoftware2"
        Me.btnAgregarSoftware2.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarSoftware2.TabIndex = 383
        Me.btnAgregarSoftware2.TabStop = False
        '
        'btnBuscarSoftware2
        '
        Me.btnBuscarSoftware2.Image = CType(resources.GetObject("btnBuscarSoftware2.Image"), System.Drawing.Image)
        Me.btnBuscarSoftware2.Location = New System.Drawing.Point(433, 30)
        Me.btnBuscarSoftware2.Name = "btnBuscarSoftware2"
        Me.btnBuscarSoftware2.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarSoftware2.TabIndex = 381
        Me.btnBuscarSoftware2.TabStop = False
        Me.btnBuscarSoftware2.UseVisualStyleBackColor = True
        '
        'txtSoftware2
        '
        Me.txtSoftware2.BackColor = System.Drawing.Color.PowderBlue
        Me.txtSoftware2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoftware2.Location = New System.Drawing.Point(119, 32)
        Me.txtSoftware2.Name = "txtSoftware2"
        Me.txtSoftware2.ReadOnly = True
        Me.txtSoftware2.Size = New System.Drawing.Size(308, 20)
        Me.txtSoftware2.TabIndex = 380
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(64, 35)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(49, 13)
        Me.Label38.TabIndex = 382
        Me.Label38.Text = "Software"
        '
        'dgvDatosSoftware
        '
        Me.dgvDatosSoftware.ContextMenuStrip = Me.cmOpSoftware
        dgvDatosSoftware_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosSoftware_DesignTimeLayout.LayoutString")
        Me.dgvDatosSoftware.DesignTimeLayout = dgvDatosSoftware_DesignTimeLayout
        Me.dgvDatosSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosSoftware.GroupByBoxVisible = False
        Me.dgvDatosSoftware.Location = New System.Drawing.Point(17, 66)
        Me.dgvDatosSoftware.Name = "dgvDatosSoftware"
        Me.dgvDatosSoftware.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosSoftware.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosSoftware.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosSoftware.Size = New System.Drawing.Size(518, 341)
        Me.dgvDatosSoftware.TabIndex = 336
        Me.dgvDatosSoftware.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpSoftware
        '
        Me.cmOpSoftware.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoSoftware, Me.miEditarSoftware, Me.miEliminarSoftware, Me.ToolStripSeparator26, Me.ToolStripSeparator27, Me.miActualizarSoftware})
        Me.cmOpSoftware.Name = "cmOpciones"
        Me.cmOpSoftware.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoSoftware
        '
        Me.miNuevoSoftware.Image = CType(resources.GetObject("miNuevoSoftware.Image"), System.Drawing.Image)
        Me.miNuevoSoftware.Name = "miNuevoSoftware"
        Me.miNuevoSoftware.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoSoftware.Text = "Nuevo"
        Me.miNuevoSoftware.ToolTipText = "Nuevo Software"
        '
        'miEditarSoftware
        '
        Me.miEditarSoftware.Image = CType(resources.GetObject("miEditarSoftware.Image"), System.Drawing.Image)
        Me.miEditarSoftware.Name = "miEditarSoftware"
        Me.miEditarSoftware.Size = New System.Drawing.Size(126, 22)
        Me.miEditarSoftware.Text = "Editar"
        Me.miEditarSoftware.ToolTipText = "Editar Software"
        '
        'miEliminarSoftware
        '
        Me.miEliminarSoftware.Image = CType(resources.GetObject("miEliminarSoftware.Image"), System.Drawing.Image)
        Me.miEliminarSoftware.Name = "miEliminarSoftware"
        Me.miEliminarSoftware.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarSoftware.Text = "Eliminar"
        Me.miEliminarSoftware.ToolTipText = "Eliminar Software"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarSoftware
        '
        Me.miActualizarSoftware.Image = CType(resources.GetObject("miActualizarSoftware.Image"), System.Drawing.Image)
        Me.miActualizarSoftware.Name = "miActualizarSoftware"
        Me.miActualizarSoftware.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarSoftware.Text = "Actualizar"
        Me.miActualizarSoftware.ToolTipText = "Actualizar Software"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 61)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(526, 415)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 699)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(598, 22)
        Me.StatusStrip1.TabIndex = 191
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmComputadora
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(598, 721)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabPestañas)
        Me.Controls.Add(Me.gbDatosComputadora)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(606, 755)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(606, 755)
        Me.Name = "frmComputadora"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Computadora"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosComputadora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosComputadora.ResumeLayout(False)
        Me.gbDatosComputadora.PerformLayout()
        CType(Me.cmbTipoComputadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbFam1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFam1.ResumeLayout(False)
        Me.gbFam1.PerformLayout()
        CType(Me.gbEstudios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstudios.ResumeLayout(False)
        Me.gbEstudios.PerformLayout()
        CType(Me.dgvSoftwares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCapacitacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCapacitacion.ResumeLayout(False)
        Me.gbCapacitacion.PerformLayout()
        CType(Me.cmbMonCapac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCapacitaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabPestañas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPestañas.ResumeLayout(False)
        Me.tpCapacitaciones.ResumeLayout(False)
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.MultiColumnCombo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MultiColumnCombo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpProcesador.ResumeLayout(False)
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.dgvDatosProcesador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpProcesador.ResumeLayout(False)
        Me.tpPlacaMadre.ResumeLayout(False)
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        CType(Me.dgvDatosPlacaMadre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpPlacaMadre.ResumeLayout(False)
        Me.tpMemoriaRam.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDatosMemoriaRam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpMemoriaRam.ResumeLayout(False)
        Me.tpTarjetaVideo.ResumeLayout(False)
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox7.ResumeLayout(False)
        Me.UiGroupBox7.PerformLayout()
        CType(Me.dgvDatosTarjetaVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpTarjetaVideo.ResumeLayout(False)
        Me.tpDiscoDuro.ResumeLayout(False)
        CType(Me.UiGroupBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox8.ResumeLayout(False)
        Me.UiGroupBox8.PerformLayout()
        CType(Me.dgvDatosDiscoDuro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpDiscoDuro.ResumeLayout(False)
        Me.tpLectora.ResumeLayout(False)
        CType(Me.UiGroupBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox9.ResumeLayout(False)
        Me.UiGroupBox9.PerformLayout()
        CType(Me.dgvDatosLectora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpLectora.ResumeLayout(False)
        Me.tpMonitor.ResumeLayout(False)
        CType(Me.UiGroupBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox10.ResumeLayout(False)
        Me.UiGroupBox10.PerformLayout()
        CType(Me.dgvDatosMonitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpMonitor.ResumeLayout(False)
        Me.tpCargador.ResumeLayout(False)
        CType(Me.UiGroupBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox11.ResumeLayout(False)
        Me.UiGroupBox11.PerformLayout()
        CType(Me.dgvDatosCargador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpCargador.ResumeLayout(False)
        Me.tpTeclado.ResumeLayout(False)
        CType(Me.UiGroupBox12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox12.ResumeLayout(False)
        Me.UiGroupBox12.PerformLayout()
        CType(Me.dgvDatosTeclado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpTeclado.ResumeLayout(False)
        Me.tpMouse.ResumeLayout(False)
        CType(Me.UiGroupBox13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox13.ResumeLayout(False)
        Me.UiGroupBox13.PerformLayout()
        CType(Me.dgvDatosMouse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpMouse.ResumeLayout(False)
        Me.tpSoftware.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.dgvDatosSoftware, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpSoftware.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biGuardarComputadora As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents biDeshacerComputadora As ToolStripButton
    Friend WithEvents biEditarComputadora As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents biCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosComputadora As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtComputadora As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents cbVigente As CheckBox
    Friend WithEvents txtIdComputadora As TextBox
    Friend WithEvents lblIdPer As Label
    Friend WithEvents lblComputadora As Label
    Friend WithEvents cmbTipoComputadora As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents biDeshacerHardware As Button
    Friend WithEvents biGrabaHardware As Button
    Friend WithEvents gbFam1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbVigenteH As CheckBox
    Friend WithEvents btnLimpiarMonitor As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarCargador As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarLectora As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarDiscoDuro As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarTarjetaVideo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarMemRam As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarPlacaMadre As Janus.Windows.EditControls.UIButton
    Friend WithEvents biLimpiarProcesador As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarPlacaMadre As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarMemRam As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarTarjetaVideo As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarDiscoDuro As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarLectora As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarCargador As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarMonitor As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAgregarProcesador As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtNotaHardware As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtMotivoFinUso As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtFecFinUso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecIniUso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtMouse As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtTeclado As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents btnBuscarMonitor As Button
    Friend WithEvents txtMonitor As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnBuscarCargador As Button
    Friend WithEvents txtCargador As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents btnBuscarLectora As Button
    Friend WithEvents txtLectora As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnBuscarDiscoDuro As Button
    Friend WithEvents txtDiscoDuro As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnBuscarTarjetaVideo As Button
    Friend WithEvents txtTarjetaVideo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnBuscarMemoriaRam As Button
    Friend WithEvents txtMemoriaRam As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnBuscarPlacaMadre As Button
    Friend WithEvents txtPlacaMadre As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnBuscarProcesador As Button
    Friend WithEvents txtProcesador As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents gbEstudios As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarSoftware As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarSoftware As Button
    Friend WithEvents txtSoftware As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dgvSoftwares As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbCapacitacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbMonCapac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDuracionCapac As TextBox
    Friend WithEvents cbEvaluadoCapac As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblDuracionCapac As Label
    Friend WithEvents txtMesesEvaluarCapac As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFecEvaluacionCapac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As Label
    Friend WithEvents biDeshacerCapac As Button
    Friend WithEvents biGrabarCapac As Button
    Friend WithEvents txtObsCapacitacion As TextBox
    Friend WithEvents txtCostoCapac As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblObsvCapac As Label
    Friend WithEvents lblCostoCapac As Label
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblProveedorCapac As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents btnBuscarProveedor As Button
    Friend WithEvents cbProgramadoCapac As CheckBox
    Friend WithEvents txtFecInicioCapac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblFecInicioCapac As Label
    Friend WithEvents txtFecFinalCapac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblFecFinalCapac As Label
    Friend WithEvents lblCursoCapac As Label
    Friend WithEvents txtCursoCapac As TextBox
    Friend WithEvents cmbTipoCapac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblTipoCapac As Label
    Friend WithEvents dgvCapacitaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents tpSoftware As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarSoftware2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarSoftware2 As Button
    Friend WithEvents txtSoftware2 As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents dgvDatosSoftware As Janus.Windows.GridEX.GridEX
    Friend WithEvents tpCapacitaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents MultiColumnCombo1 As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label39 As Label
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents IntegerUpDown1 As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label42 As Label
    Friend WithEvents CalendarCombo3 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label43 As Label
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents NumericEditBox1 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents UiButton18 As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label46 As Label
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents Button14 As Button
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CalendarCombo4 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label47 As Label
    Friend WithEvents CalendarCombo5 As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents MultiColumnCombo2 As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label50 As Label
    Friend WithEvents GridEX2 As Janus.Windows.GridEX.GridEX
    Friend WithEvents tpProcesador As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpPlacaMadre As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpMemoriaRam As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpTarjetaVideo As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpDiscoDuro As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpLectora As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpMonitor As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpCargador As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpTeclado As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents TabPestañas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tpMouse As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarProcesador1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarProcesador1 As Button
    Friend WithEvents txtProcesador1 As TextBox
    Friend WithEvents dgvDatosProcesador As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label9 As Label
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarPlacaMadre1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarPlacaMadre1 As Button
    Friend WithEvents txtPlacaMadre1 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dgvDatosPlacaMadre As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarMemoriaram1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarMemoriaram1 As Button
    Friend WithEvents txtMemoriaram1 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents dgvDatosMemoriaRam As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox7 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarTarjetaVideo1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarTarjetaVideo1 As Button
    Friend WithEvents txtTarjetaVideo1 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents dgvDatosTarjetaVideo As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox8 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarDiscoDuro1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarDiscoDuro1 As Button
    Friend WithEvents txtDiscoDuro1 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents dgvDatosDiscoDuro As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox9 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarLectora1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarLectora1 As Button
    Friend WithEvents txtLectora1 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents dgvDatosLectora As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox10 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarMonitor1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarMonitor1 As Button
    Friend WithEvents txtMonitor1 As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents dgvDatosMonitor As Janus.Windows.GridEX.GridEX
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents UiGroupBox11 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarCargador1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarCargador1 As Button
    Friend WithEvents txtCargador1 As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents dgvDatosCargador As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox12 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarTeclado1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarTeclado1 As Button
    Friend WithEvents txtTeclado1 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents dgvDatosTeclado As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox13 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAgregarMouse1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarMouse1 As Button
    Friend WithEvents txtMouse1 As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents dgvDatosMouse As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpProcesador As ContextMenuStrip
    Friend WithEvents miNuevoProc As ToolStripMenuItem
    Friend WithEvents miEditProc As ToolStripMenuItem
    Friend WithEvents miElimProc As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents miActProc As ToolStripMenuItem
    Friend WithEvents cmOpPlacaMadre As ContextMenuStrip
    Friend WithEvents miNuevoPlaca As ToolStripMenuItem
    Friend WithEvents miEditarPlaca As ToolStripMenuItem
    Friend WithEvents miEliminarPlaca As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents miActualizarPlaca As ToolStripMenuItem
    Friend WithEvents cmOpMemoriaRam As ContextMenuStrip
    Friend WithEvents miNuevoMem As ToolStripMenuItem
    Friend WithEvents miEditarMem As ToolStripMenuItem
    Friend WithEvents miEliminarMem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents miActualizarMem As ToolStripMenuItem
    Friend WithEvents cmOpTarjetaVideo As ContextMenuStrip
    Friend WithEvents miNuevoTarj As ToolStripMenuItem
    Friend WithEvents miEditarTarj As ToolStripMenuItem
    Friend WithEvents miEliminarTarj As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents miActualizarTarj As ToolStripMenuItem
    Friend WithEvents cmOpDiscoDuro As ContextMenuStrip
    Friend WithEvents miNuevoDisco As ToolStripMenuItem
    Friend WithEvents miEditarDisco As ToolStripMenuItem
    Friend WithEvents miEliminarDisco As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents miActualizarDisco As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmOpLectora As ContextMenuStrip
    Friend WithEvents miNuevaLectora As ToolStripMenuItem
    Friend WithEvents miEditarLectora As ToolStripMenuItem
    Friend WithEvents miEliminarLectora As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator17 As ToolStripSeparator
    Friend WithEvents miActualizarLectora As ToolStripMenuItem
    Friend WithEvents cmOpMonitor As ContextMenuStrip
    Friend WithEvents miNuevoMonitor As ToolStripMenuItem
    Friend WithEvents miEditarMonitor As ToolStripMenuItem
    Friend WithEvents miEliminarMonitor As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator19 As ToolStripSeparator
    Friend WithEvents miActualizarMonitor As ToolStripMenuItem
    Friend WithEvents cmOpCargador As ContextMenuStrip
    Friend WithEvents miNuevoCargador As ToolStripMenuItem
    Friend WithEvents miEditarCargador As ToolStripMenuItem
    Friend WithEvents miEliminarCargador As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator21 As ToolStripSeparator
    Friend WithEvents miActualizarCargador As ToolStripMenuItem
    Friend WithEvents cmOpTeclado As ContextMenuStrip
    Friend WithEvents miNuevoTeclado As ToolStripMenuItem
    Friend WithEvents miEditarTeclado As ToolStripMenuItem
    Friend WithEvents miEliminarTeclado As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator23 As ToolStripSeparator
    Friend WithEvents miActualizarTeclado As ToolStripMenuItem
    Friend WithEvents cmOpMouse As ContextMenuStrip
    Friend WithEvents miNuevoMouse As ToolStripMenuItem
    Friend WithEvents miEditarMouse As ToolStripMenuItem
    Friend WithEvents miEliminarMouse As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator24 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator25 As ToolStripSeparator
    Friend WithEvents miActualizarMouse As ToolStripMenuItem
    Friend WithEvents cmOpSoftware As ContextMenuStrip
    Friend WithEvents miNuevoSoftware As ToolStripMenuItem
    Friend WithEvents miEditarSoftware As ToolStripMenuItem
    Friend WithEvents miEliminarSoftware As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator26 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator27 As ToolStripSeparator
    Friend WithEvents miActualizarSoftware As ToolStripMenuItem
    Friend WithEvents txtObservacionCom As TextBox
    Friend WithEvents Label32 As Label
End Class
