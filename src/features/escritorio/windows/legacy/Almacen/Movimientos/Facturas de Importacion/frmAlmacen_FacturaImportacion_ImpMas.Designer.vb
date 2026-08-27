<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlmacen_FacturaImportacion_ImpMas
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
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlmacen_FacturaImportacion_ImpMas))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdImportacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNeto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEstado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvFacturas = New System.Windows.Forms.DataGridView()
        Me.cIdImportacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.gbTipoReporte = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbConformidad = New System.Windows.Forms.RadioButton()
        Me.rbListadoGeneral = New System.Windows.Forms.RadioButton()
        Me.gbMostrarStock = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDisponible = New System.Windows.Forms.RadioButton()
        Me.rbFisico = New System.Windows.Forms.RadioButton()
        Me.gbOrdenarPor = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbPorCodigo = New System.Windows.Forms.RadioButton()
        Me.rbPorNumFactura = New System.Windows.Forms.RadioButton()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoReporte.SuspendLayout()
        CType(Me.gbMostrarStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMostrarStock.SuspendLayout()
        CType(Me.gbOrdenarPor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenarPor.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.txtCodEmbarque)
        Me.gbDatosBusqueda.Controls.Add(Me.Label8)
        Me.gbDatosBusqueda.Controls.Add(Me.txtFecha)
        Me.gbDatosBusqueda.Controls.Add(Me.Label1)
        Me.gbDatosBusqueda.Controls.Add(Me.Label4)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbIdLocacion)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbOficinas)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(12, 3)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(714, 59)
        Me.gbDatosBusqueda.TabIndex = 0
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmbarque.Location = New System.Drawing.Point(494, 31)
        Me.txtCodEmbarque.MaxLength = 30
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(110, 20)
        Me.txtCodEmbarque.TabIndex = 26
        Me.txtCodEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(507, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "CodEmbarque"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(381, 31)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ShowNullButton = True
        Me.txtFecha.Size = New System.Drawing.Size(92, 20)
        Me.txtFecha.TabIndex = 19
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(406, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(230, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Almacén"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(159, 31)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(198, 20)
        Me.cmbIdLocacion.TabIndex = 17
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Oficina"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(18, 31)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(119, 20)
        Me.cmbOficinas.TabIndex = 16
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(626, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnBuscar.TabIndex = 21
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdImportacion1, Me.cIdLocacion1, Me.cNumDoc1, Me.cFecDoc1, Me.cDesProv1, Me.cTotalNeto1, Me.cEstado1})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(394, 87)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(336, 220)
        Me.dgvSeleccionados.TabIndex = 33
        '
        'cIdImportacion1
        '
        Me.cIdImportacion1.HeaderText = "IdImportacion"
        Me.cIdImportacion1.Name = "cIdImportacion1"
        Me.cIdImportacion1.Visible = False
        '
        'cIdLocacion1
        '
        Me.cIdLocacion1.HeaderText = "IdLocacion"
        Me.cIdLocacion1.Name = "cIdLocacion1"
        Me.cIdLocacion1.Visible = False
        '
        'cNumDoc1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNumDoc1.DefaultCellStyle = DataGridViewCellStyle1
        Me.cNumDoc1.HeaderText = "Número"
        Me.cNumDoc1.Name = "cNumDoc1"
        Me.cNumDoc1.ReadOnly = True
        Me.cNumDoc1.Width = 130
        '
        'cFecDoc1
        '
        Me.cFecDoc1.HeaderText = "FecDoc"
        Me.cFecDoc1.Name = "cFecDoc1"
        Me.cFecDoc1.Visible = False
        '
        'cDesProv1
        '
        Me.cDesProv1.HeaderText = "Proveedor"
        Me.cDesProv1.Name = "cDesProv1"
        Me.cDesProv1.Width = 186
        '
        'cTotalNeto1
        '
        Me.cTotalNeto1.HeaderText = "TotalNeto"
        Me.cTotalNeto1.Name = "cTotalNeto1"
        Me.cTotalNeto1.Visible = False
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
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(348, 205)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 27)
        Me.btnAgregarTodos.TabIndex = 36
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(8, 69)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(62, 15)
        Me.lblPersonal.TabIndex = 32
        Me.lblPersonal.Text = "Facturas"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(348, 164)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 27)
        Me.btnAgregar.TabIndex = 35
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(394, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 15)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Seleccionados"
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowUserToAddRows = False
        Me.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdImportacion, Me.cIdLocacion, Me.cNumDoc, Me.cFecDoc, Me.cDesProv, Me.cTotalNeto, Me.cEstado})
        Me.dgvFacturas.Location = New System.Drawing.Point(8, 87)
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.RowHeadersVisible = False
        Me.dgvFacturas.Size = New System.Drawing.Size(336, 220)
        Me.dgvFacturas.TabIndex = 31
        '
        'cIdImportacion
        '
        Me.cIdImportacion.HeaderText = "IdImportacion"
        Me.cIdImportacion.Name = "cIdImportacion"
        Me.cIdImportacion.Visible = False
        '
        'cIdLocacion
        '
        Me.cIdLocacion.HeaderText = "IdLocacion"
        Me.cIdLocacion.Name = "cIdLocacion"
        Me.cIdLocacion.Visible = False
        '
        'cNumDoc
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNumDoc.DefaultCellStyle = DataGridViewCellStyle2
        Me.cNumDoc.HeaderText = "Número"
        Me.cNumDoc.Name = "cNumDoc"
        Me.cNumDoc.ReadOnly = True
        Me.cNumDoc.Width = 130
        '
        'cFecDoc
        '
        Me.cFecDoc.HeaderText = "FecDoc"
        Me.cFecDoc.Name = "cFecDoc"
        Me.cFecDoc.Visible = False
        '
        'cDesProv
        '
        Me.cDesProv.HeaderText = "Proveedor"
        Me.cDesProv.Name = "cDesProv"
        Me.cDesProv.Width = 186
        '
        'cTotalNeto
        '
        Me.cTotalNeto.HeaderText = "TotalNeto"
        Me.cTotalNeto.Name = "cTotalNeto"
        Me.cTotalNeto.Visible = False
        '
        'cEstado
        '
        Me.cEstado.HeaderText = "Estado"
        Me.cEstado.Name = "cEstado"
        Me.cEstado.Visible = False
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Location = New System.Drawing.Point(628, 71)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(32, 13)
        Me.lblRegistros.TabIndex = 39
        Me.lblRegistros.Text = "Num"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(546, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "#Registros :"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(374, 364)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 41
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(291, 364)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(78, 27)
        Me.btnImprimir.TabIndex = 40
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'gbTipoReporte
        '
        Me.gbTipoReporte.Controls.Add(Me.rbConformidad)
        Me.gbTipoReporte.Controls.Add(Me.rbListadoGeneral)
        Me.gbTipoReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoReporte.Location = New System.Drawing.Point(8, 313)
        Me.gbTipoReporte.Name = "gbTipoReporte"
        Me.gbTipoReporte.Size = New System.Drawing.Size(264, 45)
        Me.gbTipoReporte.TabIndex = 114
        Me.gbTipoReporte.Text = "Tipo de Reporte"
        Me.gbTipoReporte.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbConformidad
        '
        Me.rbConformidad.AutoSize = True
        Me.rbConformidad.Location = New System.Drawing.Point(154, 17)
        Me.rbConformidad.Name = "rbConformidad"
        Me.rbConformidad.Size = New System.Drawing.Size(95, 17)
        Me.rbConformidad.TabIndex = 14
        Me.rbConformidad.Text = "Conformidad"
        Me.rbConformidad.UseVisualStyleBackColor = True
        '
        'rbListadoGeneral
        '
        Me.rbListadoGeneral.AutoSize = True
        Me.rbListadoGeneral.Checked = True
        Me.rbListadoGeneral.Location = New System.Drawing.Point(24, 17)
        Me.rbListadoGeneral.Name = "rbListadoGeneral"
        Me.rbListadoGeneral.Size = New System.Drawing.Size(114, 17)
        Me.rbListadoGeneral.TabIndex = 12
        Me.rbListadoGeneral.TabStop = True
        Me.rbListadoGeneral.Text = "Listado General"
        Me.rbListadoGeneral.UseVisualStyleBackColor = True
        '
        'gbMostrarStock
        '
        Me.gbMostrarStock.Controls.Add(Me.rbDisponible)
        Me.gbMostrarStock.Controls.Add(Me.rbFisico)
        Me.gbMostrarStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMostrarStock.Location = New System.Drawing.Point(292, 313)
        Me.gbMostrarStock.Name = "gbMostrarStock"
        Me.gbMostrarStock.Size = New System.Drawing.Size(212, 45)
        Me.gbMostrarStock.TabIndex = 115
        Me.gbMostrarStock.Text = "Mostrar Stock"
        Me.gbMostrarStock.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDisponible
        '
        Me.rbDisponible.AutoSize = True
        Me.rbDisponible.Location = New System.Drawing.Point(110, 17)
        Me.rbDisponible.Name = "rbDisponible"
        Me.rbDisponible.Size = New System.Drawing.Size(84, 17)
        Me.rbDisponible.TabIndex = 14
        Me.rbDisponible.Text = "Disponible"
        Me.rbDisponible.UseVisualStyleBackColor = True
        '
        'rbFisico
        '
        Me.rbFisico.AutoSize = True
        Me.rbFisico.Checked = True
        Me.rbFisico.Location = New System.Drawing.Point(31, 17)
        Me.rbFisico.Name = "rbFisico"
        Me.rbFisico.Size = New System.Drawing.Size(60, 17)
        Me.rbFisico.TabIndex = 12
        Me.rbFisico.TabStop = True
        Me.rbFisico.Text = "Físico"
        Me.rbFisico.UseVisualStyleBackColor = True
        '
        'gbOrdenarPor
        '
        Me.gbOrdenarPor.Controls.Add(Me.rbPorCodigo)
        Me.gbOrdenarPor.Controls.Add(Me.rbPorNumFactura)
        Me.gbOrdenarPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrdenarPor.Location = New System.Drawing.Point(521, 313)
        Me.gbOrdenarPor.Name = "gbOrdenarPor"
        Me.gbOrdenarPor.Size = New System.Drawing.Size(209, 45)
        Me.gbOrdenarPor.TabIndex = 116
        Me.gbOrdenarPor.Text = "Ordenar x"
        Me.gbOrdenarPor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbPorCodigo
        '
        Me.rbPorCodigo.AutoSize = True
        Me.rbPorCodigo.Location = New System.Drawing.Point(126, 17)
        Me.rbPorCodigo.Name = "rbPorCodigo"
        Me.rbPorCodigo.Size = New System.Drawing.Size(64, 17)
        Me.rbPorCodigo.TabIndex = 14
        Me.rbPorCodigo.Text = "Código"
        Me.rbPorCodigo.UseVisualStyleBackColor = True
        '
        'rbPorNumFactura
        '
        Me.rbPorNumFactura.AutoSize = True
        Me.rbPorNumFactura.Checked = True
        Me.rbPorNumFactura.Location = New System.Drawing.Point(26, 17)
        Me.rbPorNumFactura.Name = "rbPorNumFactura"
        Me.rbPorNumFactura.Size = New System.Drawing.Size(86, 17)
        Me.rbPorNumFactura.TabIndex = 12
        Me.rbPorNumFactura.TabStop = True
        Me.rbPorNumFactura.Text = "N° Factura"
        Me.rbPorNumFactura.UseVisualStyleBackColor = True
        '
        'frmAlmacen_FacturaImportacion_ImpMas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(740, 398)
        Me.Controls.Add(Me.gbOrdenarPor)
        Me.Controls.Add(Me.gbMostrarStock)
        Me.Controls.Add(Me.gbTipoReporte)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvFacturas)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlmacen_FacturaImportacion_ImpMas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir Facturas de Importación Masivo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoReporte.ResumeLayout(False)
        Me.gbTipoReporte.PerformLayout()
        CType(Me.gbMostrarStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMostrarStock.ResumeLayout(False)
        Me.gbMostrarStock.PerformLayout()
        CType(Me.gbOrdenarPor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenarPor.ResumeLayout(False)
        Me.gbOrdenarPor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents cIdImportacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesProv1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNeto1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEstado1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdImportacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNeto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbTipoReporte As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbConformidad As System.Windows.Forms.RadioButton
    Friend WithEvents rbListadoGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents gbMostrarStock As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbDisponible As System.Windows.Forms.RadioButton
    Friend WithEvents rbFisico As System.Windows.Forms.RadioButton
    Friend WithEvents gbOrdenarPor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPorCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorNumFactura As System.Windows.Forms.RadioButton
End Class
