<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDiario_ImportarVentas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiario_ImportarVentas))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalDebitoOtroNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDebitoNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalVentaExpNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lbltotalIGV = New System.Windows.Forms.TextBox()
        Me.txtTotalVentaNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gbEmbarque = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnConsultarVentas = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.gbEmbarque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEmbarque.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 377)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(640, 20)
        Me.ssBarra.TabIndex = 194
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(440, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(210, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(640, 31)
        Me.ToolStrip.TabIndex = 193
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(325, 341)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 27)
        Me.btnCancelar.TabIndex = 230
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(243, 341)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 27)
        Me.btnAceptar.TabIndex = 229
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(7, 96)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(627, 197)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebitoOtroNS)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebitoNS)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalVentaExpNS)
        Me.UiGroupBox6.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalVentaNS)
        Me.UiGroupBox6.Location = New System.Drawing.Point(7, 294)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(627, 41)
        Me.UiGroupBox6.TabIndex = 227
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalDebitoOtroNS
        '
        Me.txtTotalDebitoOtroNS.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDebitoOtroNS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebitoOtroNS.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDebitoOtroNS.Location = New System.Drawing.Point(369, 14)
        Me.txtTotalDebitoOtroNS.MaxLength = 5
        Me.txtTotalDebitoOtroNS.Name = "txtTotalDebitoOtroNS"
        Me.txtTotalDebitoOtroNS.ReadOnly = True
        Me.txtTotalDebitoOtroNS.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalDebitoOtroNS.TabIndex = 14
        Me.txtTotalDebitoOtroNS.TabStop = False
        Me.txtTotalDebitoOtroNS.Text = "0.00"
        Me.txtTotalDebitoOtroNS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDebitoOtroNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDebitoOtroNS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDebitoNS
        '
        Me.txtTotalDebitoNS.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDebitoNS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebitoNS.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDebitoNS.Location = New System.Drawing.Point(250, 14)
        Me.txtTotalDebitoNS.MaxLength = 5
        Me.txtTotalDebitoNS.Name = "txtTotalDebitoNS"
        Me.txtTotalDebitoNS.ReadOnly = True
        Me.txtTotalDebitoNS.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalDebitoNS.TabIndex = 13
        Me.txtTotalDebitoNS.TabStop = False
        Me.txtTotalDebitoNS.Text = "0.00"
        Me.txtTotalDebitoNS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDebitoNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDebitoNS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalVentaExpNS
        '
        Me.txtTotalVentaExpNS.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalVentaExpNS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVentaExpNS.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalVentaExpNS.Location = New System.Drawing.Point(488, 14)
        Me.txtTotalVentaExpNS.MaxLength = 5
        Me.txtTotalVentaExpNS.Name = "txtTotalVentaExpNS"
        Me.txtTotalVentaExpNS.ReadOnly = True
        Me.txtTotalVentaExpNS.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalVentaExpNS.TabIndex = 12
        Me.txtTotalVentaExpNS.TabStop = False
        Me.txtTotalVentaExpNS.Text = "0.00"
        Me.txtTotalVentaExpNS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalVentaExpNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalVentaExpNS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbltotalIGV
        '
        Me.lbltotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalIGV.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lbltotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalIGV.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalIGV.Location = New System.Drawing.Point(6, 14)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(125, 20)
        Me.lbltotalIGV.TabIndex = 9
        Me.lbltotalIGV.TabStop = False
        Me.lbltotalIGV.Text = "TOTAL :"
        Me.lbltotalIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalVentaNS
        '
        Me.txtTotalVentaNS.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalVentaNS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVentaNS.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalVentaNS.Location = New System.Drawing.Point(131, 14)
        Me.txtTotalVentaNS.MaxLength = 5
        Me.txtTotalVentaNS.Name = "txtTotalVentaNS"
        Me.txtTotalVentaNS.ReadOnly = True
        Me.txtTotalVentaNS.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalVentaNS.TabIndex = 5
        Me.txtTotalVentaNS.TabStop = False
        Me.txtTotalVentaNS.Text = "0.00"
        Me.txtTotalVentaNS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalVentaNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalVentaNS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbEmbarque
        '
        Me.gbEmbarque.Controls.Add(Me.txtFecha)
        Me.gbEmbarque.Controls.Add(Me.btnConsultarVentas)
        Me.gbEmbarque.Location = New System.Drawing.Point(9, 34)
        Me.gbEmbarque.Name = "gbEmbarque"
        Me.gbEmbarque.Size = New System.Drawing.Size(150, 57)
        Me.gbEmbarque.TabIndex = 231
        Me.gbEmbarque.Text = "Fecha"
        Me.gbEmbarque.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecha.IsNullDate = True
        Me.txtFecha.Location = New System.Drawing.Point(19, 22)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(86, 20)
        Me.txtFecha.TabIndex = 225
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'btnConsultarVentas
        '
        Me.btnConsultarVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultarVentas.Image = CType(resources.GetObject("btnConsultarVentas.Image"), System.Drawing.Image)
        Me.btnConsultarVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultarVentas.Location = New System.Drawing.Point(111, 19)
        Me.btnConsultarVentas.Name = "btnConsultarVentas"
        Me.btnConsultarVentas.Size = New System.Drawing.Size(28, 25)
        Me.btnConsultarVentas.TabIndex = 299
        Me.btnConsultarVentas.TabStop = False
        Me.btnConsultarVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultarVentas.UseVisualStyleBackColor = True
        '
        'frmDiario_ImportarVentas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(640, 397)
        Me.Controls.Add(Me.gbEmbarque)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiario_ImportarVentas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Ventas"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.gbEmbarque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEmbarque.ResumeLayout(False)
        Me.gbEmbarque.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As StatusStrip
    Friend WithEvents sslError As ToolStripStatusLabel
    Friend WithEvents sslTotal As ToolStripStatusLabel
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalVentaExpNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbltotalIGV As TextBox
    Friend WithEvents txtTotalVentaNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDebitoOtroNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDebitoNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gbEmbarque As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnConsultarVentas As Button
End Class
