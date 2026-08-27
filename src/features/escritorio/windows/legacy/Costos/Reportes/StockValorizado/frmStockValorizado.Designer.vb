<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockValorizado
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
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMov_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockValorizado))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gpAlmacenes = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.gbOpciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbStockActual = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbSaldoInicio = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbStockFecha = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbTipStock = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbCeros = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbNegativos = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPositivos = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbSinCeros = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbFecha = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbTipoReporte = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbRepResumen = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbRepTotalGeneral = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbIndicadores = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbDetalle = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbTotalGeneralAnt = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbGerencial = New Janus.Windows.EditControls.UIRadioButton()
        Me.ckLibro = New Janus.Windows.EditControls.UICheckBox()
        Me.gbRubro = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbAgrupacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbPorProveedor = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPorMarca = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPorClase = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPorRubros = New Janus.Windows.EditControls.UIRadioButton()
        Me.dgvGerencial = New System.Windows.Forms.DataGridView()
        Me.gbExportar = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExportar = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPantalla = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbMovimiento = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbCodMov = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpAlmacenes.SuspendLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpciones.SuspendLayout()
        CType(Me.gbTipStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipStock.SuspendLayout()
        CType(Me.gbFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFecha.SuspendLayout()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoReporte.SuspendLayout()
        CType(Me.gbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRubro.SuspendLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbAgrupacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgrupacion.SuspendLayout()
        CType(Me.dgvGerencial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportar.SuspendLayout()
        CType(Me.gbMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMovimiento.SuspendLayout()
        CType(Me.cmbCodMov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gpAlmacenes
        '
        Me.gpAlmacenes.Controls.Add(Me.cbAlmacen)
        Me.gpAlmacenes.Controls.Add(Me.cbOficina)
        Me.gpAlmacenes.Controls.Add(Me.Label2)
        Me.gpAlmacenes.Controls.Add(Me.Label1)
        Me.gpAlmacenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpAlmacenes.Location = New System.Drawing.Point(145, 9)
        Me.gpAlmacenes.Name = "gpAlmacenes"
        Me.gpAlmacenes.Size = New System.Drawing.Size(321, 62)
        Me.gpAlmacenes.TabIndex = 5
        Me.gpAlmacenes.Text = "Almacenes"
        Me.gpAlmacenes.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(67, 37)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(248, 20)
        Me.cbAlmacen.TabIndex = 3
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(67, 15)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(161, 20)
        Me.cbOficina.TabIndex = 2
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Almacen :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Oficina :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "A la Fecha :"
        '
        'cbFecha
        '
        '
        '
        '
        Me.cbFecha.DropDownCalendar.Name = ""
        Me.cbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecha.Location = New System.Drawing.Point(84, 11)
        Me.cbFecha.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(93, 20)
        Me.cbFecha.TabIndex = 7
        Me.cbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.rbStockActual)
        Me.gbOpciones.Controls.Add(Me.rbSaldoInicio)
        Me.gbOpciones.Controls.Add(Me.rbStockFecha)
        Me.gbOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(9, 8)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(131, 98)
        Me.gbOpciones.TabIndex = 8
        Me.gbOpciones.Text = "Opciones"
        Me.gbOpciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbStockActual
        '
        Me.rbStockActual.Location = New System.Drawing.Point(7, 68)
        Me.rbStockActual.Name = "rbStockActual"
        Me.rbStockActual.Size = New System.Drawing.Size(111, 16)
        Me.rbStockActual.TabIndex = 2
        Me.rbStockActual.Text = "Stock Actual"
        Me.rbStockActual.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbSaldoInicio
        '
        Me.rbSaldoInicio.Location = New System.Drawing.Point(7, 46)
        Me.rbSaldoInicio.Name = "rbSaldoInicio"
        Me.rbSaldoInicio.Size = New System.Drawing.Size(118, 14)
        Me.rbSaldoInicio.TabIndex = 1
        Me.rbSaldoInicio.Text = "Saldos de Inicio"
        Me.rbSaldoInicio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbStockFecha
        '
        Me.rbStockFecha.Checked = True
        Me.rbStockFecha.Location = New System.Drawing.Point(7, 22)
        Me.rbStockFecha.Name = "rbStockFecha"
        Me.rbStockFecha.Size = New System.Drawing.Size(123, 14)
        Me.rbStockFecha.TabIndex = 0
        Me.rbStockFecha.TabStop = True
        Me.rbStockFecha.Text = "Stock a la Fecha"
        Me.rbStockFecha.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbTipStock
        '
        Me.gbTipStock.Controls.Add(Me.rbCeros)
        Me.gbTipStock.Controls.Add(Me.rbNegativos)
        Me.gbTipStock.Controls.Add(Me.rbPositivos)
        Me.gbTipStock.Controls.Add(Me.rbSinCeros)
        Me.gbTipStock.Controls.Add(Me.rbTodos)
        Me.gbTipStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipStock.Location = New System.Drawing.Point(339, 77)
        Me.gbTipStock.Name = "gbTipStock"
        Me.gbTipStock.Size = New System.Drawing.Size(127, 118)
        Me.gbTipStock.TabIndex = 9
        Me.gbTipStock.Text = "Tipo Stock"
        Me.gbTipStock.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbCeros
        '
        Me.rbCeros.Location = New System.Drawing.Point(9, 95)
        Me.rbCeros.Name = "rbCeros"
        Me.rbCeros.Size = New System.Drawing.Size(107, 16)
        Me.rbCeros.TabIndex = 4
        Me.rbCeros.Text = "Con Ceros"
        Me.rbCeros.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbNegativos
        '
        Me.rbNegativos.Location = New System.Drawing.Point(9, 75)
        Me.rbNegativos.Name = "rbNegativos"
        Me.rbNegativos.Size = New System.Drawing.Size(109, 15)
        Me.rbNegativos.TabIndex = 3
        Me.rbNegativos.Text = "Negativos"
        Me.rbNegativos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPositivos
        '
        Me.rbPositivos.Location = New System.Drawing.Point(9, 55)
        Me.rbPositivos.Name = "rbPositivos"
        Me.rbPositivos.Size = New System.Drawing.Size(98, 15)
        Me.rbPositivos.TabIndex = 2
        Me.rbPositivos.Text = "Positivos"
        Me.rbPositivos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbSinCeros
        '
        Me.rbSinCeros.Location = New System.Drawing.Point(9, 37)
        Me.rbSinCeros.Name = "rbSinCeros"
        Me.rbSinCeros.Size = New System.Drawing.Size(111, 14)
        Me.rbSinCeros.TabIndex = 1
        Me.rbSinCeros.Text = "Todos sin Ceros"
        Me.rbSinCeros.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbTodos
        '
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(9, 18)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(103, 14)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(153, 330)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 27)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(238, 330)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 27)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbFecha
        '
        Me.gbFecha.Controls.Add(Me.cbFecha)
        Me.gbFecha.Controls.Add(Me.Label3)
        Me.gbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFecha.Location = New System.Drawing.Point(148, 75)
        Me.gbFecha.Name = "gbFecha"
        Me.gbFecha.Size = New System.Drawing.Size(182, 35)
        Me.gbFecha.TabIndex = 12
        Me.gbFecha.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbTipoReporte
        '
        Me.gbTipoReporte.Controls.Add(Me.rbRepResumen)
        Me.gbTipoReporte.Controls.Add(Me.rbRepTotalGeneral)
        Me.gbTipoReporte.Controls.Add(Me.rbIndicadores)
        Me.gbTipoReporte.Controls.Add(Me.rbDetalle)
        Me.gbTipoReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoReporte.Location = New System.Drawing.Point(9, 112)
        Me.gbTipoReporte.Name = "gbTipoReporte"
        Me.gbTipoReporte.Size = New System.Drawing.Size(131, 129)
        Me.gbTipoReporte.TabIndex = 13
        Me.gbTipoReporte.Text = "Tipo Reporte"
        Me.gbTipoReporte.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbRepResumen
        '
        Me.rbRepResumen.Location = New System.Drawing.Point(8, 74)
        Me.rbRepResumen.Name = "rbRepResumen"
        Me.rbRepResumen.Size = New System.Drawing.Size(105, 16)
        Me.rbRepResumen.TabIndex = 21
        Me.rbRepResumen.Text = "Resumen"
        Me.rbRepResumen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbRepTotalGeneral
        '
        Me.rbRepTotalGeneral.Location = New System.Drawing.Point(8, 46)
        Me.rbRepTotalGeneral.Name = "rbRepTotalGeneral"
        Me.rbRepTotalGeneral.Size = New System.Drawing.Size(105, 16)
        Me.rbRepTotalGeneral.TabIndex = 20
        Me.rbRepTotalGeneral.Text = "Total General"
        Me.rbRepTotalGeneral.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbIndicadores
        '
        Me.rbIndicadores.Location = New System.Drawing.Point(8, 102)
        Me.rbIndicadores.Name = "rbIndicadores"
        Me.rbIndicadores.Size = New System.Drawing.Size(105, 16)
        Me.rbIndicadores.TabIndex = 19
        Me.rbIndicadores.Text = "Indicador"
        Me.rbIndicadores.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbDetalle
        '
        Me.rbDetalle.Checked = True
        Me.rbDetalle.Location = New System.Drawing.Point(8, 20)
        Me.rbDetalle.Name = "rbDetalle"
        Me.rbDetalle.Size = New System.Drawing.Size(71, 14)
        Me.rbDetalle.TabIndex = 0
        Me.rbDetalle.TabStop = True
        Me.rbDetalle.Text = "Detalle"
        Me.rbDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbTotalGeneralAnt
        '
        Me.rbTotalGeneralAnt.Enabled = False
        Me.rbTotalGeneralAnt.Location = New System.Drawing.Point(147, 281)
        Me.rbTotalGeneralAnt.Name = "rbTotalGeneralAnt"
        Me.rbTotalGeneralAnt.Size = New System.Drawing.Size(105, 16)
        Me.rbTotalGeneralAnt.TabIndex = 2
        Me.rbTotalGeneralAnt.Text = "Total General Ant"
        Me.rbTotalGeneralAnt.Visible = False
        Me.rbTotalGeneralAnt.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbGerencial
        '
        Me.rbGerencial.Enabled = False
        Me.rbGerencial.Location = New System.Drawing.Point(147, 263)
        Me.rbGerencial.Name = "rbGerencial"
        Me.rbGerencial.Size = New System.Drawing.Size(63, 16)
        Me.rbGerencial.TabIndex = 18
        Me.rbGerencial.Text = "Gerencial"
        Me.rbGerencial.Visible = False
        Me.rbGerencial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckLibro
        '
        Me.ckLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLibro.Location = New System.Drawing.Point(165, 144)
        Me.ckLibro.Name = "ckLibro"
        Me.ckLibro.Size = New System.Drawing.Size(152, 18)
        Me.ckLibro.TabIndex = 15
        Me.ckLibro.Text = "Impresion para el Libro"
        Me.ckLibro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbRubro
        '
        Me.gbRubro.Controls.Add(Me.cmbCodRub)
        Me.gbRubro.Controls.Add(Me.Label4)
        Me.gbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRubro.Location = New System.Drawing.Point(147, 180)
        Me.gbRubro.Name = "gbRubro"
        Me.gbRubro.Size = New System.Drawing.Size(182, 36)
        Me.gbRubro.TabIndex = 16
        Me.gbRubro.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(81, 11)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(96, 20)
        Me.cmbCodRub.TabIndex = 7
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Rubro :"
        '
        'gbAgrupacion
        '
        Me.gbAgrupacion.Controls.Add(Me.rbPorProveedor)
        Me.gbAgrupacion.Controls.Add(Me.rbPorMarca)
        Me.gbAgrupacion.Controls.Add(Me.rbPorClase)
        Me.gbAgrupacion.Controls.Add(Me.rbPorRubros)
        Me.gbAgrupacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAgrupacion.Location = New System.Drawing.Point(339, 201)
        Me.gbAgrupacion.Name = "gbAgrupacion"
        Me.gbAgrupacion.Size = New System.Drawing.Size(127, 105)
        Me.gbAgrupacion.TabIndex = 17
        Me.gbAgrupacion.Text = "Agrupado por:"
        Me.gbAgrupacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbPorProveedor
        '
        Me.rbPorProveedor.Location = New System.Drawing.Point(9, 82)
        Me.rbPorProveedor.Name = "rbPorProveedor"
        Me.rbPorProveedor.Size = New System.Drawing.Size(105, 16)
        Me.rbPorProveedor.TabIndex = 4
        Me.rbPorProveedor.Text = "Por Proveedor"
        Me.rbPorProveedor.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPorMarca
        '
        Me.rbPorMarca.Location = New System.Drawing.Point(9, 60)
        Me.rbPorMarca.Name = "rbPorMarca"
        Me.rbPorMarca.Size = New System.Drawing.Size(105, 16)
        Me.rbPorMarca.TabIndex = 3
        Me.rbPorMarca.Text = "Por Marca"
        Me.rbPorMarca.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPorClase
        '
        Me.rbPorClase.Location = New System.Drawing.Point(9, 39)
        Me.rbPorClase.Name = "rbPorClase"
        Me.rbPorClase.Size = New System.Drawing.Size(105, 16)
        Me.rbPorClase.TabIndex = 2
        Me.rbPorClase.Text = "Por Clase"
        Me.rbPorClase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPorRubros
        '
        Me.rbPorRubros.Checked = True
        Me.rbPorRubros.Location = New System.Drawing.Point(9, 19)
        Me.rbPorRubros.Name = "rbPorRubros"
        Me.rbPorRubros.Size = New System.Drawing.Size(100, 14)
        Me.rbPorRubros.TabIndex = 0
        Me.rbPorRubros.TabStop = True
        Me.rbPorRubros.Text = "Por Rubros"
        Me.rbPorRubros.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dgvGerencial
        '
        Me.dgvGerencial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGerencial.Location = New System.Drawing.Point(238, 261)
        Me.dgvGerencial.Name = "dgvGerencial"
        Me.dgvGerencial.Size = New System.Drawing.Size(72, 34)
        Me.dgvGerencial.TabIndex = 18
        Me.dgvGerencial.Visible = False
        '
        'gbExportar
        '
        Me.gbExportar.Controls.Add(Me.rbExportar)
        Me.gbExportar.Controls.Add(Me.rbPantalla)
        Me.gbExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExportar.Location = New System.Drawing.Point(8, 247)
        Me.gbExportar.Name = "gbExportar"
        Me.gbExportar.Size = New System.Drawing.Size(131, 59)
        Me.gbExportar.TabIndex = 19
        Me.gbExportar.Text = "Exportar"
        Me.gbExportar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExportar
        '
        Me.rbExportar.Location = New System.Drawing.Point(9, 36)
        Me.rbExportar.Name = "rbExportar"
        Me.rbExportar.Size = New System.Drawing.Size(105, 16)
        Me.rbExportar.TabIndex = 3
        Me.rbExportar.Text = "Exportar"
        Me.rbExportar.Visible = False
        Me.rbExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPantalla
        '
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(9, 16)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(71, 14)
        Me.rbPantalla.TabIndex = 1
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbMovimiento
        '
        Me.gbMovimiento.Controls.Add(Me.cmbCodMov)
        Me.gbMovimiento.Controls.Add(Me.Label5)
        Me.gbMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMovimiento.Location = New System.Drawing.Point(148, 217)
        Me.gbMovimiento.Name = "gbMovimiento"
        Me.gbMovimiento.Size = New System.Drawing.Size(182, 36)
        Me.gbMovimiento.TabIndex = 20
        Me.gbMovimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbCodMov
        '
        Me.cmbCodMov.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMov_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMov_DesignTimeLayout.LayoutString")
        Me.cmbCodMov.DesignTimeLayout = cmbCodMov_DesignTimeLayout
        Me.cmbCodMov.Location = New System.Drawing.Point(89, 11)
        Me.cmbCodMov.Name = "cmbCodMov"
        Me.cmbCodMov.SelectedIndex = -1
        Me.cmbCodMov.SelectedItem = Nothing
        Me.cmbCodMov.Size = New System.Drawing.Size(87, 20)
        Me.cmbCodMov.TabIndex = 21
        Me.cmbCodMov.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Movimiento :"
        '
        'frmStockValorizado
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(487, 378)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.rbGerencial)
        Me.Controls.Add(Me.gbExportar)
        Me.Controls.Add(Me.rbTotalGeneralAnt)
        Me.Controls.Add(Me.dgvGerencial)
        Me.Controls.Add(Me.gbAgrupacion)
        Me.Controls.Add(Me.gbRubro)
        Me.Controls.Add(Me.ckLibro)
        Me.Controls.Add(Me.gbTipoReporte)
        Me.Controls.Add(Me.gbFecha)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbTipStock)
        Me.Controls.Add(Me.gbOpciones)
        Me.Controls.Add(Me.gpAlmacenes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStockValorizado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Reporte de Stock Valorizado"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpAlmacenes.ResumeLayout(False)
        Me.gpAlmacenes.PerformLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpciones.ResumeLayout(False)
        CType(Me.gbTipStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipStock.ResumeLayout(False)
        CType(Me.gbFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFecha.ResumeLayout(False)
        Me.gbFecha.PerformLayout()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoReporte.ResumeLayout(False)
        CType(Me.gbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRubro.ResumeLayout(False)
        Me.gbRubro.PerformLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbAgrupacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgrupacion.ResumeLayout(False)
        CType(Me.dgvGerencial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportar.ResumeLayout(False)
        CType(Me.gbMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMovimiento.ResumeLayout(False)
        Me.gbMovimiento.PerformLayout()
        CType(Me.cmbCodMov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gpAlmacenes As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbOpciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbStockActual As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbSaldoInicio As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbStockFecha As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbTipStock As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbCeros As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbNegativos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPositivos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbSinCeros As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents gbFecha As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbTipoReporte As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTotalGeneralAnt As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDetalle As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents ckLibro As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents gbRubro As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbAgrupacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPorClase As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPorRubros As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPorMarca As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbGerencial As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents dgvGerencial As System.Windows.Forms.DataGridView
    Friend WithEvents gbExportar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExportar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPantalla As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPorProveedor As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbIndicadores As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbMovimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMov As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents rbRepTotalGeneral As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbRepResumen As Janus.Windows.EditControls.UIRadioButton
End Class
