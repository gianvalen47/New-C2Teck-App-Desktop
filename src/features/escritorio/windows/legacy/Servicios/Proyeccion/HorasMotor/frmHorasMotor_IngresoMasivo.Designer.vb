<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorasMotor_IngresoMasivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHorasMotor_IngresoMasivo))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biIngresar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cNumSerie2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNomEquipo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalHoras2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cHoraTotalNueva2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDatosTemp = New System.Windows.Forms.DataGridView()
        Me.cNumSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNomEquipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalHoras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cModMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecFinGarantia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesUbicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cHoraParcial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMantenimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFechaMantenimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatosTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biIngresar, Me.ToolStripSeparator1, Me.biCerrar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(746, 31)
        Me.ToolStrip.TabIndex = 251
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biIngresar
        '
        Me.biIngresar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biIngresar.Image = CType(resources.GetObject("biIngresar.Image"), System.Drawing.Image)
        Me.biIngresar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biIngresar.Name = "biIngresar"
        Me.biIngresar.Size = New System.Drawing.Size(28, 28)
        Me.biIngresar.Text = "Agregar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Location = New System.Drawing.Point(268, 44)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(64, 13)
        Me.lblUbicacion.TabIndex = 252
        Me.lblUbicacion.Text = "Ubicacion"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Enabled = False
        Me.txtUbicacion.Location = New System.Drawing.Point(338, 40)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(100, 20)
        Me.txtUbicacion.TabIndex = 253
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cNumSerie2, Me.cNomEquipo2, Me.cTotalHoras2, Me.cHoraTotalNueva2, Me.cObservacion2})
        Me.dgvDatos.Location = New System.Drawing.Point(12, 72)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersVisible = False
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDatos.Size = New System.Drawing.Size(707, 304)
        Me.dgvDatos.TabIndex = 254
        '
        'cNumSerie2
        '
        Me.cNumSerie2.DataPropertyName = "NumSerie"
        Me.cNumSerie2.HeaderText = "Serie Motor"
        Me.cNumSerie2.Name = "cNumSerie2"
        Me.cNumSerie2.ReadOnly = True
        Me.cNumSerie2.Width = 120
        '
        'cNomEquipo2
        '
        Me.cNomEquipo2.DataPropertyName = "NomEquipo"
        Me.cNomEquipo2.HeaderText = "Equipo"
        Me.cNomEquipo2.Name = "cNomEquipo2"
        Me.cNomEquipo2.ReadOnly = True
        Me.cNomEquipo2.Width = 120
        '
        'cTotalHoras2
        '
        Me.cTotalHoras2.DataPropertyName = "TotalHoras"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cTotalHoras2.DefaultCellStyle = DataGridViewCellStyle8
        Me.cTotalHoras2.HeaderText = "Hrs. Tot. Actual"
        Me.cTotalHoras2.Name = "cTotalHoras2"
        Me.cTotalHoras2.ReadOnly = True
        Me.cTotalHoras2.Width = 120
        '
        'cHoraTotalNueva2
        '
        Me.cHoraTotalNueva2.DataPropertyName = "HoraTotalNueva"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cHoraTotalNueva2.DefaultCellStyle = DataGridViewCellStyle9
        Me.cHoraTotalNueva2.HeaderText = "Hrs. Tot. Nueva"
        Me.cHoraTotalNueva2.Name = "cHoraTotalNueva2"
        Me.cHoraTotalNueva2.Width = 120
        '
        'cObservacion2
        '
        Me.cObservacion2.DataPropertyName = "Observacion"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cObservacion2.DefaultCellStyle = DataGridViewCellStyle10
        Me.cObservacion2.HeaderText = "Observacion"
        Me.cObservacion2.Name = "cObservacion2"
        Me.cObservacion2.Width = 200
        '
        'dgvDatosTemp
        '
        Me.dgvDatosTemp.AllowUserToAddRows = False
        Me.dgvDatosTemp.AllowUserToDeleteRows = False
        Me.dgvDatosTemp.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatosTemp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDatosTemp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cNumSerie, Me.cNomEquipo, Me.cTotalHoras, Me.cDescripcion, Me.cModMer, Me.cFecFinGarantia, Me.cDesUbicacion, Me.cHoraParcial, Me.cDesMantenimiento, Me.cFechaMantenimiento, Me.cObservacion})
        Me.dgvDatosTemp.Location = New System.Drawing.Point(632, 36)
        Me.dgvDatosTemp.MultiSelect = False
        Me.dgvDatosTemp.Name = "dgvDatosTemp"
        Me.dgvDatosTemp.RowHeadersVisible = False
        Me.dgvDatosTemp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatosTemp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDatosTemp.Size = New System.Drawing.Size(41, 30)
        Me.dgvDatosTemp.TabIndex = 255
        Me.dgvDatosTemp.Visible = False
        '
        'cNumSerie
        '
        Me.cNumSerie.DataPropertyName = "NumSerie"
        Me.cNumSerie.HeaderText = "Serie Motor"
        Me.cNumSerie.Name = "cNumSerie"
        Me.cNumSerie.ReadOnly = True
        Me.cNumSerie.Width = 120
        '
        'cNomEquipo
        '
        Me.cNomEquipo.DataPropertyName = "NomEquipo"
        Me.cNomEquipo.HeaderText = "Equipo"
        Me.cNomEquipo.Name = "cNomEquipo"
        Me.cNomEquipo.ReadOnly = True
        Me.cNomEquipo.Width = 120
        '
        'cTotalHoras
        '
        Me.cTotalHoras.DataPropertyName = "TotalHoras"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cTotalHoras.DefaultCellStyle = DataGridViewCellStyle2
        Me.cTotalHoras.HeaderText = "Hrs. Tot. Actual"
        Me.cTotalHoras.Name = "cTotalHoras"
        Me.cTotalHoras.ReadOnly = True
        Me.cTotalHoras.Width = 120
        '
        'cDescripcion
        '
        Me.cDescripcion.DataPropertyName = "Descripcion"
        DataGridViewCellStyle3.Format = "d"
        Me.cDescripcion.DefaultCellStyle = DataGridViewCellStyle3
        Me.cDescripcion.HeaderText = "Descripcion"
        Me.cDescripcion.Name = "cDescripcion"
        Me.cDescripcion.ReadOnly = True
        Me.cDescripcion.Visible = False
        Me.cDescripcion.Width = 80
        '
        'cModMer
        '
        Me.cModMer.DataPropertyName = "ModMer"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cModMer.DefaultCellStyle = DataGridViewCellStyle4
        Me.cModMer.HeaderText = "ModMer"
        Me.cModMer.Name = "cModMer"
        Me.cModMer.ReadOnly = True
        Me.cModMer.Visible = False
        Me.cModMer.Width = 80
        '
        'cFecFinGarantia
        '
        Me.cFecFinGarantia.DataPropertyName = "FecFinGarantia"
        Me.cFecFinGarantia.HeaderText = "FecFinGarantia"
        Me.cFecFinGarantia.Name = "cFecFinGarantia"
        Me.cFecFinGarantia.ReadOnly = True
        Me.cFecFinGarantia.Visible = False
        Me.cFecFinGarantia.Width = 80
        '
        'cDesUbicacion
        '
        Me.cDesUbicacion.DataPropertyName = "DesUbicacion"
        Me.cDesUbicacion.HeaderText = "DesUbicacion"
        Me.cDesUbicacion.Name = "cDesUbicacion"
        Me.cDesUbicacion.ReadOnly = True
        Me.cDesUbicacion.Visible = False
        Me.cDesUbicacion.Width = 50
        '
        'cHoraParcial
        '
        Me.cHoraParcial.DataPropertyName = "HoraParcial"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cHoraParcial.DefaultCellStyle = DataGridViewCellStyle5
        Me.cHoraParcial.HeaderText = "HoraParcial"
        Me.cHoraParcial.Name = "cHoraParcial"
        Me.cHoraParcial.ReadOnly = True
        Me.cHoraParcial.Visible = False
        '
        'cDesMantenimiento
        '
        Me.cDesMantenimiento.DataPropertyName = "DesMantenimiento"
        Me.cDesMantenimiento.HeaderText = "DesMantenimiento"
        Me.cDesMantenimiento.Name = "cDesMantenimiento"
        Me.cDesMantenimiento.Visible = False
        '
        'cFechaMantenimiento
        '
        Me.cFechaMantenimiento.DataPropertyName = "FechaMantenimiento"
        Me.cFechaMantenimiento.HeaderText = "FechaMantenimiento"
        Me.cFechaMantenimiento.Name = "cFechaMantenimiento"
        Me.cFechaMantenimiento.Visible = False
        '
        'cObservacion
        '
        Me.cObservacion.DataPropertyName = "Observacion"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cObservacion.DefaultCellStyle = DataGridViewCellStyle6
        Me.cObservacion.HeaderText = "Observacion"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.Width = 200
        '
        'frmHorasMotor_IngresoMasivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(746, 408)
        Me.Controls.Add(Me.dgvDatosTemp)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.txtUbicacion)
        Me.Controls.Add(Me.lblUbicacion)
        Me.Controls.Add(Me.ToolStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHorasMotor_IngresoMasivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Masivo de Horas Motor"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatosTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biIngresar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents txtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDatosTemp As System.Windows.Forms.DataGridView
    Friend WithEvents cNumSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNomEquipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalHoras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cModMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecFinGarantia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesUbicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cHoraParcial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMantenimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFechaMantenimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNumSerie2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNomEquipo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalHoras2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cHoraTotalNueva2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
