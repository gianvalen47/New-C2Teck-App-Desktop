<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepTomaInventario
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
        Me.components = New System.ComponentModel.Container
        Dim cmbModMer_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbTipMot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbIdClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepTomaInventario))
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.rbExportarCodBarra = New System.Windows.Forms.RadioButton
        Me.rbPantalla = New System.Windows.Forms.RadioButton
        Me.rbExportExcel = New System.Windows.Forms.RadioButton
        Me.cmbModMer = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbTipMot = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.rbTodosUbi = New System.Windows.Forms.RadioButton
        Me.rbUbi = New System.Windows.Forms.RadioButton
        Me.rbSinUbi = New System.Windows.Forms.RadioButton
        Me.txtUbiMer = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbIdClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbUbicacion = New System.Windows.Forms.CheckBox
        Me.rbConStock = New System.Windows.Forms.RadioButton
        Me.rbFisico = New System.Windows.Forms.RadioButton
        Me.rbSinStock = New System.Windows.Forms.RadioButton
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.txtAplicacion = New System.Windows.Forms.TextBox
        Me.rbAplicacion = New System.Windows.Forms.RadioButton
        Me.btnBuscarAplicacion = New System.Windows.Forms.Button
        Me.rbMarca = New System.Windows.Forms.RadioButton
        Me.txtMarca = New System.Windows.Forms.TextBox
        Me.btnBuscaMarca = New System.Windows.Forms.Button
        Me.rbbajomaximo = New System.Windows.Forms.RadioButton
        Me.rbSobFal = New System.Windows.Forms.RadioButton
        Me.rbtodos = New System.Windows.Forms.RadioButton
        Me.rbbajominimo = New System.Windows.Forms.RadioButton
        Me.rbnegativos = New System.Windows.Forms.RadioButton
        Me.rbpositivos = New System.Windows.Forms.RadioButton
        Me.rbceros = New System.Windows.Forms.RadioButton
        Me.rbsinceros = New System.Windows.Forms.RadioButton
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.gbOrdenar = New Janus.Windows.EditControls.UIGroupBox
        Me.gbMostrarStock = New Janus.Windows.EditControls.UIGroupBox
        Me.gbTipoStock = New Janus.Windows.EditControls.UIGroupBox
        Me.gbAplicacion = New Janus.Windows.EditControls.UIGroupBox
        Me.gbMarca = New Janus.Windows.EditControls.UIGroupBox
        Me.gbUbicacion = New Janus.Windows.EditControls.UIGroupBox
        Me.gbInventario = New Janus.Windows.EditControls.UIGroupBox
        Me.gbMercaderia = New Janus.Windows.EditControls.UIGroupBox
        Me.rbReman = New System.Windows.Forms.RadioButton
        Me.rbTodosMer = New System.Windows.Forms.RadioButton
        Me.gbExportar = New Janus.Windows.EditControls.UIGroupBox
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbModMer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipMot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdClase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbOrdenar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenar.SuspendLayout()
        CType(Me.gbMostrarStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMostrarStock.SuspendLayout()
        CType(Me.gbTipoStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoStock.SuspendLayout()
        CType(Me.gbAplicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAplicacion.SuspendLayout()
        CType(Me.gbMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMarca.SuspendLayout()
        CType(Me.gbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbUbicacion.SuspendLayout()
        CType(Me.gbInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbInventario.SuspendLayout()
        CType(Me.gbMercaderia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMercaderia.SuspendLayout()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportar.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'rbExportarCodBarra
        '
        Me.rbExportarCodBarra.AutoSize = True
        Me.rbExportarCodBarra.Location = New System.Drawing.Point(18, 67)
        Me.rbExportarCodBarra.Name = "rbExportarCodBarra"
        Me.rbExportarCodBarra.Size = New System.Drawing.Size(173, 17)
        Me.rbExportarCodBarra.TabIndex = 61
        Me.rbExportarCodBarra.Text = "Exportar Codigo de Barras"
        Me.rbExportarCodBarra.UseVisualStyleBackColor = True
        '
        'rbPantalla
        '
        Me.rbPantalla.AutoSize = True
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(18, 21)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(71, 17)
        Me.rbPantalla.TabIndex = 48
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.UseVisualStyleBackColor = True
        '
        'rbExportExcel
        '
        Me.rbExportExcel.AutoSize = True
        Me.rbExportExcel.Location = New System.Drawing.Point(18, 44)
        Me.rbExportExcel.Name = "rbExportExcel"
        Me.rbExportExcel.Size = New System.Drawing.Size(56, 17)
        Me.rbExportExcel.TabIndex = 47
        Me.rbExportExcel.Text = "Excel"
        Me.rbExportExcel.UseVisualStyleBackColor = True
        '
        'cmbModMer
        '
        Me.cmbModMer.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbModMer_DesignTimeLayout.LayoutString = resources.GetString("cmbModMer_DesignTimeLayout.LayoutString")
        Me.cmbModMer.DesignTimeLayout = cmbModMer_DesignTimeLayout
        Me.cmbModMer.Location = New System.Drawing.Point(97, 177)
        Me.cmbModMer.Name = "cmbModMer"
        Me.cmbModMer.SelectedIndex = -1
        Me.cmbModMer.SelectedItem = Nothing
        Me.cmbModMer.Size = New System.Drawing.Size(140, 20)
        Me.cmbModMer.TabIndex = 58
        Me.cmbModMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 15)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Modelo:"
        '
        'cmbTipMot
        '
        Me.cmbTipMot.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipMot_DesignTimeLayout.LayoutString = resources.GetString("cmbTipMot_DesignTimeLayout.LayoutString")
        Me.cmbTipMot.DesignTimeLayout = cmbTipMot_DesignTimeLayout
        Me.cmbTipMot.Location = New System.Drawing.Point(97, 141)
        Me.cmbTipMot.Name = "cmbTipMot"
        Me.cmbTipMot.SelectedIndex = -1
        Me.cmbTipMot.SelectedItem = Nothing
        Me.cmbTipMot.Size = New System.Drawing.Size(142, 20)
        Me.cmbTipMot.TabIndex = 56
        Me.cmbTipMot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Tipo Motor:"
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(97, 213)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(121, 20)
        Me.cmbCodRub.TabIndex = 54
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 15)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Rubro:"
        '
        'rbTodosUbi
        '
        Me.rbTodosUbi.AutoSize = True
        Me.rbTodosUbi.Checked = True
        Me.rbTodosUbi.Location = New System.Drawing.Point(22, 19)
        Me.rbTodosUbi.Name = "rbTodosUbi"
        Me.rbTodosUbi.Size = New System.Drawing.Size(60, 17)
        Me.rbTodosUbi.TabIndex = 13
        Me.rbTodosUbi.TabStop = True
        Me.rbTodosUbi.Text = "Todos"
        Me.rbTodosUbi.UseVisualStyleBackColor = True
        '
        'rbUbi
        '
        Me.rbUbi.AutoSize = True
        Me.rbUbi.Location = New System.Drawing.Point(22, 65)
        Me.rbUbi.Name = "rbUbi"
        Me.rbUbi.Size = New System.Drawing.Size(105, 17)
        Me.rbUbi.TabIndex = 12
        Me.rbUbi.TabStop = True
        Me.rbUbi.Text = "Por Ubicacion"
        Me.rbUbi.UseVisualStyleBackColor = True
        '
        'rbSinUbi
        '
        Me.rbSinUbi.AutoSize = True
        Me.rbSinUbi.Location = New System.Drawing.Point(22, 42)
        Me.rbSinUbi.Name = "rbSinUbi"
        Me.rbSinUbi.Size = New System.Drawing.Size(104, 17)
        Me.rbSinUbi.TabIndex = 11
        Me.rbSinUbi.TabStop = True
        Me.rbSinUbi.Text = "Sin Ubicación"
        Me.rbSinUbi.UseVisualStyleBackColor = True
        '
        'txtUbiMer
        '
        Me.txtUbiMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUbiMer.Location = New System.Drawing.Point(22, 88)
        Me.txtUbiMer.Name = "txtUbiMer"
        Me.txtUbiMer.ReadOnly = True
        Me.txtUbiMer.Size = New System.Drawing.Size(89, 20)
        Me.txtUbiMer.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 15)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Clase:"
        '
        'cmbIdClase
        '
        Me.cmbIdClase.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdClase_DesignTimeLayout.LayoutString = resources.GetString("cmbIdClase_DesignTimeLayout.LayoutString")
        Me.cmbIdClase.DesignTimeLayout = cmbIdClase_DesignTimeLayout
        Me.cmbIdClase.Location = New System.Drawing.Point(97, 249)
        Me.cmbIdClase.Name = "cmbIdClase"
        Me.cmbIdClase.SelectedIndex = -1
        Me.cmbIdClase.SelectedItem = Nothing
        Me.cmbIdClase.Size = New System.Drawing.Size(120, 20)
        Me.cmbIdClase.TabIndex = 44
        Me.cmbIdClase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(458, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "{ Tipo de Stock }"
        '
        'cbUbicacion
        '
        Me.cbUbicacion.AutoSize = True
        Me.cbUbicacion.Location = New System.Drawing.Point(28, 19)
        Me.cbUbicacion.Name = "cbUbicacion"
        Me.cbUbicacion.Size = New System.Drawing.Size(106, 17)
        Me.cbUbicacion.TabIndex = 44
        Me.cbUbicacion.Text = "Por Ubicación"
        Me.cbUbicacion.UseVisualStyleBackColor = True
        '
        'rbConStock
        '
        Me.rbConStock.AutoSize = True
        Me.rbConStock.Checked = True
        Me.rbConStock.Location = New System.Drawing.Point(37, 16)
        Me.rbConStock.Name = "rbConStock"
        Me.rbConStock.Size = New System.Drawing.Size(84, 17)
        Me.rbConStock.TabIndex = 13
        Me.rbConStock.TabStop = True
        Me.rbConStock.Text = "Con Stock"
        Me.rbConStock.UseVisualStyleBackColor = True
        '
        'rbFisico
        '
        Me.rbFisico.AutoSize = True
        Me.rbFisico.Location = New System.Drawing.Point(37, 62)
        Me.rbFisico.Name = "rbFisico"
        Me.rbFisico.Size = New System.Drawing.Size(60, 17)
        Me.rbFisico.TabIndex = 12
        Me.rbFisico.TabStop = True
        Me.rbFisico.Text = "Físico"
        Me.rbFisico.UseVisualStyleBackColor = True
        '
        'rbSinStock
        '
        Me.rbSinStock.AutoSize = True
        Me.rbSinStock.Location = New System.Drawing.Point(37, 39)
        Me.rbSinStock.Name = "rbSinStock"
        Me.rbSinStock.Size = New System.Drawing.Size(80, 17)
        Me.rbSinStock.TabIndex = 11
        Me.rbSinStock.TabStop = True
        Me.rbSinStock.Text = "Sin Stock"
        Me.rbSinStock.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Location = New System.Drawing.Point(134, 33)
        Me.txtFecha.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(93, 20)
        Me.txtFecha.TabIndex = 38
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtAplicacion
        '
        Me.txtAplicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAplicacion.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtAplicacion.Location = New System.Drawing.Point(12, 40)
        Me.txtAplicacion.MaxLength = 3
        Me.txtAplicacion.Name = "txtAplicacion"
        Me.txtAplicacion.ReadOnly = True
        Me.txtAplicacion.Size = New System.Drawing.Size(115, 20)
        Me.txtAplicacion.TabIndex = 29
        Me.txtAplicacion.TabStop = False
        '
        'rbAplicacion
        '
        Me.rbAplicacion.AutoSize = True
        Me.rbAplicacion.Checked = True
        Me.rbAplicacion.Location = New System.Drawing.Point(14, 19)
        Me.rbAplicacion.Name = "rbAplicacion"
        Me.rbAplicacion.Size = New System.Drawing.Size(117, 17)
        Me.rbAplicacion.TabIndex = 33
        Me.rbAplicacion.TabStop = True
        Me.rbAplicacion.Text = "Toda Aplicación"
        Me.rbAplicacion.UseVisualStyleBackColor = True
        '
        'btnBuscarAplicacion
        '
        Me.btnBuscarAplicacion.Image = CType(resources.GetObject("btnBuscarAplicacion.Image"), System.Drawing.Image)
        Me.btnBuscarAplicacion.Location = New System.Drawing.Point(127, 39)
        Me.btnBuscarAplicacion.Name = "btnBuscarAplicacion"
        Me.btnBuscarAplicacion.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarAplicacion.TabIndex = 30
        Me.btnBuscarAplicacion.UseVisualStyleBackColor = True
        '
        'rbMarca
        '
        Me.rbMarca.AutoSize = True
        Me.rbMarca.Checked = True
        Me.rbMarca.Location = New System.Drawing.Point(14, 19)
        Me.rbMarca.Name = "rbMarca"
        Me.rbMarca.Size = New System.Drawing.Size(93, 17)
        Me.rbMarca.TabIndex = 32
        Me.rbMarca.TabStop = True
        Me.rbMarca.Text = "Toda Marca"
        Me.rbMarca.UseVisualStyleBackColor = True
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMarca.Location = New System.Drawing.Point(12, 40)
        Me.txtMarca.MaxLength = 3
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(115, 20)
        Me.txtMarca.TabIndex = 27
        Me.txtMarca.TabStop = False
        '
        'btnBuscaMarca
        '
        Me.btnBuscaMarca.Image = CType(resources.GetObject("btnBuscaMarca.Image"), System.Drawing.Image)
        Me.btnBuscaMarca.Location = New System.Drawing.Point(127, 38)
        Me.btnBuscaMarca.Name = "btnBuscaMarca"
        Me.btnBuscaMarca.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscaMarca.TabIndex = 28
        Me.btnBuscaMarca.UseVisualStyleBackColor = True
        '
        'rbbajomaximo
        '
        Me.rbbajomaximo.AutoSize = True
        Me.rbbajomaximo.Location = New System.Drawing.Point(22, 163)
        Me.rbbajomaximo.Name = "rbbajomaximo"
        Me.rbbajomaximo.Size = New System.Drawing.Size(110, 17)
        Me.rbbajomaximo.TabIndex = 12
        Me.rbbajomaximo.TabStop = True
        Me.rbbajomaximo.Text = "Bajo el Máximo"
        Me.rbbajomaximo.UseVisualStyleBackColor = True
        '
        'rbSobFal
        '
        Me.rbSobFal.AutoSize = True
        Me.rbSobFal.Location = New System.Drawing.Point(22, 187)
        Me.rbSobFal.Name = "rbSobFal"
        Me.rbSobFal.Size = New System.Drawing.Size(108, 17)
        Me.rbSobFal.TabIndex = 11
        Me.rbSobFal.TabStop = True
        Me.rbSobFal.Text = "Sobra. y Falta."
        Me.rbSobFal.UseVisualStyleBackColor = True
        '
        'rbtodos
        '
        Me.rbtodos.AutoSize = True
        Me.rbtodos.Checked = True
        Me.rbtodos.Location = New System.Drawing.Point(22, 19)
        Me.rbtodos.Name = "rbtodos"
        Me.rbtodos.Size = New System.Drawing.Size(60, 17)
        Me.rbtodos.TabIndex = 10
        Me.rbtodos.TabStop = True
        Me.rbtodos.Text = "Todos"
        Me.rbtodos.UseVisualStyleBackColor = True
        '
        'rbbajominimo
        '
        Me.rbbajominimo.AutoSize = True
        Me.rbbajominimo.Location = New System.Drawing.Point(22, 139)
        Me.rbbajominimo.Name = "rbbajominimo"
        Me.rbbajominimo.Size = New System.Drawing.Size(109, 17)
        Me.rbbajominimo.TabIndex = 9
        Me.rbbajominimo.TabStop = True
        Me.rbbajominimo.Text = "Bajo el Mínimo"
        Me.rbbajominimo.UseVisualStyleBackColor = True
        '
        'rbnegativos
        '
        Me.rbnegativos.AutoSize = True
        Me.rbnegativos.Location = New System.Drawing.Point(22, 115)
        Me.rbnegativos.Name = "rbnegativos"
        Me.rbnegativos.Size = New System.Drawing.Size(82, 17)
        Me.rbnegativos.TabIndex = 8
        Me.rbnegativos.TabStop = True
        Me.rbnegativos.Text = "Negativos"
        Me.rbnegativos.UseVisualStyleBackColor = True
        '
        'rbpositivos
        '
        Me.rbpositivos.AutoSize = True
        Me.rbpositivos.Location = New System.Drawing.Point(22, 91)
        Me.rbpositivos.Name = "rbpositivos"
        Me.rbpositivos.Size = New System.Drawing.Size(76, 17)
        Me.rbpositivos.TabIndex = 7
        Me.rbpositivos.TabStop = True
        Me.rbpositivos.Text = "Positivos"
        Me.rbpositivos.UseVisualStyleBackColor = True
        '
        'rbceros
        '
        Me.rbceros.AutoSize = True
        Me.rbceros.Location = New System.Drawing.Point(22, 67)
        Me.rbceros.Name = "rbceros"
        Me.rbceros.Size = New System.Drawing.Size(57, 17)
        Me.rbceros.TabIndex = 6
        Me.rbceros.TabStop = True
        Me.rbceros.Text = "Ceros"
        Me.rbceros.UseVisualStyleBackColor = True
        '
        'rbsinceros
        '
        Me.rbsinceros.AutoSize = True
        Me.rbsinceros.Location = New System.Drawing.Point(22, 43)
        Me.rbsinceros.Name = "rbsinceros"
        Me.rbsinceros.Size = New System.Drawing.Size(116, 17)
        Me.rbsinceros.TabIndex = 5
        Me.rbsinceros.TabStop = True
        Me.rbsinceros.Text = "Todos sin Ceros"
        Me.rbsinceros.UseVisualStyleBackColor = True
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(97, 69)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(129, 20)
        Me.cmbOficinas.TabIndex = 7
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stock a la Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Oficina:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Almacén:"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(97, 105)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(129, 20)
        Me.cmbIdLocacion.TabIndex = 8
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 393)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(50, 27)
        Me.DataGridView1.TabIndex = 60
        Me.DataGridView1.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(221, 394)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 26)
        Me.btnAceptar.TabIndex = 26
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
        Me.btnCancelar.Location = New System.Drawing.Point(322, 394)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 26)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbOrdenar
        '
        Me.gbOrdenar.Controls.Add(Me.cbUbicacion)
        Me.gbOrdenar.Location = New System.Drawing.Point(260, 22)
        Me.gbOrdenar.Name = "gbOrdenar"
        Me.gbOrdenar.Size = New System.Drawing.Size(160, 43)
        Me.gbOrdenar.TabIndex = 60
        Me.gbOrdenar.Text = "Ordenar"
        Me.gbOrdenar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbMostrarStock
        '
        Me.gbMostrarStock.Controls.Add(Me.rbConStock)
        Me.gbMostrarStock.Controls.Add(Me.rbFisico)
        Me.gbMostrarStock.Controls.Add(Me.rbSinStock)
        Me.gbMostrarStock.Location = New System.Drawing.Point(260, 71)
        Me.gbMostrarStock.Name = "gbMostrarStock"
        Me.gbMostrarStock.Size = New System.Drawing.Size(160, 86)
        Me.gbMostrarStock.TabIndex = 61
        Me.gbMostrarStock.Text = "Mostrar Stock"
        Me.gbMostrarStock.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbTipoStock
        '
        Me.gbTipoStock.Controls.Add(Me.rbbajomaximo)
        Me.gbTipoStock.Controls.Add(Me.rbtodos)
        Me.gbTipoStock.Controls.Add(Me.rbSobFal)
        Me.gbTipoStock.Controls.Add(Me.rbsinceros)
        Me.gbTipoStock.Controls.Add(Me.rbceros)
        Me.gbTipoStock.Controls.Add(Me.rbbajominimo)
        Me.gbTipoStock.Controls.Add(Me.rbpositivos)
        Me.gbTipoStock.Controls.Add(Me.rbnegativos)
        Me.gbTipoStock.Location = New System.Drawing.Point(445, 32)
        Me.gbTipoStock.Name = "gbTipoStock"
        Me.gbTipoStock.Size = New System.Drawing.Size(150, 220)
        Me.gbTipoStock.TabIndex = 61
        Me.gbTipoStock.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbAplicacion
        '
        Me.gbAplicacion.Controls.Add(Me.txtAplicacion)
        Me.gbAplicacion.Controls.Add(Me.rbAplicacion)
        Me.gbAplicacion.Controls.Add(Me.btnBuscarAplicacion)
        Me.gbAplicacion.Location = New System.Drawing.Point(260, 163)
        Me.gbAplicacion.Name = "gbAplicacion"
        Me.gbAplicacion.Size = New System.Drawing.Size(160, 68)
        Me.gbAplicacion.TabIndex = 61
        Me.gbAplicacion.Text = "Buscar Aplicación"
        Me.gbAplicacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbMarca
        '
        Me.gbMarca.Controls.Add(Me.rbMarca)
        Me.gbMarca.Controls.Add(Me.txtMarca)
        Me.gbMarca.Controls.Add(Me.btnBuscaMarca)
        Me.gbMarca.Location = New System.Drawing.Point(260, 237)
        Me.gbMarca.Name = "gbMarca"
        Me.gbMarca.Size = New System.Drawing.Size(160, 68)
        Me.gbMarca.TabIndex = 61
        Me.gbMarca.Text = "Buscar Marca"
        Me.gbMarca.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbUbicacion
        '
        Me.gbUbicacion.Controls.Add(Me.rbTodosUbi)
        Me.gbUbicacion.Controls.Add(Me.txtUbiMer)
        Me.gbUbicacion.Controls.Add(Me.rbUbi)
        Me.gbUbicacion.Controls.Add(Me.rbSinUbi)
        Me.gbUbicacion.Location = New System.Drawing.Point(445, 260)
        Me.gbUbicacion.Name = "gbUbicacion"
        Me.gbUbicacion.Size = New System.Drawing.Size(150, 116)
        Me.gbUbicacion.TabIndex = 61
        Me.gbUbicacion.Text = "Ubicación"
        Me.gbUbicacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbInventario
        '
        Me.gbInventario.Controls.Add(Me.gbMercaderia)
        Me.gbInventario.Controls.Add(Me.gbExportar)
        Me.gbInventario.Controls.Add(Me.gbMarca)
        Me.gbInventario.Controls.Add(Me.cmbModMer)
        Me.gbInventario.Controls.Add(Me.gbUbicacion)
        Me.gbInventario.Controls.Add(Me.Label8)
        Me.gbInventario.Controls.Add(Me.gbAplicacion)
        Me.gbInventario.Controls.Add(Me.cmbTipMot)
        Me.gbInventario.Controls.Add(Me.gbTipoStock)
        Me.gbInventario.Controls.Add(Me.Label6)
        Me.gbInventario.Controls.Add(Me.gbMostrarStock)
        Me.gbInventario.Controls.Add(Me.cmbCodRub)
        Me.gbInventario.Controls.Add(Me.Label7)
        Me.gbInventario.Controls.Add(Me.Label4)
        Me.gbInventario.Controls.Add(Me.gbOrdenar)
        Me.gbInventario.Controls.Add(Me.Label5)
        Me.gbInventario.Controls.Add(Me.Label1)
        Me.gbInventario.Controls.Add(Me.cmbIdClase)
        Me.gbInventario.Controls.Add(Me.cmbIdLocacion)
        Me.gbInventario.Controls.Add(Me.txtFecha)
        Me.gbInventario.Controls.Add(Me.Label3)
        Me.gbInventario.Controls.Add(Me.cmbOficinas)
        Me.gbInventario.Controls.Add(Me.Label2)
        Me.gbInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInventario.Location = New System.Drawing.Point(6, 3)
        Me.gbInventario.Name = "gbInventario"
        Me.gbInventario.Size = New System.Drawing.Size(603, 384)
        Me.gbInventario.TabIndex = 61
        Me.gbInventario.Text = "INVENTARIO"
        Me.gbInventario.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'gbMercaderia
        '
        Me.gbMercaderia.Controls.Add(Me.rbReman)
        Me.gbMercaderia.Controls.Add(Me.rbTodosMer)
        Me.gbMercaderia.Location = New System.Drawing.Point(260, 311)
        Me.gbMercaderia.Name = "gbMercaderia"
        Me.gbMercaderia.Size = New System.Drawing.Size(160, 65)
        Me.gbMercaderia.TabIndex = 63
        Me.gbMercaderia.Text = "Buscar Mercadería"
        Me.gbMercaderia.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbReman
        '
        Me.rbReman.AutoSize = True
        Me.rbReman.Location = New System.Drawing.Point(14, 40)
        Me.rbReman.Name = "rbReman"
        Me.rbReman.Size = New System.Drawing.Size(125, 17)
        Me.rbReman.TabIndex = 1
        Me.rbReman.Text = "Remanofacturado"
        Me.rbReman.UseVisualStyleBackColor = True
        '
        'rbTodosMer
        '
        Me.rbTodosMer.AutoSize = True
        Me.rbTodosMer.Checked = True
        Me.rbTodosMer.Location = New System.Drawing.Point(14, 17)
        Me.rbTodosMer.Name = "rbTodosMer"
        Me.rbTodosMer.Size = New System.Drawing.Size(60, 17)
        Me.rbTodosMer.TabIndex = 0
        Me.rbTodosMer.TabStop = True
        Me.rbTodosMer.Text = "Todos"
        Me.rbTodosMer.UseVisualStyleBackColor = True
        '
        'gbExportar
        '
        Me.gbExportar.Controls.Add(Me.rbExportarCodBarra)
        Me.gbExportar.Controls.Add(Me.rbPantalla)
        Me.gbExportar.Controls.Add(Me.rbExportExcel)
        Me.gbExportar.Location = New System.Drawing.Point(9, 279)
        Me.gbExportar.Name = "gbExportar"
        Me.gbExportar.Size = New System.Drawing.Size(219, 97)
        Me.gbExportar.TabIndex = 62
        Me.gbExportar.Text = "Exportar"
        Me.gbExportar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmRepTomaInventario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(615, 425)
        Me.Controls.Add(Me.gbInventario)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepTomaInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Toma de Inventario"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbModMer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipMot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdClase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbOrdenar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenar.ResumeLayout(False)
        Me.gbOrdenar.PerformLayout()
        CType(Me.gbMostrarStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMostrarStock.ResumeLayout(False)
        Me.gbMostrarStock.PerformLayout()
        CType(Me.gbTipoStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoStock.ResumeLayout(False)
        Me.gbTipoStock.PerformLayout()
        CType(Me.gbAplicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAplicacion.ResumeLayout(False)
        Me.gbAplicacion.PerformLayout()
        CType(Me.gbMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMarca.ResumeLayout(False)
        Me.gbMarca.PerformLayout()
        CType(Me.gbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbUbicacion.ResumeLayout(False)
        Me.gbUbicacion.PerformLayout()
        CType(Me.gbInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbInventario.ResumeLayout(False)
        Me.gbInventario.PerformLayout()
        CType(Me.gbMercaderia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMercaderia.ResumeLayout(False)
        Me.gbMercaderia.PerformLayout()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportar.ResumeLayout(False)
        Me.gbExportar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtUbiMer As System.Windows.Forms.TextBox
    Friend WithEvents txtAplicacion As System.Windows.Forms.TextBox
    Friend WithEvents rbAplicacion As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscarAplicacion As System.Windows.Forms.Button
    Friend WithEvents rbMarca As System.Windows.Forms.RadioButton
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscaMarca As System.Windows.Forms.Button
    Friend WithEvents rbtodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbbajominimo As System.Windows.Forms.RadioButton
    Friend WithEvents rbnegativos As System.Windows.Forms.RadioButton
    Friend WithEvents rbpositivos As System.Windows.Forms.RadioButton
    Friend WithEvents rbceros As System.Windows.Forms.RadioButton
    Friend WithEvents rbsinceros As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents rbFisico As System.Windows.Forms.RadioButton
    Friend WithEvents rbSinStock As System.Windows.Forms.RadioButton
    Friend WithEvents rbConStock As System.Windows.Forms.RadioButton
    Friend WithEvents rbSobFal As System.Windows.Forms.RadioButton
    Friend WithEvents cbUbicacion As System.Windows.Forms.CheckBox
    Friend WithEvents cmbIdClase As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbTodosUbi As System.Windows.Forms.RadioButton
    Friend WithEvents rbUbi As System.Windows.Forms.RadioButton
    Friend WithEvents rbSinUbi As System.Windows.Forms.RadioButton
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTipMot As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbModMer As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents rbPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rbExportExcel As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents rbExportarCodBarra As System.Windows.Forms.RadioButton
    Friend WithEvents rbbajomaximo As System.Windows.Forms.RadioButton
    Friend WithEvents gbMostrarStock As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbOrdenar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbMarca As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbAplicacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbTipoStock As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbInventario As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbExportar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbUbicacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbMercaderia As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbReman As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodosMer As System.Windows.Forms.RadioButton
End Class
