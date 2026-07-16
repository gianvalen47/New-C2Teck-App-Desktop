<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarEquipo
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
        Dim cmbModelo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMarca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarEquipo))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDesEquipo = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumSerie = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbModelo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDesEquipo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNumSerie)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbModelo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbMarca)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(594, 73)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Búsqueda"
        '
        'txtDesEquipo
        '
        Me.txtDesEquipo.Location = New System.Drawing.Point(404, 39)
        Me.txtDesEquipo.Name = "txtDesEquipo"
        Me.txtDesEquipo.Numeric = True
        Me.txtDesEquipo.Size = New System.Drawing.Size(112, 20)
        Me.txtDesEquipo.TabIndex = 292
        Me.txtDesEquipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(438, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 293
        Me.Label3.Text = "Equipo"
        '
        'txtNumSerie
        '
        Me.txtNumSerie.Location = New System.Drawing.Point(276, 39)
        Me.txtNumSerie.Name = "txtNumSerie"
        Me.txtNumSerie.Numeric = True
        Me.txtNumSerie.Size = New System.Drawing.Size(112, 20)
        Me.txtNumSerie.TabIndex = 290
        Me.txtNumSerie.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(309, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 291
        Me.Label6.Text = "Serie"
        '
        'cmbModelo
        '
        Me.cmbModelo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbModelo_DesignTimeLayout.LayoutString = resources.GetString("cmbModelo_DesignTimeLayout.LayoutString")
        Me.cmbModelo.DesignTimeLayout = cmbModelo_DesignTimeLayout
        Me.cmbModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModelo.Location = New System.Drawing.Point(141, 39)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.SelectedIndex = -1
        Me.cmbModelo.SelectedItem = Nothing
        Me.cmbModelo.Size = New System.Drawing.Size(119, 20)
        Me.cmbModelo.TabIndex = 289
        Me.cmbModelo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(178, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Modelo"
        '
        'cmbMarca
        '
        Me.cmbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMarca_DesignTimeLayout.LayoutString = resources.GetString("cmbMarca_DesignTimeLayout.LayoutString")
        Me.cmbMarca.DesignTimeLayout = cmbMarca_DesignTimeLayout
        Me.cmbMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.Location = New System.Drawing.Point(6, 39)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.SelectedIndex = -1
        Me.cmbMarca.SelectedItem = Nothing
        Me.cmbMarca.Size = New System.Drawing.Size(119, 20)
        Me.cmbMarca.TabIndex = 287
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 286
        Me.Label2.Text = "Marca"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(523, 35)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(61, 25)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 312)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(617, 20)
        Me.ssBarra.TabIndex = 22
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
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(12, 91)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(590, 206)
        Me.dgvDatos.TabIndex = 239
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmBuscarEquipo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(617, 332)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarEquipo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Equipo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNinguno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtDesEquipo As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumSerie As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbModelo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
End Class
