<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsientos
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
        Dim cmbCuentaBanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsientos))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnBuscarRegistro = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.biEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.biEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.biGuardar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.biImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.btnReembolso = New System.Windows.Forms.Button
        Me.btnProvisional = New System.Windows.Forms.Button
        Me.lblDesCtaBanco = New System.Windows.Forms.TextBox
        Me.cmbCuentaBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnRendirFondos = New System.Windows.Forms.Button
        Me.txtCodCuenta = New System.Windows.Forms.TextBox
        Me.lblDesCuenta = New System.Windows.Forms.TextBox
        Me.gbEstado = New Janus.Windows.EditControls.UIGroupBox
        Me.rbAnulado = New System.Windows.Forms.CheckBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.btnBuscarCuenta = New System.Windows.Forms.Button
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtGlosa = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnPendientes = New System.Windows.Forms.Button
        Me.txtTipCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.miDuplicar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox
        Me.txtDesCuenta = New System.Windows.Forms.TextBox
        Me.txtDiferenciaDol = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalHaberDol = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalDebeDol = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lblTotalNeto = New System.Windows.Forms.TextBox
        Me.lbltotalIGV = New System.Windows.Forms.TextBox
        Me.lblTotalVenta = New System.Windows.Forms.TextBox
        Me.txtDiferenciaSol = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalHaberSol = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalDebeSol = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.txtNumRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbCuentaBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(300, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "Comprobante :"
        '
        'btnBuscarRegistro
        '
        Me.btnBuscarRegistro.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarRegistro.Location = New System.Drawing.Point(502, 37)
        Me.btnBuscarRegistro.Name = "btnBuscarRegistro"
        Me.btnBuscarRegistro.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarRegistro.TabIndex = 3
        Me.btnBuscarRegistro.TabStop = False
        Me.btnBuscarRegistro.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(425, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "-"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 506)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(704, 20)
        Me.ssBarra.TabIndex = 188
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(450, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(210, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biEditar, Me.ToolStripSeparator8, Me.biEliminar, Me.ToolStripSeparator3, Me.biGuardar, Me.ToolStripSeparator13, Me.biDeshacer, Me.ToolStripSeparator4, Me.biImprimir, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(704, 31)
        Me.ToolStrip.TabIndex = 187
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Cabecera"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar Asiento"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Reportes"
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
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnReembolso)
        Me.UiGroupBox1.Controls.Add(Me.btnProvisional)
        Me.UiGroupBox1.Controls.Add(Me.lblDesCtaBanco)
        Me.UiGroupBox1.Controls.Add(Me.cmbCuentaBanco)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.btnRendirFondos)
        Me.UiGroupBox1.Controls.Add(Me.txtCodCuenta)
        Me.UiGroupBox1.Controls.Add(Me.lblDesCuenta)
        Me.UiGroupBox1.Controls.Add(Me.gbEstado)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCuenta)
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label17)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Controls.Add(Me.txtGlosa)
        Me.UiGroupBox1.Controls.Add(Me.txtNombre)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.btnPendientes)
        Me.UiGroupBox1.Controls.Add(Me.txtTipCambio)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.lblFecha)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 58)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(693, 195)
        Me.UiGroupBox1.TabIndex = 4
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnReembolso
        '
        Me.btnReembolso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReembolso.Image = CType(resources.GetObject("btnReembolso.Image"), System.Drawing.Image)
        Me.btnReembolso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReembolso.Location = New System.Drawing.Point(581, 66)
        Me.btnReembolso.Name = "btnReembolso"
        Me.btnReembolso.Size = New System.Drawing.Size(92, 24)
        Me.btnReembolso.TabIndex = 235
        Me.btnReembolso.Text = "Reembolso"
        Me.btnReembolso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReembolso.UseVisualStyleBackColor = True
        '
        'btnProvisional
        '
        Me.btnProvisional.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProvisional.Image = CType(resources.GetObject("btnProvisional.Image"), System.Drawing.Image)
        Me.btnProvisional.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProvisional.Location = New System.Drawing.Point(581, 42)
        Me.btnProvisional.Name = "btnProvisional"
        Me.btnProvisional.Size = New System.Drawing.Size(92, 24)
        Me.btnProvisional.TabIndex = 234
        Me.btnProvisional.Text = "Provisional"
        Me.btnProvisional.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProvisional.UseVisualStyleBackColor = True
        '
        'lblDesCtaBanco
        '
        Me.lblDesCtaBanco.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesCtaBanco.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDesCtaBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCtaBanco.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDesCtaBanco.Location = New System.Drawing.Point(246, 18)
        Me.lblDesCtaBanco.Name = "lblDesCtaBanco"
        Me.lblDesCtaBanco.ReadOnly = True
        Me.lblDesCtaBanco.Size = New System.Drawing.Size(329, 12)
        Me.lblDesCtaBanco.TabIndex = 233
        Me.lblDesCtaBanco.TabStop = False
        Me.lblDesCtaBanco.Text = "DESCRIPCIÓN DE CUENTA BANCO"
        '
        'cmbCuentaBanco
        '
        Me.cmbCuentaBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCuentaBanco_DesignTimeLayout.LayoutString = resources.GetString("cmbCuentaBanco_DesignTimeLayout.LayoutString")
        Me.cmbCuentaBanco.DesignTimeLayout = cmbCuentaBanco_DesignTimeLayout
        Me.cmbCuentaBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCuentaBanco.Location = New System.Drawing.Point(93, 14)
        Me.cmbCuentaBanco.Name = "cmbCuentaBanco"
        Me.cmbCuentaBanco.SelectedIndex = -1
        Me.cmbCuentaBanco.SelectedItem = Nothing
        Me.cmbCuentaBanco.Size = New System.Drawing.Size(147, 20)
        Me.cmbCuentaBanco.TabIndex = 4
        Me.cmbCuentaBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 231
        Me.Label4.Text = "Banco :"
        '
        'btnRendirFondos
        '
        Me.btnRendirFondos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRendirFondos.Image = CType(resources.GetObject("btnRendirFondos.Image"), System.Drawing.Image)
        Me.btnRendirFondos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRendirFondos.Location = New System.Drawing.Point(573, 90)
        Me.btnRendirFondos.Name = "btnRendirFondos"
        Me.btnRendirFondos.Size = New System.Drawing.Size(109, 24)
        Me.btnRendirFondos.TabIndex = 230
        Me.btnRendirFondos.Text = "Rend. Fondos"
        Me.btnRendirFondos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRendirFondos.UseVisualStyleBackColor = True
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCuenta.Location = New System.Drawing.Point(93, 40)
        Me.txtCodCuenta.MaxLength = 20
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(86, 20)
        Me.txtCodCuenta.TabIndex = 5
        Me.txtCodCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDesCuenta
        '
        Me.lblDesCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDesCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDesCuenta.Location = New System.Drawing.Point(212, 43)
        Me.lblDesCuenta.Name = "lblDesCuenta"
        Me.lblDesCuenta.ReadOnly = True
        Me.lblDesCuenta.Size = New System.Drawing.Size(363, 12)
        Me.lblDesCuenta.TabIndex = 229
        Me.lblDesCuenta.TabStop = False
        Me.lblDesCuenta.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.rbAnulado)
        Me.gbEstado.Controls.Add(Me.Label18)
        Me.gbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEstado.Location = New System.Drawing.Point(238, 155)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(192, 33)
        Me.gbEstado.TabIndex = 13
        Me.gbEstado.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'rbAnulado
        '
        Me.rbAnulado.AutoSize = True
        Me.rbAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAnulado.Location = New System.Drawing.Point(90, 12)
        Me.rbAnulado.Name = "rbAnulado"
        Me.rbAnulado.Size = New System.Drawing.Size(72, 17)
        Me.rbAnulado.TabIndex = 14
        Me.rbAnulado.Text = "Anulado"
        Me.rbAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbAnulado.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(28, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 196
        Me.Label18.Text = "Estado :"
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(181, 39)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCuenta.TabIndex = 6
        Me.btnBuscarCuenta.TabStop = False
        Me.btnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(93, 164)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(66, 20)
        Me.cmbMoneda.TabIndex = 12
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 168)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 223
        Me.Label17.Text = "Moneda :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 221
        Me.Label16.Text = "Glosa :"
        '
        'txtGlosa
        '
        Me.txtGlosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlosa.Location = New System.Drawing.Point(93, 118)
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtGlosa.Size = New System.Drawing.Size(589, 37)
        Me.txtGlosa.TabIndex = 11
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(93, 92)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(474, 20)
        Me.txtNombre.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 218
        Me.Label5.Text = "Nombre :"
        '
        'btnPendientes
        '
        Me.btnPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendientes.Image = Global.SIGECOM.My.Resources.Resources.CrdFle12
        Me.btnPendientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPendientes.Location = New System.Drawing.Point(581, 18)
        Me.btnPendientes.Name = "btnPendientes"
        Me.btnPendientes.Size = New System.Drawing.Size(92, 24)
        Me.btnPendientes.TabIndex = 9
        Me.btnPendientes.Text = "Pendientes"
        Me.btnPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPendientes.UseVisualStyleBackColor = True
        '
        'txtTipCambio
        '
        Me.txtTipCambio.DecimalDigits = 4
        Me.txtTipCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCambio.Location = New System.Drawing.Point(353, 66)
        Me.txtTipCambio.MaxLength = 10
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.Size = New System.Drawing.Size(73, 20)
        Me.txtTipCambio.TabIndex = 8
        Me.txtTipCambio.Text = "0.0000"
        Me.txtTipCambio.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtTipCambio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(275, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 216
        Me.Label15.Text = "T. Cambio :"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(10, 69)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(50, 13)
        Me.lblFecha.TabIndex = 214
        Me.lblFecha.Text = "Fecha :"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecha.IsNullDate = True
        Me.txtFecha.Location = New System.Drawing.Point(93, 66)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(86, 20)
        Me.txtFecha.TabIndex = 7
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 177
        Me.Label3.Text = "Nro Cuenta :"
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miDuplicar, Me.miEliminar, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 126)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miDuplicar
        '
        Me.miDuplicar.Image = Global.SIGECOM.My.Resources.Resources.Canjear
        Me.miDuplicar.Name = "miDuplicar"
        Me.miDuplicar.Size = New System.Drawing.Size(126, 22)
        Me.miDuplicar.Text = "Duplicar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtDesCuenta)
        Me.UiGroupBox6.Controls.Add(Me.txtDiferenciaDol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalHaberDol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebeDol)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalVenta)
        Me.UiGroupBox6.Controls.Add(Me.txtDiferenciaSol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalHaberSol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebeSol)
        Me.UiGroupBox6.Location = New System.Drawing.Point(5, 427)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(693, 74)
        Me.UiGroupBox6.TabIndex = 215
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDesCuenta
        '
        Me.txtDesCuenta.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.txtDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDesCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesCuenta.ForeColor = System.Drawing.Color.Brown
        Me.txtDesCuenta.Location = New System.Drawing.Point(10, 15)
        Me.txtDesCuenta.Name = "txtDesCuenta"
        Me.txtDesCuenta.ReadOnly = True
        Me.txtDesCuenta.Size = New System.Drawing.Size(382, 12)
        Me.txtDesCuenta.TabIndex = 222
        Me.txtDesCuenta.TabStop = False
        Me.txtDesCuenta.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        Me.txtDesCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDiferenciaDol
        '
        Me.txtDiferenciaDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtDiferenciaDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtDiferenciaDol.Location = New System.Drawing.Point(597, 49)
        Me.txtDiferenciaDol.MaxLength = 5
        Me.txtDiferenciaDol.Name = "txtDiferenciaDol"
        Me.txtDiferenciaDol.ReadOnly = True
        Me.txtDiferenciaDol.Size = New System.Drawing.Size(90, 20)
        Me.txtDiferenciaDol.TabIndex = 13
        Me.txtDiferenciaDol.TabStop = False
        Me.txtDiferenciaDol.Text = "0.00"
        Me.txtDiferenciaDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDiferenciaDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDiferenciaDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalHaberDol
        '
        Me.txtTotalHaberDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalHaberDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHaberDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalHaberDol.Location = New System.Drawing.Point(597, 30)
        Me.txtTotalHaberDol.MaxLength = 5
        Me.txtTotalHaberDol.Name = "txtTotalHaberDol"
        Me.txtTotalHaberDol.ReadOnly = True
        Me.txtTotalHaberDol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalHaberDol.TabIndex = 12
        Me.txtTotalHaberDol.TabStop = False
        Me.txtTotalHaberDol.Text = "0.00"
        Me.txtTotalHaberDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalHaberDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalHaberDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDebeDol
        '
        Me.txtTotalDebeDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDebeDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebeDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDebeDol.Location = New System.Drawing.Point(597, 11)
        Me.txtTotalDebeDol.MaxLength = 5
        Me.txtTotalDebeDol.Name = "txtTotalDebeDol"
        Me.txtTotalDebeDol.ReadOnly = True
        Me.txtTotalDebeDol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalDebeDol.TabIndex = 11
        Me.txtTotalDebeDol.TabStop = False
        Me.txtTotalDebeDol.Text = "0.00"
        Me.txtTotalDebeDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDebeDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDebeDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(6, 49)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(492, 20)
        Me.lblTotalNeto.TabIndex = 10
        Me.lblTotalNeto.TabStop = False
        Me.lblTotalNeto.Text = "DIFERENCIA :"
        Me.lblTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalIGV
        '
        Me.lbltotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalIGV.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lbltotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalIGV.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalIGV.Location = New System.Drawing.Point(6, 30)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(492, 20)
        Me.lbltotalIGV.TabIndex = 9
        Me.lbltotalIGV.TabStop = False
        Me.lbltotalIGV.Text = "TOTAL HABER :"
        Me.lbltotalIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalVenta.Location = New System.Drawing.Point(6, 11)
        Me.lblTotalVenta.MaxLength = 20
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.ReadOnly = True
        Me.lblTotalVenta.Size = New System.Drawing.Size(492, 20)
        Me.lblTotalVenta.TabIndex = 8
        Me.lblTotalVenta.TabStop = False
        Me.lblTotalVenta.Text = "TOTAL DEBE :"
        Me.lblTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiferenciaSol
        '
        Me.txtDiferenciaSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtDiferenciaSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtDiferenciaSol.Location = New System.Drawing.Point(497, 49)
        Me.txtDiferenciaSol.MaxLength = 5
        Me.txtDiferenciaSol.Name = "txtDiferenciaSol"
        Me.txtDiferenciaSol.ReadOnly = True
        Me.txtDiferenciaSol.Size = New System.Drawing.Size(90, 20)
        Me.txtDiferenciaSol.TabIndex = 6
        Me.txtDiferenciaSol.TabStop = False
        Me.txtDiferenciaSol.Text = "0.00"
        Me.txtDiferenciaSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDiferenciaSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDiferenciaSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalHaberSol
        '
        Me.txtTotalHaberSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalHaberSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHaberSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalHaberSol.Location = New System.Drawing.Point(497, 30)
        Me.txtTotalHaberSol.MaxLength = 5
        Me.txtTotalHaberSol.Name = "txtTotalHaberSol"
        Me.txtTotalHaberSol.ReadOnly = True
        Me.txtTotalHaberSol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalHaberSol.TabIndex = 5
        Me.txtTotalHaberSol.TabStop = False
        Me.txtTotalHaberSol.Text = "0.00"
        Me.txtTotalHaberSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalHaberSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalHaberSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDebeSol
        '
        Me.txtTotalDebeSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDebeSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebeSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDebeSol.Location = New System.Drawing.Point(497, 11)
        Me.txtTotalDebeSol.MaxLength = 5
        Me.txtTotalDebeSol.Name = "txtTotalDebeSol"
        Me.txtTotalDebeSol.ReadOnly = True
        Me.txtTotalDebeSol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalDebeSol.TabIndex = 3
        Me.txtTotalDebeSol.TabStop = False
        Me.txtTotalDebeSol.Text = "0.00"
        Me.txtTotalDebeSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDebeSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDebeSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.Location = New System.Drawing.Point(392, 38)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMesRegistro.Size = New System.Drawing.Size(30, 20)
        Me.txtMesRegistro.TabIndex = 219
        '
        'txtNumRegistro
        '
        Me.txtNumRegistro.Location = New System.Drawing.Point(439, 38)
        Me.txtNumRegistro.MaxLength = 6
        Me.txtNumRegistro.Name = "txtNumRegistro"
        Me.txtNumRegistro.Numeric = True
        Me.txtNumRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumRegistro.Size = New System.Drawing.Size(59, 20)
        Me.txtNumRegistro.TabIndex = 1
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(208, 38)
        Me.txtPeriodo.Maximum = 2020
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriodo.TabIndex = 218
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(152, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 225
        Me.Label7.Text = "Periodo"
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(5, 259)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(693, 162)
        Me.dgvDatos.TabIndex = 226
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmAsientos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(704, 526)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.txtNumRegistro)
        Me.Controls.Add(Me.txtMesRegistro)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBuscarRegistro)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsientos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tesorería - Asientos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbCuentaBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarRegistro As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtTipCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnPendientes As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtDiferenciaDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalHaberDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDebeDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalIGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalHaberSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDebeSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDuplicar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtNumRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents txtDesCuenta As System.Windows.Forms.TextBox
    Friend WithEvents gbEstado As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblDesCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents btnRendirFondos As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCuentaBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblDesCtaBanco As System.Windows.Forms.TextBox
    Friend WithEvents btnProvisional As System.Windows.Forms.Button
    Friend WithEvents btnReembolso As System.Windows.Forms.Button
End Class
