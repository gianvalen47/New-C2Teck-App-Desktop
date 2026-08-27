<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovAlmacenImpMasiva
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
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovAlmacenImpMasiva))
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdMovimiento1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdDocumento1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNombre1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdSerieDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumJob1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCli1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotNeto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumFac1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEstado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvFacturas = New System.Windows.Forms.DataGridView()
        Me.cIdMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdSerieDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumFac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbTipoReporte = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbPorOrdenCompra = New System.Windows.Forms.RadioButton()
        Me.rbPorFactura = New System.Windows.Forms.RadioButton()
        Me.rbPorUbicacion = New System.Windows.Forms.RadioButton()
        Me.rbPorDestino = New System.Windows.Forms.RadioButton()
        Me.rbPorCodigo = New System.Windows.Forms.RadioButton()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoReporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbMes)
        Me.gbDatosBusqueda.Controls.Add(Me.Label7)
        Me.gbDatosBusqueda.Controls.Add(Me.Label5)
        Me.gbDatosBusqueda.Controls.Add(Me.txtanio)
        Me.gbDatosBusqueda.Controls.Add(Me.Label4)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbIdLocacion)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbOficinas)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(13, 11)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(723, 68)
        Me.gbDatosBusqueda.TabIndex = 1
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(487, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnBuscar.TabIndex = 22
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(228, 35)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(62, 20)
        Me.cmbMes.TabIndex = 13
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(241, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Mes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(185, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtanio.Location = New System.Drawing.Point(173, 35)
        Me.txtanio.Maximum = 2050
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2006
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(50, 20)
        Me.txtanio.TabIndex = 12
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2006
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(395, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Almacén"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(376, 35)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(105, 20)
        Me.cmbIdLocacion.TabIndex = 15
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(308, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Oficina"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(295, 35)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(77, 20)
        Me.cmbOficinas.TabIndex = 14
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Location = New System.Drawing.Point(631, 90)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(32, 13)
        Me.lblRegistros.TabIndex = 47
        Me.lblRegistros.Text = "Num"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(377, 400)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 49
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(549, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "#Registros :"
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(294, 400)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(78, 27)
        Me.btnImprimir.TabIndex = 48
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdMovimiento1, Me.cIdLocacion1, Me.cIdDocumento1, Me.cNombre1, Me.cAbrDoc1, Me.cIdSerieDoc1, Me.cNumDoc1, Me.cFecDoc1, Me.cNumJob1, Me.cDesCli1, Me.cCodMon1, Me.cTotNeto1, Me.cNumFac1, Me.cEstado1})
        Me.dgvSeleccionados.Location = New System.Drawing.Point(399, 106)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(336, 220)
        Me.dgvSeleccionados.TabIndex = 44
        '
        'cIdMovimiento1
        '
        Me.cIdMovimiento1.HeaderText = "IdMovimiento"
        Me.cIdMovimiento1.Name = "cIdMovimiento1"
        Me.cIdMovimiento1.Visible = False
        Me.cIdMovimiento1.Width = 186
        '
        'cIdLocacion1
        '
        Me.cIdLocacion1.HeaderText = "IdLocacion"
        Me.cIdLocacion1.Name = "cIdLocacion1"
        Me.cIdLocacion1.Visible = False
        '
        'cIdDocumento1
        '
        Me.cIdDocumento1.HeaderText = "IdDocumento"
        Me.cIdDocumento1.Name = "cIdDocumento1"
        Me.cIdDocumento1.Visible = False
        '
        'cNombre1
        '
        Me.cNombre1.HeaderText = "Nombre"
        Me.cNombre1.Name = "cNombre1"
        Me.cNombre1.Visible = False
        '
        'cAbrDoc1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cAbrDoc1.DefaultCellStyle = DataGridViewCellStyle1
        Me.cAbrDoc1.HeaderText = "AbrDoc"
        Me.cAbrDoc1.Name = "cAbrDoc1"
        Me.cAbrDoc1.ReadOnly = True
        Me.cAbrDoc1.Visible = False
        Me.cAbrDoc1.Width = 130
        '
        'cIdSerieDoc1
        '
        Me.cIdSerieDoc1.HeaderText = "IdSerieDoc"
        Me.cIdSerieDoc1.Name = "cIdSerieDoc1"
        Me.cIdSerieDoc1.Visible = False
        '
        'cNumDoc1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNumDoc1.DefaultCellStyle = DataGridViewCellStyle2
        Me.cNumDoc1.HeaderText = "Número"
        Me.cNumDoc1.Name = "cNumDoc1"
        '
        'cFecDoc1
        '
        Me.cFecDoc1.HeaderText = "FecDoc"
        Me.cFecDoc1.Name = "cFecDoc1"
        Me.cFecDoc1.Visible = False
        '
        'cNumJob1
        '
        Me.cNumJob1.HeaderText = "NumJob"
        Me.cNumJob1.Name = "cNumJob1"
        Me.cNumJob1.Visible = False
        '
        'cDesCli1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cDesCli1.DefaultCellStyle = DataGridViewCellStyle3
        Me.cDesCli1.HeaderText = "Cliente"
        Me.cDesCli1.Name = "cDesCli1"
        Me.cDesCli1.Width = 220
        '
        'cCodMon1
        '
        Me.cCodMon1.HeaderText = "CodMon"
        Me.cCodMon1.Name = "cCodMon1"
        Me.cCodMon1.Visible = False
        '
        'cTotNeto1
        '
        Me.cTotNeto1.HeaderText = "TotNeto"
        Me.cTotNeto1.Name = "cTotNeto1"
        Me.cTotNeto1.Visible = False
        '
        'cNumFac1
        '
        Me.cNumFac1.HeaderText = "NumFac"
        Me.cNumFac1.Name = "cNumFac1"
        Me.cNumFac1.Visible = False
        '
        'cEstado1
        '
        Me.cEstado1.HeaderText = "Estado"
        Me.cEstado1.Name = "cEstado1"
        Me.cEstado1.Visible = False
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(10, 88)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(62, 15)
        Me.lblPersonal.TabIndex = 43
        Me.lblPersonal.Text = "Facturas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(397, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 15)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Seleccionados"
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowUserToAddRows = False
        Me.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdMovimiento, Me.cIdLocacion, Me.cIdDocumento, Me.cNombre, Me.cAbrDoc, Me.cIdSerieDoc, Me.cNumDoc, Me.cFecDoc, Me.cNumJob, Me.cDesCli, Me.cCodMon, Me.cTotNeto, Me.cNumFac, Me.cEstado})
        Me.dgvFacturas.Location = New System.Drawing.Point(12, 106)
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.RowHeadersVisible = False
        Me.dgvFacturas.Size = New System.Drawing.Size(336, 220)
        Me.dgvFacturas.TabIndex = 42
        '
        'cIdMovimiento
        '
        Me.cIdMovimiento.HeaderText = "IdMovimiento"
        Me.cIdMovimiento.Name = "cIdMovimiento"
        Me.cIdMovimiento.Visible = False
        Me.cIdMovimiento.Width = 186
        '
        'cIdLocacion
        '
        Me.cIdLocacion.HeaderText = "IdLocacion"
        Me.cIdLocacion.Name = "cIdLocacion"
        Me.cIdLocacion.Visible = False
        '
        'cIdDocumento
        '
        Me.cIdDocumento.HeaderText = "IdDocumento"
        Me.cIdDocumento.Name = "cIdDocumento"
        Me.cIdDocumento.Visible = False
        '
        'cNombre
        '
        Me.cNombre.HeaderText = "Nombre"
        Me.cNombre.Name = "cNombre"
        Me.cNombre.Visible = False
        '
        'cAbrDoc
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cAbrDoc.DefaultCellStyle = DataGridViewCellStyle4
        Me.cAbrDoc.HeaderText = "AbrDoc"
        Me.cAbrDoc.Name = "cAbrDoc"
        Me.cAbrDoc.ReadOnly = True
        Me.cAbrDoc.Visible = False
        Me.cAbrDoc.Width = 130
        '
        'cIdSerieDoc
        '
        Me.cIdSerieDoc.HeaderText = "IdSerieDoc"
        Me.cIdSerieDoc.Name = "cIdSerieDoc"
        Me.cIdSerieDoc.Visible = False
        '
        'cNumDoc
        '
        Me.cNumDoc.HeaderText = "Número"
        Me.cNumDoc.Name = "cNumDoc"
        '
        'cFecDoc
        '
        Me.cFecDoc.HeaderText = "FecDoc"
        Me.cFecDoc.Name = "cFecDoc"
        Me.cFecDoc.Visible = False
        '
        'cNumJob
        '
        Me.cNumJob.HeaderText = "NumJob"
        Me.cNumJob.Name = "cNumJob"
        Me.cNumJob.Visible = False
        Me.cNumJob.Width = 220
        '
        'cDesCli
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cDesCli.DefaultCellStyle = DataGridViewCellStyle5
        Me.cDesCli.HeaderText = "Cliente"
        Me.cDesCli.Name = "cDesCli"
        Me.cDesCli.Width = 220
        '
        'cCodMon
        '
        Me.cCodMon.HeaderText = "CodMon"
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.Visible = False
        '
        'cTotNeto
        '
        Me.cTotNeto.HeaderText = "TotNeto"
        Me.cTotNeto.Name = "cTotNeto"
        Me.cTotNeto.Visible = False
        '
        'cNumFac
        '
        Me.cNumFac.HeaderText = "NumFac"
        Me.cNumFac.Name = "cNumFac"
        Me.cNumFac.Visible = False
        '
        'cEstado
        '
        Me.cEstado.HeaderText = "Estado"
        Me.cEstado.Name = "cEstado"
        Me.cEstado.Visible = False
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(352, 227)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 27)
        Me.btnAgregarTodos.TabIndex = 51
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(352, 186)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 27)
        Me.btnAgregar.TabIndex = 50
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
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
        'gbTipoReporte
        '
        Me.gbTipoReporte.Controls.Add(Me.rbPorOrdenCompra)
        Me.gbTipoReporte.Controls.Add(Me.rbPorFactura)
        Me.gbTipoReporte.Controls.Add(Me.rbPorUbicacion)
        Me.gbTipoReporte.Controls.Add(Me.rbPorDestino)
        Me.gbTipoReporte.Controls.Add(Me.rbPorCodigo)
        Me.gbTipoReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoReporte.Location = New System.Drawing.Point(12, 340)
        Me.gbTipoReporte.Name = "gbTipoReporte"
        Me.gbTipoReporte.Size = New System.Drawing.Size(724, 51)
        Me.gbTipoReporte.TabIndex = 115
        Me.gbTipoReporte.Text = "Ordenado Por :"
        Me.gbTipoReporte.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbPorOrdenCompra
        '
        Me.rbPorOrdenCompra.AutoSize = True
        Me.rbPorOrdenCompra.Location = New System.Drawing.Point(581, 23)
        Me.rbPorOrdenCompra.Name = "rbPorOrdenCompra"
        Me.rbPorOrdenCompra.Size = New System.Drawing.Size(105, 17)
        Me.rbPorOrdenCompra.TabIndex = 17
        Me.rbPorOrdenCompra.Text = "Orden Compra"
        Me.rbPorOrdenCompra.UseVisualStyleBackColor = True
        '
        'rbPorFactura
        '
        Me.rbPorFactura.AutoSize = True
        Me.rbPorFactura.Location = New System.Drawing.Point(438, 23)
        Me.rbPorFactura.Name = "rbPorFactura"
        Me.rbPorFactura.Size = New System.Drawing.Size(86, 17)
        Me.rbPorFactura.TabIndex = 16
        Me.rbPorFactura.Text = "N° Factura"
        Me.rbPorFactura.UseVisualStyleBackColor = True
        '
        'rbPorUbicacion
        '
        Me.rbPorUbicacion.AutoSize = True
        Me.rbPorUbicacion.Location = New System.Drawing.Point(300, 23)
        Me.rbPorUbicacion.Name = "rbPorUbicacion"
        Me.rbPorUbicacion.Size = New System.Drawing.Size(82, 17)
        Me.rbPorUbicacion.TabIndex = 15
        Me.rbPorUbicacion.Text = "Ubicacion"
        Me.rbPorUbicacion.UseVisualStyleBackColor = True
        '
        'rbPorDestino
        '
        Me.rbPorDestino.AutoSize = True
        Me.rbPorDestino.Location = New System.Drawing.Point(174, 23)
        Me.rbPorDestino.Name = "rbPorDestino"
        Me.rbPorDestino.Size = New System.Drawing.Size(68, 17)
        Me.rbPorDestino.TabIndex = 14
        Me.rbPorDestino.Text = "Destino"
        Me.rbPorDestino.UseVisualStyleBackColor = True
        '
        'rbPorCodigo
        '
        Me.rbPorCodigo.AutoSize = True
        Me.rbPorCodigo.Checked = True
        Me.rbPorCodigo.Location = New System.Drawing.Point(45, 23)
        Me.rbPorCodigo.Name = "rbPorCodigo"
        Me.rbPorCodigo.Size = New System.Drawing.Size(64, 17)
        Me.rbPorCodigo.TabIndex = 12
        Me.rbPorCodigo.TabStop = True
        Me.rbPorCodigo.Text = "Codigo"
        Me.rbPorCodigo.UseVisualStyleBackColor = True
        '
        'frmMovAlmacenImpMasiva
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(764, 453)
        Me.Controls.Add(Me.gbTipoReporte)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvFacturas)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovAlmacenImpMasiva"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresion Masiva"
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoReporte.ResumeLayout(False)
        Me.gbTipoReporte.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblRegistros As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents dgvSeleccionados As DataGridView
    Friend WithEvents lblPersonal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvFacturas As DataGridView
    Friend WithEvents btnAgregarTodos As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents miEliminar As ToolStripMenuItem
    Friend WithEvents cmbOpciones As ContextMenuStrip
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnBuscar As Button
    Friend WithEvents cIdDocumento1 As DataGridViewTextBoxColumn
    Friend WithEvents cNombre1 As DataGridViewTextBoxColumn
    Friend WithEvents cAbrDoc1 As DataGridViewTextBoxColumn
    Friend WithEvents cIdSerieDoc1 As DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc1 As DataGridViewTextBoxColumn
    Friend WithEvents cNumJob1 As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon1 As DataGridViewTextBoxColumn
    Friend WithEvents cTotNeto1 As DataGridViewTextBoxColumn
    Friend WithEvents cNumFac1 As DataGridViewTextBoxColumn
    Friend WithEvents cEstado1 As DataGridViewTextBoxColumn
    Friend WithEvents cIdDocumento As DataGridViewTextBoxColumn
    Friend WithEvents cNombre As DataGridViewTextBoxColumn
    Friend WithEvents cAbrDoc As DataGridViewTextBoxColumn
    Friend WithEvents cIdSerieDoc As DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc As DataGridViewTextBoxColumn
    Friend WithEvents cNumJob As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As DataGridViewTextBoxColumn
    Friend WithEvents cTotNeto As DataGridViewTextBoxColumn
    Friend WithEvents cNumFac As DataGridViewTextBoxColumn
    Friend WithEvents cEstado As DataGridViewTextBoxColumn
    Friend WithEvents cDesCli As DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc As DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion As DataGridViewTextBoxColumn
    Friend WithEvents cIdMovimiento As DataGridViewTextBoxColumn
    Friend WithEvents cDesCli1 As DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc1 As DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion1 As DataGridViewTextBoxColumn
    Friend WithEvents cIdMovimiento1 As DataGridViewTextBoxColumn
    Friend WithEvents gbTipoReporte As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPorDestino As RadioButton
    Friend WithEvents rbPorCodigo As RadioButton
    Friend WithEvents rbPorOrdenCompra As RadioButton
    Friend WithEvents rbPorFactura As RadioButton
    Friend WithEvents rbPorUbicacion As RadioButton
End Class
