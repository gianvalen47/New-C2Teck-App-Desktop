<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegComprasDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegComprasDet))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarCuenta = New System.Windows.Forms.Button()
        Me.lblDesCuenta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gbSoles = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalFilaSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoNoAfectoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoIgvSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMontoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gbDolares = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalFilaDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoNoAfectoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoIgvDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
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
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAsignar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbCentroCosto = New Janus.Windows.EditControls.UIGroupBox()
        Me.biAsignar = New System.Windows.Forms.Button()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.gbSoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSoles.SuspendLayout()
        CType(Me.gbDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDolares.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCentroCosto.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.btnBuscarCuenta)
        Me.gbDetalle.Controls.Add(Me.lblDesCuenta)
        Me.gbDetalle.Controls.Add(Me.Label9)
        Me.gbDetalle.Controls.Add(Me.txtObservacion)
        Me.gbDetalle.Controls.Add(Me.btnBuscarJob)
        Me.gbDetalle.Controls.Add(Me.txtNumJob)
        Me.gbDetalle.Controls.Add(Me.Label14)
        Me.gbDetalle.Controls.Add(Me.txtCodCuenta)
        Me.gbDetalle.Controls.Add(Me.Label10)
        Me.gbDetalle.Controls.Add(Me.gbSoles)
        Me.gbDetalle.Controls.Add(Me.gbDolares)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(5, 29)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(557, 225)
        Me.gbDetalle.TabIndex = 0
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(125, 14)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCuenta.TabIndex = 241
        Me.btnBuscarCuenta.TabStop = False
        Me.btnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'lblDesCuenta
        '
        Me.lblDesCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDesCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDesCuenta.Location = New System.Drawing.Point(154, 19)
        Me.lblDesCuenta.Name = "lblDesCuenta"
        Me.lblDesCuenta.ReadOnly = True
        Me.lblDesCuenta.Size = New System.Drawing.Size(251, 12)
        Me.lblDesCuenta.TabIndex = 219
        Me.lblDesCuenta.TabStop = False
        Me.lblDesCuenta.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 216
        Me.Label9.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(95, 179)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(450, 37)
        Me.txtObservacion.TabIndex = 13
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(520, 14)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 213
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumJob.Location = New System.Drawing.Point(443, 15)
        Me.txtNumJob.MaxLength = 20
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(75, 20)
        Me.txtNumJob.TabIndex = 2
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(410, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 13)
        Me.Label14.TabIndex = 212
        Me.Label14.Text = "OT"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCuenta.Location = New System.Drawing.Point(64, 15)
        Me.txtCodCuenta.MaxLength = 20
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(58, 20)
        Me.txtCodCuenta.TabIndex = 1
        Me.txtCodCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Cuenta"
        '
        'gbSoles
        '
        Me.gbSoles.Controls.Add(Me.Label3)
        Me.gbSoles.Controls.Add(Me.Label2)
        Me.gbSoles.Controls.Add(Me.Label1)
        Me.gbSoles.Controls.Add(Me.txtTotalFilaSol)
        Me.gbSoles.Controls.Add(Me.txtMontoNoAfectoSol)
        Me.gbSoles.Controls.Add(Me.txtMontoIgvSol)
        Me.gbSoles.Controls.Add(Me.Label8)
        Me.gbSoles.Controls.Add(Me.txtMontoSol)
        Me.gbSoles.Location = New System.Drawing.Point(11, 38)
        Me.gbSoles.Name = "gbSoles"
        Me.gbSoles.Size = New System.Drawing.Size(255, 134)
        Me.gbSoles.TabIndex = 5
        Me.gbSoles.Text = "Soles"
        Me.gbSoles.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Monto Total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Monto No Afecto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Monto Igv"
        '
        'txtTotalFilaSol
        '
        Me.txtTotalFilaSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalFilaSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFilaSol.Location = New System.Drawing.Point(126, 103)
        Me.txtTotalFilaSol.MaxLength = 30
        Me.txtTotalFilaSol.Name = "txtTotalFilaSol"
        Me.txtTotalFilaSol.ReadOnly = True
        Me.txtTotalFilaSol.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalFilaSol.TabIndex = 38
        Me.txtTotalFilaSol.Text = "0.00"
        Me.txtTotalFilaSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalFilaSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoNoAfectoSol
        '
        Me.txtMontoNoAfectoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfectoSol.Location = New System.Drawing.Point(126, 75)
        Me.txtMontoNoAfectoSol.MaxLength = 30
        Me.txtMontoNoAfectoSol.Name = "txtMontoNoAfectoSol"
        Me.txtMontoNoAfectoSol.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoNoAfectoSol.TabIndex = 8
        Me.txtMontoNoAfectoSol.Text = "0.00"
        Me.txtMontoNoAfectoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfectoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoIgvSol
        '
        Me.txtMontoIgvSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIgvSol.Location = New System.Drawing.Point(126, 47)
        Me.txtMontoIgvSol.MaxLength = 30
        Me.txtMontoIgvSol.Name = "txtMontoIgvSol"
        Me.txtMontoIgvSol.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoIgvSol.TabIndex = 7
        Me.txtMontoIgvSol.Text = "0.00"
        Me.txtMontoIgvSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIgvSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Monto"
        '
        'txtMontoSol
        '
        Me.txtMontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSol.Location = New System.Drawing.Point(126, 19)
        Me.txtMontoSol.MaxLength = 30
        Me.txtMontoSol.Name = "txtMontoSol"
        Me.txtMontoSol.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoSol.TabIndex = 6
        Me.txtMontoSol.Text = "0.00"
        Me.txtMontoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDolares
        '
        Me.gbDolares.Controls.Add(Me.Label4)
        Me.gbDolares.Controls.Add(Me.Label5)
        Me.gbDolares.Controls.Add(Me.Label6)
        Me.gbDolares.Controls.Add(Me.Label7)
        Me.gbDolares.Controls.Add(Me.txtTotalFilaDol)
        Me.gbDolares.Controls.Add(Me.txtMontoNoAfectoDol)
        Me.gbDolares.Controls.Add(Me.txtMontoIgvDol)
        Me.gbDolares.Controls.Add(Me.txtMontoDol)
        Me.gbDolares.Location = New System.Drawing.Point(290, 38)
        Me.gbDolares.Name = "gbDolares"
        Me.gbDolares.Size = New System.Drawing.Size(255, 134)
        Me.gbDolares.TabIndex = 9
        Me.gbDolares.Text = "Dolares"
        Me.gbDolares.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Monto Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Monto No Afecto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Monto Igv"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Monto"
        '
        'txtTotalFilaDol
        '
        Me.txtTotalFilaDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalFilaDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFilaDol.Location = New System.Drawing.Point(126, 103)
        Me.txtTotalFilaDol.MaxLength = 30
        Me.txtTotalFilaDol.Name = "txtTotalFilaDol"
        Me.txtTotalFilaDol.ReadOnly = True
        Me.txtTotalFilaDol.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalFilaDol.TabIndex = 42
        Me.txtTotalFilaDol.Text = "0.00"
        Me.txtTotalFilaDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalFilaDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoNoAfectoDol
        '
        Me.txtMontoNoAfectoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfectoDol.Location = New System.Drawing.Point(126, 75)
        Me.txtMontoNoAfectoDol.MaxLength = 30
        Me.txtMontoNoAfectoDol.Name = "txtMontoNoAfectoDol"
        Me.txtMontoNoAfectoDol.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoNoAfectoDol.TabIndex = 12
        Me.txtMontoNoAfectoDol.Text = "0.00"
        Me.txtMontoNoAfectoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfectoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoIgvDol
        '
        Me.txtMontoIgvDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIgvDol.Location = New System.Drawing.Point(126, 47)
        Me.txtMontoIgvDol.MaxLength = 30
        Me.txtMontoIgvDol.Name = "txtMontoIgvDol"
        Me.txtMontoIgvDol.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoIgvDol.TabIndex = 11
        Me.txtMontoIgvDol.Text = "0.00"
        Me.txtMontoIgvDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIgvDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoDol
        '
        Me.txtMontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDol.Location = New System.Drawing.Point(126, 19)
        Me.txtMontoDol.MaxLength = 30
        Me.txtMontoDol.Name = "txtMontoDol"
        Me.txtMontoDol.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoDol.TabIndex = 10
        Me.txtMontoDol.Text = "0.00"
        Me.txtMontoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biGuardar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator6, Me.biDeshacer, Me.ToolStripSeparator8, Me.biCerrar, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(584, 31)
        Me.ToolStrip1.TabIndex = 240
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 476)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(584, 20)
        Me.ssBarra.TabIndex = 241
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(340, 15)
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
        'gbCentroCosto
        '
        Me.gbCentroCosto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCentroCosto.Controls.Add(Me.biAsignar)
        Me.gbCentroCosto.Controls.Add(Me.dgvDatos)
        Me.gbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCentroCosto.Location = New System.Drawing.Point(5, 260)
        Me.gbCentroCosto.Name = "gbCentroCosto"
        Me.gbCentroCosto.Size = New System.Drawing.Size(558, 197)
        Me.gbCentroCosto.TabIndex = 242
        Me.gbCentroCosto.Text = "Centros de Costo"
        Me.gbCentroCosto.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbCentroCosto.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'biAsignar
        '
        Me.biAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biAsignar.Image = CType(resources.GetObject("biAsignar.Image"), System.Drawing.Image)
        Me.biAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.biAsignar.Location = New System.Drawing.Point(459, 12)
        Me.biAsignar.Name = "biAsignar"
        Me.biAsignar.Size = New System.Drawing.Size(74, 25)
        Me.biAsignar.TabIndex = 239
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
        Me.dgvDatos.Location = New System.Drawing.Point(6, 41)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(545, 115)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmRegComprasDet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(584, 496)
        Me.ControlBox = False
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbCentroCosto)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegComprasDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Compra Detalle"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        CType(Me.gbSoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSoles.ResumeLayout(False)
        Me.gbSoles.PerformLayout()
        CType(Me.gbDolares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDolares.ResumeLayout(False)
        Me.gbDolares.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCentroCosto.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbSoles As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbDolares As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalFilaSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoNoAfectoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoIgvSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMontoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFilaDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoNoAfectoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoIgvDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblDesCuenta As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAsignar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbCentroCosto As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents biAsignar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
End Class
