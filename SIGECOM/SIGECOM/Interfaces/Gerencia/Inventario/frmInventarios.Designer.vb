<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventarios))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkStockValorizado01 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkMotoresStock = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkBateriasStock = New System.Windows.Forms.RadioButton()
        Me.chkFiltrosStock = New System.Windows.Forms.RadioButton()
        Me.chkStockValorizado02 = New System.Windows.Forms.RadioButton()
        Me.btnConsolidado = New System.Windows.Forms.Button()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkInventarioSinMovimiento = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbCiclos = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbNinguno = New Janus.Windows.EditControls.UIRadioButton()
        Me.rb2C = New Janus.Windows.EditControls.UIRadioButton()
        Me.rb4C = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton()
        Me.chkRepuestosStock = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvGerencial = New System.Windows.Forms.DataGridView()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.chkResumen = New System.Windows.Forms.RadioButton()
        Me.gbSinMovimiento = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbMarcaAgua = New System.Windows.Forms.CheckBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCiclos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCiclos.SuspendLayout()
        CType(Me.dgvGerencial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbSinMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSinMovimiento.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(124, 537)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(212, 537)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 273)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Reporte Gerencial 022"
        '
        'chkStockValorizado01
        '
        Me.chkStockValorizado01.AutoSize = True
        Me.chkStockValorizado01.Location = New System.Drawing.Point(91, 298)
        Me.chkStockValorizado01.Name = "chkStockValorizado01"
        Me.chkStockValorizado01.Size = New System.Drawing.Size(139, 17)
        Me.chkStockValorizado01.TabIndex = 6
        Me.chkStockValorizado01.Text = "Stock Valorizado 01"
        Me.chkStockValorizado01.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Reporte Gerencial 021"
        '
        'chkMotoresStock
        '
        Me.chkMotoresStock.AutoSize = True
        Me.chkMotoresStock.Checked = True
        Me.chkMotoresStock.Location = New System.Drawing.Point(91, 43)
        Me.chkMotoresStock.Name = "chkMotoresStock"
        Me.chkMotoresStock.Size = New System.Drawing.Size(125, 17)
        Me.chkMotoresStock.TabIndex = 1
        Me.chkMotoresStock.TabStop = True
        Me.chkMotoresStock.Text = "Motores en Stock"
        Me.chkMotoresStock.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(59, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 22)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "INVENTARIO Y COSTOS"
        '
        'chkBateriasStock
        '
        Me.chkBateriasStock.AutoSize = True
        Me.chkBateriasStock.Location = New System.Drawing.Point(91, 66)
        Me.chkBateriasStock.Name = "chkBateriasStock"
        Me.chkBateriasStock.Size = New System.Drawing.Size(126, 17)
        Me.chkBateriasStock.TabIndex = 2
        Me.chkBateriasStock.Text = "Baterias en Stock"
        Me.chkBateriasStock.UseVisualStyleBackColor = True
        '
        'chkFiltrosStock
        '
        Me.chkFiltrosStock.AutoSize = True
        Me.chkFiltrosStock.Location = New System.Drawing.Point(91, 89)
        Me.chkFiltrosStock.Name = "chkFiltrosStock"
        Me.chkFiltrosStock.Size = New System.Drawing.Size(114, 17)
        Me.chkFiltrosStock.TabIndex = 3
        Me.chkFiltrosStock.Text = "Filtros en Stock"
        Me.chkFiltrosStock.UseVisualStyleBackColor = True
        '
        'chkStockValorizado02
        '
        Me.chkStockValorizado02.AutoSize = True
        Me.chkStockValorizado02.Location = New System.Drawing.Point(91, 318)
        Me.chkStockValorizado02.Name = "chkStockValorizado02"
        Me.chkStockValorizado02.Size = New System.Drawing.Size(139, 17)
        Me.chkStockValorizado02.TabIndex = 7
        Me.chkStockValorizado02.Text = "Stock Valorizado 02"
        Me.chkStockValorizado02.UseVisualStyleBackColor = True
        '
        'btnConsolidado
        '
        Me.btnConsolidado.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado.Location = New System.Drawing.Point(235, 293)
        Me.btnConsolidado.Name = "btnConsolidado"
        Me.btnConsolidado.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado.TabIndex = 28
        Me.btnConsolidado.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado.UseVisualStyleBackColor = True
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(116, 40)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(99, 20)
        Me.cbFecFinal.TabIndex = 13
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(118, 15)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 12
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(63, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Hasta :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(59, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Desde :"
        '
        'chkInventarioSinMovimiento
        '
        Me.chkInventarioSinMovimiento.AutoSize = True
        Me.chkInventarioSinMovimiento.Location = New System.Drawing.Point(91, 377)
        Me.chkInventarioSinMovimiento.Name = "chkInventarioSinMovimiento"
        Me.chkInventarioSinMovimiento.Size = New System.Drawing.Size(171, 17)
        Me.chkInventarioSinMovimiento.TabIndex = 8
        Me.chkInventarioSinMovimiento.Text = "Inventario Sin movimiento"
        Me.chkInventarioSinMovimiento.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(74, 354)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Reporte Gerencial 023"
        '
        'gbCiclos
        '
        Me.gbCiclos.Controls.Add(Me.rbNinguno)
        Me.gbCiclos.Controls.Add(Me.rb2C)
        Me.gbCiclos.Controls.Add(Me.rb4C)
        Me.gbCiclos.Controls.Add(Me.rbTodos)
        Me.gbCiclos.Location = New System.Drawing.Point(116, 132)
        Me.gbCiclos.Name = "gbCiclos"
        Me.gbCiclos.Size = New System.Drawing.Size(88, 106)
        Me.gbCiclos.TabIndex = 11
        Me.gbCiclos.Text = "Ciclos"
        '
        'rbNinguno
        '
        Me.rbNinguno.Location = New System.Drawing.Point(6, 78)
        Me.rbNinguno.Name = "rbNinguno"
        Me.rbNinguno.Size = New System.Drawing.Size(76, 23)
        Me.rbNinguno.TabIndex = 3
        Me.rbNinguno.Text = "No tienen"
        '
        'rb2C
        '
        Me.rb2C.Location = New System.Drawing.Point(6, 55)
        Me.rb2C.Name = "rb2C"
        Me.rb2C.Size = New System.Drawing.Size(76, 23)
        Me.rb2C.TabIndex = 2
        Me.rb2C.Text = "2 Ciclos"
        '
        'rb4C
        '
        Me.rb4C.Location = New System.Drawing.Point(6, 34)
        Me.rb4C.Name = "rb4C"
        Me.rb4C.Size = New System.Drawing.Size(76, 23)
        Me.rb4C.TabIndex = 1
        Me.rb4C.Text = "4 Ciclos"
        '
        'rbTodos
        '
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(5, 14)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(77, 23)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        '
        'chkRepuestosStock
        '
        Me.chkRepuestosStock.AutoSize = True
        Me.chkRepuestosStock.Location = New System.Drawing.Point(91, 112)
        Me.chkRepuestosStock.Name = "chkRepuestosStock"
        Me.chkRepuestosStock.Size = New System.Drawing.Size(140, 17)
        Me.chkRepuestosStock.TabIndex = 4
        Me.chkRepuestosStock.Text = "Repuestos en Stock"
        Me.chkRepuestosStock.UseVisualStyleBackColor = True
        '
        'dgvGerencial
        '
        Me.dgvGerencial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGerencial.Location = New System.Drawing.Point(300, 537)
        Me.dgvGerencial.Name = "dgvGerencial"
        Me.dgvGerencial.Size = New System.Drawing.Size(35, 25)
        Me.dgvGerencial.TabIndex = 11
        Me.dgvGerencial.Visible = False
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.chkResumen)
        Me.UiGroupBox1.Controls.Add(Me.gbSinMovimiento)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.chkStockValorizado02)
        Me.UiGroupBox1.Controls.Add(Me.chkBateriasStock)
        Me.UiGroupBox1.Controls.Add(Me.chkFiltrosStock)
        Me.UiGroupBox1.Controls.Add(Me.btnConsolidado)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.chkMotoresStock)
        Me.UiGroupBox1.Controls.Add(Me.chkStockValorizado01)
        Me.UiGroupBox1.Controls.Add(Me.chkInventarioSinMovimiento)
        Me.UiGroupBox1.Controls.Add(Me.chkRepuestosStock)
        Me.UiGroupBox1.Controls.Add(Me.gbCiclos)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(18, 39)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(323, 486)
        Me.UiGroupBox1.TabIndex = 30
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'chkResumen
        '
        Me.chkResumen.AutoSize = True
        Me.chkResumen.Location = New System.Drawing.Point(87, 244)
        Me.chkResumen.Name = "chkResumen"
        Me.chkResumen.Size = New System.Drawing.Size(230, 17)
        Me.chkResumen.TabIndex = 5
        Me.chkResumen.Text = "Resumen Motores - Baterias - Filtros"
        Me.chkResumen.UseVisualStyleBackColor = True
        '
        'gbSinMovimiento
        '
        Me.gbSinMovimiento.Controls.Add(Me.cbFecFinal)
        Me.gbSinMovimiento.Controls.Add(Me.cbFecInicio)
        Me.gbSinMovimiento.Controls.Add(Me.Label6)
        Me.gbSinMovimiento.Controls.Add(Me.Label5)
        Me.gbSinMovimiento.Location = New System.Drawing.Point(16, 405)
        Me.gbSinMovimiento.Name = "gbSinMovimiento"
        Me.gbSinMovimiento.Size = New System.Drawing.Size(290, 67)
        Me.gbSinMovimiento.TabIndex = 30
        Me.gbSinMovimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbMarcaAgua
        '
        Me.cbMarcaAgua.AutoSize = True
        Me.cbMarcaAgua.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMarcaAgua.Location = New System.Drawing.Point(12, 543)
        Me.cbMarcaAgua.Name = "cbMarcaAgua"
        Me.cbMarcaAgua.Size = New System.Drawing.Size(112, 17)
        Me.cbMarcaAgua.TabIndex = 195
        Me.cbMarcaAgua.Text = "Marca de Agua"
        Me.cbMarcaAgua.UseVisualStyleBackColor = True
        '
        'frmInventarios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(390, 605)
        Me.Controls.Add(Me.cbMarcaAgua)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvGerencial)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Gerencial de Inventarios y Costos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCiclos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCiclos.ResumeLayout(False)
        CType(Me.dgvGerencial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gbSinMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSinMovimiento.ResumeLayout(False)
        Me.gbSinMovimiento.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents chkStockValorizado01 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkMotoresStock As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkFiltrosStock As System.Windows.Forms.RadioButton
    Friend WithEvents chkBateriasStock As System.Windows.Forms.RadioButton
    Friend WithEvents gbCiclos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbNinguno As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rb2C As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rb4C As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents chkRepuestosStock As System.Windows.Forms.RadioButton
    Friend WithEvents chkInventarioSinMovimiento As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnConsolidado As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkStockValorizado02 As System.Windows.Forms.RadioButton
    Friend WithEvents dgvGerencial As System.Windows.Forms.DataGridView
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbSinMovimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents chkResumen As System.Windows.Forms.RadioButton
    Friend WithEvents cbMarcaAgua As CheckBox
End Class
