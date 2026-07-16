<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmComCotizacionSolicitud
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
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSolicitud_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbContacto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComCotizacionSolicitud))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDescargarExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtNumCotizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtProveedor = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnBuscarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.cmbSolicitud = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmOpciones = New Janus.Windows.Ribbon.RibbonContextMenu(Me.components)
        Me.miModificar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miEliminar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miActualizar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miAsignar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbContacto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAgregarContacto = New Janus.Windows.EditControls.UIButton()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biGuardar, Me.ToolStripSeparator3, Me.biEditar, Me.ToolStripSeparator4, Me.biDeshacer, Me.ToolStripSeparator5, Me.biDescargarExcel, Me.ToolStripSeparator1, Me.biImportarExcel, Me.ToolStripSeparator2, Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(667, 31)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar Cotización"
        Me.biGuardar.ToolTipText = "Mostrar Solicitud Seleccionada"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Cotización"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biDescargarExcel
        '
        Me.biDescargarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDescargarExcel.Image = CType(resources.GetObject("biDescargarExcel.Image"), System.Drawing.Image)
        Me.biDescargarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDescargarExcel.Name = "biDescargarExcel"
        Me.biDescargarExcel.Size = New System.Drawing.Size(28, 28)
        Me.biDescargarExcel.Text = "Descargar Formato Excel"
        Me.biDescargarExcel.ToolTipText = "Descargar Formato Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarExcel
        '
        Me.biImportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarExcel.Image = CType(resources.GetObject("biImportarExcel.Image"), System.Drawing.Image)
        Me.biImportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarExcel.Name = "biImportarExcel"
        Me.biImportarExcel.Size = New System.Drawing.Size(28, 28)
        Me.biImportarExcel.Text = "Cargar Formato Excel"
        Me.biImportarExcel.ToolTipText = "Cargar Formato Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar la Ventana Actual"
        Me.biSalir.ToolTipText = "Salir de la Ventana"
        '
        'txtNumCotizacion
        '
        Me.txtNumCotizacion.Location = New System.Drawing.Point(66, 25)
        Me.txtNumCotizacion.Name = "txtNumCotizacion"
        Me.txtNumCotizacion.Size = New System.Drawing.Size(109, 20)
        Me.txtNumCotizacion.TabIndex = 8
        Me.txtNumCotizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbFecha
        '
        '
        '
        '
        Me.cbFecha.DropDownCalendar.Name = ""
        Me.cbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecha.Location = New System.Drawing.Point(224, 25)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(87, 20)
        Me.cbFecha.TabIndex = 9
        Me.cbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbCodMon
        '
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(356, 25)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(48, 20)
        Me.cmbCodMon.TabIndex = 10
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.Location = New System.Drawing.Point(66, 62)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(316, 20)
        Me.txtProveedor.TabIndex = 13
        Me.txtProveedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(382, 60)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 23)
        Me.btnBuscarProveedor.TabIndex = 14
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP
        '
        'cmbSolicitud
        '
        cmbSolicitud_DesignTimeLayout.LayoutString = resources.GetString("cmbSolicitud_DesignTimeLayout.LayoutString")
        Me.cmbSolicitud.DesignTimeLayout = cmbSolicitud_DesignTimeLayout
        Me.cmbSolicitud.Location = New System.Drawing.Point(551, 25)
        Me.cmbSolicitud.Name = "cmbSolicitud"
        Me.cmbSolicitud.SelectedIndex = -1
        Me.cmbSolicitud.SelectedItem = Nothing
        Me.cmbSolicitud.Size = New System.Drawing.Size(85, 20)
        Me.cmbSolicitud.TabIndex = 12
        Me.cmbSolicitud.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(503, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Solicitud"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Proveedor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "#Cotización"
        '
        'cmOpciones
        '
        Me.cmOpciones.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.miModificar, Me.miEliminar, Me.miActualizar, Me.miAsignar})
        Me.cmOpciones.Name = "cmOpciones"
        '
        'miModificar
        '
        Me.miModificar.Image = CType(resources.GetObject("miModificar.Image"), System.Drawing.Image)
        Me.miModificar.Key = "DropDownCommand1"
        Me.miModificar.Name = "miModificar"
        Me.miModificar.Text = "Modificar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = CType(resources.GetObject("miEliminar.Image"), System.Drawing.Image)
        Me.miEliminar.Key = "DropDownCommand1"
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Text = "Eliminar"
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Key = "DropDownCommand2"
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Text = "Actualizar"
        '
        'miAsignar
        '
        Me.miAsignar.Image = CType(resources.GetObject("miAsignar.Image"), System.Drawing.Image)
        Me.miAsignar.Key = "DropDownCommand1"
        Me.miAsignar.Name = "miAsignar"
        Me.miAsignar.Text = "Asignar Cotizacion"
        '
        'dgvDatos
        '
        Me.cmOpciones.SetContextMenu(Me.dgvDatos, True)
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 137)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(655, 212)
        Me.dgvDatos.TabIndex = 14
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIgv
        '
        Me.txtIgv.Location = New System.Drawing.Point(449, 25)
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.Size = New System.Drawing.Size(41, 20)
        Me.txtIgv.TabIndex = 11
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(185, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(324, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Mon."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(424, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Igv"
        '
        'cmbContacto
        '
        cmbContacto_DesignTimeLayout.LayoutString = resources.GetString("cmbContacto_DesignTimeLayout.LayoutString")
        Me.cmbContacto.DesignTimeLayout = cmbContacto_DesignTimeLayout
        Me.cmbContacto.Location = New System.Drawing.Point(483, 61)
        Me.cmbContacto.Name = "cmbContacto"
        Me.cmbContacto.SelectedIndex = -1
        Me.cmbContacto.SelectedItem = Nothing
        Me.cmbContacto.Size = New System.Drawing.Size(130, 20)
        Me.cmbContacto.TabIndex = 15
        Me.cmbContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(432, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Contacto"
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarContacto.Location = New System.Drawing.Point(614, 60)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.Size = New System.Drawing.Size(23, 21)
        Me.btnAgregarContacto.TabIndex = 16
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 354)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(667, 20)
        Me.ssBarra.TabIndex = 169
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnAgregarContacto)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.cmbContacto)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtIgv)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.cmbSolicitud)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarProveedor)
        Me.UiGroupBox1.Controls.Add(Me.txtProveedor)
        Me.UiGroupBox1.Controls.Add(Me.cmbCodMon)
        Me.UiGroupBox1.Controls.Add(Me.cbFecha)
        Me.UiGroupBox1.Controls.Add(Me.txtNumCotizacion)
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 35)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(648, 95)
        Me.UiGroupBox1.TabIndex = 170
        Me.UiGroupBox1.Text = "Datos de Cotización"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(450, 17)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(30, 18)
        Me.DataGridView2.TabIndex = 179
        Me.DataGridView2.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(412, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(32, 20)
        Me.DataGridView1.TabIndex = 178
        Me.DataGridView1.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmComCotizacionSolicitud
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(667, 374)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(675, 408)
        Me.Name = "frmComCotizacionSolicitud"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmComCotizacionSolicitud"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtNumCotizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnBuscarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtProveedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbSolicitud As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmOpciones As Janus.Windows.Ribbon.RibbonContextMenu
    Friend WithEvents miModificar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents miEliminar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents miActualizar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbContacto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarContacto As Janus.Windows.EditControls.UIButton
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents biDescargarExcel As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents biImportarExcel As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents miAsignar As Janus.Windows.Ribbon.DropDownCommand
End Class
