<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnticipo
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
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnticipo))
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbBanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtObsAnt = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtTipCam = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumAnt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.UiGroupBox1.Controls.Add(Me.cmbOficinas)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.cmbBanco)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtObsAnt)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.txtTotal)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.cmbPago)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtTipCam)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtNumAnt)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(617, 342)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = " [ Detalles ] "
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Location = New System.Drawing.Point(258, 64)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(129, 20)
        Me.cmbIdLocacion.TabIndex = 22
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(78, 64)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(77, 20)
        Me.cmbOficinas.TabIndex = 18
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(193, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Almacén :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Oficina :"
        '
        'cmbBanco
        '
        Me.cmbBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbBanco_DesignTimeLayout.LayoutString = resources.GetString("cmbBanco_DesignTimeLayout.LayoutString")
        Me.cmbBanco.DesignTimeLayout = cmbBanco_DesignTimeLayout
        Me.cmbBanco.Location = New System.Drawing.Point(428, 124)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.SelectedIndex = -1
        Me.cmbBanco.SelectedItem = Nothing
        Me.cmbBanco.Size = New System.Drawing.Size(180, 20)
        Me.cmbBanco.TabIndex = 13
        Me.cmbBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(368, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Banco :"
        '
        'txtObsAnt
        '
        Me.txtObsAnt.Location = New System.Drawing.Point(8, 197)
        Me.txtObsAnt.Multiline = True
        Me.txtObsAnt.Name = "txtObsAnt"
        Me.txtObsAnt.Size = New System.Drawing.Size(600, 110)
        Me.txtObsAnt.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Observaciones :"
        '
        'txtTotal
        '
        Me.txtTotal.DecimalDigits = 2
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(488, 154)
        Me.txtTotal.MaxLength = 12
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(120, 20)
        Me.txtTotal.TabIndex = 15
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(428, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Total :"
        '
        'cmbPago
        '
        Me.cmbPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPago_DesignTimeLayout.LayoutString = resources.GetString("cmbPago_DesignTimeLayout.LayoutString")
        Me.cmbPago.DesignTimeLayout = cmbPago_DesignTimeLayout
        Me.cmbPago.Location = New System.Drawing.Point(248, 124)
        Me.cmbPago.Name = "cmbPago"
        Me.cmbPago.SelectedIndex = -1
        Me.cmbPago.SelectedItem = Nothing
        Me.cmbPago.Size = New System.Drawing.Size(100, 20)
        Me.cmbPago.TabIndex = 11
        Me.cmbPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(158, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Forma Pago :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(78, 124)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(60, 20)
        Me.cmbMoneda.TabIndex = 9
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Moneda :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cliente :"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Control
        Me.txtCliente.ButtonImage = CType(resources.GetObject("txtCliente.ButtonImage"), System.Drawing.Image)
        Me.txtCliente.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(78, 94)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(385, 20)
        Me.txtCliente.TabIndex = 7
        Me.txtCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTipCam
        '
        Me.txtTipCam.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipCam.DecimalDigits = 3
        Me.txtTipCam.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.txtTipCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCam.Location = New System.Drawing.Point(508, 35)
        Me.txtTipCam.MaxLength = 12
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.ReadOnly = True
        Me.txtTipCam.Size = New System.Drawing.Size(100, 20)
        Me.txtTipCam.TabIndex = 5
        Me.txtTipCam.TabStop = False
        Me.txtTipCam.Text = "0.000"
        Me.txtTipCam.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTipCam.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTipCam.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(388, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tipo de Cambio :"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(258, 35)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(102, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.Value = New Date(2009, 10, 6, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(198, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha :"
        '
        'txtNumAnt
        '
        Me.txtNumAnt.BackColor = System.Drawing.Color.Beige
        Me.txtNumAnt.DecimalDigits = 0
        Me.txtNumAnt.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.txtNumAnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumAnt.FormatString = "##########"
        Me.txtNumAnt.Location = New System.Drawing.Point(78, 35)
        Me.txtNumAnt.MaxLength = 10
        Me.txtNumAnt.Name = "txtNumAnt"
        Me.txtNumAnt.ReadOnly = True
        Me.txtNumAnt.Size = New System.Drawing.Size(100, 20)
        Me.txtNumAnt.TabIndex = 1
        Me.txtNumAnt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtNumAnt.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtNumAnt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnGuardar)
        Me.UiGroupBox2.Controls.Add(Me.btnEliminar)
        Me.UiGroupBox2.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 307)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(617, 35)
        Me.UiGroupBox2.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(395, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 24)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(468, 8)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(73, 24)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(541, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miGuardar, Me.miEliminar, Me.miCancelar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(121, 70)
        '
        'miGuardar
        '
        Me.miGuardar.Image = CType(resources.GetObject("miGuardar.Image"), System.Drawing.Image)
        Me.miGuardar.Name = "miGuardar"
        Me.miGuardar.Size = New System.Drawing.Size(120, 22)
        Me.miGuardar.Text = "&Guandar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = CType(resources.GetObject("miEliminar.Image"), System.Drawing.Image)
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(120, 22)
        Me.miEliminar.Text = "&Eliminar"
        '
        'miCancelar
        '
        Me.miCancelar.Image = CType(resources.GetObject("miCancelar.Image"), System.Drawing.Image)
        Me.miCancelar.Name = "miCancelar"
        Me.miCancelar.Size = New System.Drawing.Size(120, 22)
        Me.miCancelar.Text = "&Cancelar"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmAnticipo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(617, 342)
        Me.ContextMenuStrip = Me.cmOpciones
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(625, 420)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(625, 350)
        Me.Name = "frmAnticipo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAnticipo"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
  Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtNumAnt As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents txtTipCam As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtCliente As Janus.Windows.GridEX.EditControls.EditBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents cmbPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
  Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtObsAnt As Janus.Windows.GridEX.EditControls.EditBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents cmbBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
  Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
  Friend WithEvents btnEliminar As System.Windows.Forms.Button
  Friend WithEvents btnGuardar As System.Windows.Forms.Button
  Friend WithEvents btnCancelar As System.Windows.Forms.Button
  Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents miGuardar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents miCancelar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
