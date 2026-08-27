<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobarServicios_Aprobar
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
        Dim cmbCodPag_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAprobarServicios_Aprobar))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.gbAdelanto = New System.Windows.Forms.GroupBox()
        Me.cmbPorcentaje = New System.Windows.Forms.ComboBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.rbMonto = New System.Windows.Forms.RadioButton()
        Me.rbPorcentaje = New System.Windows.Forms.RadioButton()
        Me.rcAdelanto = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCodPag = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblCondPago = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbRechazar = New System.Windows.Forms.RadioButton()
        Me.rbAprobar = New System.Windows.Forms.RadioButton()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAdelanto.SuspendLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(183, 302)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(74, 23)
        Me.btnCancelar.TabIndex = 131
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(104, 302)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(72, 23)
        Me.btnAceptar.TabIndex = 130
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(186, 44)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(83, 20)
        Me.txtFecha.TabIndex = 141
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(130, 178)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(231, 119)
        Me.txtObservacion.TabIndex = 140
        '
        'gbAdelanto
        '
        Me.gbAdelanto.Controls.Add(Me.cmbPorcentaje)
        Me.gbAdelanto.Controls.Add(Me.txtMonto)
        Me.gbAdelanto.Controls.Add(Me.rbMonto)
        Me.gbAdelanto.Controls.Add(Me.rbPorcentaje)
        Me.gbAdelanto.Location = New System.Drawing.Point(99, 78)
        Me.gbAdelanto.Name = "gbAdelanto"
        Me.gbAdelanto.Size = New System.Drawing.Size(170, 62)
        Me.gbAdelanto.TabIndex = 139
        Me.gbAdelanto.TabStop = False
        '
        'cmbPorcentaje
        '
        Me.cmbPorcentaje.AutoCompleteCustomSource.AddRange(New String() {"10,", "20"})
        Me.cmbPorcentaje.Enabled = False
        Me.cmbPorcentaje.FormattingEnabled = True
        Me.cmbPorcentaje.Location = New System.Drawing.Point(93, 11)
        Me.cmbPorcentaje.Name = "cmbPorcentaje"
        Me.cmbPorcentaje.Size = New System.Drawing.Size(57, 21)
        Me.cmbPorcentaje.TabIndex = 40
        '
        'txtMonto
        '
        Me.txtMonto.Enabled = False
        Me.txtMonto.Location = New System.Drawing.Point(93, 37)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(66, 20)
        Me.txtMonto.TabIndex = 42
        '
        'rbMonto
        '
        Me.rbMonto.AutoSize = True
        Me.rbMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMonto.Location = New System.Drawing.Point(6, 38)
        Me.rbMonto.Name = "rbMonto"
        Me.rbMonto.Size = New System.Drawing.Size(60, 17)
        Me.rbMonto.TabIndex = 1
        Me.rbMonto.TabStop = True
        Me.rbMonto.Text = "Monto"
        Me.rbMonto.UseVisualStyleBackColor = True
        '
        'rbPorcentaje
        '
        Me.rbPorcentaje.AutoSize = True
        Me.rbPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorcentaje.Location = New System.Drawing.Point(6, 15)
        Me.rbPorcentaje.Name = "rbPorcentaje"
        Me.rbPorcentaje.Size = New System.Drawing.Size(83, 17)
        Me.rbPorcentaje.TabIndex = 0
        Me.rbPorcentaje.TabStop = True
        Me.rbPorcentaje.Text = "Porcertaje"
        Me.rbPorcentaje.UseVisualStyleBackColor = True
        '
        'rcAdelanto
        '
        Me.rcAdelanto.AutoSize = True
        Me.rcAdelanto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rcAdelanto.Location = New System.Drawing.Point(17, 89)
        Me.rcAdelanto.Name = "rcAdelanto"
        Me.rcAdelanto.Size = New System.Drawing.Size(76, 17)
        Me.rcAdelanto.TabIndex = 138
        Me.rcAdelanto.Text = "Adelanto"
        Me.rcAdelanto.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(46, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "Observación"
        '
        'cmbCodPag
        '
        Me.cmbCodPag.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPag_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPag_DesignTimeLayout.LayoutString")
        Me.cmbCodPag.DesignTimeLayout = cmbCodPag_DesignTimeLayout
        Me.cmbCodPag.Location = New System.Drawing.Point(130, 152)
        Me.cmbCodPag.Name = "cmbCodPag"
        Me.cmbCodPag.SelectedIndex = -1
        Me.cmbCodPag.SelectedItem = Nothing
        Me.cmbCodPag.Size = New System.Drawing.Size(231, 20)
        Me.cmbCodPag.TabIndex = 136
        Me.cmbCodPag.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCondPago
        '
        Me.lblCondPago.AutoSize = True
        Me.lblCondPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondPago.Location = New System.Drawing.Point(14, 156)
        Me.lblCondPago.Name = "lblCondPago"
        Me.lblCondPago.Size = New System.Drawing.Size(114, 13)
        Me.lblCondPago.TabIndex = 135
        Me.lblCondPago.Text = "Condición de Pago"
        Me.lblCondPago.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(138, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Fecha"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(186, 21)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(83, 20)
        Me.txtNumDoc.TabIndex = 133
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(133, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Número"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbRechazar)
        Me.GroupBox1.Controls.Add(Me.rbAprobar)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(109, 68)
        Me.GroupBox1.TabIndex = 142
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'rbRechazar
        '
        Me.rbRechazar.AutoSize = True
        Me.rbRechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRechazar.Location = New System.Drawing.Point(12, 41)
        Me.rbRechazar.Name = "rbRechazar"
        Me.rbRechazar.Size = New System.Drawing.Size(79, 17)
        Me.rbRechazar.TabIndex = 2
        Me.rbRechazar.Text = "Rechazar"
        Me.rbRechazar.UseVisualStyleBackColor = True
        '
        'rbAprobar
        '
        Me.rbAprobar.AutoSize = True
        Me.rbAprobar.Checked = True
        Me.rbAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAprobar.Location = New System.Drawing.Point(12, 18)
        Me.rbAprobar.Name = "rbAprobar"
        Me.rbAprobar.Size = New System.Drawing.Size(69, 17)
        Me.rbAprobar.TabIndex = 1
        Me.rbAprobar.TabStop = True
        Me.rbAprobar.Text = "Aprobar"
        Me.rbAprobar.UseVisualStyleBackColor = True
        '
        'frmAprobarServicios_Aprobar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(375, 337)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.gbAdelanto)
        Me.Controls.Add(Me.rcAdelanto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbCodPag)
        Me.Controls.Add(Me.lblCondPago)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAprobarServicios_Aprobar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmServicios_Cotizacion_Aprobar"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAdelanto.ResumeLayout(False)
        Me.gbAdelanto.PerformLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents gbAdelanto As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPorcentaje As System.Windows.Forms.ComboBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents rbMonto As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorcentaje As System.Windows.Forms.RadioButton
    Friend WithEvents rcAdelanto As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCodPag As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblCondPago As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbRechazar As System.Windows.Forms.RadioButton
    Friend WithEvents rbAprobar As System.Windows.Forms.RadioButton
End Class
