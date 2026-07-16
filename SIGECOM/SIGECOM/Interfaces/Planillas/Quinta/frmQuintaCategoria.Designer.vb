<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuintaCategoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuintaCategoria))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.miImportarIngresosPlanilla = New System.Windows.Forms.ToolStripMenuItem()
        Me.miProcesarRetencion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.miExportarRetencion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalPendiente = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalRetenido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalImpuestos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIngresos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(10, 149)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(628, 395)
        Me.dgvDatos.TabIndex = 213
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripSeparator10, Me.miImportarIngresosPlanilla, Me.miProcesarRetencion, Me.ToolStripSeparator9, Me.miExportarRetencion, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(262, 220)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(261, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(261, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(261, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(261, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(258, 6)
        '
        'miImportarIngresosPlanilla
        '
        Me.miImportarIngresosPlanilla.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.miImportarIngresosPlanilla.Name = "miImportarIngresosPlanilla"
        Me.miImportarIngresosPlanilla.Size = New System.Drawing.Size(261, 22)
        Me.miImportarIngresosPlanilla.Text = "Importar Ingreso/Retención Planilla"
        '
        'miProcesarRetencion
        '
        Me.miProcesarRetencion.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.miProcesarRetencion.Name = "miProcesarRetencion"
        Me.miProcesarRetencion.Size = New System.Drawing.Size(261, 22)
        Me.miProcesarRetencion.Text = "Procesar Retención"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(258, 6)
        '
        'miExportarRetencion
        '
        Me.miExportarRetencion.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.miExportarRetencion.Name = "miExportarRetencion"
        Me.miExportarRetencion.Size = New System.Drawing.Size(261, 22)
        Me.miExportarRetencion.Text = "Exportar Retención a Planilla"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(258, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(261, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(261, 22)
        Me.miSalir.Text = "Salir"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 549)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(645, 20)
        Me.ssBarra.TabIndex = 217
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(480, 15)
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
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator8, Me.biActualizar, Me.ToolStripSeparator7, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(645, 31)
        Me.ToolStrip.TabIndex = 216
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Faltas de Personal"
        Me.biActualizar.ToolTipText = "Actualizar Faltas de Personal"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
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
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPendiente)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalRetenido)
        Me.UiGroupBox1.Controls.Add(Me.txtColaborador)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.txtPeriodo)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalImpuestos)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.txtIngresos)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 35)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(631, 108)
        Me.UiGroupBox1.TabIndex = 362
        Me.UiGroupBox1.Text = "Datos del Periodo"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(194, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 373
        Me.Label1.Text = "Total Pendiente"
        '
        'txtTotalPendiente
        '
        Me.txtTotalPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPendiente.Location = New System.Drawing.Point(293, 75)
        Me.txtTotalPendiente.MaxLength = 10
        Me.txtTotalPendiente.Name = "txtTotalPendiente"
        Me.txtTotalPendiente.ReadOnly = True
        Me.txtTotalPendiente.Size = New System.Drawing.Size(81, 20)
        Me.txtTotalPendiente.TabIndex = 372
        Me.txtTotalPendiente.Text = "0.00"
        Me.txtTotalPendiente.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPendiente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 371
        Me.Label2.Text = "Total Retenido"
        '
        'txtTotalRetenido
        '
        Me.txtTotalRetenido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRetenido.Location = New System.Drawing.Point(99, 75)
        Me.txtTotalRetenido.MaxLength = 10
        Me.txtTotalRetenido.Name = "txtTotalRetenido"
        Me.txtTotalRetenido.ReadOnly = True
        Me.txtTotalRetenido.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalRetenido.TabIndex = 370
        Me.txtTotalRetenido.Text = "0.00"
        Me.txtTotalRetenido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalRetenido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtColaborador
        '
        Me.txtColaborador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtColaborador.Location = New System.Drawing.Point(85, 21)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(540, 20)
        Me.txtColaborador.TabIndex = 368
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 369
        Me.Label3.Text = "Colaborador"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(34, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 367
        Me.Label11.Text = "Periodo"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(85, 48)
        Me.txtPeriodo.MaxLength = 2
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Numeric = True
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPeriodo.Size = New System.Drawing.Size(47, 20)
        Me.txtPeriodo.TabIndex = 366
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(350, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 13)
        Me.Label7.TabIndex = 365
        Me.Label7.Text = "Total Impuestos Calculado"
        '
        'txtTotalImpuestos
        '
        Me.txtTotalImpuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalImpuestos.Location = New System.Drawing.Point(511, 48)
        Me.txtTotalImpuestos.MaxLength = 10
        Me.txtTotalImpuestos.Name = "txtTotalImpuestos"
        Me.txtTotalImpuestos.ReadOnly = True
        Me.txtTotalImpuestos.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalImpuestos.TabIndex = 364
        Me.txtTotalImpuestos.Text = "0.00"
        Me.txtTotalImpuestos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalImpuestos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(136, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 363
        Me.Label8.Text = "Total Ingresos"
        '
        'txtIngresos
        '
        Me.txtIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngresos.Location = New System.Drawing.Point(227, 48)
        Me.txtIngresos.MaxLength = 10
        Me.txtIngresos.Name = "txtIngresos"
        Me.txtIngresos.ReadOnly = True
        Me.txtIngresos.Size = New System.Drawing.Size(111, 20)
        Me.txtIngresos.TabIndex = 362
        Me.txtIngresos.Text = "0.00"
        Me.txtIngresos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIngresos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmQuintaCategoria
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(645, 569)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.dgvDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuintaCategoria"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procesar Quinta Categoria Detalle"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miImportarIngresosPlanilla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents miProcesarRetencion As ToolStripMenuItem
    Friend WithEvents miExportarRetencion As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotalPendiente As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTotalRetenido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtColaborador As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalImpuestos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtIngresos As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
