<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepVencCtasxPagar
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
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepVencCtasxPagar))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbTipoCompra = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbComprasExterior = New System.Windows.Forms.RadioButton()
        Me.rbComprasLocales = New System.Windows.Forms.RadioButton()
        Me.gbDocumento = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTotales = New System.Windows.Forms.RadioButton()
        Me.rbProveedor = New System.Windows.Forms.RadioButton()
        Me.rbFecVenc = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbResumido = New System.Windows.Forms.RadioButton()
        Me.rbDetallado = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbPendientes = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbBuscarProveedor = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gbTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoCompra.SuspendLayout()
        CType(Me.gbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDocumento.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbTipoCompra)
        Me.GroupBox1.Controls.Add(Me.gbDocumento)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox4)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox1)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox6)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbFecFinal)
        Me.GroupBox1.Controls.Add(Me.cbFecInicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(481, 258)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'gbTipoCompra
        '
        Me.gbTipoCompra.Controls.Add(Me.rbComprasExterior)
        Me.gbTipoCompra.Controls.Add(Me.rbComprasLocales)
        Me.gbTipoCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoCompra.Location = New System.Drawing.Point(7, 168)
        Me.gbTipoCompra.Name = "gbTipoCompra"
        Me.gbTipoCompra.Size = New System.Drawing.Size(144, 79)
        Me.gbTipoCompra.TabIndex = 11
        Me.gbTipoCompra.Text = "Tipo de Compra"
        Me.gbTipoCompra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbComprasExterior
        '
        Me.rbComprasExterior.AutoSize = True
        Me.rbComprasExterior.Location = New System.Drawing.Point(5, 45)
        Me.rbComprasExterior.Name = "rbComprasExterior"
        Me.rbComprasExterior.Size = New System.Drawing.Size(134, 17)
        Me.rbComprasExterior.TabIndex = 1
        Me.rbComprasExterior.TabStop = True
        Me.rbComprasExterior.Text = "Compras al Exterior"
        Me.rbComprasExterior.UseVisualStyleBackColor = True
        '
        'rbComprasLocales
        '
        Me.rbComprasLocales.AutoSize = True
        Me.rbComprasLocales.Checked = True
        Me.rbComprasLocales.Location = New System.Drawing.Point(5, 22)
        Me.rbComprasLocales.Name = "rbComprasLocales"
        Me.rbComprasLocales.Size = New System.Drawing.Size(121, 17)
        Me.rbComprasLocales.TabIndex = 0
        Me.rbComprasLocales.TabStop = True
        Me.rbComprasLocales.Text = "Compras Locales"
        Me.rbComprasLocales.UseVisualStyleBackColor = True
        '
        'gbDocumento
        '
        Me.gbDocumento.Controls.Add(Me.Label15)
        Me.gbDocumento.Controls.Add(Me.cmbTipoDoc)
        Me.gbDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDocumento.Location = New System.Drawing.Point(20, 109)
        Me.gbDocumento.Name = "gbDocumento"
        Me.gbDocumento.Size = New System.Drawing.Size(445, 44)
        Me.gbDocumento.TabIndex = 9
        Me.gbDocumento.Text = "Documento"
        Me.gbDocumento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(33, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Tipo Documento"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(139, 16)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(249, 20)
        Me.cmbTipoDoc.TabIndex = 10
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.rbTotales)
        Me.UiGroupBox4.Controls.Add(Me.rbProveedor)
        Me.UiGroupBox4.Controls.Add(Me.rbFecVenc)
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(359, 168)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(113, 79)
        Me.UiGroupBox4.TabIndex = 14
        Me.UiGroupBox4.Text = "Ordenado por :"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTotales
        '
        Me.rbTotales.AutoSize = True
        Me.rbTotales.Checked = True
        Me.rbTotales.Location = New System.Drawing.Point(10, 54)
        Me.rbTotales.Name = "rbTotales"
        Me.rbTotales.Size = New System.Drawing.Size(67, 17)
        Me.rbTotales.TabIndex = 17
        Me.rbTotales.TabStop = True
        Me.rbTotales.Text = "Totales"
        Me.rbTotales.UseVisualStyleBackColor = True
        Me.rbTotales.Visible = False
        '
        'rbProveedor
        '
        Me.rbProveedor.AutoSize = True
        Me.rbProveedor.Checked = True
        Me.rbProveedor.Location = New System.Drawing.Point(10, 35)
        Me.rbProveedor.Name = "rbProveedor"
        Me.rbProveedor.Size = New System.Drawing.Size(83, 17)
        Me.rbProveedor.TabIndex = 16
        Me.rbProveedor.TabStop = True
        Me.rbProveedor.Text = "Proveedor"
        Me.rbProveedor.UseVisualStyleBackColor = True
        '
        'rbFecVenc
        '
        Me.rbFecVenc.AutoSize = True
        Me.rbFecVenc.Checked = True
        Me.rbFecVenc.Location = New System.Drawing.Point(10, 16)
        Me.rbFecVenc.Name = "rbFecVenc"
        Me.rbFecVenc.Size = New System.Drawing.Size(97, 17)
        Me.rbFecVenc.TabIndex = 15
        Me.rbFecVenc.TabStop = True
        Me.rbFecVenc.Text = "Fecha Venc."
        Me.rbFecVenc.UseVisualStyleBackColor = True
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbResumido)
        Me.UiGroupBox3.Controls.Add(Me.rbDetallado)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(261, 168)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(92, 79)
        Me.UiGroupBox3.TabIndex = 13
        Me.UiGroupBox3.Text = "Tipo"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbResumido
        '
        Me.rbResumido.AutoSize = True
        Me.rbResumido.Location = New System.Drawing.Point(6, 46)
        Me.rbResumido.Name = "rbResumido"
        Me.rbResumido.Size = New System.Drawing.Size(79, 17)
        Me.rbResumido.TabIndex = 1
        Me.rbResumido.Text = "Agrupado"
        Me.rbResumido.UseVisualStyleBackColor = True
        '
        'rbDetallado
        '
        Me.rbDetallado.AutoSize = True
        Me.rbDetallado.Checked = True
        Me.rbDetallado.Location = New System.Drawing.Point(6, 21)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(79, 17)
        Me.rbDetallado.TabIndex = 15
        Me.rbDetallado.TabStop = True
        Me.rbDetallado.Text = "Detallado"
        Me.rbDetallado.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbTodos)
        Me.UiGroupBox1.Controls.Add(Me.rbPendientes)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(157, 168)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(99, 79)
        Me.UiGroupBox1.TabIndex = 12
        Me.UiGroupBox1.Text = "Condición"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(6, 46)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(60, 17)
        Me.rbTodos.TabIndex = 1
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbPendientes
        '
        Me.rbPendientes.AutoSize = True
        Me.rbPendientes.Checked = True
        Me.rbPendientes.Location = New System.Drawing.Point(6, 21)
        Me.rbPendientes.Name = "rbPendientes"
        Me.rbPendientes.Size = New System.Drawing.Size(88, 17)
        Me.rbPendientes.TabIndex = 15
        Me.rbPendientes.TabStop = True
        Me.rbPendientes.Text = "Pendientes"
        Me.rbPendientes.UseVisualStyleBackColor = True
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Controls.Add(Me.txtProveedor)
        Me.UiGroupBox6.Controls.Add(Me.btnBuscarProveedor)
        Me.UiGroupBox6.Controls.Add(Me.Label12)
        Me.UiGroupBox6.Controls.Add(Me.rbBuscarProveedor)
        Me.UiGroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox6.Location = New System.Drawing.Point(20, 43)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(445, 58)
        Me.UiGroupBox6.TabIndex = 3
        Me.UiGroupBox6.Text = "Buscar Proveedor"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(89, 32)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(296, 20)
        Me.txtProveedor.TabIndex = 4
        Me.txtProveedor.TabStop = False
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(387, 31)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 5
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Proveedor"
        '
        'rbBuscarProveedor
        '
        Me.rbBuscarProveedor.AutoSize = True
        Me.rbBuscarProveedor.Checked = True
        Me.rbBuscarProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarProveedor.Location = New System.Drawing.Point(183, 12)
        Me.rbBuscarProveedor.Name = "rbBuscarProveedor"
        Me.rbBuscarProveedor.Size = New System.Drawing.Size(117, 17)
        Me.rbBuscarProveedor.TabIndex = 17
        Me.rbBuscarProveedor.TabStop = False
        Me.rbBuscarProveedor.Text = "Todo Proveedor"
        Me.rbBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(280, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Al  :"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(313, 18)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 2
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
        Me.cbFecInicio.Location = New System.Drawing.Point(154, 18)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = " Fechas   Del : "
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(173, 274)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(255, 274)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepVencCtasxPagar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(506, 308)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepVencCtasxPagar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte  de Vencimientos de Cuentas x Pagar"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gbTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoCompra.ResumeLayout(False)
        Me.gbTipoCompra.PerformLayout()
        CType(Me.gbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDocumento.ResumeLayout(False)
        Me.gbDocumento.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbBuscarProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumido As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTotales As System.Windows.Forms.RadioButton
    Friend WithEvents rbProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbFecVenc As System.Windows.Forms.RadioButton
    Friend WithEvents gbDocumento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbTipoCompra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbComprasExterior As System.Windows.Forms.RadioButton
    Friend WithEvents rbComprasLocales As System.Windows.Forms.RadioButton
End Class
