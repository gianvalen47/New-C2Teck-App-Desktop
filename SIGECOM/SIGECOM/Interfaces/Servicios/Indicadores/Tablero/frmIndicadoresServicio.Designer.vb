<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadoresServicio
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
        Dim dgvDatosNivSer_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosNivSer_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column15.HeaderImage")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadoresServicio))
        Dim dgvDatosNivSer_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column16.Image")
        Dim cmbAno_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosMO_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosMO_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column9.HeaderImage")
        Dim dgvDatosMO_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column10.Image")
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.txtLunes = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMesAnt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtdiaant = New System.Windows.Forms.Button()
        Me.txtdiasig = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAnio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMes = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtSemana = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvDatosNivSer = New Janus.Windows.GridEX.GridEX()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbAno = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnActualizarNivSer = New System.Windows.Forms.Button()
        Me.dgvDatosMO = New Janus.Windows.GridEX.GridEX()
        Me.btnActualizarMO = New System.Windows.Forms.Button()
        Me.btnAtrasoConsolidado = New System.Windows.Forms.Button()
        Me.dgvTipo4 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDatosNivSer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbAno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvDatosMO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipo4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReporte)
        Me.GroupBox1.Controls.Add(Me.txtLunes)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMesAnt)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.txtdiaant)
        Me.GroupBox1.Controls.Add(Me.txtdiasig)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 315)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(679, 10)
        Me.GroupBox1.TabIndex = 271
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.Location = New System.Drawing.Point(30, 69)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(56, 23)
        Me.btnReporte.TabIndex = 272
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        Me.btnReporte.Visible = False
        '
        'txtLunes
        '
        '
        '
        '
        Me.txtLunes.DropDownCalendar.Name = ""
        Me.txtLunes.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtLunes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLunes.IsNullDate = True
        Me.txtLunes.Location = New System.Drawing.Point(30, 47)
        Me.txtLunes.Name = "txtLunes"
        Me.txtLunes.Size = New System.Drawing.Size(103, 20)
        Me.txtLunes.TabIndex = 271
        Me.txtLunes.Visible = False
        Me.txtLunes.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(423, 47)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(71, 23)
        Me.btnBuscar.TabIndex = 270
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(214, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 257
        Me.Label2.Text = "Fecha Actual : "
        '
        'txtMesAnt
        '
        Me.txtMesAnt.BackColor = System.Drawing.SystemColors.Control
        Me.txtMesAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesAnt.Location = New System.Drawing.Point(638, 87)
        Me.txtMesAnt.MaxLength = 10
        Me.txtMesAnt.Name = "txtMesAnt"
        Me.txtMesAnt.ReadOnly = True
        Me.txtMesAnt.Size = New System.Drawing.Size(42, 20)
        Me.txtMesAnt.TabIndex = 269
        Me.txtMesAnt.TabStop = False
        Me.txtMesAnt.Text = "0"
        Me.txtMesAnt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtMesAnt.Value = CType(0US, UShort)
        Me.txtMesAnt.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt16
        Me.txtMesAnt.Visible = False
        Me.txtMesAnt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.IsNullDate = True
        Me.txtFecha.Location = New System.Drawing.Point(313, 47)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(103, 20)
        Me.txtFecha.TabIndex = 259
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtdiaant
        '
        Me.txtdiaant.Location = New System.Drawing.Point(313, 69)
        Me.txtdiaant.Name = "txtdiaant"
        Me.txtdiaant.Size = New System.Drawing.Size(46, 20)
        Me.txtdiaant.TabIndex = 260
        Me.txtdiaant.Text = "<"
        Me.txtdiaant.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.txtdiaant.UseVisualStyleBackColor = True
        '
        'txtdiasig
        '
        Me.txtdiasig.Location = New System.Drawing.Point(358, 69)
        Me.txtdiasig.Name = "txtdiasig"
        Me.txtdiasig.Size = New System.Drawing.Size(46, 20)
        Me.txtdiasig.TabIndex = 261
        Me.txtdiasig.Text = ">"
        Me.txtdiasig.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.txtdiasig.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(542, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 265
        Me.Label7.Text = "Mes Anterior : "
        Me.Label7.Visible = False
        '
        'txtAnio
        '
        Me.txtAnio.BackColor = System.Drawing.SystemColors.Control
        Me.txtAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtAnio.Location = New System.Drawing.Point(258, 14)
        Me.txtAnio.MaxLength = 10
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ReadOnly = True
        Me.txtAnio.Size = New System.Drawing.Size(42, 20)
        Me.txtAnio.TabIndex = 268
        Me.txtAnio.TabStop = False
        Me.txtAnio.Text = "0"
        Me.txtAnio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtAnio.Value = CType(0, Short)
        Me.txtAnio.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.txtAnio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMes
        '
        Me.txtMes.BackColor = System.Drawing.SystemColors.Control
        Me.txtMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMes.Location = New System.Drawing.Point(168, 14)
        Me.txtMes.MaxLength = 10
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(42, 20)
        Me.txtMes.TabIndex = 267
        Me.txtMes.TabStop = False
        Me.txtMes.Text = "0"
        Me.txtMes.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtMes.Value = CType(0, Short)
        Me.txtMes.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.txtMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtSemana
        '
        Me.txtSemana.BackColor = System.Drawing.SystemColors.Control
        Me.txtSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSemana.Location = New System.Drawing.Point(74, 14)
        Me.txtSemana.MaxLength = 10
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.ReadOnly = True
        Me.txtSemana.Size = New System.Drawing.Size(42, 20)
        Me.txtSemana.TabIndex = 266
        Me.txtSemana.TabStop = False
        Me.txtSemana.Text = "0"
        Me.txtSemana.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtSemana.Value = CType(0, Short)
        Me.txtSemana.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.txtSemana.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Semana : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(123, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "Mes : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(217, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 264
        Me.Label6.Text = "Año : "
        '
        'dgvDatosNivSer
        '
        Me.dgvDatosNivSer.AllowCardSizing = False
        Me.dgvDatosNivSer.AllowColumnDrag = False
        Me.dgvDatosNivSer.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvDatosNivSer.AlternatingColors = True
        Me.dgvDatosNivSer.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        dgvDatosNivSer_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatosNivSer_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatosNivSer_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("dgvDatosNivSer_DesignTimeLayout_Reference_1.Instance"), Object)
        dgvDatosNivSer_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatosNivSer_DesignTimeLayout_Reference_0, dgvDatosNivSer_DesignTimeLayout_Reference_1})
        dgvDatosNivSer_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosNivSer_DesignTimeLayout.LayoutString")
        Me.dgvDatosNivSer.DesignTimeLayout = dgvDatosNivSer_DesignTimeLayout
        Me.dgvDatosNivSer.EmptyRows = True
        Me.dgvDatosNivSer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosNivSer.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvDatosNivSer.GroupByBoxVisible = False
        Me.dgvDatosNivSer.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvDatosNivSer.Location = New System.Drawing.Point(12, 110)
        Me.dgvDatosNivSer.Name = "dgvDatosNivSer"
        Me.dgvDatosNivSer.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosNivSer.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosNivSer.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosNivSer.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosNivSer.SelectOnExpand = False
        Me.dgvDatosNivSer.Size = New System.Drawing.Size(810, 199)
        Me.dgvDatosNivSer.TabIndex = 272
        Me.dgvDatosNivSer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cmbAno)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 12)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(813, 62)
        Me.UiGroupBox1.TabIndex = 273
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbAno
        '
        Me.cmbAno.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAno_DesignTimeLayout.LayoutString = resources.GetString("cmbAno_DesignTimeLayout.LayoutString")
        Me.cmbAno.DesignTimeLayout = cmbAno_DesignTimeLayout
        Me.cmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAno.Location = New System.Drawing.Point(59, 24)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.SelectedIndex = -1
        Me.cmbAno.SelectedItem = Nothing
        Me.cmbAno.Size = New System.Drawing.Size(60, 20)
        Me.cmbAno.TabIndex = 280
        Me.cmbAno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 279
        Me.Label3.Text = "Año :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtSemana)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtAnio)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Controls.Add(Me.txtMes)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(498, 10)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(310, 42)
        Me.UiGroupBox2.TabIndex = 279
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(398, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 263
        Me.Label1.Text = "Fecha Actual : "
        '
        'btnActualizarNivSer
        '
        Me.btnActualizarNivSer.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnActualizarNivSer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizarNivSer.Location = New System.Drawing.Point(732, 80)
        Me.btnActualizarNivSer.Name = "btnActualizarNivSer"
        Me.btnActualizarNivSer.Size = New System.Drawing.Size(90, 24)
        Me.btnActualizarNivSer.TabIndex = 272
        Me.btnActualizarNivSer.Text = "Actualizar"
        Me.btnActualizarNivSer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizarNivSer.UseVisualStyleBackColor = True
        '
        'dgvDatosMO
        '
        Me.dgvDatosMO.AllowCardSizing = False
        Me.dgvDatosMO.AllowColumnDrag = False
        Me.dgvDatosMO.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvDatosMO.AlternatingColors = True
        Me.dgvDatosMO.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        dgvDatosMO_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatosMO_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatosMO_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("dgvDatosMO_DesignTimeLayout_Reference_1.Instance"), Object)
        dgvDatosMO_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatosMO_DesignTimeLayout_Reference_0, dgvDatosMO_DesignTimeLayout_Reference_1})
        dgvDatosMO_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosMO_DesignTimeLayout.LayoutString")
        Me.dgvDatosMO.DesignTimeLayout = dgvDatosMO_DesignTimeLayout
        Me.dgvDatosMO.EmptyRows = True
        Me.dgvDatosMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosMO.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvDatosMO.GroupByBoxVisible = False
        Me.dgvDatosMO.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvDatosMO.Location = New System.Drawing.Point(14, 358)
        Me.dgvDatosMO.Name = "dgvDatosMO"
        Me.dgvDatosMO.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosMO.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosMO.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosMO.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosMO.SelectOnExpand = False
        Me.dgvDatosMO.Size = New System.Drawing.Size(808, 212)
        Me.dgvDatosMO.TabIndex = 274
        Me.dgvDatosMO.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnActualizarMO
        '
        Me.btnActualizarMO.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnActualizarMO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizarMO.Location = New System.Drawing.Point(732, 328)
        Me.btnActualizarMO.Name = "btnActualizarMO"
        Me.btnActualizarMO.Size = New System.Drawing.Size(90, 24)
        Me.btnActualizarMO.TabIndex = 275
        Me.btnActualizarMO.Text = "Actualizar"
        Me.btnActualizarMO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizarMO.UseVisualStyleBackColor = True
        '
        'btnAtrasoConsolidado
        '
        Me.btnAtrasoConsolidado.Image = CType(resources.GetObject("btnAtrasoConsolidado.Image"), System.Drawing.Image)
        Me.btnAtrasoConsolidado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtrasoConsolidado.Location = New System.Drawing.Point(577, 80)
        Me.btnAtrasoConsolidado.Name = "btnAtrasoConsolidado"
        Me.btnAtrasoConsolidado.Size = New System.Drawing.Size(145, 24)
        Me.btnAtrasoConsolidado.TabIndex = 276
        Me.btnAtrasoConsolidado.Text = "Atraso Consolidado"
        Me.btnAtrasoConsolidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAtrasoConsolidado.UseVisualStyleBackColor = True
        '
        'dgvTipo4
        '
        Me.dgvTipo4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo4.Location = New System.Drawing.Point(675, 328)
        Me.dgvTipo4.Name = "dgvTipo4"
        Me.dgvTipo4.Size = New System.Drawing.Size(47, 20)
        Me.dgvTipo4.TabIndex = 278
        Me.dgvTipo4.Visible = False
        '
        'frmIndicadoresServicio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(836, 598)
        Me.Controls.Add(Me.dgvTipo4)
        Me.Controls.Add(Me.btnAtrasoConsolidado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnActualizarNivSer)
        Me.Controls.Add(Me.btnActualizarMO)
        Me.Controls.Add(Me.dgvDatosMO)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatosNivSer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIndicadoresServicio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicadores de Servicio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDatosNivSer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbAno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.dgvDatosMO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipo4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMesAnt As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtAnio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtdiaant As System.Windows.Forms.Button
    Friend WithEvents txtMes As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtdiasig As System.Windows.Forms.Button
    Friend WithEvents txtSemana As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvDatosNivSer As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtLunes As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnActualizarNivSer As System.Windows.Forms.Button
    Friend WithEvents dgvDatosMO As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnActualizarMO As System.Windows.Forms.Button
    Friend WithEvents btnAtrasoConsolidado As System.Windows.Forms.Button
    Friend WithEvents dgvTipo4 As System.Windows.Forms.DataGridView
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbAno As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As Label
End Class
