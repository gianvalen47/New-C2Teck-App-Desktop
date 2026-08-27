<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenCompra_GenerarDocumento
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
        Dim cmbIdLocCli_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenCompra_GenerarDocumento))
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbIdLocCli = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvPrueba = New System.Windows.Forms.DataGridView()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.IdOrdenDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesMer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanAte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanPen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOrden1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMerCli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeaMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DscMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotFila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanSep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecIniSep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecFinSep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecMod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSugerido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSugeridoCab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreMerSug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DsctoSug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalFilaSug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.cmbIdLocCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbIdLocCli
        '
        Me.cmbIdLocCli.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocCli_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocCli_DesignTimeLayout.LayoutString")
        Me.cmbIdLocCli.DesignTimeLayout = cmbIdLocCli_DesignTimeLayout
        Me.cmbIdLocCli.FlatBorderColor = System.Drawing.SystemColors.Desktop
        Me.cmbIdLocCli.Location = New System.Drawing.Point(452, 18)
        Me.cmbIdLocCli.Name = "cmbIdLocCli"
        Me.cmbIdLocCli.SelectedIndex = -1
        Me.cmbIdLocCli.SelectedItem = Nothing
        Me.cmbIdLocCli.Size = New System.Drawing.Size(233, 20)
        Me.cmbIdLocCli.TabIndex = 3
        Me.cmbIdLocCli.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(522, 272)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(93, 25)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Generar Doc."
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarGroupBackground
        Me.UiGroupBox1.Controls.Add(Me.dgvPrueba)
        Me.UiGroupBox1.Controls.Add(Me.cmbIdLocCli)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipo)
        Me.UiGroupBox1.Controls.Add(Me.txtFecDoc)
        Me.UiGroupBox1.Controls.Add(Me.lblFecha)
        Me.UiGroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 4)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(770, 265)
        Me.UiGroupBox1.TabIndex = 6
        Me.UiGroupBox1.Text = "Datos Generales"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005
        '
        'dgvPrueba
        '
        Me.dgvPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrueba.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOrdenDet, Me.Item, Me.CodMer, Me.DesMer1, Me.CanMer, Me.CanAte, Me.CanPen, Me.Despacho, Me.IdOrden1, Me.Item1, Me.CodMerCli, Me.DeaMer, Me.PreMer, Me.DscMer, Me.TotFila, Me.CanSep, Me.FecIniSep, Me.FecFinSep, Me.CodUsu, Me.Observacion, Me.FecMod, Me.IdSugerido, Me.IdSugeridoCab, Me.PreMerSug, Me.DsctoSug, Me.TotalFilaSug, Me.Stock})
        Me.dgvPrueba.ContextMenuStrip = Me.cmOpciones
        Me.dgvPrueba.Location = New System.Drawing.Point(7, 44)
        Me.dgvPrueba.Name = "dgvPrueba"
        Me.dgvPrueba.Size = New System.Drawing.Size(753, 215)
        Me.dgvPrueba.TabIndex = 7
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(174, 76)
        '
        'miSeleccionarTodo
        '
        Me.miSeleccionarTodo.Image = CType(resources.GetObject("miSeleccionarTodo.Image"), System.Drawing.Image)
        Me.miSeleccionarTodo.Name = "miSeleccionarTodo"
        Me.miSeleccionarTodo.Size = New System.Drawing.Size(173, 22)
        Me.miSeleccionarTodo.Text = "Seleccionar Todos"
        '
        'miSeterCEROTodos
        '
        Me.miSeterCEROTodos.Image = CType(resources.GetObject("miSeterCEROTodos.Image"), System.Drawing.Image)
        Me.miSeterCEROTodos.Name = "miSeterCEROTodos"
        Me.miSeterCEROTodos.Size = New System.Drawing.Size(173, 22)
        Me.miSeterCEROTodos.Text = "Poner en ""0"" todos"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(173, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(402, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Loc. Clie."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tipo"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.Color.Beige
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(199, 18)
        Me.txtNumDoc.MaxLength = 200
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(76, 20)
        Me.txtNumDoc.TabIndex = 1
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Location = New System.Drawing.Point(155, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Número"
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipo.Location = New System.Drawing.Point(30, 18)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(121, 20)
        Me.cmbTipo.TabIndex = 0
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecDoc.Location = New System.Drawing.Point(318, 18)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.Size = New System.Drawing.Size(82, 20)
        Me.txtFecDoc.TabIndex = 2
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(281, 22)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha"
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(12, 275)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(41, 25)
        Me.dgvDatos.TabIndex = 4
        Me.dgvDatos.Visible = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(617, 272)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'IdOrdenDet
        '
        Me.IdOrdenDet.DataPropertyName = "IdOrdenDet"
        Me.IdOrdenDet.HeaderText = "IdOrdenDet "
        Me.IdOrdenDet.Name = "IdOrdenDet"
        Me.IdOrdenDet.Visible = False
        '
        'Item
        '
        Me.Item.DataPropertyName = "Item"
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.Width = 40
        '
        'CodMer
        '
        Me.CodMer.DataPropertyName = "CodMer"
        Me.CodMer.HeaderText = "Código"
        Me.CodMer.Name = "CodMer"
        Me.CodMer.Width = 110
        '
        'DesMer1
        '
        Me.DesMer1.DataPropertyName = "DesMer1"
        Me.DesMer1.HeaderText = "Descripción"
        Me.DesMer1.Name = "DesMer1"
        Me.DesMer1.Width = 250
        '
        'CanMer
        '
        Me.CanMer.DataPropertyName = "CanMer"
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Me.CanMer.DefaultCellStyle = DataGridViewCellStyle1
        Me.CanMer.HeaderText = "Cant."
        Me.CanMer.Name = "CanMer"
        Me.CanMer.Width = 55
        '
        'CanAte
        '
        Me.CanAte.DataPropertyName = "CanAte"
        Me.CanAte.HeaderText = "Atend."
        Me.CanAte.Name = "CanAte"
        Me.CanAte.Width = 55
        '
        'CanPen
        '
        Me.CanPen.DataPropertyName = "CanPen"
        Me.CanPen.HeaderText = "Pend."
        Me.CanPen.Name = "CanPen"
        Me.CanPen.Width = 55
        '
        'Despacho
        '
        Me.Despacho.DataPropertyName = "Despacho"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        Me.Despacho.DefaultCellStyle = DataGridViewCellStyle2
        Me.Despacho.HeaderText = "A Desp."
        Me.Despacho.Name = "Despacho"
        Me.Despacho.Width = 65
        '
        'IdOrden1
        '
        Me.IdOrden1.HeaderText = "IdOrden"
        Me.IdOrden1.Name = "IdOrden1"
        Me.IdOrden1.Visible = False
        '
        'Item1
        '
        Me.Item1.HeaderText = "Item1"
        Me.Item1.Name = "Item1"
        Me.Item1.Visible = False
        '
        'CodMerCli
        '
        Me.CodMerCli.HeaderText = "CodMerCli"
        Me.CodMerCli.Name = "CodMerCli"
        Me.CodMerCli.Visible = False
        '
        'DeaMer
        '
        Me.DeaMer.HeaderText = "DeaMer"
        Me.DeaMer.Name = "DeaMer"
        Me.DeaMer.Visible = False
        '
        'PreMer
        '
        Me.PreMer.HeaderText = "PreMer"
        Me.PreMer.Name = "PreMer"
        Me.PreMer.Visible = False
        '
        'DscMer
        '
        Me.DscMer.HeaderText = "DscMer"
        Me.DscMer.Name = "DscMer"
        Me.DscMer.Visible = False
        '
        'TotFila
        '
        Me.TotFila.HeaderText = "TotFila"
        Me.TotFila.Name = "TotFila"
        Me.TotFila.Visible = False
        '
        'CanSep
        '
        Me.CanSep.HeaderText = "CanSep"
        Me.CanSep.Name = "CanSep"
        Me.CanSep.Visible = False
        '
        'FecIniSep
        '
        Me.FecIniSep.HeaderText = "FecIniSep"
        Me.FecIniSep.Name = "FecIniSep"
        Me.FecIniSep.Visible = False
        '
        'FecFinSep
        '
        Me.FecFinSep.HeaderText = "FecFinSep"
        Me.FecFinSep.Name = "FecFinSep"
        Me.FecFinSep.Visible = False
        '
        'CodUsu
        '
        Me.CodUsu.HeaderText = "CodUsu"
        Me.CodUsu.Name = "CodUsu"
        Me.CodUsu.Visible = False
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.Visible = False
        '
        'FecMod
        '
        Me.FecMod.HeaderText = "FecMod"
        Me.FecMod.Name = "FecMod"
        Me.FecMod.Visible = False
        '
        'IdSugerido
        '
        Me.IdSugerido.HeaderText = "IdSugerido"
        Me.IdSugerido.Name = "IdSugerido"
        Me.IdSugerido.Visible = False
        '
        'IdSugeridoCab
        '
        Me.IdSugeridoCab.HeaderText = "IdSugeridoCab"
        Me.IdSugeridoCab.Name = "IdSugeridoCab"
        Me.IdSugeridoCab.Visible = False
        '
        'PreMerSug
        '
        Me.PreMerSug.HeaderText = "PreMerSug"
        Me.PreMerSug.Name = "PreMerSug"
        Me.PreMerSug.Visible = False
        '
        'DsctoSug
        '
        Me.DsctoSug.HeaderText = "DsctoSug"
        Me.DsctoSug.Name = "DsctoSug"
        Me.DsctoSug.Visible = False
        '
        'TotalFilaSug
        '
        Me.TotalFilaSug.HeaderText = "TotalFilaSug"
        Me.TotalFilaSug.Name = "TotalFilaSug"
        Me.TotalFilaSug.Visible = False
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "Stock"
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        Me.Stock.Width = 55
        '
        'frmOrdenCompra_GenerarDocumento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(782, 321)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrdenCompra_GenerarDocumento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Documento"
        CType(Me.cmbIdLocCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbIdLocCli As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeleccionarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeterCEROTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvPrueba As System.Windows.Forms.DataGridView
    Friend WithEvents IdOrdenDet As DataGridViewTextBoxColumn
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents CodMer As DataGridViewTextBoxColumn
    Friend WithEvents DesMer1 As DataGridViewTextBoxColumn
    Friend WithEvents CanMer As DataGridViewTextBoxColumn
    Friend WithEvents CanAte As DataGridViewTextBoxColumn
    Friend WithEvents CanPen As DataGridViewTextBoxColumn
    Friend WithEvents Despacho As DataGridViewTextBoxColumn
    Friend WithEvents IdOrden1 As DataGridViewTextBoxColumn
    Friend WithEvents Item1 As DataGridViewTextBoxColumn
    Friend WithEvents CodMerCli As DataGridViewTextBoxColumn
    Friend WithEvents DeaMer As DataGridViewTextBoxColumn
    Friend WithEvents PreMer As DataGridViewTextBoxColumn
    Friend WithEvents DscMer As DataGridViewTextBoxColumn
    Friend WithEvents TotFila As DataGridViewTextBoxColumn
    Friend WithEvents CanSep As DataGridViewTextBoxColumn
    Friend WithEvents FecIniSep As DataGridViewTextBoxColumn
    Friend WithEvents FecFinSep As DataGridViewTextBoxColumn
    Friend WithEvents CodUsu As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents FecMod As DataGridViewTextBoxColumn
    Friend WithEvents IdSugerido As DataGridViewTextBoxColumn
    Friend WithEvents IdSugeridoCab As DataGridViewTextBoxColumn
    Friend WithEvents PreMerSug As DataGridViewTextBoxColumn
    Friend WithEvents DsctoSug As DataGridViewTextBoxColumn
    Friend WithEvents TotalFilaSug As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
End Class
