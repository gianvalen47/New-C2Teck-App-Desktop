<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_Cotizacion_Nuevo
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
        Dim cmbRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios_Cotizacion_Nuevo))
        Dim cmbSubRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmbRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbSubRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.txtItem = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.btnDesvincular = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.gbDetalles = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSubRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalles.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbRubro
        '
        Me.cmbRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbRubro_DesignTimeLayout.LayoutString")
        Me.cmbRubro.DesignTimeLayout = cmbRubro_DesignTimeLayout
        Me.cmbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubro.Location = New System.Drawing.Point(104, 20)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.SelectedIndex = -1
        Me.cmbRubro.SelectedItem = Nothing
        Me.cmbRubro.Size = New System.Drawing.Size(191, 20)
        Me.cmbRubro.TabIndex = 1
        Me.cmbRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(49, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 13)
        Me.Label23.TabIndex = 251
        Me.Label23.Text = "Rubro :"
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSubRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbSubRubro_DesignTimeLayout.LayoutString")
        Me.cmbSubRubro.DesignTimeLayout = cmbSubRubro_DesignTimeLayout
        Me.cmbSubRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubRubro.Location = New System.Drawing.Point(104, 46)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.SelectedIndex = -1
        Me.cmbSubRubro.SelectedItem = Nothing
        Me.cmbSubRubro.Size = New System.Drawing.Size(276, 20)
        Me.cmbSubRubro.TabIndex = 2
        Me.cmbSubRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(23, 50)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(75, 13)
        Me.Label22.TabIndex = 250
        Me.Label22.Text = "Sub Rubro :"
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacion.Location = New System.Drawing.Point(12, 112)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(86, 13)
        Me.lblObservacion.TabIndex = 252
        Me.lblObservacion.Text = "Observación :"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(104, 98)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(414, 35)
        Me.txtObservacion.TabIndex = 4
        '
        'txtItem
        '
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.Location = New System.Drawing.Point(104, 72)
        Me.txtItem.Maximum = 300
        Me.txtItem.MaxLength = 200
        Me.txtItem.Minimum = 1
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(54, 20)
        Me.txtItem.TabIndex = 3
        Me.txtItem.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtItem.Value = 1
        Me.txtItem.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(59, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 254
        Me.Label7.Text = "Item :"
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.Location = New System.Drawing.Point(328, 139)
        Me.txtDescuento.MaxLength = 10
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(100, 20)
        Me.txtDescuento.TabIndex = 6
        Me.txtDescuento.Text = "0.00"
        Me.txtDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(270, 143)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 259
        Me.Label12.Text = "Dscto. :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 258
        Me.Label8.Text = "Monto :"
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(104, 139)
        Me.txtMonto.MaxLength = 10
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 20)
        Me.txtMonto.TabIndex = 5
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjuntar.Image = CType(resources.GetObject("btnAdjuntar.Image"), System.Drawing.Image)
        Me.btnAdjuntar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdjuntar.Location = New System.Drawing.Point(306, 15)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(78, 25)
        Me.btnAdjuntar.TabIndex = 262
        Me.btnAdjuntar.TabStop = False
        Me.btnAdjuntar.Text = "Adjuntar"
        Me.btnAdjuntar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdjuntar.UseVisualStyleBackColor = True
        '
        'btnDesvincular
        '
        Me.btnDesvincular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesvincular.Image = Global.SIGECOM.My.Resources.Resources.UpLoad
        Me.btnDesvincular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesvincular.Location = New System.Drawing.Point(390, 15)
        Me.btnDesvincular.Name = "btnDesvincular"
        Me.btnDesvincular.Size = New System.Drawing.Size(96, 25)
        Me.btnDesvincular.TabIndex = 263
        Me.btnDesvincular.TabStop = False
        Me.btnDesvincular.Text = "Desvincular"
        Me.btnDesvincular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDesvincular.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.Label23)
        Me.gbDatos.Controls.Add(Me.btnDesvincular)
        Me.gbDatos.Controls.Add(Me.Label22)
        Me.gbDatos.Controls.Add(Me.btnAdjuntar)
        Me.gbDatos.Controls.Add(Me.cmbSubRubro)
        Me.gbDatos.Controls.Add(Me.cmbRubro)
        Me.gbDatos.Controls.Add(Me.txtObservacion)
        Me.gbDatos.Controls.Add(Me.txtDescuento)
        Me.gbDatos.Controls.Add(Me.lblObservacion)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.txtItem)
        Me.gbDatos.Controls.Add(Me.txtMonto)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(6, 35)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(524, 166)
        Me.gbDatos.TabIndex = 264
        Me.gbDatos.Text = "Datos de Rubro"
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
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
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator5, Me.biGuardar, Me.ToolStripSeparator4, Me.biEditar, Me.ToolStripSeparator2, Me.biDeshacer, Me.ToolStripSeparator1, Me.biSalir, Me.ToolStripSeparator3})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(540, 31)
        Me.ToolStrip.TabIndex = 267
        Me.ToolStrip.Text = "Guardar Datos de la Cotizacion"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar los Datos"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.DataSource = Me.dgvDatos.Layouts
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(7, 16)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(511, 176)
        Me.dgvDatos.TabIndex = 268
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDetalles
        '
        Me.gbDetalles.Controls.Add(Me.dgvDatos)
        Me.gbDetalles.Location = New System.Drawing.Point(6, 207)
        Me.gbDetalles.Name = "gbDetalles"
        Me.gbDetalles.Size = New System.Drawing.Size(524, 198)
        Me.gbDetalles.TabIndex = 269
        Me.gbDetalles.Text = "Detalle Costos Involucrados"
        Me.gbDetalles.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalles.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmServicios_Cotizacion_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(540, 416)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbDetalles)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_Cotizacion_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Rubro"
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSubRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalles.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbSubRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtItem As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAdjuntar As System.Windows.Forms.Button
    Friend WithEvents btnDesvincular As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDetalles As Janus.Windows.EditControls.UIGroupBox
End Class
