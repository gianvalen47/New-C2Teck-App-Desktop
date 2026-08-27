<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob_Mostrar_Materiales
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob_Mostrar_Materiales))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtPrecioDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PrecioDol = New System.Windows.Forms.Label()
        Me.txtMontoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.MontoSol = New System.Windows.Forms.Label()
        Me.MontoDol = New System.Windows.Forms.Label()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvMateriales = New System.Windows.Forms.DataGridView()
        Me.CodJob2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDocumento2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaTras2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecReg2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApeNom2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesRubro2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesSubRubro2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumDoc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ruc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMon2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoSol2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoDol2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Placa2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdGastoReal2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPer2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodRubro2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodSubRubro2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AbrDoc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipCam2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AplicaIgv2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Igv2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodusuApro2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodJobTras2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodUsuTras2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodUsu2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirIp2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomPc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEStado2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdGastoGer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMontoDol2 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMostrarMat = New System.Windows.Forms.Label()
        Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Devuelto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entregado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biActualizar, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(874, 31)
        Me.ToolStrip.TabIndex = 249
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Solicitud de Job"
        Me.biActualizar.Visible = False
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 667)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(874, 20)
        Me.ssBarra.TabIndex = 250
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(550, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPrecioDol
        '
        Me.txtPrecioDol.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtPrecioDol.DisabledForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPrecioDol.Enabled = False
        Me.txtPrecioDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioDol.FormatString = " ###,##0.00."
        Me.txtPrecioDol.Location = New System.Drawing.Point(499, 326)
        Me.txtPrecioDol.Name = "txtPrecioDol"
        Me.txtPrecioDol.ReadOnly = True
        Me.txtPrecioDol.Size = New System.Drawing.Size(105, 21)
        Me.txtPrecioDol.TabIndex = 283
        Me.txtPrecioDol.TabStop = False
        Me.txtPrecioDol.Text = " 0.00"
        Me.txtPrecioDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'PrecioDol
        '
        Me.PrecioDol.AutoSize = True
        Me.PrecioDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioDol.Location = New System.Drawing.Point(357, 331)
        Me.PrecioDol.Name = "PrecioDol"
        Me.PrecioDol.Size = New System.Drawing.Size(45, 13)
        Me.PrecioDol.TabIndex = 282
        Me.PrecioDol.Text = "Label2"
        '
        'txtMontoSol
        '
        Me.txtMontoSol.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtMontoSol.DisabledForeColor = System.Drawing.SystemColors.Desktop
        Me.txtMontoSol.Enabled = False
        Me.txtMontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSol.FormatString = " ###,##0.00."
        Me.txtMontoSol.Location = New System.Drawing.Point(741, 352)
        Me.txtMontoSol.Name = "txtMontoSol"
        Me.txtMontoSol.ReadOnly = True
        Me.txtMontoSol.Size = New System.Drawing.Size(105, 21)
        Me.txtMontoSol.TabIndex = 281
        Me.txtMontoSol.TabStop = False
        Me.txtMontoSol.Text = " 0.00"
        Me.txtMontoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtMontoDol
        '
        Me.txtMontoDol.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtMontoDol.DisabledForeColor = System.Drawing.SystemColors.Desktop
        Me.txtMontoDol.Enabled = False
        Me.txtMontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDol.FormatString = " ###,##0.00."
        Me.txtMontoDol.Location = New System.Drawing.Point(741, 326)
        Me.txtMontoDol.Name = "txtMontoDol"
        Me.txtMontoDol.ReadOnly = True
        Me.txtMontoDol.Size = New System.Drawing.Size(105, 21)
        Me.txtMontoDol.TabIndex = 280
        Me.txtMontoDol.TabStop = False
        Me.txtMontoDol.Text = " 0.00"
        Me.txtMontoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'MontoSol
        '
        Me.MontoSol.AutoSize = True
        Me.MontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontoSol.Location = New System.Drawing.Point(644, 357)
        Me.MontoSol.Name = "MontoSol"
        Me.MontoSol.Size = New System.Drawing.Size(45, 13)
        Me.MontoSol.TabIndex = 279
        Me.MontoSol.Text = "Label4"
        '
        'MontoDol
        '
        Me.MontoDol.AutoSize = True
        Me.MontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontoDol.Location = New System.Drawing.Point(631, 331)
        Me.MontoDol.Name = "MontoDol"
        Me.MontoDol.Size = New System.Drawing.Size(45, 13)
        Me.MontoDol.TabIndex = 278
        Me.MontoDol.Text = "Label2"
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRubro.Location = New System.Drawing.Point(417, 52)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(62, 15)
        Me.lblRubro.TabIndex = 276
        Me.lblRubro.Text = "lblRubro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(357, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 275
        Me.Label3.Text = "Rubro :"
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.Location = New System.Drawing.Point(65, 52)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(76, 15)
        Me.lblNumJob.TabIndex = 274
        Me.lblNumJob.Text = "lblNumJob"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(417, 359)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 285
        Me.Label1.Text = "Materiales"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(357, 359)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 284
        Me.Label2.Text = "Rubro :"
        '
        'dgvMateriales
        '
        Me.dgvMateriales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMateriales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodJob2, Me.IdDocumento2, Me.FechaTras2, Me.FecReg2, Me.ApeNom2, Me.Fecha2, Me.DesRubro2, Me.DesSubRubro2, Me.NumDoc2, Me.Proveedor2, Me.Ruc2, Me.Descripcion2, Me.CodMon2, Me.MontoSol2, Me.MontoDol2, Me.Placa2, Me.Estado2, Me.IdGastoReal2, Me.IdPer2, Me.CodRubro2, Me.CodSubRubro2, Me.Nombre2, Me.AbrDoc2, Me.TipCam2, Me.AplicaIgv2, Me.Igv2, Me.CodusuApro2, Me.CodJobTras2, Me.CodUsuTras2, Me.CodUsu2, Me.DirIp2, Me.NomPc2, Me.IdEStado2, Me.IdGastoGer})
        Me.dgvMateriales.Location = New System.Drawing.Point(12, 386)
        Me.dgvMateriales.Name = "dgvMateriales"
        Me.dgvMateriales.ReadOnly = True
        Me.dgvMateriales.Size = New System.Drawing.Size(832, 221)
        Me.dgvMateriales.TabIndex = 286
        '
        'CodJob2
        '
        Me.CodJob2.DataPropertyName = "CodJob"
        Me.CodJob2.HeaderText = "CodJob2"
        Me.CodJob2.Name = "CodJob2"
        Me.CodJob2.ReadOnly = True
        Me.CodJob2.Visible = False
        '
        'IdDocumento2
        '
        Me.IdDocumento2.DataPropertyName = "IdDocumento"
        Me.IdDocumento2.HeaderText = "IdDocumento2"
        Me.IdDocumento2.Name = "IdDocumento2"
        Me.IdDocumento2.ReadOnly = True
        Me.IdDocumento2.Visible = False
        '
        'FechaTras2
        '
        Me.FechaTras2.DataPropertyName = "FechaTras"
        Me.FechaTras2.HeaderText = "FechaTras2"
        Me.FechaTras2.Name = "FechaTras2"
        Me.FechaTras2.ReadOnly = True
        Me.FechaTras2.Visible = False
        '
        'FecReg2
        '
        Me.FecReg2.DataPropertyName = "FecReg"
        Me.FecReg2.HeaderText = "FecReg2"
        Me.FecReg2.Name = "FecReg2"
        Me.FecReg2.ReadOnly = True
        Me.FecReg2.Visible = False
        '
        'ApeNom2
        '
        Me.ApeNom2.DataPropertyName = "ApeNom"
        Me.ApeNom2.HeaderText = "ApeNom2"
        Me.ApeNom2.Name = "ApeNom2"
        Me.ApeNom2.ReadOnly = True
        Me.ApeNom2.Visible = False
        '
        'Fecha2
        '
        Me.Fecha2.DataPropertyName = "Fecha"
        Me.Fecha2.HeaderText = "Fecha2"
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.ReadOnly = True
        Me.Fecha2.Visible = False
        '
        'DesRubro2
        '
        Me.DesRubro2.DataPropertyName = "DesRubro"
        Me.DesRubro2.HeaderText = "DesRubro2"
        Me.DesRubro2.Name = "DesRubro2"
        Me.DesRubro2.ReadOnly = True
        Me.DesRubro2.Visible = False
        '
        'DesSubRubro2
        '
        Me.DesSubRubro2.DataPropertyName = "DesSubRubro"
        Me.DesSubRubro2.HeaderText = "DesSubRubro2"
        Me.DesSubRubro2.Name = "DesSubRubro2"
        Me.DesSubRubro2.ReadOnly = True
        Me.DesSubRubro2.Visible = False
        '
        'NumDoc2
        '
        Me.NumDoc2.DataPropertyName = "NumDoc"
        Me.NumDoc2.HeaderText = "NumDoc2"
        Me.NumDoc2.Name = "NumDoc2"
        Me.NumDoc2.ReadOnly = True
        Me.NumDoc2.Visible = False
        '
        'Proveedor2
        '
        Me.Proveedor2.DataPropertyName = "Proveedor"
        Me.Proveedor2.HeaderText = "Proveedor2"
        Me.Proveedor2.Name = "Proveedor2"
        Me.Proveedor2.ReadOnly = True
        Me.Proveedor2.Visible = False
        '
        'Ruc2
        '
        Me.Ruc2.DataPropertyName = "Ruc"
        Me.Ruc2.HeaderText = "Ruc2"
        Me.Ruc2.Name = "Ruc2"
        Me.Ruc2.ReadOnly = True
        Me.Ruc2.Visible = False
        '
        'Descripcion2
        '
        Me.Descripcion2.DataPropertyName = "Descripcion"
        Me.Descripcion2.HeaderText = "Descripción"
        Me.Descripcion2.Name = "Descripcion2"
        Me.Descripcion2.ReadOnly = True
        Me.Descripcion2.Width = 530
        '
        'CodMon2
        '
        Me.CodMon2.DataPropertyName = "CodMon"
        Me.CodMon2.HeaderText = "CodMon2"
        Me.CodMon2.Name = "CodMon2"
        Me.CodMon2.ReadOnly = True
        Me.CodMon2.Visible = False
        '
        'MontoSol2
        '
        Me.MontoSol2.DataPropertyName = "MontoSol"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.MontoSol2.DefaultCellStyle = DataGridViewCellStyle1
        Me.MontoSol2.HeaderText = "MontoSol"
        Me.MontoSol2.Name = "MontoSol2"
        Me.MontoSol2.ReadOnly = True
        Me.MontoSol2.Width = 95
        '
        'MontoDol2
        '
        Me.MontoDol2.DataPropertyName = "MontoDol"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.MontoDol2.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontoDol2.HeaderText = "MontoDol"
        Me.MontoDol2.Name = "MontoDol2"
        Me.MontoDol2.ReadOnly = True
        Me.MontoDol2.Width = 95
        '
        'Placa2
        '
        Me.Placa2.DataPropertyName = "Placa"
        Me.Placa2.HeaderText = "Placa2"
        Me.Placa2.Name = "Placa2"
        Me.Placa2.ReadOnly = True
        Me.Placa2.Visible = False
        '
        'Estado2
        '
        Me.Estado2.DataPropertyName = "Estado"
        Me.Estado2.HeaderText = "Estado2"
        Me.Estado2.Name = "Estado2"
        Me.Estado2.ReadOnly = True
        Me.Estado2.Visible = False
        '
        'IdGastoReal2
        '
        Me.IdGastoReal2.DataPropertyName = "IdGastoReal"
        Me.IdGastoReal2.HeaderText = "IdGastoReal2"
        Me.IdGastoReal2.Name = "IdGastoReal2"
        Me.IdGastoReal2.ReadOnly = True
        Me.IdGastoReal2.Visible = False
        '
        'IdPer2
        '
        Me.IdPer2.DataPropertyName = "IdPer"
        Me.IdPer2.HeaderText = "IdPer2"
        Me.IdPer2.Name = "IdPer2"
        Me.IdPer2.ReadOnly = True
        Me.IdPer2.Visible = False
        '
        'CodRubro2
        '
        Me.CodRubro2.DataPropertyName = "CodRubro"
        Me.CodRubro2.HeaderText = "CodRubro2"
        Me.CodRubro2.Name = "CodRubro2"
        Me.CodRubro2.ReadOnly = True
        Me.CodRubro2.Visible = False
        '
        'CodSubRubro2
        '
        Me.CodSubRubro2.DataPropertyName = "CodSubRubro"
        Me.CodSubRubro2.HeaderText = "CodSubRubro2"
        Me.CodSubRubro2.Name = "CodSubRubro2"
        Me.CodSubRubro2.ReadOnly = True
        Me.CodSubRubro2.Visible = False
        '
        'Nombre2
        '
        Me.Nombre2.DataPropertyName = "Nombre"
        Me.Nombre2.HeaderText = "Nombre2"
        Me.Nombre2.Name = "Nombre2"
        Me.Nombre2.ReadOnly = True
        Me.Nombre2.Visible = False
        '
        'AbrDoc2
        '
        Me.AbrDoc2.DataPropertyName = "AbrDoc"
        Me.AbrDoc2.HeaderText = "AbrDoc2"
        Me.AbrDoc2.Name = "AbrDoc2"
        Me.AbrDoc2.ReadOnly = True
        Me.AbrDoc2.Visible = False
        '
        'TipCam2
        '
        Me.TipCam2.DataPropertyName = "TipCam"
        Me.TipCam2.HeaderText = "TipCam2"
        Me.TipCam2.Name = "TipCam2"
        Me.TipCam2.ReadOnly = True
        Me.TipCam2.Visible = False
        '
        'AplicaIgv2
        '
        Me.AplicaIgv2.DataPropertyName = "AplicaIgv"
        Me.AplicaIgv2.HeaderText = "AplicaIgv2"
        Me.AplicaIgv2.Name = "AplicaIgv2"
        Me.AplicaIgv2.ReadOnly = True
        Me.AplicaIgv2.Visible = False
        '
        'Igv2
        '
        Me.Igv2.DataPropertyName = "Igv"
        Me.Igv2.HeaderText = "Igv2"
        Me.Igv2.Name = "Igv2"
        Me.Igv2.ReadOnly = True
        Me.Igv2.Visible = False
        '
        'CodusuApro2
        '
        Me.CodusuApro2.DataPropertyName = "CodusuApro"
        Me.CodusuApro2.HeaderText = "CodusuApro2"
        Me.CodusuApro2.Name = "CodusuApro2"
        Me.CodusuApro2.ReadOnly = True
        Me.CodusuApro2.Visible = False
        '
        'CodJobTras2
        '
        Me.CodJobTras2.DataPropertyName = "CodJobTras"
        Me.CodJobTras2.HeaderText = "CodJobTras2"
        Me.CodJobTras2.Name = "CodJobTras2"
        Me.CodJobTras2.ReadOnly = True
        Me.CodJobTras2.Visible = False
        '
        'CodUsuTras2
        '
        Me.CodUsuTras2.DataPropertyName = "CodUsuTras"
        Me.CodUsuTras2.HeaderText = "CodUsuTras2"
        Me.CodUsuTras2.Name = "CodUsuTras2"
        Me.CodUsuTras2.ReadOnly = True
        Me.CodUsuTras2.Visible = False
        '
        'CodUsu2
        '
        Me.CodUsu2.DataPropertyName = "CodUsu"
        Me.CodUsu2.HeaderText = "CodUsu2"
        Me.CodUsu2.Name = "CodUsu2"
        Me.CodUsu2.ReadOnly = True
        Me.CodUsu2.Visible = False
        '
        'DirIp2
        '
        Me.DirIp2.DataPropertyName = "DirIp"
        Me.DirIp2.HeaderText = "DirIp2"
        Me.DirIp2.Name = "DirIp2"
        Me.DirIp2.ReadOnly = True
        Me.DirIp2.Visible = False
        '
        'NomPc2
        '
        Me.NomPc2.DataPropertyName = "NomPc"
        Me.NomPc2.HeaderText = "NomPc2"
        Me.NomPc2.Name = "NomPc2"
        Me.NomPc2.ReadOnly = True
        Me.NomPc2.Visible = False
        '
        'IdEStado2
        '
        Me.IdEStado2.DataPropertyName = "IdEStado"
        Me.IdEStado2.HeaderText = "IdEStado2"
        Me.IdEStado2.Name = "IdEStado2"
        Me.IdEStado2.ReadOnly = True
        Me.IdEStado2.Visible = False
        '
        'IdGastoGer
        '
        Me.IdGastoGer.DataPropertyName = "IdGastoGer"
        Me.IdGastoGer.HeaderText = "IdGastoGer"
        Me.IdGastoGer.Name = "IdGastoGer"
        Me.IdGastoGer.ReadOnly = True
        Me.IdGastoGer.Visible = False
        '
        'txtMontoDol2
        '
        Me.txtMontoDol2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtMontoDol2.DisabledForeColor = System.Drawing.SystemColors.Desktop
        Me.txtMontoDol2.Enabled = False
        Me.txtMontoDol2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDol2.FormatString = " ###,##0.00."
        Me.txtMontoDol2.Location = New System.Drawing.Point(741, 620)
        Me.txtMontoDol2.Name = "txtMontoDol2"
        Me.txtMontoDol2.ReadOnly = True
        Me.txtMontoDol2.Size = New System.Drawing.Size(105, 21)
        Me.txtMontoDol2.TabIndex = 288
        Me.txtMontoDol2.TabStop = False
        Me.txtMontoDol2.Text = " 0.00"
        Me.txtMontoDol2.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(631, 625)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 287
        Me.Label4.Text = "Label2"
        '
        'lblMostrarMat
        '
        Me.lblMostrarMat.AutoSize = True
        Me.lblMostrarMat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMostrarMat.Location = New System.Drawing.Point(12, 334)
        Me.lblMostrarMat.Name = "lblMostrarMat"
        Me.lblMostrarMat.Size = New System.Drawing.Size(175, 13)
        Me.lblMostrarMat.TabIndex = 289
        Me.lblMostrarMat.Text = "* No existen Otros Materiales Extras"
        Me.lblMostrarMat.Visible = False
        '
        'Costo
        '
        Me.Costo.DataPropertyName = "Costo"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Costo.DefaultCellStyle = DataGridViewCellStyle5
        Me.Costo.HeaderText = "Costo"
        Me.Costo.Name = "Costo"
        Me.Costo.ReadOnly = True
        Me.Costo.Width = 95
        '
        'Devuelto
        '
        Me.Devuelto.DataPropertyName = "Devuelto"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Devuelto.DefaultCellStyle = DataGridViewCellStyle4
        Me.Devuelto.HeaderText = "Devuelto"
        Me.Devuelto.Name = "Devuelto"
        Me.Devuelto.ReadOnly = True
        Me.Devuelto.Width = 60
        '
        'Entregado
        '
        Me.Entregado.DataPropertyName = "Entregado"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Entregado.DefaultCellStyle = DataGridViewCellStyle3
        Me.Entregado.HeaderText = "Entregado"
        Me.Entregado.Name = "Entregado"
        Me.Entregado.ReadOnly = True
        Me.Entregado.Width = 60
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 320
        '
        'Articulo
        '
        Me.Articulo.DataPropertyName = "Articulo"
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Width = 90
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Articulo, Me.Descripcion, Me.Entregado, Me.Devuelto, Me.Costo})
        Me.dgvDatos.Location = New System.Drawing.Point(12, 85)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.Size = New System.Drawing.Size(832, 227)
        Me.dgvDatos.TabIndex = 277
        '
        'frmJob_Mostrar_Materiales
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(874, 687)
        Me.Controls.Add(Me.lblMostrarMat)
        Me.Controls.Add(Me.dgvMateriales)
        Me.Controls.Add(Me.txtMontoDol2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPrecioDol)
        Me.Controls.Add(Me.PrecioDol)
        Me.Controls.Add(Me.txtMontoSol)
        Me.Controls.Add(Me.txtMontoDol)
        Me.Controls.Add(Me.MontoSol)
        Me.Controls.Add(Me.MontoDol)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.lblRubro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNumJob)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJob_Mostrar_Materiales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Materiales"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtPrecioDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PrecioDol As System.Windows.Forms.Label
    Friend WithEvents txtMontoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents MontoSol As System.Windows.Forms.Label
    Friend WithEvents MontoDol As System.Windows.Forms.Label
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvMateriales As System.Windows.Forms.DataGridView
    Friend WithEvents txtMontoDol2 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMostrarMat As System.Windows.Forms.Label
    Friend WithEvents CodJob2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDocumento2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaTras2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecReg2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApeNom2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesRubro2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesSubRubro2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumDoc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ruc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodMon2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoSol2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoDol2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Placa2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdGastoReal2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdPer2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodRubro2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodSubRubro2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AbrDoc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipCam2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AplicaIgv2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Igv2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodusuApro2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodJobTras2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodUsuTras2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodUsu2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DirIp2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomPc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdEStado2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdGastoGer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entregado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Devuelto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Costo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
