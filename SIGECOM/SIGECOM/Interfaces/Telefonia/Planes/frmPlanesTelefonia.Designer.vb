<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanesTelefonia
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
        Dim cmbTipoServicio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanesTelefonia))
        Dim cmbOperador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoServicio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOperador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtDesPlan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbTipoServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOperador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.Label3)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbTipoServicio)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbOperador)
        Me.gbDatosBusqueda.Controls.Add(Me.txtDesPlan)
        Me.gbDatosBusqueda.Controls.Add(Me.Label1)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(6, 30)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(884, 60)
        Me.gbDatosBusqueda.TabIndex = 243
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(311, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "Tipo Servicio"
        '
        'cmbTipoServicio
        '
        Me.cmbTipoServicio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoServicio_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoServicio_DesignTimeLayout.LayoutString")
        Me.cmbTipoServicio.DesignTimeLayout = cmbTipoServicio_DesignTimeLayout
        Me.cmbTipoServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoServicio.Location = New System.Drawing.Point(268, 32)
        Me.cmbTipoServicio.Name = "cmbTipoServicio"
        Me.cmbTipoServicio.SelectedIndex = -1
        Me.cmbTipoServicio.SelectedItem = Nothing
        Me.cmbTipoServicio.Size = New System.Drawing.Size(168, 20)
        Me.cmbTipoServicio.TabIndex = 279
        Me.cmbTipoServicio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 278
        Me.Label2.Text = "Operador"
        '
        'cmbOperador
        '
        Me.cmbOperador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOperador_DesignTimeLayout.LayoutString = resources.GetString("cmbOperador_DesignTimeLayout.LayoutString")
        Me.cmbOperador.DesignTimeLayout = cmbOperador_DesignTimeLayout
        Me.cmbOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperador.Location = New System.Drawing.Point(38, 32)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.SelectedIndex = -1
        Me.cmbOperador.SelectedItem = Nothing
        Me.cmbOperador.Size = New System.Drawing.Size(176, 20)
        Me.cmbOperador.TabIndex = 277
        Me.cmbOperador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDesPlan
        '
        Me.txtDesPlan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesPlan.Location = New System.Drawing.Point(494, 32)
        Me.txtDesPlan.MaxLength = 50
        Me.txtDesPlan.Name = "txtDesPlan"
        Me.txtDesPlan.Size = New System.Drawing.Size(240, 20)
        Me.txtDesPlan.TabIndex = 283
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(566, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 276
        Me.Label1.Text = "Descripción"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(776, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 295
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biImprimir, Me.ToolStripSeparator2, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator3, Me.biEliminar, Me.ToolStripSeparator4, Me.biActualizar, Me.ToolStripSeparator5, Me.biSalir, Me.ToolStripSeparator11})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(912, 31)
        Me.ToolStrip.TabIndex = 245
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Plan"
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
        Me.biNuevo.Text = "Nuevo Plan"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar Plan"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar Plan"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Plan"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 120)
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
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
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
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(126, 22)
        Me.miSalir.Text = "Salir"
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
        Me.ssBarra.Location = New System.Drawing.Point(0, 353)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(912, 20)
        Me.ssBarra.TabIndex = 247
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(400, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(100, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 96)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(896, 244)
        Me.dgvDatos.TabIndex = 248
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmPlanesTelefonia
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(912, 373)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanesTelefonia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planes"
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbTipoServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOperador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoServicio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOperador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtDesPlan As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
End Class
