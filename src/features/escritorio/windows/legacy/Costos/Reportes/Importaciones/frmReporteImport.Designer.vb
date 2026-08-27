<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteImport
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
        Dim cbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdCliente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteImport))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox11 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbComparacionCabDet = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPreciovsCosto = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbRegistroUnidad = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbEmbarque = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbRegistroProveedor = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbResumen = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbRegistro = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbAlmacenes = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbPeriodo = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbNumero = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.gbEmbarque = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtEmbarque = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbMoneda = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbIdCliente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbOrdenar = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbFechaIngreso = New System.Windows.Forms.RadioButton()
        Me.rbNroIngreso = New System.Windows.Forms.RadioButton()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.btnAceptarE = New System.Windows.Forms.Button()
        Me.gbFlete = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbFlete = New System.Windows.Forms.CheckBox()
        Me.gbNroIng = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNroIng = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.gbExportarExcel = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbExportarExcel = New System.Windows.Forms.CheckBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox11.SuspendLayout()
        CType(Me.gbAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAlmacenes.SuspendLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPeriodo.SuspendLayout()
        CType(Me.gbNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNumero.SuspendLayout()
        CType(Me.gbEmbarque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEmbarque.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMoneda.SuspendLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.cmbIdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbOrdenar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenar.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbFlete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFlete.SuspendLayout()
        CType(Me.gbNroIng, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNroIng.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbExportarExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportarExcel.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox11
        '
        Me.UiGroupBox11.Controls.Add(Me.rbComparacionCabDet)
        Me.UiGroupBox11.Controls.Add(Me.rbPreciovsCosto)
        Me.UiGroupBox11.Controls.Add(Me.rbRegistroUnidad)
        Me.UiGroupBox11.Controls.Add(Me.rbEmbarque)
        Me.UiGroupBox11.Controls.Add(Me.rbRegistroProveedor)
        Me.UiGroupBox11.Controls.Add(Me.rbResumen)
        Me.UiGroupBox11.Controls.Add(Me.rbRegistro)
        Me.UiGroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox11.Location = New System.Drawing.Point(6, 2)
        Me.UiGroupBox11.Name = "UiGroupBox11"
        Me.UiGroupBox11.Size = New System.Drawing.Size(299, 106)
        Me.UiGroupBox11.TabIndex = 0
        Me.UiGroupBox11.Text = "Tipo de Reporte"
        Me.UiGroupBox11.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbComparacionCabDet
        '
        Me.rbComparacionCabDet.Location = New System.Drawing.Point(5, 83)
        Me.rbComparacionCabDet.Name = "rbComparacionCabDet"
        Me.rbComparacionCabDet.Size = New System.Drawing.Size(173, 17)
        Me.rbComparacionCabDet.TabIndex = 7
        Me.rbComparacionCabDet.Text = "Comparación Cabecera - Detalle"
        Me.rbComparacionCabDet.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPreciovsCosto
        '
        Me.rbPreciovsCosto.Location = New System.Drawing.Point(160, 61)
        Me.rbPreciovsCosto.Name = "rbPreciovsCosto"
        Me.rbPreciovsCosto.Size = New System.Drawing.Size(127, 17)
        Me.rbPreciovsCosto.TabIndex = 6
        Me.rbPreciovsCosto.Text = "Precio vs Costo"
        Me.rbPreciovsCosto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbRegistroUnidad
        '
        Me.rbRegistroUnidad.Location = New System.Drawing.Point(5, 39)
        Me.rbRegistroUnidad.Name = "rbRegistroUnidad"
        Me.rbRegistroUnidad.Size = New System.Drawing.Size(148, 17)
        Me.rbRegistroUnidad.TabIndex = 5
        Me.rbRegistroUnidad.Text = "Registro por Unid. Negocio"
        Me.rbRegistroUnidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbEmbarque
        '
        Me.rbEmbarque.Location = New System.Drawing.Point(160, 38)
        Me.rbEmbarque.Name = "rbEmbarque"
        Me.rbEmbarque.Size = New System.Drawing.Size(127, 17)
        Me.rbEmbarque.TabIndex = 4
        Me.rbEmbarque.Text = "Registro por Embarque"
        Me.rbEmbarque.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbRegistroProveedor
        '
        Me.rbRegistroProveedor.Location = New System.Drawing.Point(160, 11)
        Me.rbRegistroProveedor.Name = "rbRegistroProveedor"
        Me.rbRegistroProveedor.Size = New System.Drawing.Size(133, 22)
        Me.rbRegistroProveedor.TabIndex = 3
        Me.rbRegistroProveedor.Text = "Registro por Proveedor"
        Me.rbRegistroProveedor.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbResumen
        '
        Me.rbResumen.Location = New System.Drawing.Point(5, 61)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(76, 17)
        Me.rbResumen.TabIndex = 2
        Me.rbResumen.Text = "Resumen"
        Me.rbResumen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbRegistro
        '
        Me.rbRegistro.Location = New System.Drawing.Point(5, 18)
        Me.rbRegistro.Name = "rbRegistro"
        Me.rbRegistro.Size = New System.Drawing.Size(149, 15)
        Me.rbRegistro.TabIndex = 1
        Me.rbRegistro.Text = "Registro de Importaciones"
        Me.rbRegistro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbAlmacenes
        '
        Me.gbAlmacenes.Controls.Add(Me.cbAlmacen)
        Me.gbAlmacenes.Controls.Add(Me.cbOficina)
        Me.gbAlmacenes.Controls.Add(Me.Label2)
        Me.gbAlmacenes.Controls.Add(Me.Label1)
        Me.gbAlmacenes.Location = New System.Drawing.Point(6, 171)
        Me.gbAlmacenes.Name = "gbAlmacenes"
        Me.gbAlmacenes.Size = New System.Drawing.Size(300, 62)
        Me.gbAlmacenes.TabIndex = 11
        Me.gbAlmacenes.Text = "Almacenes"
        Me.gbAlmacenes.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(74, 37)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(220, 20)
        Me.cbAlmacen.TabIndex = 13
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(74, 15)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(143, 20)
        Me.cbOficina.TabIndex = 12
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Almacen :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Oficina :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(145, 348)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 30)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(226, 348)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbPeriodo
        '
        Me.gbPeriodo.Controls.Add(Me.txtFechaFin)
        Me.gbPeriodo.Controls.Add(Me.txtFechaInicio)
        Me.gbPeriodo.Controls.Add(Me.Label6)
        Me.gbPeriodo.Controls.Add(Me.Label5)
        Me.gbPeriodo.Location = New System.Drawing.Point(6, 110)
        Me.gbPeriodo.Name = "gbPeriodo"
        Me.gbPeriodo.Size = New System.Drawing.Size(210, 57)
        Me.gbPeriodo.TabIndex = 4
        Me.gbPeriodo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFechaFin
        '
        '
        '
        '
        Me.txtFechaFin.DropDownCalendar.Name = ""
        Me.txtFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaFin.Location = New System.Drawing.Point(108, 31)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.txtFechaFin.TabIndex = 6
        Me.txtFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.DropDownCalendar.Name = ""
        Me.txtFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaInicio.Location = New System.Drawing.Point(7, 31)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(95, 20)
        Me.txtFechaInicio.TabIndex = 5
        Me.txtFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(108, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 15)
        Me.Label6.TabIndex = 153
        Me.Label6.Text = "Fecha Fin"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 15)
        Me.Label5.TabIndex = 152
        Me.Label5.Text = "Fecha Inicio"
        '
        'gbNumero
        '
        Me.gbNumero.Controls.Add(Me.txtNumero)
        Me.gbNumero.Location = New System.Drawing.Point(6, 110)
        Me.gbNumero.Name = "gbNumero"
        Me.gbNumero.Size = New System.Drawing.Size(124, 57)
        Me.gbNumero.TabIndex = 7
        Me.gbNumero.Text = "Numero Factura"
        Me.gbNumero.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(8, 23)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(109, 20)
        Me.txtNumero.TabIndex = 8
        '
        'gbEmbarque
        '
        Me.gbEmbarque.Controls.Add(Me.txtEmbarque)
        Me.gbEmbarque.Location = New System.Drawing.Point(6, 110)
        Me.gbEmbarque.Name = "gbEmbarque"
        Me.gbEmbarque.Size = New System.Drawing.Size(144, 57)
        Me.gbEmbarque.TabIndex = 14
        Me.gbEmbarque.Text = "Código de Embarque"
        Me.gbEmbarque.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtEmbarque
        '
        Me.txtEmbarque.Location = New System.Drawing.Point(8, 23)
        Me.txtEmbarque.Name = "txtEmbarque"
        Me.txtEmbarque.Size = New System.Drawing.Size(127, 20)
        Me.txtEmbarque.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 15)
        Me.Label10.TabIndex = 138
        Me.Label10.Text = "Moneda"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.Location = New System.Drawing.Point(13, 31)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(59, 20)
        Me.cmbMoneda.TabIndex = 10
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.Label10)
        Me.gbMoneda.Controls.Add(Me.cmbMoneda)
        Me.gbMoneda.Location = New System.Drawing.Point(221, 110)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(85, 57)
        Me.gbMoneda.TabIndex = 9
        Me.gbMoneda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.cmbIdCliente)
        Me.gbProveedor.Controls.Add(Me.Label3)
        Me.gbProveedor.Location = New System.Drawing.Point(6, 237)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(300, 45)
        Me.gbProveedor.TabIndex = 14
        Me.gbProveedor.Text = "Proveedor"
        Me.gbProveedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbIdCliente
        '
        Me.cmbIdCliente.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdCliente_DesignTimeLayout.LayoutString = resources.GetString("cmbIdCliente_DesignTimeLayout.LayoutString")
        Me.cmbIdCliente.DesignTimeLayout = cmbIdCliente_DesignTimeLayout
        Me.cmbIdCliente.Location = New System.Drawing.Point(74, 16)
        Me.cmbIdCliente.Name = "cmbIdCliente"
        Me.cmbIdCliente.SelectedIndex = -1
        Me.cmbIdCliente.SelectedItem = Nothing
        Me.cmbIdCliente.Size = New System.Drawing.Size(187, 20)
        Me.cmbIdCliente.TabIndex = 15
        Me.cmbIdCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Proveedor :"
        '
        'gbOrdenar
        '
        Me.gbOrdenar.Controls.Add(Me.rbFechaIngreso)
        Me.gbOrdenar.Controls.Add(Me.rbNroIngreso)
        Me.gbOrdenar.Location = New System.Drawing.Point(6, 302)
        Me.gbOrdenar.Name = "gbOrdenar"
        Me.gbOrdenar.Size = New System.Drawing.Size(300, 41)
        Me.gbOrdenar.TabIndex = 17
        Me.gbOrdenar.Text = "Ordenar"
        Me.gbOrdenar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbFechaIngreso
        '
        Me.rbFechaIngreso.AutoSize = True
        Me.rbFechaIngreso.Location = New System.Drawing.Point(160, 15)
        Me.rbFechaIngreso.Name = "rbFechaIngreso"
        Me.rbFechaIngreso.Size = New System.Drawing.Size(93, 17)
        Me.rbFechaIngreso.TabIndex = 51
        Me.rbFechaIngreso.Text = "Fecha Ingreso"
        Me.rbFechaIngreso.UseVisualStyleBackColor = True
        '
        'rbNroIngreso
        '
        Me.rbNroIngreso.AutoSize = True
        Me.rbNroIngreso.Checked = True
        Me.rbNroIngreso.Location = New System.Drawing.Point(55, 15)
        Me.rbNroIngreso.Name = "rbNroIngreso"
        Me.rbNroIngreso.Size = New System.Drawing.Size(80, 17)
        Me.rbNroIngreso.TabIndex = 50
        Me.rbNroIngreso.TabStop = True
        Me.rbNroIngreso.Text = "Nro Ingreso"
        Me.rbNroIngreso.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(9, 390)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Size = New System.Drawing.Size(46, 26)
        Me.dgvDatos.TabIndex = 19
        Me.dgvDatos.Visible = False
        '
        'btnAceptarE
        '
        Me.btnAceptarE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarE.Image = Global.SIGECOM.My.Resources.Resources.excel_ico
        Me.btnAceptarE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarE.Location = New System.Drawing.Point(61, 348)
        Me.btnAceptarE.Name = "btnAceptarE"
        Me.btnAceptarE.Size = New System.Drawing.Size(78, 30)
        Me.btnAceptarE.TabIndex = 18
        Me.btnAceptarE.Text = "Aceptar"
        Me.btnAceptarE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarE.UseVisualStyleBackColor = True
        '
        'gbFlete
        '
        Me.gbFlete.Controls.Add(Me.cbFlete)
        Me.gbFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFlete.Location = New System.Drawing.Point(6, 343)
        Me.gbFlete.Name = "gbFlete"
        Me.gbFlete.Size = New System.Drawing.Size(133, 35)
        Me.gbFlete.TabIndex = 20
        Me.gbFlete.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbFlete
        '
        Me.cbFlete.AutoSize = True
        Me.cbFlete.Location = New System.Drawing.Point(18, 12)
        Me.cbFlete.Name = "cbFlete"
        Me.cbFlete.Size = New System.Drawing.Size(100, 17)
        Me.cbFlete.TabIndex = 0
        Me.cbFlete.Text = "Mostrar Flete"
        Me.cbFlete.UseVisualStyleBackColor = True
        '
        'gbNroIng
        '
        Me.gbNroIng.Controls.Add(Me.txtNroIng)
        Me.gbNroIng.Location = New System.Drawing.Point(6, 239)
        Me.gbNroIng.Name = "gbNroIng"
        Me.gbNroIng.Size = New System.Drawing.Size(124, 57)
        Me.gbNroIng.TabIndex = 21
        Me.gbNroIng.Text = "Nro Ing."
        Me.gbNroIng.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNroIng
        '
        Me.txtNroIng.Location = New System.Drawing.Point(8, 23)
        Me.txtNroIng.Name = "txtNroIng"
        Me.txtNroIng.Size = New System.Drawing.Size(109, 20)
        Me.txtNroIng.TabIndex = 8
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(296, 288)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(21, 18)
        Me.DataGridView1.TabIndex = 111
        Me.DataGridView1.Visible = False
        '
        'gbExportarExcel
        '
        Me.gbExportarExcel.Controls.Add(Me.cbExportarExcel)
        Me.gbExportarExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExportarExcel.Location = New System.Drawing.Point(6, 343)
        Me.gbExportarExcel.Name = "gbExportarExcel"
        Me.gbExportarExcel.Size = New System.Drawing.Size(133, 35)
        Me.gbExportarExcel.TabIndex = 112
        Me.gbExportarExcel.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbExportarExcel
        '
        Me.cbExportarExcel.AutoSize = True
        Me.cbExportarExcel.Location = New System.Drawing.Point(18, 12)
        Me.cbExportarExcel.Name = "cbExportarExcel"
        Me.cbExportarExcel.Size = New System.Drawing.Size(108, 17)
        Me.cbExportarExcel.TabIndex = 0
        Me.cbExportarExcel.Text = "Exportar Excel"
        Me.cbExportarExcel.UseVisualStyleBackColor = True
        '
        'frmReporteImport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(313, 399)
        Me.Controls.Add(Me.gbExportarExcel)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.gbNroIng)
        Me.Controls.Add(Me.gbNumero)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbFlete)
        Me.Controls.Add(Me.gbEmbarque)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnAceptarE)
        Me.Controls.Add(Me.gbOrdenar)
        Me.Controls.Add(Me.gbProveedor)
        Me.Controls.Add(Me.gbPeriodo)
        Me.Controls.Add(Me.UiGroupBox11)
        Me.Controls.Add(Me.gbAlmacenes)
        Me.Controls.Add(Me.gbMoneda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importaciones"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox11.ResumeLayout(False)
        CType(Me.gbAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAlmacenes.ResumeLayout(False)
        Me.gbAlmacenes.PerformLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPeriodo.ResumeLayout(False)
        Me.gbPeriodo.PerformLayout()
        CType(Me.gbNumero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNumero.ResumeLayout(False)
        Me.gbNumero.PerformLayout()
        CType(Me.gbEmbarque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEmbarque.ResumeLayout(False)
        Me.gbEmbarque.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.cmbIdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbOrdenar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenar.ResumeLayout(False)
        Me.gbOrdenar.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbFlete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFlete.ResumeLayout(False)
        Me.gbFlete.PerformLayout()
        CType(Me.gbNroIng, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNroIng.ResumeLayout(False)
        Me.gbNroIng.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbExportarExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportarExcel.ResumeLayout(False)
        Me.gbExportarExcel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox11 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumen As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbRegistro As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbAlmacenes As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents gbPeriodo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbNumero As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbMoneda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbRegistroProveedor As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cmbIdCliente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbOrdenar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbNroIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents rbFechaIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents rbEmbarque As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbEmbarque As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptarE As System.Windows.Forms.Button
    Friend WithEvents rbRegistroUnidad As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbFlete As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbFlete As System.Windows.Forms.CheckBox
    Friend WithEvents rbPreciovsCosto As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbComparacionCabDet As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbNroIng As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtNroIng As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents gbExportarExcel As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbExportarExcel As CheckBox
End Class
