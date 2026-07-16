<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGarantias
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
        Dim cbDocumento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGarantias))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.gvOpciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbtnProcesar = New System.Windows.Forms.RadioButton()
        Me.rbtnFacturar = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFactura = New System.Windows.Forms.Label()
        Me.cbDocumento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNroJob = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNroFactura = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbGD = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbGR = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gvOpciones.SuspendLayout()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(213, 28)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 0
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'gvOpciones
        '
        Me.gvOpciones.Controls.Add(Me.rbtnProcesar)
        Me.gvOpciones.Controls.Add(Me.rbtnFacturar)
        Me.gvOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvOpciones.Location = New System.Drawing.Point(16, 294)
        Me.gvOpciones.Name = "gvOpciones"
        Me.gvOpciones.Size = New System.Drawing.Size(113, 68)
        Me.gvOpciones.TabIndex = 118
        Me.gvOpciones.Text = "Opciones"
        Me.gvOpciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbtnProcesar
        '
        Me.rbtnProcesar.AutoSize = True
        Me.rbtnProcesar.Location = New System.Drawing.Point(16, 42)
        Me.rbtnProcesar.Name = "rbtnProcesar"
        Me.rbtnProcesar.Size = New System.Drawing.Size(75, 17)
        Me.rbtnProcesar.TabIndex = 0
        Me.rbtnProcesar.Text = "Procesar"
        Me.rbtnProcesar.UseVisualStyleBackColor = True
        '
        'rbtnFacturar
        '
        Me.rbtnFacturar.AutoSize = True
        Me.rbtnFacturar.Checked = True
        Me.rbtnFacturar.Location = New System.Drawing.Point(16, 19)
        Me.rbtnFacturar.Name = "rbtnFacturar"
        Me.rbtnFacturar.Size = New System.Drawing.Size(72, 17)
        Me.rbtnFacturar.TabIndex = 1
        Me.rbtnFacturar.TabStop = True
        Me.rbtnFacturar.Text = "Facturar"
        Me.rbtnFacturar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "Nro de OT:"
        '
        'lblFactura
        '
        Me.lblFactura.AutoSize = True
        Me.lblFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactura.Location = New System.Drawing.Point(141, 315)
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Size = New System.Drawing.Size(76, 16)
        Me.lblFactura.TabIndex = 121
        Me.lblFactura.Text = "Tipo Doc."
        '
        'cbDocumento
        '
        Me.cbDocumento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbDocumento_DesignTimeLayout.LayoutString = resources.GetString("cbDocumento_DesignTimeLayout.LayoutString")
        Me.cbDocumento.DesignTimeLayout = cbDocumento_DesignTimeLayout
        Me.cbDocumento.Location = New System.Drawing.Point(208, 341)
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.SelectedIndex = -1
        Me.cbDocumento.SelectedItem = Nothing
        Me.cbDocumento.Size = New System.Drawing.Size(164, 20)
        Me.cbDocumento.TabIndex = 552
        Me.cbDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNroJob
        '
        Me.txtNroJob.Location = New System.Drawing.Point(108, 29)
        Me.txtNroJob.Name = "txtNroJob"
        Me.txtNroJob.Size = New System.Drawing.Size(100, 20)
        Me.txtNroJob.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 373)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "Observacion:"
        '
        'txtNroFactura
        '
        Me.txtNroFactura.Location = New System.Drawing.Point(377, 342)
        Me.txtNroFactura.Name = "txtNroFactura"
        Me.txtNroFactura.Size = New System.Drawing.Size(100, 20)
        Me.txtNroFactura.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(522, 423)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 130
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(439, 423)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.AcceptsTab = True
        Me.txtObservacion.Location = New System.Drawing.Point(12, 392)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(411, 81)
        Me.txtObservacion.TabIndex = 136
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 85)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(639, 200)
        Me.DataGridView1.TabIndex = 137
        '
        'txtCondicion
        '
        Me.txtCondicion.BackColor = System.Drawing.SystemColors.Window
        Me.txtCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCondicion.Location = New System.Drawing.Point(145, 341)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.Size = New System.Drawing.Size(58, 20)
        Me.txtCondicion.TabIndex = 4
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbGD)
        Me.UiGroupBox1.Controls.Add(Me.rbGR)
        Me.UiGroupBox1.Location = New System.Drawing.Point(272, 8)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(309, 67)
        Me.UiGroupBox1.TabIndex = 553
        '
        'rbGD
        '
        Me.rbGD.Location = New System.Drawing.Point(12, 39)
        Me.rbGD.Name = "rbGD"
        Me.rbGD.Size = New System.Drawing.Size(290, 23)
        Me.rbGD.TabIndex = 1
        Me.rbGD.Text = "Procesar Solo Guias de Devolución"
        '
        'rbGR
        '
        Me.rbGR.Checked = True
        Me.rbGR.Location = New System.Drawing.Point(12, 15)
        Me.rbGR.Name = "rbGR"
        Me.rbGR.Size = New System.Drawing.Size(291, 23)
        Me.rbGR.TabIndex = 0
        Me.rbGR.TabStop = True
        Me.rbGR.Text = "Facturar OT y Guías de Remisión"
        '
        'frmGarantias
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(670, 523)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.txtCondicion)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.txtNroFactura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNroJob)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cbDocumento)
        Me.Controls.Add(Me.lblFactura)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.gvOpciones)
        Me.Controls.Add(Me.btnBuscarJob)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGarantias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturar Job y Guías de Remision / Procesar  Solo Guias de Devolución"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gvOpciones.ResumeLayout(False)
        Me.gvOpciones.PerformLayout()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents gvOpciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbtnProcesar As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFacturar As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFactura As System.Windows.Forms.Label
    Friend WithEvents cbDocumento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNroJob As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNroFactura As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtCondicion As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbGD As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbGR As Janus.Windows.EditControls.UIRadioButton
End Class
