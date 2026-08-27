<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiario_ImportarImportaciones
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiario_ImportarImportaciones))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDuplicar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDiferenciaDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalHaberDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDebeDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalNeto = New System.Windows.Forms.TextBox()
        Me.lbltotalIGV = New System.Windows.Forms.TextBox()
        Me.lblTotalVenta = New System.Windows.Forms.TextBox()
        Me.txtDiferenciaSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalHaberSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDebeSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gbEmbarque = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarRegistro = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.gbEmbarque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEmbarque.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 382)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(541, 20)
        Me.ssBarra.TabIndex = 192
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(440, 15)
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(541, 31)
        Me.ToolStrip.TabIndex = 191
        Me.ToolStrip.Text = "ToolStrip"
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
        Me.UiGroupBox6.Controls.Add(Me.txtDiferenciaDol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalHaberDol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebeDol)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalVenta)
        Me.UiGroupBox6.Controls.Add(Me.txtDiferenciaSol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalHaberSol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebeSol)
        Me.UiGroupBox6.Location = New System.Drawing.Point(14, 258)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(510, 74)
        Me.UiGroupBox6.TabIndex = 221
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDiferenciaDol
        '
        Me.txtDiferenciaDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtDiferenciaDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtDiferenciaDol.Location = New System.Drawing.Point(404, 49)
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
        Me.txtTotalHaberDol.Location = New System.Drawing.Point(404, 30)
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
        Me.txtTotalDebeDol.Location = New System.Drawing.Point(404, 11)
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
        Me.lblTotalNeto.Location = New System.Drawing.Point(9, 49)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(290, 20)
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
        Me.lbltotalIGV.Location = New System.Drawing.Point(9, 30)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(290, 20)
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
        Me.lblTotalVenta.Location = New System.Drawing.Point(9, 11)
        Me.lblTotalVenta.MaxLength = 20
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.ReadOnly = True
        Me.lblTotalVenta.Size = New System.Drawing.Size(290, 20)
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
        Me.txtDiferenciaSol.Location = New System.Drawing.Point(305, 49)
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
        Me.txtTotalHaberSol.Location = New System.Drawing.Point(305, 30)
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
        Me.txtTotalDebeSol.Location = New System.Drawing.Point(305, 11)
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
        'gbEmbarque
        '
        Me.gbEmbarque.Controls.Add(Me.btnBuscarRegistro)
        Me.gbEmbarque.Controls.Add(Me.btnSiguiente)
        Me.gbEmbarque.Controls.Add(Me.txtCodEmbarque)
        Me.gbEmbarque.Location = New System.Drawing.Point(13, 26)
        Me.gbEmbarque.Name = "gbEmbarque"
        Me.gbEmbarque.Size = New System.Drawing.Size(214, 57)
        Me.gbEmbarque.TabIndex = 223
        Me.gbEmbarque.Text = "Código de Embarque"
        Me.gbEmbarque.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarRegistro
        '
        Me.btnBuscarRegistro.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarRegistro.Location = New System.Drawing.Point(144, 23)
        Me.btnBuscarRegistro.Name = "btnBuscarRegistro"
        Me.btnBuscarRegistro.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarRegistro.TabIndex = 300
        Me.btnBuscarRegistro.TabStop = False
        Me.btnBuscarRegistro.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSiguiente.Location = New System.Drawing.Point(175, 22)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(28, 25)
        Me.btnSiguiente.TabIndex = 299
        Me.btnSiguiente.TabStop = False
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.Location = New System.Drawing.Point(11, 24)
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(127, 20)
        Me.txtCodEmbarque.TabIndex = 8
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(12, 91)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(515, 169)
        Me.dgvDatos.TabIndex = 224
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(272, 338)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 27)
        Me.btnCancelar.TabIndex = 226
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(190, 338)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 27)
        Me.btnAceptar.TabIndex = 225
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmDiario_ImportarImportaciones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(541, 402)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.gbEmbarque)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiario_ImportarImportaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Importaciones"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.gbEmbarque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEmbarque.ResumeLayout(False)
        Me.gbEmbarque.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDuplicar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents gbEmbarque As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnBuscarRegistro As System.Windows.Forms.Button
End Class
