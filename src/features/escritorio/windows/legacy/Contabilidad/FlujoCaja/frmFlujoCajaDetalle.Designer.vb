<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlujoCajaDetalle
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
        Dim cmbConcepto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlujoCajaDetalle))
        Dim dgvObservaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtMontoInicio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtIdFlujoCaja = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbConcepto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmOpcionesObs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvObservaciones = New Janus.Windows.GridEX.GridEX()
        Me.tpObservaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.tpGastos = New Janus.Windows.UI.Tab.UITabPage()
        Me.biGuardar = New System.Windows.Forms.Button()
        Me.biCerrar = New System.Windows.Forms.Button()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesObs.SuspendLayout()
        CType(Me.dgvObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpObservaciones.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpGastos.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 104)
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
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtMontoInicio)
        Me.UiGroupBox1.Controls.Add(Me.txtIdFlujoCaja)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.cmbConcepto)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(503, 159)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos de Flujo de Caja Detalle"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtMontoInicio
        '
        Me.txtMontoInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoInicio.Location = New System.Drawing.Point(98, 76)
        Me.txtMontoInicio.MaxLength = 10
        Me.txtMontoInicio.Name = "txtMontoInicio"
        Me.txtMontoInicio.Size = New System.Drawing.Size(109, 20)
        Me.txtMontoInicio.TabIndex = 396
        Me.txtMontoInicio.Text = "0.00"
        Me.txtMontoInicio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoInicio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIdFlujoCaja
        '
        Me.txtIdFlujoCaja.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdFlujoCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdFlujoCaja.Enabled = False
        Me.txtIdFlujoCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdFlujoCaja.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdFlujoCaja.Location = New System.Drawing.Point(98, 20)
        Me.txtIdFlujoCaja.MaxLength = 20
        Me.txtIdFlujoCaja.Name = "txtIdFlujoCaja"
        Me.txtIdFlujoCaja.ReadOnly = True
        Me.txtIdFlujoCaja.Size = New System.Drawing.Size(124, 20)
        Me.txtIdFlujoCaja.TabIndex = 1
        Me.txtIdFlujoCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 377
        Me.Label6.Text = "Código"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(51, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 375
        Me.Label8.Text = "Monto"
        '
        'cmbConcepto
        '
        Me.cmbConcepto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbConcepto_DesignTimeLayout.LayoutString = resources.GetString("cmbConcepto_DesignTimeLayout.LayoutString")
        Me.cmbConcepto.DesignTimeLayout = cmbConcepto_DesignTimeLayout
        Me.cmbConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConcepto.Location = New System.Drawing.Point(98, 47)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.SelectedIndex = -1
        Me.cmbConcepto.SelectedItem = Nothing
        Me.cmbConcepto.Size = New System.Drawing.Size(332, 20)
        Me.cmbConcepto.TabIndex = 8
        Me.cmbConcepto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbConcepto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 372
        Me.Label5.Text = "Concepto"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(98, 106)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(387, 41)
        Me.txtObservacion.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Descripción"
        '
        'cmOpcionesObs
        '
        Me.cmOpcionesObs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoObs, Me.miMostrarObs, Me.miEliminarObs, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.miActualizarObs})
        Me.cmOpcionesObs.Name = "cmOpciones"
        Me.cmOpcionesObs.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoObs
        '
        Me.miNuevoObs.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoObs.Name = "miNuevoObs"
        Me.miNuevoObs.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoObs.Text = "Nuevo"
        Me.miNuevoObs.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarObs
        '
        Me.miMostrarObs.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarObs.Name = "miMostrarObs"
        Me.miMostrarObs.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarObs.Text = "Mostrar"
        Me.miMostrarObs.ToolTipText = "Mostrar Detalle"
        '
        'miEliminarObs
        '
        Me.miEliminarObs.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarObs.Name = "miEliminarObs"
        Me.miEliminarObs.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarObs.Text = "Eliminar"
        Me.miEliminarObs.ToolTipText = "Eliminar Detalle"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarObs
        '
        Me.miActualizarObs.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarObs.Name = "miActualizarObs"
        Me.miActualizarObs.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarObs.Text = "Actualizar"
        Me.miActualizarObs.ToolTipText = "Refrescar Lista Detalles"
        '
        'dgvObservaciones
        '
        Me.dgvObservaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvObservaciones.ContextMenuStrip = Me.cmOpcionesObs
        dgvObservaciones_DesignTimeLayout.LayoutString = resources.GetString("dgvObservaciones_DesignTimeLayout.LayoutString")
        Me.dgvObservaciones.DesignTimeLayout = dgvObservaciones_DesignTimeLayout
        Me.dgvObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvObservaciones.GroupByBoxVisible = False
        Me.dgvObservaciones.Location = New System.Drawing.Point(11, 9)
        Me.dgvObservaciones.Name = "dgvObservaciones"
        Me.dgvObservaciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvObservaciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvObservaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvObservaciones.Size = New System.Drawing.Size(611, 197)
        Me.dgvObservaciones.TabIndex = 340
        Me.dgvObservaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tpObservaciones
        '
        Me.tpObservaciones.Controls.Add(Me.dgvObservaciones)
        Me.tpObservaciones.Icon = CType(resources.GetObject("tpObservaciones.Icon"), System.Drawing.Icon)
        Me.tpObservaciones.Location = New System.Drawing.Point(1, 23)
        Me.tpObservaciones.Name = "tpObservaciones"
        Me.tpObservaciones.Size = New System.Drawing.Size(647, 237)
        Me.tpObservaciones.TabStop = True
        Me.tpObservaciones.Text = "OBSERVACIONES"
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(11, 7)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(623, 214)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tpGastos
        '
        Me.tpGastos.Controls.Add(Me.dgvDatos)
        Me.tpGastos.Icon = CType(resources.GetObject("tpGastos.Icon"), System.Drawing.Icon)
        Me.tpGastos.Location = New System.Drawing.Point(1, 23)
        Me.tpGastos.Name = "tpGastos"
        Me.tpGastos.Size = New System.Drawing.Size(647, 237)
        Me.tpGastos.TabStop = True
        Me.tpGastos.Text = "GASTOS"
        '
        'biGuardar
        '
        Me.biGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.biGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.biGuardar.Location = New System.Drawing.Point(148, 179)
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(77, 26)
        Me.biGuardar.TabIndex = 237
        Me.biGuardar.Text = "Aceptar"
        Me.biGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.biGuardar.UseVisualStyleBackColor = True
        '
        'biCerrar
        '
        Me.biCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.biCerrar.Location = New System.Drawing.Point(283, 179)
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(82, 26)
        Me.biCerrar.TabIndex = 238
        Me.biCerrar.Text = "Cancelar"
        Me.biCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.biCerrar.UseVisualStyleBackColor = True
        '
        'frmFlujoCajaDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(530, 218)
        Me.Controls.Add(Me.biCerrar)
        Me.Controls.Add(Me.biGuardar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFlujoCajaDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flujo de Caja Detalle"
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesObs.ResumeLayout(False)
        CType(Me.dgvObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpObservaciones.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpGastos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbConcepto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIdFlujoCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmOpcionesObs As ContextMenuStrip
    Friend WithEvents miNuevoObs As ToolStripMenuItem
    Friend WithEvents miMostrarObs As ToolStripMenuItem
    Friend WithEvents miEliminarObs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents miActualizarObs As ToolStripMenuItem
    Friend WithEvents dgvObservaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents tpObservaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents tpGastos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents biCerrar As Button
    Friend WithEvents biGuardar As Button
    Friend WithEvents txtMontoInicio As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
