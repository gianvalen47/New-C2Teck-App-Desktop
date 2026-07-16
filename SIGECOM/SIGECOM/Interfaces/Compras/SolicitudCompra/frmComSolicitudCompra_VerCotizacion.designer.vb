<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudCompra_VerCotizacion
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudCompra_VerCotizacion))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.txtDesPrv = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCotizacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtPreMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDsctoMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.VisualStyleManager1 = New Janus.Windows.Common.VisualStyleManager(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
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
        Me.Label1.Location = New System.Drawing.Point(10, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cotizacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Precio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Dscto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Observacion"
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(4, 34)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Office2007CustomColor = System.Drawing.Color.White
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(558, 205)
        Me.dgvDatos.TabIndex = 9
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDesPrv
        '
        Me.txtDesPrv.Location = New System.Drawing.Point(88, 19)
        Me.txtDesPrv.Name = "txtDesPrv"
        Me.txtDesPrv.ReadOnly = True
        Me.txtDesPrv.Size = New System.Drawing.Size(423, 20)
        Me.txtDesPrv.TabIndex = 11
        Me.txtDesPrv.TabStop = False
        Me.txtDesPrv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCotizacion
        '
        Me.txtCotizacion.Location = New System.Drawing.Point(88, 45)
        Me.txtCotizacion.Name = "txtCotizacion"
        Me.txtCotizacion.ReadOnly = True
        Me.txtCotizacion.Size = New System.Drawing.Size(225, 20)
        Me.txtCotizacion.TabIndex = 12
        Me.txtCotizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPreMer
        '
        Me.txtPreMer.DecimalDigits = 4
        Me.txtPreMer.Location = New System.Drawing.Point(88, 69)
        Me.txtPreMer.Name = "txtPreMer"
        Me.txtPreMer.ReadOnly = True
        Me.txtPreMer.Size = New System.Drawing.Size(103, 20)
        Me.txtPreMer.TabIndex = 13
        Me.txtPreMer.Text = "0.0000"
        Me.txtPreMer.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtPreMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDsctoMer
        '
        Me.txtDsctoMer.Location = New System.Drawing.Point(88, 93)
        Me.txtDsctoMer.Name = "txtDsctoMer"
        Me.txtDsctoMer.ReadOnly = True
        Me.txtDsctoMer.Size = New System.Drawing.Size(103, 20)
        Me.txtDsctoMer.TabIndex = 14
        Me.txtDsctoMer.Text = "0.00"
        Me.txtDsctoMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDsctoMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(88, 116)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(436, 39)
        Me.txtObservacion.TabIndex = 15
        Me.txtObservacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(571, 31)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.txtDsctoMer)
        Me.UiGroupBox1.Controls.Add(Me.txtPreMer)
        Me.UiGroupBox1.Controls.Add(Me.txtCotizacion)
        Me.UiGroupBox1.Controls.Add(Me.txtDesPrv)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(4, 245)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(558, 165)
        Me.UiGroupBox1.TabIndex = 21
        Me.UiGroupBox1.Text = "Datos de Cotización"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmComSolicitudCompra_VerCotizacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(571, 421)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudCompra_VerCotizacion"
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
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDsctoMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPreMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCotizacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents VisualStyleManager1 As Janus.Windows.Common.VisualStyleManager
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
End Class
