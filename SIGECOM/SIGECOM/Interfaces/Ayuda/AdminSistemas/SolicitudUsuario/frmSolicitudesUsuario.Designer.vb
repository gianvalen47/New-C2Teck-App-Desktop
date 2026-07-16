<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudesUsuario
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
        Me.components = New System.ComponentModel.Container
        Dim dgvSolicitudes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbTipSol1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudesUsuario))
        Dim cmbEstados_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvSolicitudes = New Janus.Windows.GridEX.GridEX
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.biImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.biNuevo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.biMostrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.biActualizar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.biCancelar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtSolicitud = New System.Windows.Forms.TextBox
        Me.cmbTipSol1 = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox
        Me.chkSolicitante = New System.Windows.Forms.CheckBox
        Me.btnBuscarPersonal = New System.Windows.Forms.Button
        Me.txtPersonal = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblVendedor = New System.Windows.Forms.Label
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmbEstados = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbTipSol1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvSolicitudes
        '
        Me.dgvSolicitudes.AllowCardSizing = False
        Me.dgvSolicitudes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        dgvSolicitudes_DesignTimeLayout.LayoutString = resources.GetString("dgvSolicitudes_DesignTimeLayout.LayoutString")
        Me.dgvSolicitudes.DesignTimeLayout = dgvSolicitudes_DesignTimeLayout
        Me.dgvSolicitudes.EmptyRows = True
        Me.dgvSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvSolicitudes.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvSolicitudes.GroupByBoxVisible = False
        Me.dgvSolicitudes.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvSolicitudes.Location = New System.Drawing.Point(4, 95)
        Me.dgvSolicitudes.Name = "dgvSolicitudes"
        Me.dgvSolicitudes.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvSolicitudes.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvSolicitudes.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvSolicitudes.SelectOnExpand = False
        Me.dgvSolicitudes.Size = New System.Drawing.Size(721, 352)
        Me.dgvSolicitudes.TabIndex = 163
        Me.dgvSolicitudes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biImprimir, Me.ToolStripSeparator2, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator3, Me.biActualizar, Me.ToolStripSeparator6, Me.biCancelar, Me.ToolStripSeparator7, Me.biSalir, Me.ToolStripSeparator12})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(733, 31)
        Me.ToolStrip.TabIndex = 46
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Solicitud de Usuario"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Crear Nueva Solicitud"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = CType(resources.GetObject("biMostrar.Image"), System.Drawing.Image)
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar Solicitud"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Solicitudes"
        Me.biActualizar.ToolTipText = "Actualizar Solicitudes"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biCancelar
        '
        Me.biCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCancelar.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.biCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCancelar.Name = "biCancelar"
        Me.biCancelar.Size = New System.Drawing.Size(28, 28)
        Me.biCancelar.Text = "Anular Job"
        Me.biCancelar.Visible = False
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
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtSolicitud)
        Me.GroupBox1.Controls.Add(Me.cmbTipSol1)
        Me.GroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.GroupBox1.Controls.Add(Me.chkSolicitante)
        Me.GroupBox1.Controls.Add(Me.btnBuscarPersonal)
        Me.GroupBox1.Controls.Add(Me.txtPersonal)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.lblVendedor)
        Me.GroupBox1.Controls.Add(Me.txtanio)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.cmbEstados)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(721, 55)
        Me.GroupBox1.TabIndex = 178
        Me.GroupBox1.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.Location = New System.Drawing.Point(676, 26)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(36, 23)
        Me.btnBuscar.TabIndex = 200
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(605, 11)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 183
        Me.Label23.Text = "Solicitud"
        '
        'txtSolicitud
        '
        Me.txtSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitud.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtSolicitud.Location = New System.Drawing.Point(608, 27)
        Me.txtSolicitud.MaxLength = 50
        Me.txtSolicitud.Name = "txtSolicitud"
        Me.txtSolicitud.Size = New System.Drawing.Size(63, 20)
        Me.txtSolicitud.TabIndex = 184
        '
        'cmbTipSol1
        '
        Me.cmbTipSol1.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipSol1_DesignTimeLayout.LayoutString = resources.GetString("cmbTipSol1_DesignTimeLayout.LayoutString")
        Me.cmbTipSol1.DesignTimeLayout = cmbTipSol1_DesignTimeLayout
        Me.cmbTipSol1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipSol1.Location = New System.Drawing.Point(318, 27)
        Me.cmbTipSol1.Name = "cmbTipSol1"
        Me.cmbTipSol1.SelectedIndex = -1
        Me.cmbTipSol1.SelectedItem = Nothing
        Me.cmbTipSol1.Size = New System.Drawing.Size(173, 20)
        Me.cmbTipSol1.TabIndex = 181
        Me.cmbTipSol1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(148, 6)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 180
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkSolicitante
        '
        Me.chkSolicitante.AutoSize = True
        Me.chkSolicitante.Checked = True
        Me.chkSolicitante.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSolicitante.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSolicitante.Location = New System.Drawing.Point(131, 10)
        Me.chkSolicitante.Name = "chkSolicitante"
        Me.chkSolicitante.Size = New System.Drawing.Size(15, 14)
        Me.chkSolicitante.TabIndex = 179
        Me.chkSolicitante.Tag = ""
        Me.chkSolicitante.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkSolicitante.UseVisualStyleBackColor = True
        '
        'btnBuscarPersonal
        '
        Me.btnBuscarPersonal.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersonal.Location = New System.Drawing.Point(289, 26)
        Me.btnBuscarPersonal.Name = "btnBuscarPersonal"
        Me.btnBuscarPersonal.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarPersonal.TabIndex = 178
        Me.btnBuscarPersonal.UseVisualStyleBackColor = True
        '
        'txtPersonal
        '
        Me.txtPersonal.BackColor = System.Drawing.SystemColors.Window
        Me.txtPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonal.Location = New System.Drawing.Point(61, 27)
        Me.txtPersonal.Name = "txtPersonal"
        Me.txtPersonal.ReadOnly = True
        Me.txtPersonal.Size = New System.Drawing.Size(226, 20)
        Me.txtPersonal.TabIndex = 177
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(62, 11)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 176
        Me.Label22.Text = "Solicitante"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.Location = New System.Drawing.Point(316, 12)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(32, 13)
        Me.lblVendedor.TabIndex = 175
        Me.lblVendedor.Text = "Tipo"
        '
        'txtanio
        '
        Me.txtanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtanio.Location = New System.Drawing.Point(9, 27)
        Me.txtanio.Maximum = 2020
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2006
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(49, 20)
        Me.txtanio.TabIndex = 174
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2006
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(11, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 13)
        Me.Label21.TabIndex = 173
        Me.Label21.Text = "Año"
        '
        'cmbEstados
        '
        Me.cmbEstados.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstados_DesignTimeLayout.LayoutString = resources.GetString("cmbEstados_DesignTimeLayout.LayoutString")
        Me.cmbEstados.DesignTimeLayout = cmbEstados_DesignTimeLayout
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.Location = New System.Drawing.Point(495, 27)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.SelectedIndex = -1
        Me.cmbEstados.SelectedItem = Nothing
        Me.cmbEstados.Size = New System.Drawing.Size(109, 20)
        Me.cmbEstados.TabIndex = 183
        Me.cmbEstados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(494, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estados"
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.ToolStripSeparator4, Me.miNuevo, Me.miMostrar, Me.miActualizar, Me.miEliminar, Me.ToolStripSeparator5, Me.miSalir})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(127, 148)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora1
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(126, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(123, 6)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(123, 6)
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(126, 22)
        Me.miSalir.Text = "Salir"
        '
        'frmSolicitudesUsuario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(733, 455)
        Me.ContextMenuStrip = Me.cmbOpciones
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.dgvSolicitudes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudesUsuario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atención Solicitud Usuario"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbTipSol1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvSolicitudes As Janus.Windows.GridEX.GridEX
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipSol1 As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkSolicitante As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarPersonal As System.Windows.Forms.Button
    Friend WithEvents txtPersonal As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbEstados As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
End Class
