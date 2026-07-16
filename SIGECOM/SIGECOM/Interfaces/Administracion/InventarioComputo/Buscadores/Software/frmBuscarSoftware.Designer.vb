<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarSoftware
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
        Dim cmbTipoSoftware_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarSoftware))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.cbLicenciaAplica = New System.Windows.Forms.CheckBox()
        Me.cmbTipoSoftware = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNomAplicacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbTipoSoftware, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.cbVigente)
        Me.gbDatosBusqueda.Controls.Add(Me.cbLicenciaAplica)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbTipoSoftware)
        Me.gbDatosBusqueda.Controls.Add(Me.Label3)
        Me.gbDatosBusqueda.Controls.Add(Me.txtNomAplicacion)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(12, 12)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(674, 65)
        Me.gbDatosBusqueda.TabIndex = 258
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbVigente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVigente.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbVigente.Location = New System.Drawing.Point(432, 21)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(47, 31)
        Me.cbVigente.TabIndex = 297
        Me.cbVigente.Text = "Vigente"
        Me.cbVigente.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cbVigente.UseVisualStyleBackColor = True
        '
        'cbLicenciaAplica
        '
        Me.cbLicenciaAplica.AutoSize = True
        Me.cbLicenciaAplica.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbLicenciaAplica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLicenciaAplica.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbLicenciaAplica.Location = New System.Drawing.Point(333, 21)
        Me.cbLicenciaAplica.Name = "cbLicenciaAplica"
        Me.cbLicenciaAplica.Size = New System.Drawing.Size(83, 31)
        Me.cbLicenciaAplica.TabIndex = 296
        Me.cbLicenciaAplica.Text = "Licencia Aplica"
        Me.cbLicenciaAplica.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cbLicenciaAplica.UseVisualStyleBackColor = True
        '
        'cmbTipoSoftware
        '
        Me.cmbTipoSoftware.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoSoftware_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoSoftware_DesignTimeLayout.LayoutString")
        Me.cmbTipoSoftware.DesignTimeLayout = cmbTipoSoftware_DesignTimeLayout
        Me.cmbTipoSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSoftware.Location = New System.Drawing.Point(70, 37)
        Me.cmbTipoSoftware.Name = "cmbTipoSoftware"
        Me.cmbTipoSoftware.SelectedIndex = -1
        Me.cmbTipoSoftware.SelectedItem = Nothing
        Me.cmbTipoSoftware.Size = New System.Drawing.Size(119, 20)
        Me.cmbTipoSoftware.TabIndex = 295
        Me.cmbTipoSoftware.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(85, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 292
        Me.Label3.Text = "Tipo Software"
        '
        'txtNomAplicacion
        '
        Me.txtNomAplicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomAplicacion.Location = New System.Drawing.Point(205, 37)
        Me.txtNomAplicacion.MaxLength = 50
        Me.txtNomAplicacion.Name = "txtNomAplicacion"
        Me.txtNomAplicacion.Size = New System.Drawing.Size(114, 20)
        Me.txtNomAplicacion.TabIndex = 288
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(232, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 263
        Me.Label2.Text = "Aplicación"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(499, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(12, 88)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(674, 206)
        Me.dgvDatos.TabIndex = 299
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 312)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(697, 20)
        Me.ssBarra.TabIndex = 301
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(280, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(150, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionar, Me.ToolStripMenuItem1, Me.miNinguno, Me.ToolStripSeparator1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(135, 82)
        '
        'miSeleccionar
        '
        Me.miSeleccionar.Image = CType(resources.GetObject("miSeleccionar.Image"), System.Drawing.Image)
        Me.miSeleccionar.Name = "miSeleccionar"
        Me.miSeleccionar.Size = New System.Drawing.Size(134, 22)
        Me.miSeleccionar.Text = "Seleccionar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(131, 6)
        '
        'miNinguno
        '
        Me.miNinguno.Image = CType(resources.GetObject("miNinguno.Image"), System.Drawing.Image)
        Me.miNinguno.Name = "miNinguno"
        Me.miNinguno.Size = New System.Drawing.Size(134, 22)
        Me.miNinguno.Text = "Ninguno"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(131, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(134, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'frmBuscarSoftware
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(697, 332)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarSoftware"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Software"
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbTipoSoftware, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbVigente As CheckBox
    Friend WithEvents cbLicenciaAplica As CheckBox
    Friend WithEvents cmbTipoSoftware As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNomAplicacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As StatusStrip
    Friend WithEvents sslError As ToolStripStatusLabel
    Friend WithEvents sslTotal As ToolStripStatusLabel
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miSeleccionar As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miNinguno As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
End Class
