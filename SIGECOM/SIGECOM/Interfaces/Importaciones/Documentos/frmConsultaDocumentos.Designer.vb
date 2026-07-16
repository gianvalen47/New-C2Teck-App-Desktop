<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaDocumentos
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
        Dim cmbTipFac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbDocumento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgDocumentos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaDocumentos))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbTipFac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cbDocumento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumero = New System.Windows.Forms.MaskedTextBox
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator101 = New System.Windows.Forms.ToolStripSeparator
        Me.biImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator102 = New System.Windows.Forms.ToolStripSeparator
        Me.biMostrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator105 = New System.Windows.Forms.ToolStripSeparator
        Me.biActualizar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator106 = New System.Windows.Forms.ToolStripSeparator
        Me.biEstados = New System.Windows.Forms.ToolStripButton
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator107 = New System.Windows.Forms.ToolStripSeparator
        Me.dgDocumentos = New Janus.Windows.GridEX.GridEX
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator202 = New System.Windows.Forms.ToolStripSeparator
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator203 = New System.Windows.Forms.ToolStripSeparator
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEstados = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator204 = New System.Windows.Forms.ToolStripSeparator
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbTipFac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipFac)
        Me.UiGroupBox1.Controls.Add(Me.cbDocumento)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtNumero)
        Me.UiGroupBox1.Controls.Add(Me.cbAlmacen)
        Me.UiGroupBox1.Controls.Add(Me.cbOficina)
        Me.UiGroupBox1.Controls.Add(Me.cbMes)
        Me.UiGroupBox1.Controls.Add(Me.txtPeriodo)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(2, 39)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(787, 59)
        Me.UiGroupBox1.TabIndex = 5
        Me.UiGroupBox1.Text = "Datos de Busqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(320, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Tipo"
        '
        'cmbTipFac
        '
        Me.cmbTipFac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipFac_DesignTimeLayout.LayoutString = resources.GetString("cmbTipFac_DesignTimeLayout.LayoutString")
        Me.cmbTipFac.DesignTimeLayout = cmbTipFac_DesignTimeLayout
        Me.cmbTipFac.Enabled = False
        Me.cmbTipFac.Location = New System.Drawing.Point(318, 30)
        Me.cmbTipFac.Name = "cmbTipFac"
        Me.cmbTipFac.SelectedIndex = -1
        Me.cmbTipFac.SelectedItem = Nothing
        Me.cmbTipFac.Size = New System.Drawing.Size(81, 20)
        Me.cmbTipFac.TabIndex = 33
        Me.cmbTipFac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbDocumento
        '
        Me.cbDocumento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbDocumento_DesignTimeLayout.LayoutString = resources.GetString("cbDocumento_DesignTimeLayout.LayoutString")
        Me.cbDocumento.DesignTimeLayout = cbDocumento_DesignTimeLayout
        Me.cbDocumento.Location = New System.Drawing.Point(135, 30)
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.SelectedIndex = -1
        Me.cbDocumento.SelectedItem = Nothing
        Me.cbDocumento.Size = New System.Drawing.Size(182, 20)
        Me.cbDocumento.TabIndex = 32
        Me.cbDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(136, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Documento"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(640, 30)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(76, 20)
        Me.txtNumero.TabIndex = 30
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(491, 30)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(146, 20)
        Me.cbAlmacen.TabIndex = 29
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(400, 30)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(90, 20)
        Me.cbOficina.TabIndex = 28
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbMes
        '
        Me.cbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbMes_DesignTimeLayout.LayoutString = resources.GetString("cbMes_DesignTimeLayout.LayoutString")
        Me.cbMes.DesignTimeLayout = cbMes_DesignTimeLayout
        Me.cbMes.Location = New System.Drawing.Point(49, 30)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.SelectedIndex = -1
        Me.cbMes.SelectedItem = Nothing
        Me.cbMes.Size = New System.Drawing.Size(85, 20)
        Me.cbMes.TabIndex = 27
        Me.cbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(4, 30)
        Me.txtPeriodo.Maximum = 3000
        Me.txtPeriodo.Minimum = 2009
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(44, 20)
        Me.txtPeriodo.TabIndex = 26
        Me.txtPeriodo.UpDownStyle = Janus.Windows.GridEX.UpDownStyle.UpDownList
        Me.txtPeriodo.Value = 2009
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(402, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Oficina"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(716, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(65, 22)
        Me.btnBuscar.TabIndex = 25
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(643, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Numero"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Periodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(490, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Almacen"
        '
        'ToolStrip
        '
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator101, Me.biImprimir, Me.ToolStripSeparator102, Me.biMostrar, Me.ToolStripSeparator105, Me.biActualizar, Me.ToolStripSeparator106, Me.biEstados, Me.biSalir, Me.ToolStripSeparator107})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(791, 31)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator101
        '
        Me.ToolStripSeparator101.Name = "ToolStripSeparator101"
        Me.ToolStripSeparator101.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Guía"
        '
        'ToolStripSeparator102
        '
        Me.ToolStripSeparator102.Name = "ToolStripSeparator102"
        Me.ToolStripSeparator102.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar Guía"
        '
        'ToolStripSeparator105
        '
        Me.ToolStripSeparator105.Name = "ToolStripSeparator105"
        Me.ToolStripSeparator105.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Guías"
        '
        'ToolStripSeparator106
        '
        Me.ToolStripSeparator106.Name = "ToolStripSeparator106"
        Me.ToolStripSeparator106.Size = New System.Drawing.Size(6, 31)
        '
        'biEstados
        '
        Me.biEstados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.biEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEstados.Name = "biEstados"
        Me.biEstados.Size = New System.Drawing.Size(28, 28)
        Me.biEstados.Text = "Ver Estados del Documento"
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar Formulario"
        '
        'ToolStripSeparator107
        '
        Me.ToolStripSeparator107.Name = "ToolStripSeparator107"
        Me.ToolStripSeparator107.Size = New System.Drawing.Size(6, 31)
        '
        'dgDocumentos
        '
        Me.dgDocumentos.AllowCardSizing = False
        Me.dgDocumentos.AllowColumnDrag = False
        Me.dgDocumentos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgDocumentos.AlternatingColors = True
        dgDocumentos_DesignTimeLayout.LayoutString = resources.GetString("dgDocumentos_DesignTimeLayout.LayoutString")
        Me.dgDocumentos.DesignTimeLayout = dgDocumentos_DesignTimeLayout
        Me.dgDocumentos.EmptyRows = True
        Me.dgDocumentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgDocumentos.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgDocumentos.GroupByBoxVisible = False
        Me.dgDocumentos.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgDocumentos.Location = New System.Drawing.Point(4, 107)
        Me.dgDocumentos.Name = "dgDocumentos"
        Me.dgDocumentos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgDocumentos.Size = New System.Drawing.Size(785, 288)
        Me.dgDocumentos.TabIndex = 7
        Me.dgDocumentos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator202, Me.miImprimir, Me.miMostrar, Me.ToolStripSeparator203, Me.miActualizar, Me.miEstados, Me.ToolStripSeparator204, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(133, 132)
        '
        'ToolStripSeparator202
        '
        Me.ToolStripSeparator202.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator202.Name = "ToolStripSeparator202"
        Me.ToolStripSeparator202.Size = New System.Drawing.Size(129, 6)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(132, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(132, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'ToolStripSeparator203
        '
        Me.ToolStripSeparator203.Name = "ToolStripSeparator203"
        Me.ToolStripSeparator203.Size = New System.Drawing.Size(129, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(132, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miEstados
        '
        Me.miEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miEstados.Name = "miEstados"
        Me.miEstados.Size = New System.Drawing.Size(132, 22)
        Me.miEstados.Text = "Estados"
        '
        'ToolStripSeparator204
        '
        Me.ToolStripSeparator204.Name = "ToolStripSeparator204"
        Me.ToolStripSeparator204.Size = New System.Drawing.Size(129, 6)
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(132, 22)
        Me.miSalir.Text = "Salir"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 402)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(791, 20)
        Me.ssBarra.TabIndex = 8
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        '
        'frmConsultaDocumentos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(791, 422)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgDocumentos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaDocumentos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Documentos de Venta"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbTipFac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbDocumento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator101 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator102 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator105 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator106 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator107 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgDocumentos As Janus.Windows.GridEX.GridEX
    Friend WithEvents biEstados As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator202 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator203 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEstados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator204 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipFac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
