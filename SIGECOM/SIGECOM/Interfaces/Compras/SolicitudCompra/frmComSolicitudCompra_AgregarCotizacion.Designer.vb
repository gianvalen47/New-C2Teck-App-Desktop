<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudCompra_AgregarCotizacion
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudCompra_AgregarCotizacion))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.txtCodPrv = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtDesPrv = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtCotizacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtPreMer = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtDsctoMer = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.VisualStyleManager1 = New Janus.Windows.Common.VisualStyleManager(Me.components)
        Me.btnBuscarProveedor = New Janus.Windows.EditControls.UIButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.biNuevo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.biModificar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.biEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.btnGuardar = New Janus.Windows.EditControls.UIButton
        Me.btnDeshacer = New Janus.Windows.EditControls.UIButton
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cotizacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Precio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Dscto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Observacion"
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(12, 43)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Office2007CustomColor = System.Drawing.Color.White
        Me.dgvDatos.Size = New System.Drawing.Size(456, 173)
        Me.dgvDatos.TabIndex = 9
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCodPrv
        '
        Me.txtCodPrv.Location = New System.Drawing.Point(73, 18)
        Me.txtCodPrv.Name = "txtCodPrv"
        Me.txtCodPrv.Size = New System.Drawing.Size(133, 20)
        Me.txtCodPrv.TabIndex = 10
        '
        'txtDesPrv
        '
        Me.txtDesPrv.Location = New System.Drawing.Point(73, 42)
        Me.txtDesPrv.Name = "txtDesPrv"
        Me.txtDesPrv.ReadOnly = True
        Me.txtDesPrv.Size = New System.Drawing.Size(362, 20)
        Me.txtDesPrv.TabIndex = 11
        Me.txtDesPrv.TabStop = False
        '
        'txtCotizacion
        '
        Me.txtCotizacion.Location = New System.Drawing.Point(73, 19)
        Me.txtCotizacion.Name = "txtCotizacion"
        Me.txtCotizacion.Size = New System.Drawing.Size(100, 20)
        Me.txtCotizacion.TabIndex = 12
        '
        'txtPreMer
        '
        Me.txtPreMer.Location = New System.Drawing.Point(73, 41)
        Me.txtPreMer.Name = "txtPreMer"
        Me.txtPreMer.Size = New System.Drawing.Size(100, 20)
        Me.txtPreMer.TabIndex = 13
        Me.txtPreMer.Text = "0.00"
        Me.txtPreMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtDsctoMer
        '
        Me.txtDsctoMer.Location = New System.Drawing.Point(73, 64)
        Me.txtDsctoMer.Name = "txtDsctoMer"
        Me.txtDsctoMer.Size = New System.Drawing.Size(100, 20)
        Me.txtDsctoMer.TabIndex = 14
        Me.txtDsctoMer.Text = "0.00"
        Me.txtDsctoMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(73, 90)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(362, 39)
        Me.txtObservacion.TabIndex = 15
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(208, 17)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarProveedor.TabIndex = 19
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biNuevo, Me.ToolStripSeparator1, Me.biModificar, Me.ToolStripSeparator2, Me.biEliminar, Me.ToolStripSeparator3, Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(479, 31)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Guardar Solicitud"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biModificar
        '
        Me.biModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biModificar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biModificar.Name = "biModificar"
        Me.biModificar.Size = New System.Drawing.Size(28, 28)
        Me.biModificar.Text = "Editar Cabecera"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Deshacer Cabecera"
        Me.biEliminar.ToolTipText = "Mostrar Solicitud Seleccionada"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Salir de la Ventana Actual"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.Location = New System.Drawing.Point(160, 443)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 25)
        Me.btnGuardar.TabIndex = 21
        Me.btnGuardar.Text = "Guardar"
        '
        'btnDeshacer
        '
        Me.btnDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnDeshacer.Location = New System.Drawing.Point(241, 442)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(75, 25)
        Me.btnDeshacer.TabIndex = 22
        Me.btnDeshacer.Text = "Deshacer"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarProveedor)
        Me.UiGroupBox1.Controls.Add(Me.txtDesPrv)
        Me.UiGroupBox1.Controls.Add(Me.txtCodPrv)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 223)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(453, 70)
        Me.UiGroupBox1.TabIndex = 23
        Me.UiGroupBox1.Text = "Proveedor"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox2.Controls.Add(Me.txtDsctoMer)
        Me.UiGroupBox2.Controls.Add(Me.txtPreMer)
        Me.UiGroupBox2.Controls.Add(Me.txtCotizacion)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 299)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(452, 136)
        Me.UiGroupBox2.TabIndex = 24
        Me.UiGroupBox2.Text = "Datos de Cotización"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmComSolicitudCompra_AgregarCotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 474)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnDeshacer)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudCompra_AgregarCotizacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmComSolicitudCompra_AgregarCotizacion"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDesPrv As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtCodPrv As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDsctoMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPreMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCotizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents VisualStyleManager1 As Janus.Windows.Common.VisualStyleManager
    Friend WithEvents btnBuscarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeshacer As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
End Class
