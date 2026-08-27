<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepInventario
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMov_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepInventario))
        Dim dgvRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipMot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCiclos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodMov = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnComprasAnuales = New System.Windows.Forms.Button()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.cbRubro = New System.Windows.Forms.CheckBox()
        Me.gbRubro = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvRubro = New Janus.Windows.GridEX.GridEX()
        Me.gbMostrarStock = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDisponible = New System.Windows.Forms.RadioButton()
        Me.rbFisico = New System.Windows.Forms.RadioButton()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbBuscarProveedor = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbIdClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbTipMot = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbInvGeneralExcel = New System.Windows.Forms.RadioButton()
        Me.rbPantalla = New System.Windows.Forms.RadioButton()
        Me.rbExportExcel = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUbiMer = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtAplicacion = New System.Windows.Forms.TextBox()
        Me.rbAplicacion = New System.Windows.Forms.RadioButton()
        Me.btnBuscarAplicacion = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbMarca = New System.Windows.Forms.RadioButton()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.btnBuscaMarca = New System.Windows.Forms.Button()
        Me.cmbCiclos = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.grTipoStock = New System.Windows.Forms.GroupBox()
        Me.rbbajomaximo = New System.Windows.Forms.RadioButton()
        Me.rbtodos = New System.Windows.Forms.RadioButton()
        Me.rbbajominimo = New System.Windows.Forms.RadioButton()
        Me.rbnegativos = New System.Windows.Forms.RadioButton()
        Me.rbpositivos = New System.Windows.Forms.RadioButton()
        Me.rbceros = New System.Windows.Forms.RadioButton()
        Me.rbsinceros = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbComprometidos = New System.Windows.Forms.RadioButton()
        Me.rbTotalizado = New System.Windows.Forms.RadioButton()
        Me.rbDetallado = New System.Windows.Forms.RadioButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRubro.SuspendLayout()
        CType(Me.dgvRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbMostrarStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMostrarStock.SuspendLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.cmbIdClase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipMot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cmbCiclos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grTipoStock.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stock a la Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Oficina:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Almacén:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "{ Ciclos }"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(118, 69)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(172, 20)
        Me.cmbOficinas.TabIndex = 7
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(118, 99)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(258, 20)
        Me.cmbIdLocacion.TabIndex = 8
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodMov
        '
        Me.cmbCodMov.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMov_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMov_DesignTimeLayout.LayoutString")
        Me.cmbCodMov.DesignTimeLayout = cmbCodMov_DesignTimeLayout
        Me.cmbCodMov.Location = New System.Drawing.Point(118, 219)
        Me.cmbCodMov.Name = "cmbCodMov"
        Me.cmbCodMov.SelectedIndex = -1
        Me.cmbCodMov.SelectedItem = Nothing
        Me.cmbCodMov.Size = New System.Drawing.Size(140, 20)
        Me.cmbCodMov.TabIndex = 21
        Me.cmbCodMov.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 221)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 16)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "{ Tipo Mov }"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.cmbUnidad)
        Me.gbDatos.Controls.Add(Me.Label11)
        Me.gbDatos.Controls.Add(Me.btnComprasAnuales)
        Me.gbDatos.Controls.Add(Me.DataGridView4)
        Me.gbDatos.Controls.Add(Me.DataGridView3)
        Me.gbDatos.Controls.Add(Me.DataGridView2)
        Me.gbDatos.Controls.Add(Me.cbRubro)
        Me.gbDatos.Controls.Add(Me.gbRubro)
        Me.gbDatos.Controls.Add(Me.gbMostrarStock)
        Me.gbDatos.Controls.Add(Me.gbProveedor)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.cmbIdClase)
        Me.gbDatos.Controls.Add(Me.cmbCodRub)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.cmbTipMot)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.GroupBox4)
        Me.gbDatos.Controls.Add(Me.DataGridView1)
        Me.gbDatos.Controls.Add(Me.txtFecha)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.txtUbiMer)
        Me.gbDatos.Controls.Add(Me.GroupBox3)
        Me.gbDatos.Controls.Add(Me.GroupBox2)
        Me.gbDatos.Controls.Add(Me.cmbCiclos)
        Me.gbDatos.Controls.Add(Me.grTipoStock)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.cmbOficinas)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.cmbCodMov)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.cmbIdLocacion)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(7, 53)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(699, 455)
        Me.gbDatos.TabIndex = 23
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Inventario"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(118, 40)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(229, 20)
        Me.cmbUnidad.TabIndex = 197
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 16)
        Me.Label11.TabIndex = 196
        Me.Label11.Text = "Unidad:"
        '
        'btnComprasAnuales
        '
        Me.btnComprasAnuales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComprasAnuales.Image = Global.SIGECOM.My.Resources.Resources.Compras_1
        Me.btnComprasAnuales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnComprasAnuales.Location = New System.Drawing.Point(403, 337)
        Me.btnComprasAnuales.Name = "btnComprasAnuales"
        Me.btnComprasAnuales.Size = New System.Drawing.Size(133, 28)
        Me.btnComprasAnuales.TabIndex = 195
        Me.btnComprasAnuales.Text = "Compras Anuales"
        Me.btnComprasAnuales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnComprasAnuales.UseVisualStyleBackColor = True
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(647, 347)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(44, 27)
        Me.DataGridView4.TabIndex = 194
        Me.DataGridView4.Visible = False
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(647, 314)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(44, 27)
        Me.DataGridView3.TabIndex = 193
        Me.DataGridView3.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(597, 314)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(44, 27)
        Me.DataGridView2.TabIndex = 192
        Me.DataGridView2.Visible = False
        '
        'cbRubro
        '
        Me.cbRubro.AutoSize = True
        Me.cbRubro.Location = New System.Drawing.Point(291, 132)
        Me.cbRubro.Name = "cbRubro"
        Me.cbRubro.Size = New System.Drawing.Size(137, 17)
        Me.cbRubro.TabIndex = 191
        Me.cbRubro.Text = "Seleccionar Rubros"
        Me.cbRubro.UseVisualStyleBackColor = True
        '
        'gbRubro
        '
        Me.gbRubro.Controls.Add(Me.dgvRubro)
        Me.gbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRubro.Location = New System.Drawing.Point(291, 155)
        Me.gbRubro.Name = "gbRubro"
        Me.gbRubro.Size = New System.Drawing.Size(227, 137)
        Me.gbRubro.TabIndex = 190
        Me.gbRubro.Visible = False
        Me.gbRubro.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvRubro
        '
        dgvRubro_DesignTimeLayout.LayoutString = resources.GetString("dgvRubro_DesignTimeLayout.LayoutString")
        Me.dgvRubro.DesignTimeLayout = dgvRubro_DesignTimeLayout
        Me.dgvRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvRubro.GroupByBoxVisible = False
        Me.dgvRubro.Location = New System.Drawing.Point(10, 13)
        Me.dgvRubro.Name = "dgvRubro"
        Me.dgvRubro.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvRubro.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvRubro.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvRubro.Size = New System.Drawing.Size(204, 116)
        Me.dgvRubro.TabIndex = 190
        Me.dgvRubro.TabStop = False
        Me.dgvRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbMostrarStock
        '
        Me.gbMostrarStock.Controls.Add(Me.rbDisponible)
        Me.gbMostrarStock.Controls.Add(Me.rbFisico)
        Me.gbMostrarStock.Location = New System.Drawing.Point(524, 245)
        Me.gbMostrarStock.Name = "gbMostrarStock"
        Me.gbMostrarStock.Size = New System.Drawing.Size(167, 63)
        Me.gbMostrarStock.TabIndex = 112
        Me.gbMostrarStock.Text = "Mostrar Stock"
        Me.gbMostrarStock.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDisponible
        '
        Me.rbDisponible.AutoSize = True
        Me.rbDisponible.Location = New System.Drawing.Point(43, 39)
        Me.rbDisponible.Name = "rbDisponible"
        Me.rbDisponible.Size = New System.Drawing.Size(84, 17)
        Me.rbDisponible.TabIndex = 14
        Me.rbDisponible.TabStop = True
        Me.rbDisponible.Text = "Disponible"
        Me.rbDisponible.UseVisualStyleBackColor = True
        '
        'rbFisico
        '
        Me.rbFisico.AutoSize = True
        Me.rbFisico.Checked = True
        Me.rbFisico.Location = New System.Drawing.Point(43, 19)
        Me.rbFisico.Name = "rbFisico"
        Me.rbFisico.Size = New System.Drawing.Size(60, 17)
        Me.rbFisico.TabIndex = 12
        Me.rbFisico.TabStop = True
        Me.rbFisico.Text = "Físico"
        Me.rbFisico.UseVisualStyleBackColor = True
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnBuscarProveedor)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.Label12)
        Me.gbProveedor.Controls.Add(Me.rbBuscarProveedor)
        Me.gbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProveedor.Location = New System.Drawing.Point(5, 313)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(380, 52)
        Me.gbProveedor.TabIndex = 111
        Me.gbProveedor.Text = "Buscar Proveedor"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(346, 25)
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
        Me.txtProveedor.Location = New System.Drawing.Point(80, 27)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(262, 20)
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
        Me.rbBuscarProveedor.Location = New System.Drawing.Point(168, 10)
        Me.rbBuscarProveedor.Name = "rbBuscarProveedor"
        Me.rbBuscarProveedor.Size = New System.Drawing.Size(117, 17)
        Me.rbBuscarProveedor.TabIndex = 17
        Me.rbBuscarProveedor.TabStop = False
        Me.rbBuscarProveedor.Text = "Todo Proveedor"
        Me.rbBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 191)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 16)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Clase:"
        '
        'cmbIdClase
        '
        Me.cmbIdClase.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdClase_DesignTimeLayout.LayoutString = resources.GetString("cmbIdClase_DesignTimeLayout.LayoutString")
        Me.cmbIdClase.DesignTimeLayout = cmbIdClase_DesignTimeLayout
        Me.cmbIdClase.Location = New System.Drawing.Point(118, 189)
        Me.cmbIdClase.Name = "cmbIdClase"
        Me.cmbIdClase.SelectedIndex = -1
        Me.cmbIdClase.SelectedItem = Nothing
        Me.cmbIdClase.Size = New System.Drawing.Size(120, 20)
        Me.cmbIdClase.TabIndex = 54
        Me.cmbIdClase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(118, 129)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(138, 20)
        Me.cmbCodRub.TabIndex = 9
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 16)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Rubro:"
        '
        'cmbTipMot
        '
        Me.cmbTipMot.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipMot_DesignTimeLayout.LayoutString = resources.GetString("cmbTipMot_DesignTimeLayout.LayoutString")
        Me.cmbTipMot.DesignTimeLayout = cmbTipMot_DesignTimeLayout
        Me.cmbTipMot.Location = New System.Drawing.Point(118, 279)
        Me.cmbTipMot.Name = "cmbTipMot"
        Me.cmbTipMot.SelectedIndex = -1
        Me.cmbTipMot.SelectedItem = Nothing
        Me.cmbTipMot.Size = New System.Drawing.Size(142, 20)
        Me.cmbTipMot.TabIndex = 52
        Me.cmbTipMot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 281)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 16)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "{ Tipo Motor }"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbInvGeneralExcel)
        Me.GroupBox4.Controls.Add(Me.rbPantalla)
        Me.GroupBox4.Controls.Add(Me.rbExportExcel)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(403, 374)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(216, 74)
        Me.GroupBox4.TabIndex = 50
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Exportar"
        '
        'rbInvGeneralExcel
        '
        Me.rbInvGeneralExcel.AutoSize = True
        Me.rbInvGeneralExcel.Location = New System.Drawing.Point(11, 48)
        Me.rbInvGeneralExcel.Name = "rbInvGeneralExcel"
        Me.rbInvGeneralExcel.Size = New System.Drawing.Size(195, 20)
        Me.rbInvGeneralExcel.TabIndex = 49
        Me.rbInvGeneralExcel.Text = "Inventario General Excel"
        Me.rbInvGeneralExcel.UseVisualStyleBackColor = True
        '
        'rbPantalla
        '
        Me.rbPantalla.AutoSize = True
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(11, 22)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(83, 20)
        Me.rbPantalla.TabIndex = 48
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.UseVisualStyleBackColor = True
        '
        'rbExportExcel
        '
        Me.rbExportExcel.AutoSize = True
        Me.rbExportExcel.Location = New System.Drawing.Point(142, 22)
        Me.rbExportExcel.Name = "rbExportExcel"
        Me.rbExportExcel.Size = New System.Drawing.Size(64, 20)
        Me.rbExportExcel.TabIndex = 47
        Me.rbExportExcel.Text = "Excel"
        Me.rbExportExcel.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(263, 15)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(25, 20)
        Me.DataGridView1.TabIndex = 49
        Me.DataGridView1.Visible = False
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Location = New System.Drawing.Point(139, 15)
        Me.txtFecha.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(93, 20)
        Me.txtFecha.TabIndex = 38
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 16)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Ubicación:"
        '
        'txtUbiMer
        '
        Me.txtUbiMer.Location = New System.Drawing.Point(118, 160)
        Me.txtUbiMer.Name = "txtUbiMer"
        Me.txtUbiMer.Size = New System.Drawing.Size(140, 20)
        Me.txtUbiMer.TabIndex = 36
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAplicacion)
        Me.GroupBox3.Controls.Add(Me.rbAplicacion)
        Me.GroupBox3.Controls.Add(Me.btnBuscarAplicacion)
        Me.GroupBox3.Location = New System.Drawing.Point(205, 374)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 74)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar Aplicación"
        '
        'txtAplicacion
        '
        Me.txtAplicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAplicacion.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtAplicacion.Location = New System.Drawing.Point(11, 43)
        Me.txtAplicacion.MaxLength = 3
        Me.txtAplicacion.Name = "txtAplicacion"
        Me.txtAplicacion.ReadOnly = True
        Me.txtAplicacion.Size = New System.Drawing.Size(128, 20)
        Me.txtAplicacion.TabIndex = 29
        Me.txtAplicacion.TabStop = False
        '
        'rbAplicacion
        '
        Me.rbAplicacion.AutoSize = True
        Me.rbAplicacion.Checked = True
        Me.rbAplicacion.Location = New System.Drawing.Point(18, 21)
        Me.rbAplicacion.Name = "rbAplicacion"
        Me.rbAplicacion.Size = New System.Drawing.Size(117, 17)
        Me.rbAplicacion.TabIndex = 33
        Me.rbAplicacion.TabStop = True
        Me.rbAplicacion.Text = "Toda Aplicación"
        Me.rbAplicacion.UseVisualStyleBackColor = True
        '
        'btnBuscarAplicacion
        '
        Me.btnBuscarAplicacion.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarAplicacion.Location = New System.Drawing.Point(145, 42)
        Me.btnBuscarAplicacion.Name = "btnBuscarAplicacion"
        Me.btnBuscarAplicacion.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarAplicacion.TabIndex = 30
        Me.btnBuscarAplicacion.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbMarca)
        Me.GroupBox2.Controls.Add(Me.txtMarca)
        Me.GroupBox2.Controls.Add(Me.btnBuscaMarca)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 374)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 74)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar Marca"
        '
        'rbMarca
        '
        Me.rbMarca.AutoSize = True
        Me.rbMarca.Checked = True
        Me.rbMarca.Location = New System.Drawing.Point(16, 22)
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
        Me.txtMarca.Location = New System.Drawing.Point(11, 45)
        Me.txtMarca.MaxLength = 3
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(115, 20)
        Me.txtMarca.TabIndex = 27
        Me.txtMarca.TabStop = False
        '
        'btnBuscaMarca
        '
        Me.btnBuscaMarca.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscaMarca.Location = New System.Drawing.Point(126, 44)
        Me.btnBuscaMarca.Name = "btnBuscaMarca"
        Me.btnBuscaMarca.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscaMarca.TabIndex = 28
        Me.btnBuscaMarca.UseVisualStyleBackColor = True
        '
        'cmbCiclos
        '
        Me.cmbCiclos.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCiclos_DesignTimeLayout.LayoutString = resources.GetString("cmbCiclos_DesignTimeLayout.LayoutString")
        Me.cmbCiclos.DesignTimeLayout = cmbCiclos_DesignTimeLayout
        Me.cmbCiclos.Location = New System.Drawing.Point(118, 249)
        Me.cmbCiclos.Name = "cmbCiclos"
        Me.cmbCiclos.SelectedIndex = -1
        Me.cmbCiclos.SelectedItem = Nothing
        Me.cmbCiclos.Size = New System.Drawing.Size(99, 20)
        Me.cmbCiclos.TabIndex = 31
        Me.cmbCiclos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grTipoStock
        '
        Me.grTipoStock.Controls.Add(Me.rbbajomaximo)
        Me.grTipoStock.Controls.Add(Me.rbtodos)
        Me.grTipoStock.Controls.Add(Me.rbbajominimo)
        Me.grTipoStock.Controls.Add(Me.rbnegativos)
        Me.grTipoStock.Controls.Add(Me.rbpositivos)
        Me.grTipoStock.Controls.Add(Me.rbceros)
        Me.grTipoStock.Controls.Add(Me.rbsinceros)
        Me.grTipoStock.Location = New System.Drawing.Point(524, 64)
        Me.grTipoStock.Name = "grTipoStock"
        Me.grTipoStock.Size = New System.Drawing.Size(167, 175)
        Me.grTipoStock.TabIndex = 26
        Me.grTipoStock.TabStop = False
        '
        'rbbajomaximo
        '
        Me.rbbajomaximo.AutoSize = True
        Me.rbbajomaximo.Location = New System.Drawing.Point(38, 150)
        Me.rbbajomaximo.Name = "rbbajomaximo"
        Me.rbbajomaximo.Size = New System.Drawing.Size(110, 17)
        Me.rbbajomaximo.TabIndex = 11
        Me.rbbajomaximo.TabStop = True
        Me.rbbajomaximo.Text = "Bajo el Máximo"
        Me.rbbajomaximo.UseVisualStyleBackColor = True
        '
        'rbtodos
        '
        Me.rbtodos.AutoSize = True
        Me.rbtodos.Checked = True
        Me.rbtodos.Location = New System.Drawing.Point(38, 12)
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
        Me.rbbajominimo.Location = New System.Drawing.Point(38, 127)
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
        Me.rbnegativos.Location = New System.Drawing.Point(38, 104)
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
        Me.rbpositivos.Location = New System.Drawing.Point(38, 81)
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
        Me.rbceros.Location = New System.Drawing.Point(38, 58)
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
        Me.rbsinceros.Location = New System.Drawing.Point(38, 35)
        Me.rbsinceros.Name = "rbsinceros"
        Me.rbsinceros.Size = New System.Drawing.Size(116, 17)
        Me.rbsinceros.TabIndex = 5
        Me.rbsinceros.TabStop = True
        Me.rbsinceros.Text = "Todos sin Ceros"
        Me.rbsinceros.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(532, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "{ Tipo de Stock }"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(274, 518)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 28)
        Me.btnAceptar.TabIndex = 24
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
        Me.btnCancelar.Location = New System.Drawing.Point(360, 518)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 28)
        Me.btnCancelar.TabIndex = 25
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbComprometidos)
        Me.UiGroupBox1.Controls.Add(Me.rbTotalizado)
        Me.UiGroupBox1.Controls.Add(Me.rbDetallado)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(203, 8)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(319, 40)
        Me.UiGroupBox1.TabIndex = 112
        Me.UiGroupBox1.Text = "Tipo"
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbComprometidos
        '
        Me.rbComprometidos.AutoSize = True
        Me.rbComprometidos.Location = New System.Drawing.Point(200, 15)
        Me.rbComprometidos.Name = "rbComprometidos"
        Me.rbComprometidos.Size = New System.Drawing.Size(110, 17)
        Me.rbComprometidos.TabIndex = 16
        Me.rbComprometidos.Text = "Comprometidos"
        Me.rbComprometidos.UseVisualStyleBackColor = True
        '
        'rbTotalizado
        '
        Me.rbTotalizado.AutoSize = True
        Me.rbTotalizado.Location = New System.Drawing.Point(109, 15)
        Me.rbTotalizado.Name = "rbTotalizado"
        Me.rbTotalizado.Size = New System.Drawing.Size(77, 17)
        Me.rbTotalizado.TabIndex = 1
        Me.rbTotalizado.Text = "Resumen"
        Me.rbTotalizado.UseVisualStyleBackColor = True
        '
        'rbDetallado
        '
        Me.rbDetallado.AutoSize = True
        Me.rbDetallado.Checked = True
        Me.rbDetallado.Location = New System.Drawing.Point(10, 15)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(79, 17)
        Me.rbDetallado.TabIndex = 15
        Me.rbDetallado.TabStop = True
        Me.rbDetallado.Text = "Detallado"
        Me.rbDetallado.UseVisualStyleBackColor = True
        '
        'frmRepInventario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(715, 552)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Inventario"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRubro.ResumeLayout(False)
        CType(Me.dgvRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbMostrarStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMostrarStock.ResumeLayout(False)
        Me.gbMostrarStock.PerformLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.cmbIdClase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipMot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cmbCiclos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grTipoStock.ResumeLayout(False)
        Me.grTipoStock.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodMov As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grTipoStock As System.Windows.Forms.GroupBox
    Friend WithEvents rbbajominimo As System.Windows.Forms.RadioButton
    Friend WithEvents rbnegativos As System.Windows.Forms.RadioButton
    Friend WithEvents rbpositivos As System.Windows.Forms.RadioButton
    Friend WithEvents rbceros As System.Windows.Forms.RadioButton
    Friend WithEvents rbsinceros As System.Windows.Forms.RadioButton
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscaMarca As System.Windows.Forms.Button
    Friend WithEvents txtAplicacion As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarAplicacion As System.Windows.Forms.Button
    Friend WithEvents cmbCiclos As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents rbMarca As System.Windows.Forms.RadioButton
    Friend WithEvents rbAplicacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbtodos As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUbiMer As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rbExportExcel As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTipMot As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbIdClase As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents rbbajomaximo As System.Windows.Forms.RadioButton
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbBuscarProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents gbMostrarStock As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbDisponible As System.Windows.Forms.RadioButton
    Friend WithEvents rbFisico As System.Windows.Forms.RadioButton
    Friend WithEvents gbRubro As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvRubro As Janus.Windows.GridEX.GridEX
    Friend WithEvents cbRubro As CheckBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents rbInvGeneralExcel As RadioButton
    Friend WithEvents btnComprasAnuales As Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTotalizado As RadioButton
    Friend WithEvents rbDetallado As RadioButton
    Friend WithEvents rbComprometidos As RadioButton
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label11 As Label
End Class
