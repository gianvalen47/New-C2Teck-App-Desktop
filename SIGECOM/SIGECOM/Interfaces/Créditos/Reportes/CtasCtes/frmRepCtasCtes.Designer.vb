<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCtasCtes
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
        Dim cmbDocu_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCobrador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCtasCtes))
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbDocu = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCobrador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblCobrador = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.rcTodoCobrador = New System.Windows.Forms.CheckBox()
        Me.rcCliente = New System.Windows.Forms.CheckBox()
        Me.cbMoneda = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.biAceptar = New System.Windows.Forms.Button()
        Me.biCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbDocGeneral = New System.Windows.Forms.RadioButton()
        Me.rbDocJudicial = New System.Windows.Forms.RadioButton()
        Me.rbDocCliente = New System.Windows.Forms.RadioButton()
        Me.rbDocDocumento = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbPendientes = New System.Windows.Forms.RadioButton()
        Me.rbCancelados = New System.Windows.Forms.RadioButton()
        Me.rbResumen = New System.Windows.Forms.RadioButton()
        Me.rbDetallado = New System.Windows.Forms.RadioButton()
        Me.rbCliente = New System.Windows.Forms.RadioButton()
        Me.rbTotal = New System.Windows.Forms.RadioButton()
        Me.rbAscendente = New System.Windows.Forms.RadioButton()
        Me.rbDescendente = New System.Windows.Forms.RadioButton()
        Me.rbCastigos = New System.Windows.Forms.RadioButton()
        Me.rbCtasCtes = New System.Windows.Forms.RadioButton()
        Me.rbProvisiones = New System.Windows.Forms.RadioButton()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtBuscarCliente = New System.Windows.Forms.TextBox()
        Me.rbExportExcel = New System.Windows.Forms.RadioButton()
        Me.rbPantalla = New System.Windows.Forms.RadioButton()
        Me.rbXUnidadNegocio = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbCobrador = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbOrden = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbOrdenado = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox10 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbCliente = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCobrador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.gbCobrador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCobrador.SuspendLayout()
        CType(Me.gbOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrden.SuspendLayout()
        CType(Me.gbOrdenado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenado.SuspendLayout()
        CType(Me.UiGroupBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox10.SuspendLayout()
        CType(Me.gbCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(273, 21)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 32
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(71, 21)
        Me.cbFecInicio.MinDate = New Date(1992, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 31
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbDocu
        '
        Me.cmbDocu.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbDocu_DesignTimeLayout.LayoutString = resources.GetString("cmbDocu_DesignTimeLayout.LayoutString")
        Me.cmbDocu.DesignTimeLayout = cmbDocu_DesignTimeLayout
        Me.cmbDocu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDocu.Location = New System.Drawing.Point(15, 70)
        Me.cmbDocu.Name = "cmbDocu"
        Me.cmbDocu.SelectedIndex = -1
        Me.cmbDocu.SelectedItem = Nothing
        Me.cmbDocu.Size = New System.Drawing.Size(126, 20)
        Me.cmbDocu.TabIndex = 22
        Me.cmbDocu.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbDocu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCobrador
        '
        Me.cmbCobrador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCobrador_DesignTimeLayout.LayoutString = resources.GetString("cmbCobrador_DesignTimeLayout.LayoutString")
        Me.cmbCobrador.DesignTimeLayout = cmbCobrador_DesignTimeLayout
        Me.cmbCobrador.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbCobrador.Enabled = False
        Me.cmbCobrador.Location = New System.Drawing.Point(93, 32)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.SelectedIndex = -1
        Me.cmbCobrador.SelectedItem = Nothing
        Me.cmbCobrador.Size = New System.Drawing.Size(288, 20)
        Me.cmbCobrador.TabIndex = 104
        Me.cmbCobrador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCobrador
        '
        Me.lblCobrador.AutoSize = True
        Me.lblCobrador.BackColor = System.Drawing.SystemColors.Control
        Me.lblCobrador.Enabled = False
        Me.lblCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrador.Location = New System.Drawing.Point(10, 34)
        Me.lblCobrador.Name = "lblCobrador"
        Me.lblCobrador.Size = New System.Drawing.Size(81, 16)
        Me.lblCobrador.TabIndex = 103
        Me.lblCobrador.Text = "Cobrador :"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(17, 119)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(145, 20)
        Me.cmbOficinas.TabIndex = 107
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.BackColor = System.Drawing.SystemColors.Control
        Me.lblOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.Location = New System.Drawing.Point(14, 100)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(60, 16)
        Me.lblOficina.TabIndex = 105
        Me.lblOficina.Text = "Oficina:"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.BackColor = System.Drawing.SystemColors.Control
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(190, 100)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(72, 16)
        Me.lblAlmacen.TabIndex = 106
        Me.lblAlmacen.Text = "Almacén:"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(193, 119)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(196, 20)
        Me.cmbIdLocacion.TabIndex = 108
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodMon.Location = New System.Drawing.Point(13, 20)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(48, 20)
        Me.cmbCodMon.TabIndex = 109
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(288, 173)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(114, 20)
        Me.cmbEstado.TabIndex = 113
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(294, 152)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(61, 16)
        Me.lblEstado.TabIndex = 114
        Me.lblEstado.Text = "Estado:"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(135, 45)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(19, 22)
        Me.DataGridView1.TabIndex = 120
        Me.DataGridView1.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(114, 45)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(19, 22)
        Me.DataGridView2.TabIndex = 120
        Me.DataGridView2.Visible = False
        '
        'rcTodoCobrador
        '
        Me.rcTodoCobrador.AutoSize = True
        Me.rcTodoCobrador.BackColor = System.Drawing.SystemColors.Control
        Me.rcTodoCobrador.Checked = True
        Me.rcTodoCobrador.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rcTodoCobrador.Location = New System.Drawing.Point(177, 14)
        Me.rcTodoCobrador.Name = "rcTodoCobrador"
        Me.rcTodoCobrador.Size = New System.Drawing.Size(61, 17)
        Me.rcTodoCobrador.TabIndex = 105
        Me.rcTodoCobrador.Text = "Todos"
        Me.rcTodoCobrador.UseVisualStyleBackColor = False
        '
        'rcCliente
        '
        Me.rcCliente.AutoSize = True
        Me.rcCliente.BackColor = System.Drawing.SystemColors.Control
        Me.rcCliente.Checked = True
        Me.rcCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rcCliente.Location = New System.Drawing.Point(162, 13)
        Me.rcCliente.Name = "rcCliente"
        Me.rcCliente.Size = New System.Drawing.Size(61, 17)
        Me.rcCliente.TabIndex = 18
        Me.rcCliente.Text = "Todos"
        Me.rcCliente.UseVisualStyleBackColor = False
        '
        'cbMoneda
        '
        Me.cbMoneda.AutoSize = True
        Me.cbMoneda.Location = New System.Drawing.Point(70, 23)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(176, 17)
        Me.cbMoneda.TabIndex = 110
        Me.cbMoneda.Text = "Mantener Mon. de Emisión"
        Me.cbMoneda.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 16)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Unidad Negocio:"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(145, 72)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(160, 20)
        Me.cmbUnidad.TabIndex = 125
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'biAceptar
        '
        Me.biAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.biAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.biAceptar.Location = New System.Drawing.Point(213, 444)
        Me.biAceptar.Name = "biAceptar"
        Me.biAceptar.Size = New System.Drawing.Size(80, 29)
        Me.biAceptar.TabIndex = 126
        Me.biAceptar.Text = "Aceptar"
        Me.biAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.biAceptar.UseVisualStyleBackColor = True
        '
        'biCancelar
        '
        Me.biCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.biCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.biCancelar.Location = New System.Drawing.Point(299, 444)
        Me.biCancelar.Name = "biCancelar"
        Me.biCancelar.Size = New System.Drawing.Size(80, 29)
        Me.biCancelar.TabIndex = 127
        Me.biCancelar.TabStop = False
        Me.biCancelar.Text = "Cancelar"
        Me.biCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.biCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(237, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Al :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Del :"
        '
        'rbDocGeneral
        '
        Me.rbDocGeneral.AutoSize = True
        Me.rbDocGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDocGeneral.Location = New System.Drawing.Point(15, 121)
        Me.rbDocGeneral.Name = "rbDocGeneral"
        Me.rbDocGeneral.Size = New System.Drawing.Size(79, 17)
        Me.rbDocGeneral.TabIndex = 143
        Me.rbDocGeneral.Text = "Gerencial"
        Me.rbDocGeneral.UseVisualStyleBackColor = True
        '
        'rbDocJudicial
        '
        Me.rbDocJudicial.AutoSize = True
        Me.rbDocJudicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDocJudicial.Location = New System.Drawing.Point(15, 98)
        Me.rbDocJudicial.Name = "rbDocJudicial"
        Me.rbDocJudicial.Size = New System.Drawing.Size(68, 17)
        Me.rbDocJudicial.TabIndex = 142
        Me.rbDocJudicial.Text = "Judicial"
        Me.rbDocJudicial.UseVisualStyleBackColor = True
        '
        'rbDocCliente
        '
        Me.rbDocCliente.AutoSize = True
        Me.rbDocCliente.Checked = True
        Me.rbDocCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDocCliente.Location = New System.Drawing.Point(15, 24)
        Me.rbDocCliente.Name = "rbDocCliente"
        Me.rbDocCliente.Size = New System.Drawing.Size(70, 17)
        Me.rbDocCliente.TabIndex = 140
        Me.rbDocCliente.TabStop = True
        Me.rbDocCliente.Text = "Clientes"
        Me.rbDocCliente.UseVisualStyleBackColor = True
        '
        'rbDocDocumento
        '
        Me.rbDocDocumento.AutoSize = True
        Me.rbDocDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDocDocumento.Location = New System.Drawing.Point(15, 47)
        Me.rbDocDocumento.Name = "rbDocDocumento"
        Me.rbDocDocumento.Size = New System.Drawing.Size(89, 17)
        Me.rbDocDocumento.TabIndex = 141
        Me.rbDocDocumento.Text = "Documento"
        Me.rbDocDocumento.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.Location = New System.Drawing.Point(15, 65)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(60, 17)
        Me.rbTodos.TabIndex = 144
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbPendientes
        '
        Me.rbPendientes.AutoSize = True
        Me.rbPendientes.Checked = True
        Me.rbPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPendientes.Location = New System.Drawing.Point(15, 17)
        Me.rbPendientes.Name = "rbPendientes"
        Me.rbPendientes.Size = New System.Drawing.Size(88, 17)
        Me.rbPendientes.TabIndex = 142
        Me.rbPendientes.TabStop = True
        Me.rbPendientes.Text = "Pendientes"
        Me.rbPendientes.UseVisualStyleBackColor = True
        '
        'rbCancelados
        '
        Me.rbCancelados.AutoSize = True
        Me.rbCancelados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCancelados.Location = New System.Drawing.Point(15, 41)
        Me.rbCancelados.Name = "rbCancelados"
        Me.rbCancelados.Size = New System.Drawing.Size(85, 17)
        Me.rbCancelados.TabIndex = 143
        Me.rbCancelados.Text = "Cancelado"
        Me.rbCancelados.UseVisualStyleBackColor = True
        '
        'rbResumen
        '
        Me.rbResumen.AutoSize = True
        Me.rbResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbResumen.Location = New System.Drawing.Point(10, 46)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(77, 17)
        Me.rbResumen.TabIndex = 144
        Me.rbResumen.Text = "Resumen"
        Me.rbResumen.UseVisualStyleBackColor = True
        '
        'rbDetallado
        '
        Me.rbDetallado.AutoSize = True
        Me.rbDetallado.Checked = True
        Me.rbDetallado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDetallado.Location = New System.Drawing.Point(10, 22)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(79, 17)
        Me.rbDetallado.TabIndex = 143
        Me.rbDetallado.TabStop = True
        Me.rbDetallado.Text = "Detallado"
        Me.rbDetallado.UseVisualStyleBackColor = True
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCliente.Location = New System.Drawing.Point(13, 52)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(64, 17)
        Me.rbCliente.TabIndex = 147
        Me.rbCliente.Text = "Cliente"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'rbTotal
        '
        Me.rbTotal.AutoSize = True
        Me.rbTotal.Checked = True
        Me.rbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTotal.Location = New System.Drawing.Point(13, 29)
        Me.rbTotal.Name = "rbTotal"
        Me.rbTotal.Size = New System.Drawing.Size(54, 17)
        Me.rbTotal.TabIndex = 146
        Me.rbTotal.TabStop = True
        Me.rbTotal.Text = "Total"
        Me.rbTotal.UseVisualStyleBackColor = True
        '
        'rbAscendente
        '
        Me.rbAscendente.AutoSize = True
        Me.rbAscendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAscendente.Location = New System.Drawing.Point(12, 52)
        Me.rbAscendente.Name = "rbAscendente"
        Me.rbAscendente.Size = New System.Drawing.Size(92, 17)
        Me.rbAscendente.TabIndex = 145
        Me.rbAscendente.Text = "Ascendente"
        Me.rbAscendente.UseVisualStyleBackColor = True
        '
        'rbDescendente
        '
        Me.rbDescendente.AutoSize = True
        Me.rbDescendente.Checked = True
        Me.rbDescendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDescendente.Location = New System.Drawing.Point(12, 29)
        Me.rbDescendente.Name = "rbDescendente"
        Me.rbDescendente.Size = New System.Drawing.Size(100, 17)
        Me.rbDescendente.TabIndex = 144
        Me.rbDescendente.TabStop = True
        Me.rbDescendente.Text = "Descendente"
        Me.rbDescendente.UseVisualStyleBackColor = True
        '
        'rbCastigos
        '
        Me.rbCastigos.AutoSize = True
        Me.rbCastigos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCastigos.Location = New System.Drawing.Point(10, 64)
        Me.rbCastigos.Name = "rbCastigos"
        Me.rbCastigos.Size = New System.Drawing.Size(73, 17)
        Me.rbCastigos.TabIndex = 146
        Me.rbCastigos.Text = "Castigos"
        Me.rbCastigos.UseVisualStyleBackColor = True
        '
        'rbCtasCtes
        '
        Me.rbCtasCtes.AutoSize = True
        Me.rbCtasCtes.Checked = True
        Me.rbCtasCtes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCtasCtes.Location = New System.Drawing.Point(10, 18)
        Me.rbCtasCtes.Name = "rbCtasCtes"
        Me.rbCtasCtes.Size = New System.Drawing.Size(79, 17)
        Me.rbCtasCtes.TabIndex = 144
        Me.rbCtasCtes.TabStop = True
        Me.rbCtasCtes.Text = "Ctas Ctes"
        Me.rbCtasCtes.UseVisualStyleBackColor = True
        '
        'rbProvisiones
        '
        Me.rbProvisiones.AutoSize = True
        Me.rbProvisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProvisiones.Location = New System.Drawing.Point(10, 41)
        Me.rbProvisiones.Name = "rbProvisiones"
        Me.rbProvisiones.Size = New System.Drawing.Size(90, 17)
        Me.rbProvisiones.TabIndex = 145
        Me.rbProvisiones.Text = "Provisiones"
        Me.rbProvisiones.UseVisualStyleBackColor = True
        '
        'btnCliente
        '
        Me.btnCliente.Enabled = False
        Me.btnCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnCliente.Location = New System.Drawing.Point(360, 33)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(25, 21)
        Me.btnCliente.TabIndex = 141
        Me.btnCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Enabled = False
        Me.lblCliente.Location = New System.Drawing.Point(14, 37)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(46, 13)
        Me.lblCliente.TabIndex = 20
        Me.lblCliente.Text = "Cliente"
        '
        'txtBuscarCliente
        '
        Me.txtBuscarCliente.Location = New System.Drawing.Point(66, 34)
        Me.txtBuscarCliente.Name = "txtBuscarCliente"
        Me.txtBuscarCliente.ReadOnly = True
        Me.txtBuscarCliente.Size = New System.Drawing.Size(288, 20)
        Me.txtBuscarCliente.TabIndex = 140
        '
        'rbExportExcel
        '
        Me.rbExportExcel.AutoSize = True
        Me.rbExportExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbExportExcel.Location = New System.Drawing.Point(15, 42)
        Me.rbExportExcel.Name = "rbExportExcel"
        Me.rbExportExcel.Size = New System.Drawing.Size(56, 17)
        Me.rbExportExcel.TabIndex = 146
        Me.rbExportExcel.Text = "Excel"
        Me.rbExportExcel.UseVisualStyleBackColor = True
        '
        'rbPantalla
        '
        Me.rbPantalla.AutoSize = True
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPantalla.Location = New System.Drawing.Point(15, 19)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(71, 17)
        Me.rbPantalla.TabIndex = 145
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.UseVisualStyleBackColor = True
        '
        'rbXUnidadNegocio
        '
        Me.rbXUnidadNegocio.AutoSize = True
        Me.rbXUnidadNegocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbXUnidadNegocio.Location = New System.Drawing.Point(10, 70)
        Me.rbXUnidadNegocio.Name = "rbXUnidadNegocio"
        Me.rbXUnidadNegocio.Size = New System.Drawing.Size(146, 17)
        Me.rbXUnidadNegocio.TabIndex = 145
        Me.rbXUnidadNegocio.Text = "X Unidad de Negocio"
        Me.rbXUnidadNegocio.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbDocGeneral)
        Me.UiGroupBox1.Controls.Add(Me.rbDocCliente)
        Me.UiGroupBox1.Controls.Add(Me.cmbDocu)
        Me.UiGroupBox1.Controls.Add(Me.rbDocDocumento)
        Me.UiGroupBox1.Controls.Add(Me.rbDocJudicial)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(423, 8)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(160, 150)
        Me.UiGroupBox1.TabIndex = 140
        Me.UiGroupBox1.Text = "DOCUMENTOS"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.rbTodos)
        Me.UiGroupBox2.Controls.Add(Me.rbPendientes)
        Me.UiGroupBox2.Controls.Add(Me.rbCancelados)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(423, 164)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(160, 91)
        Me.UiGroupBox2.TabIndex = 141
        Me.UiGroupBox2.Text = "CONDICION"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbXUnidadNegocio)
        Me.UiGroupBox3.Controls.Add(Me.rbDetallado)
        Me.UiGroupBox3.Controls.Add(Me.rbResumen)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(423, 261)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(160, 100)
        Me.UiGroupBox3.TabIndex = 142
        Me.UiGroupBox3.Text = "TIPO"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox4.Controls.Add(Me.Label3)
        Me.UiGroupBox4.Controls.Add(Me.Label2)
        Me.UiGroupBox4.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(405, 53)
        Me.UiGroupBox4.TabIndex = 143
        Me.UiGroupBox4.Text = "FECHAS"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.Controls.Add(Me.rbExportExcel)
        Me.UiGroupBox5.Controls.Add(Me.rbPantalla)
        Me.UiGroupBox5.Controls.Add(Me.DataGridView1)
        Me.UiGroupBox5.Controls.Add(Me.DataGridView2)
        Me.UiGroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox5.Location = New System.Drawing.Point(423, 367)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(160, 70)
        Me.UiGroupBox5.TabIndex = 144
        Me.UiGroupBox5.Text = "EXPORTAR"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Controls.Add(Me.cbMoneda)
        Me.UiGroupBox6.Controls.Add(Me.cmbCodMon)
        Me.UiGroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox6.Location = New System.Drawing.Point(8, 147)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(254, 50)
        Me.UiGroupBox6.TabIndex = 145
        Me.UiGroupBox6.Text = "MONEDA"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'gbCobrador
        '
        Me.gbCobrador.Controls.Add(Me.rcTodoCobrador)
        Me.gbCobrador.Controls.Add(Me.cmbCobrador)
        Me.gbCobrador.Controls.Add(Me.lblCobrador)
        Me.gbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCobrador.Location = New System.Drawing.Point(8, 206)
        Me.gbCobrador.Name = "gbCobrador"
        Me.gbCobrador.Size = New System.Drawing.Size(394, 61)
        Me.gbCobrador.TabIndex = 146
        Me.gbCobrador.Text = "COBRADOR"
        Me.gbCobrador.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'gbOrden
        '
        Me.gbOrden.Controls.Add(Me.rbCliente)
        Me.gbOrden.Controls.Add(Me.rbTotal)
        Me.gbOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrden.Location = New System.Drawing.Point(8, 276)
        Me.gbOrden.Name = "gbOrden"
        Me.gbOrden.Size = New System.Drawing.Size(122, 91)
        Me.gbOrden.TabIndex = 147
        Me.gbOrden.Text = "ORDENADO X"
        Me.gbOrden.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'gbOrdenado
        '
        Me.gbOrdenado.Controls.Add(Me.rbAscendente)
        Me.gbOrdenado.Controls.Add(Me.rbDescendente)
        Me.gbOrdenado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrdenado.Location = New System.Drawing.Point(144, 276)
        Me.gbOrdenado.Name = "gbOrdenado"
        Me.gbOrdenado.Size = New System.Drawing.Size(118, 91)
        Me.gbOrdenado.TabIndex = 148
        Me.gbOrdenado.Text = "ORDEN"
        Me.gbOrdenado.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'UiGroupBox10
        '
        Me.UiGroupBox10.Controls.Add(Me.rbCastigos)
        Me.UiGroupBox10.Controls.Add(Me.rbCtasCtes)
        Me.UiGroupBox10.Controls.Add(Me.rbProvisiones)
        Me.UiGroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox10.Location = New System.Drawing.Point(277, 276)
        Me.UiGroupBox10.Name = "UiGroupBox10"
        Me.UiGroupBox10.Size = New System.Drawing.Size(125, 91)
        Me.UiGroupBox10.TabIndex = 149
        Me.UiGroupBox10.Text = "TIPO CUENTA"
        Me.UiGroupBox10.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'gbCliente
        '
        Me.gbCliente.Controls.Add(Me.btnCliente)
        Me.gbCliente.Controls.Add(Me.txtBuscarCliente)
        Me.gbCliente.Controls.Add(Me.lblCliente)
        Me.gbCliente.Controls.Add(Me.rcCliente)
        Me.gbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCliente.Location = New System.Drawing.Point(8, 376)
        Me.gbCliente.Name = "gbCliente"
        Me.gbCliente.Size = New System.Drawing.Size(394, 61)
        Me.gbCliente.TabIndex = 150
        Me.gbCliente.Text = "CLIENTE"
        Me.gbCliente.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'frmRepCtasCtes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(592, 480)
        Me.Controls.Add(Me.gbCliente)
        Me.Controls.Add(Me.UiGroupBox10)
        Me.Controls.Add(Me.gbOrdenado)
        Me.Controls.Add(Me.gbOrden)
        Me.Controls.Add(Me.gbCobrador)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.UiGroupBox5)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.biAceptar)
        Me.Controls.Add(Me.biCancelar)
        Me.Controls.Add(Me.cmbUnidad)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.cmbOficinas)
        Me.Controls.Add(Me.lblOficina)
        Me.Controls.Add(Me.lblAlmacen)
        Me.Controls.Add(Me.cmbIdLocacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepCtasCtes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Cuentas Corrientes"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCobrador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.gbCobrador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCobrador.ResumeLayout(False)
        Me.gbCobrador.PerformLayout()
        CType(Me.gbOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrden.ResumeLayout(False)
        Me.gbOrden.PerformLayout()
        CType(Me.gbOrdenado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenado.ResumeLayout(False)
        Me.gbOrdenado.PerformLayout()
        CType(Me.UiGroupBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox10.ResumeLayout(False)
        Me.UiGroupBox10.PerformLayout()
        CType(Me.gbCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCliente.ResumeLayout(False)
        Me.gbCliente.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmbDocu As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCobrador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblCobrador As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblOficina As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents rcTodoCobrador As System.Windows.Forms.CheckBox
    Friend WithEvents rcCliente As System.Windows.Forms.CheckBox
    Friend WithEvents cbMoneda As System.Windows.Forms.CheckBox
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents biAceptar As System.Windows.Forms.Button
    Friend WithEvents biCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbExportExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rbPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents rbCastigos As System.Windows.Forms.RadioButton
    Friend WithEvents rbCtasCtes As System.Windows.Forms.RadioButton
    Friend WithEvents rbProvisiones As System.Windows.Forms.RadioButton
    Friend WithEvents rbAscendente As System.Windows.Forms.RadioButton
    Friend WithEvents rbDescendente As System.Windows.Forms.RadioButton
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbTotal As System.Windows.Forms.RadioButton
    Friend WithEvents rbResumen As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents rbCancelados As System.Windows.Forms.RadioButton
    Friend WithEvents rbDocGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents rbDocJudicial As System.Windows.Forms.RadioButton
    Friend WithEvents rbDocCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbDocDocumento As System.Windows.Forms.RadioButton
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents txtBuscarCliente As System.Windows.Forms.TextBox
    Friend WithEvents rbXUnidadNegocio As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbCobrador As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox10 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbOrdenado As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbOrden As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbCliente As Janus.Windows.EditControls.UIGroupBox
End Class
