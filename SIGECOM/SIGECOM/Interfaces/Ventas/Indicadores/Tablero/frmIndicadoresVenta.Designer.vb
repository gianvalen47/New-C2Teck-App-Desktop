<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadoresVenta
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
        Dim dgvDatosMensual_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosMensual_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column8.HeaderImage")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadoresVenta))
        Dim dgvDatosMensual_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column9.Image")
        Dim dgvDatosDiario_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosDiario_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column8.HeaderImage")
        Dim dgvDatosDiario_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column9.Image")
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.dgvDatosMensual = New Janus.Windows.GridEX.GridEX()
        Me.dgvDatosDiario = New Janus.Windows.GridEX.GridEX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdiaant = New System.Windows.Forms.Button()
        Me.txtdiasig = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSemana = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMes = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtAnio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMesAnt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaMensual = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscarMensual = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarDiaria = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaDiaria = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtdiaantdia = New System.Windows.Forms.Button()
        Me.txtdiasigdia = New System.Windows.Forms.Button()
        CType(Me.dgvDatosMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatosDiario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDatosMensual
        '
        Me.dgvDatosMensual.AllowCardSizing = False
        Me.dgvDatosMensual.AllowColumnDrag = False
        Me.dgvDatosMensual.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvDatosMensual.AlternatingColors = True
        Me.dgvDatosMensual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatosMensual.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        dgvDatosMensual_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatosMensual_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatosMensual_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("dgvDatosMensual_DesignTimeLayout_Reference_1.Instance"), Object)
        dgvDatosMensual_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatosMensual_DesignTimeLayout_Reference_0, dgvDatosMensual_DesignTimeLayout_Reference_1})
        dgvDatosMensual_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosMensual_DesignTimeLayout.LayoutString")
        Me.dgvDatosMensual.DesignTimeLayout = dgvDatosMensual_DesignTimeLayout
        Me.dgvDatosMensual.EmptyRows = True
        Me.dgvDatosMensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosMensual.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvDatosMensual.GroupByBoxVisible = False
        Me.dgvDatosMensual.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvDatosMensual.Location = New System.Drawing.Point(12, 114)
        Me.dgvDatosMensual.Name = "dgvDatosMensual"
        Me.dgvDatosMensual.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosMensual.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosMensual.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosMensual.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosMensual.SelectOnExpand = False
        Me.dgvDatosMensual.Size = New System.Drawing.Size(638, 211)
        Me.dgvDatosMensual.TabIndex = 254
        Me.dgvDatosMensual.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDatosDiario
        '
        Me.dgvDatosDiario.AllowCardSizing = False
        Me.dgvDatosDiario.AllowColumnDrag = False
        Me.dgvDatosDiario.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvDatosDiario.AlternatingColors = True
        Me.dgvDatosDiario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatosDiario.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        dgvDatosDiario_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatosDiario_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatosDiario_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("dgvDatosDiario_DesignTimeLayout_Reference_1.Instance"), Object)
        dgvDatosDiario_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatosDiario_DesignTimeLayout_Reference_0, dgvDatosDiario_DesignTimeLayout_Reference_1})
        dgvDatosDiario_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosDiario_DesignTimeLayout.LayoutString")
        Me.dgvDatosDiario.DesignTimeLayout = dgvDatosDiario_DesignTimeLayout
        Me.dgvDatosDiario.EmptyRows = True
        Me.dgvDatosDiario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosDiario.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvDatosDiario.GroupByBoxVisible = False
        Me.dgvDatosDiario.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvDatosDiario.Location = New System.Drawing.Point(12, 394)
        Me.dgvDatosDiario.Name = "dgvDatosDiario"
        Me.dgvDatosDiario.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosDiario.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosDiario.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosDiario.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosDiario.SelectOnExpand = False
        Me.dgvDatosDiario.Size = New System.Drawing.Size(638, 211)
        Me.dgvDatosDiario.TabIndex = 256
        Me.dgvDatosDiario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(148, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 257
        Me.Label2.Text = "Fecha Mensual : "
        '
        'txtdiaant
        '
        Me.txtdiaant.Location = New System.Drawing.Point(256, 60)
        Me.txtdiaant.Name = "txtdiaant"
        Me.txtdiaant.Size = New System.Drawing.Size(46, 20)
        Me.txtdiaant.TabIndex = 260
        Me.txtdiaant.Text = "<"
        Me.txtdiaant.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.txtdiaant.UseVisualStyleBackColor = True
        Me.txtdiaant.Visible = False
        '
        'txtdiasig
        '
        Me.txtdiasig.Location = New System.Drawing.Point(301, 60)
        Me.txtdiasig.Name = "txtdiasig"
        Me.txtdiasig.Size = New System.Drawing.Size(46, 20)
        Me.txtdiasig.TabIndex = 261
        Me.txtdiasig.Text = ">"
        Me.txtdiasig.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.txtdiasig.UseVisualStyleBackColor = True
        Me.txtdiasig.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(473, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Semana : "
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(495, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "Mes : "
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(496, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 264
        Me.Label6.Text = "Año : "
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(447, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 265
        Me.Label7.Text = "Mes Anterior : "
        Me.Label7.Visible = False
        '
        'txtSemana
        '
        Me.txtSemana.BackColor = System.Drawing.SystemColors.Control
        Me.txtSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSemana.Location = New System.Drawing.Point(543, 11)
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
        Me.txtSemana.Visible = False
        Me.txtSemana.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMes
        '
        Me.txtMes.BackColor = System.Drawing.SystemColors.Control
        Me.txtMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMes.Location = New System.Drawing.Point(543, 33)
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
        Me.txtMes.Visible = False
        Me.txtMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtAnio
        '
        Me.txtAnio.BackColor = System.Drawing.SystemColors.Control
        Me.txtAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtAnio.Location = New System.Drawing.Point(543, 56)
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
        Me.txtAnio.Visible = False
        Me.txtAnio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMesAnt
        '
        Me.txtMesAnt.BackColor = System.Drawing.SystemColors.Control
        Me.txtMesAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesAnt.Location = New System.Drawing.Point(543, 78)
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
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(179, 17)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(129, 20)
        Me.cmbMes.TabIndex = 193
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaMensual)
        Me.GroupBox1.Controls.Add(Me.btnBuscarMensual)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMesAnt)
        Me.GroupBox1.Controls.Add(Me.txtAnio)
        Me.GroupBox1.Controls.Add(Me.txtdiaant)
        Me.GroupBox1.Controls.Add(Me.txtMes)
        Me.GroupBox1.Controls.Add(Me.txtdiasig)
        Me.GroupBox1.Controls.Add(Me.txtSemana)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 103)
        Me.GroupBox1.TabIndex = 270
        Me.GroupBox1.TabStop = False
        '
        'txtFechaMensual
        '
        Me.txtFechaMensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaMensual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaMensual.Location = New System.Drawing.Point(256, 41)
        Me.txtFechaMensual.Name = "txtFechaMensual"
        Me.txtFechaMensual.ShowUpDown = True
        Me.txtFechaMensual.Size = New System.Drawing.Size(99, 20)
        Me.txtFechaMensual.TabIndex = 271
        Me.txtFechaMensual.Value = New Date(2013, 6, 1, 0, 0, 0, 0)
        '
        'btnBuscarMensual
        '
        Me.btnBuscarMensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarMensual.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMensual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarMensual.Location = New System.Drawing.Point(366, 38)
        Me.btnBuscarMensual.Name = "btnBuscarMensual"
        Me.btnBuscarMensual.Size = New System.Drawing.Size(71, 23)
        Me.btnBuscarMensual.TabIndex = 270
        Me.btnBuscarMensual.Text = "Buscar"
        Me.btnBuscarMensual.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarMensual.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBuscarDiaria)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtFechaDiaria)
        Me.GroupBox2.Controls.Add(Me.txtdiaantdia)
        Me.GroupBox2.Controls.Add(Me.txtdiasigdia)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 330)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(627, 60)
        Me.GroupBox2.TabIndex = 271
        Me.GroupBox2.TabStop = False
        '
        'btnBuscarDiaria
        '
        Me.btnBuscarDiaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarDiaria.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarDiaria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarDiaria.Location = New System.Drawing.Point(366, 12)
        Me.btnBuscarDiaria.Name = "btnBuscarDiaria"
        Me.btnBuscarDiaria.Size = New System.Drawing.Size(71, 23)
        Me.btnBuscarDiaria.TabIndex = 270
        Me.btnBuscarDiaria.Text = "Buscar"
        Me.btnBuscarDiaria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarDiaria.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(162, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Fecha Diaria : "
        '
        'txtFechaDiaria
        '
        '
        '
        '
        Me.txtFechaDiaria.DropDownCalendar.Name = ""
        Me.txtFechaDiaria.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaDiaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaDiaria.IsNullDate = True
        Me.txtFechaDiaria.Location = New System.Drawing.Point(257, 14)
        Me.txtFechaDiaria.Name = "txtFechaDiaria"
        Me.txtFechaDiaria.Size = New System.Drawing.Size(103, 20)
        Me.txtFechaDiaria.TabIndex = 259
        Me.txtFechaDiaria.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtdiaantdia
        '
        Me.txtdiaantdia.Location = New System.Drawing.Point(256, 34)
        Me.txtdiaantdia.Name = "txtdiaantdia"
        Me.txtdiaantdia.Size = New System.Drawing.Size(46, 20)
        Me.txtdiaantdia.TabIndex = 260
        Me.txtdiaantdia.Text = "<"
        Me.txtdiaantdia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.txtdiaantdia.UseVisualStyleBackColor = True
        '
        'txtdiasigdia
        '
        Me.txtdiasigdia.Location = New System.Drawing.Point(301, 34)
        Me.txtdiasigdia.Name = "txtdiasigdia"
        Me.txtdiasigdia.Size = New System.Drawing.Size(46, 20)
        Me.txtdiasigdia.TabIndex = 261
        Me.txtdiasigdia.Text = ">"
        Me.txtdiasigdia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.txtdiasigdia.UseVisualStyleBackColor = True
        '
        'frmIndicadoresVenta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(670, 624)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDatosDiario)
        Me.Controls.Add(Me.dgvDatosMensual)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIndicadoresVenta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicadores de Venta"
        CType(Me.dgvDatosMensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatosDiario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDatosMensual As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvDatosDiario As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdiaant As System.Windows.Forms.Button
    Friend WithEvents txtdiasig As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSemana As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMes As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtAnio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMesAnt As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscarMensual As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscarDiaria As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaDiaria As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtdiaantdia As System.Windows.Forms.Button
    Friend WithEvents txtdiasigdia As System.Windows.Forms.Button
    Friend WithEvents txtFechaMensual As System.Windows.Forms.DateTimePicker
End Class
