<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturacionElectronica_ComunicadoBaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturacionElectronica_ComunicadoBaja))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbProcesoJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miObtenerEstadoSunat = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbTipDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumDocRef = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSerieDocRef = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biObtenerEstadoSunat = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProcesoJob.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.cmbTipDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbProcesoJob
        '
        Me.gbProcesoJob.Controls.Add(Me.ssBarra)
        Me.gbProcesoJob.Controls.Add(Me.btnBuscar)
        Me.gbProcesoJob.Controls.Add(Me.dgvDatos)
        Me.gbProcesoJob.Controls.Add(Me.cmbTipDoc)
        Me.gbProcesoJob.Controls.Add(Me.Label6)
        Me.gbProcesoJob.Controls.Add(Me.txtNumDocRef)
        Me.gbProcesoJob.Controls.Add(Me.Label16)
        Me.gbProcesoJob.Controls.Add(Me.txtSerieDocRef)
        Me.gbProcesoJob.Controls.Add(Me.Label8)
        Me.gbProcesoJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProcesoJob.Location = New System.Drawing.Point(12, 37)
        Me.gbProcesoJob.Name = "gbProcesoJob"
        Me.gbProcesoJob.Size = New System.Drawing.Size(874, 374)
        Me.gbProcesoJob.TabIndex = 114
        Me.gbProcesoJob.Text = "Datos del documento"
        Me.gbProcesoJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(3, 351)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(868, 20)
        Me.ssBarra.TabIndex = 120
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
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
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(647, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 25)
        Me.btnBuscar.TabIndex = 40
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(14, 69)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(844, 270)
        Me.dgvDatos.TabIndex = 118
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMostrar, Me.miObtenerEstadoSunat, Me.ToolStripSeparator21, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(189, 76)
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(188, 22)
        Me.miMostrar.Text = "&Mostrar"
        '
        'miObtenerEstadoSunat
        '
        Me.miObtenerEstadoSunat.Image = Global.SIGECOM.My.Resources.Resources.Enviar_
        Me.miObtenerEstadoSunat.Name = "miObtenerEstadoSunat"
        Me.miObtenerEstadoSunat.Size = New System.Drawing.Size(188, 22)
        Me.miObtenerEstadoSunat.Text = "Obtener Estado Sunat"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(185, 6)
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(188, 22)
        Me.miSalir.Text = "&Salir"
        '
        'cmbTipDoc
        '
        Me.cmbTipDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipDoc.DesignTimeLayout = cmbTipDoc_DesignTimeLayout
        Me.cmbTipDoc.Location = New System.Drawing.Point(236, 28)
        Me.cmbTipDoc.Name = "cmbTipDoc"
        Me.cmbTipDoc.SelectedIndex = -1
        Me.cmbTipDoc.SelectedItem = Nothing
        Me.cmbTipDoc.Size = New System.Drawing.Size(124, 20)
        Me.cmbTipDoc.TabIndex = 37
        Me.cmbTipDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(167, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Tipo Doc."
        '
        'txtNumDocRef
        '
        Me.txtNumDocRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDocRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDocRef.Location = New System.Drawing.Point(556, 28)
        Me.txtNumDocRef.MaxLength = 100
        Me.txtNumDocRef.Name = "txtNumDocRef"
        Me.txtNumDocRef.Size = New System.Drawing.Size(70, 20)
        Me.txtNumDocRef.TabIndex = 39
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(501, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "N° Doc."
        '
        'txtSerieDocRef
        '
        Me.txtSerieDocRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDocRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDocRef.Location = New System.Drawing.Point(437, 28)
        Me.txtSerieDocRef.MaxLength = 100
        Me.txtSerieDocRef.Name = "txtSerieDocRef"
        Me.txtSerieDocRef.Size = New System.Drawing.Size(48, 20)
        Me.txtSerieDocRef.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(398, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Serie"
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biMostrar, Me.ToolStripSeparator2, Me.biObtenerEstadoSunat, Me.ToolStripSeparator1, Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(914, 31)
        Me.ToolStrip1.TabIndex = 115
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar"
        Me.biMostrar.ToolTipText = "Mostrar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biObtenerEstadoSunat
        '
        Me.biObtenerEstadoSunat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biObtenerEstadoSunat.Image = Global.SIGECOM.My.Resources.Resources.Enviar_
        Me.biObtenerEstadoSunat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biObtenerEstadoSunat.Name = "biObtenerEstadoSunat"
        Me.biObtenerEstadoSunat.Size = New System.Drawing.Size(28, 28)
        Me.biObtenerEstadoSunat.Text = "Obtener Estado Sunat"
        Me.biObtenerEstadoSunat.ToolTipText = "Obtener Estado Sunat"
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
        Me.biSalir.Text = "Salir"
        '
        'frmFacturacionElectronica_ComunicadoBaja
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(914, 438)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbProcesoJob)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturacionElectronica_ComunicadoBaja"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturacion Electronica - Comunicados de Baja"
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProcesoJob.ResumeLayout(False)
        Me.gbProcesoJob.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.cmbTipDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbProcesoJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbTipDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumDocRef As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSerieDocRef As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents biObtenerEstadoSunat As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miObtenerEstadoSunat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
End Class
