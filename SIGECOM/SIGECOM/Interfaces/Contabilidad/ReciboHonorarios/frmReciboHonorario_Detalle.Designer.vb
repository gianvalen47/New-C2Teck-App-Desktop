<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReciboHonorario_Detalle
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
        Dim cmbMedio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReciboHonorario_Detalle))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtMontoNetoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoIRDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblDesCuenta = New System.Windows.Forms.TextBox()
        Me.gbSoles = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtMontoNetoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMontoIRSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnBuscarNroCuenta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservación = New System.Windows.Forms.TextBox()
        Me.cmbMedio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbCentroCosto = New Janus.Windows.EditControls.UIGroupBox()
        Me.biAsignar = New System.Windows.Forms.Button()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAsignar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbSoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSoles.SuspendLayout()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCentroCosto.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biGuardar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator6, Me.biDeshacer, Me.ToolStripSeparator8, Me.biCerrar, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(594, 31)
        Me.ToolStrip1.TabIndex = 244
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Datos"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.UiGroupBox1)
        Me.gbDetalle.Controls.Add(Me.lblDesCuenta)
        Me.gbDetalle.Controls.Add(Me.gbSoles)
        Me.gbDetalle.Controls.Add(Me.btnBuscarNroCuenta)
        Me.gbDetalle.Controls.Add(Me.Label1)
        Me.gbDetalle.Controls.Add(Me.txtCodCuenta)
        Me.gbDetalle.Controls.Add(Me.Label3)
        Me.gbDetalle.Controls.Add(Me.txtObservación)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(12, 34)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(570, 225)
        Me.gbDetalle.TabIndex = 245
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtMontoNetoDol)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoDol)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoIRDol)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Location = New System.Drawing.Point(294, 50)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(255, 105)
        Me.UiGroupBox1.TabIndex = 248
        Me.UiGroupBox1.Text = "Dolares"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtMontoNetoDol
        '
        Me.txtMontoNetoDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoNetoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNetoDol.Location = New System.Drawing.Point(132, 70)
        Me.txtMontoNetoDol.MaxLength = 10
        Me.txtMontoNetoDol.Name = "txtMontoNetoDol"
        Me.txtMontoNetoDol.ReadOnly = True
        Me.txtMontoNetoDol.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoNetoDol.TabIndex = 292
        Me.txtMontoNetoDol.TabStop = False
        Me.txtMontoNetoDol.Text = "0.00"
        Me.txtMontoNetoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNetoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoDol
        '
        Me.txtMontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDol.Location = New System.Drawing.Point(132, 19)
        Me.txtMontoDol.MaxLength = 10
        Me.txtMontoDol.Name = "txtMontoDol"
        Me.txtMontoDol.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoDol.TabIndex = 8
        Me.txtMontoDol.Text = "0.00"
        Me.txtMontoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoIRDol
        '
        Me.txtMontoIRDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIRDol.Location = New System.Drawing.Point(132, 45)
        Me.txtMontoIRDol.MaxLength = 10
        Me.txtMontoIRDol.Name = "txtMontoIRDol"
        Me.txtMontoIRDol.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoIRDol.TabIndex = 9
        Me.txtMontoIRDol.Text = "0.00"
        Me.txtMontoIRDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIRDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 295
        Me.Label10.Text = "Monto Dolares"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 297
        Me.Label8.Text = "Monto IR Dolares"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 13)
        Me.Label9.TabIndex = 296
        Me.Label9.Text = "Monto Neto Dolares"
        '
        'lblDesCuenta
        '
        Me.lblDesCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDesCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDesCuenta.Location = New System.Drawing.Point(231, 27)
        Me.lblDesCuenta.Name = "lblDesCuenta"
        Me.lblDesCuenta.ReadOnly = True
        Me.lblDesCuenta.Size = New System.Drawing.Size(251, 12)
        Me.lblDesCuenta.TabIndex = 301
        Me.lblDesCuenta.TabStop = False
        Me.lblDesCuenta.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        '
        'gbSoles
        '
        Me.gbSoles.Controls.Add(Me.txtMontoNetoSol)
        Me.gbSoles.Controls.Add(Me.txtMontoSol)
        Me.gbSoles.Controls.Add(Me.Label6)
        Me.gbSoles.Controls.Add(Me.Label5)
        Me.gbSoles.Controls.Add(Me.Label4)
        Me.gbSoles.Controls.Add(Me.txtMontoIRSol)
        Me.gbSoles.Location = New System.Drawing.Point(17, 50)
        Me.gbSoles.Name = "gbSoles"
        Me.gbSoles.Size = New System.Drawing.Size(255, 105)
        Me.gbSoles.TabIndex = 247
        Me.gbSoles.Text = "Soles"
        Me.gbSoles.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtMontoNetoSol
        '
        Me.txtMontoNetoSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoNetoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNetoSol.Location = New System.Drawing.Point(124, 70)
        Me.txtMontoNetoSol.MaxLength = 10
        Me.txtMontoNetoSol.Name = "txtMontoNetoSol"
        Me.txtMontoNetoSol.ReadOnly = True
        Me.txtMontoNetoSol.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoNetoSol.TabIndex = 249
        Me.txtMontoNetoSol.TabStop = False
        Me.txtMontoNetoSol.Text = "0.00"
        Me.txtMontoNetoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNetoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoSol
        '
        Me.txtMontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSol.Location = New System.Drawing.Point(124, 19)
        Me.txtMontoSol.MaxLength = 10
        Me.txtMontoSol.Name = "txtMontoSol"
        Me.txtMontoSol.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoSol.TabIndex = 3
        Me.txtMontoSol.Text = "0.00"
        Me.txtMontoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 247
        Me.Label6.Text = "Monto Soles"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 248
        Me.Label5.Text = "Monto Neto Soles"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 250
        Me.Label4.Text = "Monto IR Soles"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtMontoIRSol
        '
        Me.txtMontoIRSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIRSol.Location = New System.Drawing.Point(124, 45)
        Me.txtMontoIRSol.MaxLength = 10
        Me.txtMontoIRSol.Name = "txtMontoIRSol"
        Me.txtMontoIRSol.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoIRSol.TabIndex = 4
        Me.txtMontoIRSol.Text = "0.00"
        Me.txtMontoIRSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIRSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarNroCuenta
        '
        Me.btnBuscarNroCuenta.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarNroCuenta.Location = New System.Drawing.Point(200, 22)
        Me.btnBuscarNroCuenta.Name = "btnBuscarNroCuenta"
        Me.btnBuscarNroCuenta.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarNroCuenta.TabIndex = 2
        Me.btnBuscarNroCuenta.TabStop = False
        Me.btnBuscarNroCuenta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 299
        Me.Label1.Text = "Nro de Cuenta"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.Location = New System.Drawing.Point(109, 23)
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(85, 20)
        Me.txtCodCuenta.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 22)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Observacion"
        '
        'txtObservación
        '
        Me.txtObservación.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservación.Location = New System.Drawing.Point(98, 164)
        Me.txtObservación.Multiline = True
        Me.txtObservación.Name = "txtObservación"
        Me.txtObservación.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservación.Size = New System.Drawing.Size(451, 43)
        Me.txtObservación.TabIndex = 15
        '
        'cmbMedio
        '
        Me.cmbMedio.BackColor = System.Drawing.SystemColors.Control
        Me.cmbMedio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMedio_DesignTimeLayout.LayoutString = resources.GetString("cmbMedio_DesignTimeLayout.LayoutString")
        Me.cmbMedio.DesignTimeLayout = cmbMedio_DesignTimeLayout
        Me.cmbMedio.Location = New System.Drawing.Point(296, 96)
        Me.cmbMedio.Name = "cmbMedio"
        Me.cmbMedio.ReadOnly = True
        Me.cmbMedio.SelectedIndex = -1
        Me.cmbMedio.SelectedItem = Nothing
        Me.cmbMedio.Size = New System.Drawing.Size(65, 20)
        Me.cmbMedio.TabIndex = 284
        Me.cmbMedio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbCentroCosto
        '
        Me.gbCentroCosto.Controls.Add(Me.biAsignar)
        Me.gbCentroCosto.Controls.Add(Me.dgvDatos)
        Me.gbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCentroCosto.Location = New System.Drawing.Point(12, 265)
        Me.gbCentroCosto.Name = "gbCentroCosto"
        Me.gbCentroCosto.Size = New System.Drawing.Size(570, 179)
        Me.gbCentroCosto.TabIndex = 246
        Me.gbCentroCosto.Text = "Centros de Costo"
        Me.gbCentroCosto.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbCentroCosto.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'biAsignar
        '
        Me.biAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biAsignar.Image = CType(resources.GetObject("biAsignar.Image"), System.Drawing.Image)
        Me.biAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.biAsignar.Location = New System.Drawing.Point(463, 19)
        Me.biAsignar.Name = "biAsignar"
        Me.biAsignar.Size = New System.Drawing.Size(74, 25)
        Me.biAsignar.TabIndex = 241
        Me.biAsignar.Text = "Asignar"
        Me.biAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.biAsignar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(10, 48)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(545, 115)
        Me.dgvDatos.TabIndex = 240
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAsignar, Me.ToolStripSeparator2, Me.ToolStripSeparator1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 60)
        '
        'miAsignar
        '
        Me.miAsignar.Image = CType(resources.GetObject("miAsignar.Image"), System.Drawing.Image)
        Me.miAsignar.Name = "miAsignar"
        Me.miAsignar.Size = New System.Drawing.Size(126, 22)
        Me.miAsignar.Text = "Asignar"
        Me.miAsignar.ToolTipText = "Nuevo Detalle"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmReciboHonorario_Detalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(594, 460)
        Me.Controls.Add(Me.gbCentroCosto)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReciboHonorario_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibo por Honorario - Detalle"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gbSoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSoles.ResumeLayout(False)
        Me.gbSoles.PerformLayout()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCentroCosto.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents biGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents biEditar As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents biDeshacer As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents biCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtMontoIRDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoNetoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoIRSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMontoNetoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMontoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtObservación As TextBox
    Friend WithEvents cmbMedio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarNroCuenta As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCodCuenta As TextBox
    Friend WithEvents gbCentroCosto As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents lblDesCuenta As TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbSoles As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents biAsignar As Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miAsignar As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
End Class
