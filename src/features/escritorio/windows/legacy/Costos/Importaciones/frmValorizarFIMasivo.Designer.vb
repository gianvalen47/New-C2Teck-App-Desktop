<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValorizarFIMasivo
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
        Dim cbEstados_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValorizarFIMasivo))
        Dim cmbVia_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbEstados = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.dtFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbVia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdImportacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdSerieDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesAlm1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdProveedor1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMon1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipCam1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotFobGen1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotFobGenSol1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNeto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNetoSol1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEstado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.dgvFacturas = New System.Windows.Forms.DataGridView()
        Me.cIdImportacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdSerieDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesAlm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipCam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotFobGen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotFobGenSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNetoSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtNumRegistro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAduana = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTransporte = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.btnBuscarPais = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtPtoEmb = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtPoliza = New System.Windows.Forms.TextBox()
        Me.txtIgvAdu = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.txtServicio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cbApliSeguro = New System.Windows.Forms.CheckBox()
        Me.txtSeguro = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotOtrosGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotFleteSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtResguardo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtOtroGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtHandling = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTranspLocal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtGastoAgencia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTerminal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtCarga = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtTipCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cbEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbVia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.txtCodEmbarque)
        Me.gbDatosBusqueda.Controls.Add(Me.Label14)
        Me.gbDatosBusqueda.Controls.Add(Me.Label12)
        Me.gbDatosBusqueda.Controls.Add(Me.cbEstados)
        Me.gbDatosBusqueda.Controls.Add(Me.dtFinal)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.Label10)
        Me.gbDatosBusqueda.Controls.Add(Me.dtInicio)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Controls.Add(Me.Label6)
        Me.gbDatosBusqueda.Controls.Add(Me.txtNumero)
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(7, 5)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(721, 56)
        Me.gbDatosBusqueda.TabIndex = 0
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmbarque.Location = New System.Drawing.Point(382, 31)
        Me.txtCodEmbarque.MaxLength = 30
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(94, 20)
        Me.txtCodEmbarque.TabIndex = 20
        Me.txtCodEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(384, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Cod Embarque"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(283, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Estado"
        '
        'cbEstados
        '
        Me.cbEstados.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbEstados_DesignTimeLayout.LayoutString = resources.GetString("cbEstados_DesignTimeLayout.LayoutString")
        Me.cbEstados.DesignTimeLayout = cbEstados_DesignTimeLayout
        Me.cbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEstados.Location = New System.Drawing.Point(267, 31)
        Me.cbEstados.Name = "cbEstados"
        Me.cbEstados.SelectedIndex = -1
        Me.cbEstados.SelectedItem = Nothing
        Me.cbEstados.Size = New System.Drawing.Size(87, 20)
        Me.cbEstados.TabIndex = 19
        Me.cbEstados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dtFinal
        '
        '
        '
        '
        Me.dtFinal.DropDownCalendar.Name = ""
        Me.dtFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.dtFinal.Location = New System.Drawing.Point(146, 31)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.NullButtonText = "Ninguno"
        Me.dtFinal.Size = New System.Drawing.Size(92, 20)
        Me.dtFinal.TabIndex = 18
        Me.dtFinal.TodayButtonText = "Hoy"
        Me.dtFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Fecha Final"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Fecha Inicio"
        '
        'dtInicio
        '
        '
        '
        '
        Me.dtInicio.DropDownCalendar.Name = ""
        Me.dtInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.dtInicio.Location = New System.Drawing.Point(26, 31)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.NullButtonText = "Ninguno"
        Me.dtInicio.Size = New System.Drawing.Size(92, 20)
        Me.dtInicio.TabIndex = 16
        Me.dtInicio.TodayButtonText = "Hoy"
        Me.dtInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(634, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 22)
        Me.btnBuscar.TabIndex = 22
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(529, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Numero"
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(503, 32)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(106, 20)
        Me.txtNumero.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(591, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Vía"
        '
        'cmbVia
        '
        Me.cmbVia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbVia_DesignTimeLayout.LayoutString = resources.GetString("cmbVia_DesignTimeLayout.LayoutString")
        Me.cmbVia.DesignTimeLayout = cmbVia_DesignTimeLayout
        Me.cmbVia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVia.Location = New System.Drawing.Point(617, 43)
        Me.cmbVia.Name = "cmbVia"
        Me.cmbVia.SelectedIndex = -1
        Me.cmbVia.SelectedItem = Nothing
        Me.cmbVia.Size = New System.Drawing.Size(91, 20)
        Me.cmbVia.TabIndex = 7
        Me.cmbVia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(346, 176)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 30
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(346, 135)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregar.TabIndex = 29
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(405, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Seleccionados"
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdImportacion1, Me.cIdSerieDoc1, Me.cIdLocacion1, Me.cNumDoc1, Me.cDesAlm1, Me.cFecDoc1, Me.cIdProveedor1, Me.cDesProv1, Me.cCodMon1, Me.cDesMon1, Me.cTipCam1, Me.cObservacion1, Me.cTotFobGen1, Me.cTotFobGenSol1, Me.cTotalNeto1, Me.cTotalNetoSol1, Me.cEstado1})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(408, 82)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(320, 178)
        Me.dgvSeleccionados.TabIndex = 27
        '
        'cIdImportacion1
        '
        Me.cIdImportacion1.HeaderText = "IdImportacion"
        Me.cIdImportacion1.Name = "cIdImportacion1"
        Me.cIdImportacion1.Visible = False
        '
        'cIdSerieDoc1
        '
        Me.cIdSerieDoc1.HeaderText = "IdSerieDoc"
        Me.cIdSerieDoc1.Name = "cIdSerieDoc1"
        Me.cIdSerieDoc1.Visible = False
        '
        'cIdLocacion1
        '
        Me.cIdLocacion1.HeaderText = "IdLocacion"
        Me.cIdLocacion1.Name = "cIdLocacion1"
        Me.cIdLocacion1.Visible = False
        '
        'cNumDoc1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNumDoc1.DefaultCellStyle = DataGridViewCellStyle3
        Me.cNumDoc1.HeaderText = "Número"
        Me.cNumDoc1.Name = "cNumDoc1"
        Me.cNumDoc1.ReadOnly = True
        Me.cNumDoc1.Width = 130
        '
        'cDesAlm1
        '
        Me.cDesAlm1.HeaderText = "Almacén"
        Me.cDesAlm1.Name = "cDesAlm1"
        Me.cDesAlm1.ReadOnly = True
        Me.cDesAlm1.Width = 170
        '
        'cFecDoc1
        '
        Me.cFecDoc1.HeaderText = "FecDoc"
        Me.cFecDoc1.Name = "cFecDoc1"
        Me.cFecDoc1.Visible = False
        '
        'cIdProveedor1
        '
        Me.cIdProveedor1.HeaderText = "IdProveedor"
        Me.cIdProveedor1.Name = "cIdProveedor1"
        Me.cIdProveedor1.Visible = False
        '
        'cDesProv1
        '
        Me.cDesProv1.HeaderText = "DesProv"
        Me.cDesProv1.Name = "cDesProv1"
        Me.cDesProv1.Visible = False
        '
        'cCodMon1
        '
        Me.cCodMon1.HeaderText = "CodMon"
        Me.cCodMon1.Name = "cCodMon1"
        Me.cCodMon1.Visible = False
        '
        'cDesMon1
        '
        Me.cDesMon1.HeaderText = "DesMon"
        Me.cDesMon1.Name = "cDesMon1"
        Me.cDesMon1.Visible = False
        '
        'cTipCam1
        '
        Me.cTipCam1.HeaderText = "TipCam"
        Me.cTipCam1.Name = "cTipCam1"
        Me.cTipCam1.Visible = False
        '
        'cObservacion1
        '
        Me.cObservacion1.HeaderText = "Observacion"
        Me.cObservacion1.Name = "cObservacion1"
        Me.cObservacion1.Visible = False
        '
        'cTotFobGen1
        '
        Me.cTotFobGen1.HeaderText = "TotFobGen"
        Me.cTotFobGen1.Name = "cTotFobGen1"
        Me.cTotFobGen1.Visible = False
        '
        'cTotFobGenSol1
        '
        Me.cTotFobGenSol1.HeaderText = "TotFobGenSol"
        Me.cTotFobGenSol1.Name = "cTotFobGenSol1"
        Me.cTotFobGenSol1.Visible = False
        '
        'cTotalNeto1
        '
        Me.cTotalNeto1.HeaderText = "TotalNeto"
        Me.cTotalNeto1.Name = "cTotalNeto1"
        Me.cTotalNeto1.Visible = False
        '
        'cTotalNetoSol1
        '
        Me.cTotalNetoSol1.HeaderText = "TotalNetoSol"
        Me.cTotalNetoSol1.Name = "cTotalNetoSol1"
        Me.cTotalNetoSol1.Visible = False
        '
        'cEstado1
        '
        Me.cEstado1.HeaderText = "Estado"
        Me.cEstado1.Name = "cEstado1"
        Me.cEstado1.Visible = False
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEliminar})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(118, 26)
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(117, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(4, 64)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(62, 15)
        Me.lblPersonal.TabIndex = 26
        Me.lblPersonal.Text = "Facturas"
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowUserToAddRows = False
        Me.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdImportacion, Me.cIdSerieDoc, Me.cIdLocacion, Me.cNumDoc, Me.cDesAlm, Me.cFecDoc, Me.cIdProveedor, Me.cDesProv, Me.cCodMon, Me.cDesMon, Me.cTipCam, Me.cObservacion, Me.cTotFobGen, Me.cTotFobGenSol, Me.cTotalNeto, Me.cTotalNetoSol, Me.cEstado})
        Me.dgvFacturas.Location = New System.Drawing.Point(7, 82)
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.RowHeadersVisible = False
        Me.dgvFacturas.Size = New System.Drawing.Size(320, 178)
        Me.dgvFacturas.TabIndex = 25
        '
        'cIdImportacion
        '
        Me.cIdImportacion.HeaderText = "IdImportacion"
        Me.cIdImportacion.Name = "cIdImportacion"
        Me.cIdImportacion.Visible = False
        '
        'cIdSerieDoc
        '
        Me.cIdSerieDoc.HeaderText = "IdSerieDoc"
        Me.cIdSerieDoc.Name = "cIdSerieDoc"
        Me.cIdSerieDoc.Visible = False
        '
        'cIdLocacion
        '
        Me.cIdLocacion.HeaderText = "IdLocacion"
        Me.cIdLocacion.Name = "cIdLocacion"
        Me.cIdLocacion.Visible = False
        '
        'cNumDoc
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNumDoc.DefaultCellStyle = DataGridViewCellStyle4
        Me.cNumDoc.HeaderText = "Número"
        Me.cNumDoc.Name = "cNumDoc"
        Me.cNumDoc.ReadOnly = True
        Me.cNumDoc.Width = 130
        '
        'cDesAlm
        '
        Me.cDesAlm.HeaderText = "Almacén"
        Me.cDesAlm.Name = "cDesAlm"
        Me.cDesAlm.ReadOnly = True
        Me.cDesAlm.Width = 170
        '
        'cFecDoc
        '
        Me.cFecDoc.HeaderText = "FecDoc"
        Me.cFecDoc.Name = "cFecDoc"
        Me.cFecDoc.Visible = False
        '
        'cIdProveedor
        '
        Me.cIdProveedor.HeaderText = "IdProveedor"
        Me.cIdProveedor.Name = "cIdProveedor"
        Me.cIdProveedor.Visible = False
        '
        'cDesProv
        '
        Me.cDesProv.HeaderText = "DesProv"
        Me.cDesProv.Name = "cDesProv"
        Me.cDesProv.Visible = False
        '
        'cCodMon
        '
        Me.cCodMon.HeaderText = "CodMon"
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.Visible = False
        '
        'cDesMon
        '
        Me.cDesMon.HeaderText = "DesMon"
        Me.cDesMon.Name = "cDesMon"
        Me.cDesMon.Visible = False
        '
        'cTipCam
        '
        Me.cTipCam.HeaderText = "TipCam"
        Me.cTipCam.Name = "cTipCam"
        Me.cTipCam.Visible = False
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observacion"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.Visible = False
        '
        'cTotFobGen
        '
        Me.cTotFobGen.HeaderText = "TotFobGen"
        Me.cTotFobGen.Name = "cTotFobGen"
        Me.cTotFobGen.Visible = False
        '
        'cTotFobGenSol
        '
        Me.cTotFobGenSol.HeaderText = "TotFobGenSol"
        Me.cTotFobGenSol.Name = "cTotFobGenSol"
        Me.cTotFobGenSol.Visible = False
        '
        'cTotalNeto
        '
        Me.cTotalNeto.HeaderText = "TotalNeto"
        Me.cTotalNeto.Name = "cTotalNeto"
        Me.cTotalNeto.Visible = False
        '
        'cTotalNetoSol
        '
        Me.cTotalNetoSol.HeaderText = "TotalNetoSol"
        Me.cTotalNetoSol.Name = "cTotalNetoSol"
        Me.cTotalNetoSol.Visible = False
        '
        'cEstado
        '
        Me.cEstado.HeaderText = "Estado"
        Me.cEstado.Name = "cEstado"
        Me.cEstado.Visible = False
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(370, 475)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(287, 475)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 25
        Me.btnAceptar.Text = "Valorizar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtNumRegistro
        '
        Me.txtNumRegistro.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRegistro.Location = New System.Drawing.Point(70, 19)
        Me.txtNumRegistro.Name = "txtNumRegistro"
        Me.txtNumRegistro.Size = New System.Drawing.Size(91, 20)
        Me.txtNumRegistro.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Nro Ingreso"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(171, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Agencia Aduana"
        '
        'txtAduana
        '
        Me.txtAduana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAduana.Location = New System.Drawing.Point(260, 19)
        Me.txtAduana.Name = "txtAduana"
        Me.txtAduana.ReadOnly = True
        Me.txtAduana.Size = New System.Drawing.Size(157, 20)
        Me.txtAduana.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(445, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Agencia Transp."
        '
        'txtTransporte
        '
        Me.txtTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransporte.Location = New System.Drawing.Point(531, 19)
        Me.txtTransporte.Name = "txtTransporte"
        Me.txtTransporte.Size = New System.Drawing.Size(177, 20)
        Me.txtTransporte.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Pais Origen"
        '
        'txtOrigen
        '
        Me.txtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrigen.Location = New System.Drawing.Point(69, 43)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(175, 20)
        Me.txtOrigen.TabIndex = 4
        '
        'btnBuscarPais
        '
        Me.btnBuscarPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPais.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPais.Location = New System.Drawing.Point(245, 42)
        Me.btnBuscarPais.Name = "btnBuscarPais"
        Me.btnBuscarPais.Size = New System.Drawing.Size(27, 22)
        Me.btnBuscarPais.TabIndex = 5
        Me.btnBuscarPais.TabStop = False
        Me.btnBuscarPais.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(325, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Fact. Aduana"
        '
        'txtFactura
        '
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(402, 43)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(129, 20)
        Me.txtFactura.TabIndex = 6
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(6, 70)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(77, 13)
        Me.Label44.TabIndex = 82
        Me.Label44.Text = "Pto. Embarque"
        '
        'txtPtoEmb
        '
        Me.txtPtoEmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPtoEmb.Location = New System.Drawing.Point(85, 67)
        Me.txtPtoEmb.Name = "txtPtoEmb"
        Me.txtPtoEmb.Size = New System.Drawing.Size(180, 20)
        Me.txtPtoEmb.TabIndex = 8
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(525, 70)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 13)
        Me.Label24.TabIndex = 88
        Me.Label24.Text = "Poliza"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(171, 95)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 13)
        Me.Label28.TabIndex = 91
        Me.Label28.Text = "I.G.V. AD. S/."
        '
        'txtPoliza
        '
        Me.txtPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPoliza.Location = New System.Drawing.Point(562, 67)
        Me.txtPoliza.Name = "txtPoliza"
        Me.txtPoliza.Size = New System.Drawing.Size(146, 20)
        Me.txtPoliza.TabIndex = 10
        '
        'txtIgvAdu
        '
        Me.txtIgvAdu.DecimalDigits = 4
        Me.txtIgvAdu.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIgvAdu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIgvAdu.Location = New System.Drawing.Point(250, 91)
        Me.txtIgvAdu.Name = "txtIgvAdu"
        Me.txtIgvAdu.Size = New System.Drawing.Size(91, 20)
        Me.txtIgvAdu.TabIndex = 12
        Me.txtIgvAdu.Text = "0.0000"
        Me.txtIgvAdu.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(326, 70)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(31, 13)
        Me.Label25.TabIndex = 100
        Me.Label25.Text = "Guía"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(369, 95)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(68, 13)
        Me.Label30.TabIndex = 101
        Me.Label30.Text = "Servicios S/."
        '
        'txtGuia
        '
        Me.txtGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuia.Location = New System.Drawing.Point(359, 67)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(107, 20)
        Me.txtGuia.TabIndex = 9
        '
        'txtServicio
        '
        Me.txtServicio.DecimalDigits = 4
        Me.txtServicio.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicio.Location = New System.Drawing.Point(439, 91)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(65, 20)
        Me.txtServicio.TabIndex = 13
        Me.txtServicio.Text = "0.0000"
        Me.txtServicio.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'cbApliSeguro
        '
        Me.cbApliSeguro.AutoSize = True
        Me.cbApliSeguro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbApliSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbApliSeguro.Location = New System.Drawing.Point(530, 93)
        Me.cbApliSeguro.Name = "cbApliSeguro"
        Me.cbApliSeguro.Size = New System.Drawing.Size(83, 17)
        Me.cbApliSeguro.TabIndex = 14
        Me.cbApliSeguro.Text = "Apli. Seguro"
        Me.cbApliSeguro.UseVisualStyleBackColor = True
        '
        'txtSeguro
        '
        Me.txtSeguro.DecimalDigits = 5
        Me.txtSeguro.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeguro.Location = New System.Drawing.Point(620, 91)
        Me.txtSeguro.Name = "txtSeguro"
        Me.txtSeguro.Size = New System.Drawing.Size(77, 20)
        Me.txtSeguro.TabIndex = 15
        Me.txtSeguro.Text = "0.00000"
        Me.txtSeguro.Value = New Decimal(New Integer() {0, 0, 0, 327680})
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(697, 95)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(15, 13)
        Me.Label42.TabIndex = 104
        Me.Label42.Text = "%"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.Label15)
        Me.UiGroupBox3.Controls.Add(Me.txtTotOtrosGastos)
        Me.UiGroupBox3.Controls.Add(Me.txtTotFleteSol)
        Me.UiGroupBox3.Controls.Add(Me.Label19)
        Me.UiGroupBox3.Controls.Add(Me.txtResguardo)
        Me.UiGroupBox3.Controls.Add(Me.Label45)
        Me.UiGroupBox3.Controls.Add(Me.txtOtroGastos)
        Me.UiGroupBox3.Controls.Add(Me.txtHandling)
        Me.UiGroupBox3.Controls.Add(Me.txtTranspLocal)
        Me.UiGroupBox3.Controls.Add(Me.Label37)
        Me.UiGroupBox3.Controls.Add(Me.Label36)
        Me.UiGroupBox3.Controls.Add(Me.txtGastoAgencia)
        Me.UiGroupBox3.Controls.Add(Me.txtTerminal)
        Me.UiGroupBox3.Controls.Add(Me.txtCarga)
        Me.UiGroupBox3.Controls.Add(Me.Label35)
        Me.UiGroupBox3.Controls.Add(Me.Label34)
        Me.UiGroupBox3.Controls.Add(Me.Label33)
        Me.UiGroupBox3.Controls.Add(Me.Label47)
        Me.UiGroupBox3.Location = New System.Drawing.Point(6, 112)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(709, 87)
        Me.UiGroupBox3.TabIndex = 16
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(235, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 13)
        Me.Label15.TabIndex = 128
        Me.Label15.Text = "Total Otros Gastos $."
        '
        'txtTotOtrosGastos
        '
        Me.txtTotOtrosGastos.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtTotOtrosGastos.DecimalDigits = 4
        Me.txtTotOtrosGastos.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotOtrosGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotOtrosGastos.Location = New System.Drawing.Point(342, 61)
        Me.txtTotOtrosGastos.Name = "txtTotOtrosGastos"
        Me.txtTotOtrosGastos.Size = New System.Drawing.Size(101, 20)
        Me.txtTotOtrosGastos.TabIndex = 24
        Me.txtTotOtrosGastos.Text = "0.0000"
        Me.txtTotOtrosGastos.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'txtTotFleteSol
        '
        Me.txtTotFleteSol.DecimalDigits = 3
        Me.txtTotFleteSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotFleteSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotFleteSol.Location = New System.Drawing.Point(599, 61)
        Me.txtTotFleteSol.Name = "txtTotFleteSol"
        Me.txtTotFleteSol.Size = New System.Drawing.Size(102, 20)
        Me.txtTotFleteSol.TabIndex = 25
        Me.txtTotFleteSol.Text = "0.000"
        Me.txtTotFleteSol.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(530, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 126
        Me.Label19.Text = "Total Flete $."
        '
        'txtResguardo
        '
        Me.txtResguardo.DecimalDigits = 4
        Me.txtResguardo.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtResguardo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResguardo.Location = New System.Drawing.Point(599, 37)
        Me.txtResguardo.Name = "txtResguardo"
        Me.txtResguardo.Size = New System.Drawing.Size(102, 20)
        Me.txtResguardo.TabIndex = 22
        Me.txtResguardo.Text = "0.0000"
        Me.txtResguardo.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(522, 40)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(77, 13)
        Me.Label45.TabIndex = 37
        Me.Label45.Text = "Resguardo S/."
        '
        'txtOtroGastos
        '
        Me.txtOtroGastos.DecimalDigits = 4
        Me.txtOtroGastos.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtOtroGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtroGastos.Location = New System.Drawing.Point(342, 37)
        Me.txtOtroGastos.Name = "txtOtroGastos"
        Me.txtOtroGastos.Size = New System.Drawing.Size(101, 20)
        Me.txtOtroGastos.TabIndex = 21
        Me.txtOtroGastos.Text = "0.0000"
        Me.txtOtroGastos.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'txtHandling
        '
        Me.txtHandling.DecimalDigits = 4
        Me.txtHandling.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtHandling.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHandling.Location = New System.Drawing.Point(115, 61)
        Me.txtHandling.Name = "txtHandling"
        Me.txtHandling.Size = New System.Drawing.Size(97, 20)
        Me.txtHandling.TabIndex = 23
        Me.txtHandling.Text = "0.0000"
        Me.txtHandling.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'txtTranspLocal
        '
        Me.txtTranspLocal.DecimalDigits = 4
        Me.txtTranspLocal.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTranspLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTranspLocal.Location = New System.Drawing.Point(115, 37)
        Me.txtTranspLocal.Name = "txtTranspLocal"
        Me.txtTranspLocal.Size = New System.Drawing.Size(97, 20)
        Me.txtTranspLocal.TabIndex = 20
        Me.txtTranspLocal.Text = "0.0000"
        Me.txtTranspLocal.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(256, 40)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(86, 13)
        Me.Label37.TabIndex = 34
        Me.Label37.Text = "Otros Gastos S/."
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(26, 40)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(90, 13)
        Me.Label36.TabIndex = 33
        Me.Label36.Text = "Transp. Local S/."
        '
        'txtGastoAgencia
        '
        Me.txtGastoAgencia.DecimalDigits = 4
        Me.txtGastoAgencia.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtGastoAgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGastoAgencia.Location = New System.Drawing.Point(599, 13)
        Me.txtGastoAgencia.Name = "txtGastoAgencia"
        Me.txtGastoAgencia.Size = New System.Drawing.Size(102, 20)
        Me.txtGastoAgencia.TabIndex = 19
        Me.txtGastoAgencia.Text = "0.0000"
        Me.txtGastoAgencia.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'txtTerminal
        '
        Me.txtTerminal.DecimalDigits = 4
        Me.txtTerminal.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerminal.Location = New System.Drawing.Point(342, 13)
        Me.txtTerminal.Name = "txtTerminal"
        Me.txtTerminal.Size = New System.Drawing.Size(101, 20)
        Me.txtTerminal.TabIndex = 18
        Me.txtTerminal.Text = "0.0000"
        Me.txtTerminal.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'txtCarga
        '
        Me.txtCarga.DecimalDigits = 4
        Me.txtCarga.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarga.Location = New System.Drawing.Point(115, 13)
        Me.txtCarga.Name = "txtCarga"
        Me.txtCarga.Size = New System.Drawing.Size(97, 20)
        Me.txtCarga.TabIndex = 17
        Me.txtCarga.Text = "0.0000"
        Me.txtCarga.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(464, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(135, 13)
        Me.Label35.TabIndex = 29
        Me.Label35.Text = "Gasto Agencia Aduana S/."
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(233, 16)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(109, 13)
        Me.Label34.TabIndex = 28
        Me.Label34.Text = "Terminal Almacen S/."
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(6, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(110, 13)
        Me.Label33.TabIndex = 27
        Me.Label33.Text = "Carga / Descarga S/."
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(49, 64)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(67, 13)
        Me.Label47.TabIndex = 104
        Me.Label47.Text = "Handling S/."
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarProveedor)
        Me.UiGroupBox2.Controls.Add(Me.txtNumRegistro)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtTipCambio)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.cmbVia)
        Me.UiGroupBox2.Controls.Add(Me.UiGroupBox3)
        Me.UiGroupBox2.Controls.Add(Me.Label42)
        Me.UiGroupBox2.Controls.Add(Me.txtSeguro)
        Me.UiGroupBox2.Controls.Add(Me.cbApliSeguro)
        Me.UiGroupBox2.Controls.Add(Me.txtServicio)
        Me.UiGroupBox2.Controls.Add(Me.txtGuia)
        Me.UiGroupBox2.Controls.Add(Me.Label30)
        Me.UiGroupBox2.Controls.Add(Me.Label25)
        Me.UiGroupBox2.Controls.Add(Me.txtIgvAdu)
        Me.UiGroupBox2.Controls.Add(Me.txtPoliza)
        Me.UiGroupBox2.Controls.Add(Me.Label24)
        Me.UiGroupBox2.Controls.Add(Me.Label28)
        Me.UiGroupBox2.Controls.Add(Me.txtPtoEmb)
        Me.UiGroupBox2.Controls.Add(Me.Label44)
        Me.UiGroupBox2.Controls.Add(Me.txtFactura)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPais)
        Me.UiGroupBox2.Controls.Add(Me.txtOrigen)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtTransporte)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtAduana)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Location = New System.Drawing.Point(7, 265)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(721, 205)
        Me.UiGroupBox2.TabIndex = 0
        Me.UiGroupBox2.Text = "Datos de Factura"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(418, 18)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 105
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtTipCambio
        '
        Me.txtTipCambio.DecimalDigits = 3
        Me.txtTipCambio.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCambio.Location = New System.Drawing.Point(73, 91)
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.Size = New System.Drawing.Size(57, 20)
        Me.txtTipCambio.TabIndex = 11
        Me.txtTipCambio.Text = "0.000"
        Me.txtTipCambio.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Tipo Cambio"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(539, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "#Registros :"
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Location = New System.Drawing.Point(621, 66)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(32, 13)
        Me.lblRegistros.TabIndex = 32
        Me.lblRegistros.Text = "Num"
        '
        'frmValorizarFIMasivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(737, 507)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvFacturas)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValorizarFIMasivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valorizar F/I Masivo"
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cbEstados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbVia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents dgvFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbVia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotFleteSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtResguardo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtOtroGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtHandling As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTranspLocal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtGastoAgencia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTerminal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCarga As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtSeguro As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbApliSeguro As System.Windows.Forms.CheckBox
    Friend WithEvents txtServicio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtIgvAdu As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPoliza As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPtoEmb As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPais As System.Windows.Forms.Button
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTransporte As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAduana As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumRegistro As System.Windows.Forms.TextBox
    Friend WithEvents txtTipCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cIdImportacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdSerieDoc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesAlm1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedor1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesProv1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMon1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMon1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTipCam1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotFobGen1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotFobGenSol1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNeto1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNetoSol1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEstado1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdImportacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdSerieDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesAlm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTipCam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotFobGen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotFobGenSol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNeto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNetoSol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbEstados As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtTotOtrosGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
