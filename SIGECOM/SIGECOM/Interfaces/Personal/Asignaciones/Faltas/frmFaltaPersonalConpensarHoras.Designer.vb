<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFaltaPersonalConpensarHoras
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFaltaPersonalConpensarHoras))
        Dim cmbPerAutoriza_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtHoraInicio = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalHoras = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.txtFechaProceso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarColaborador = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbPerAutoriza = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPerAutoriza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtHoraInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalHoras)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.btnConsultar)
        Me.UiGroupBox1.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaProceso)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtColaborador)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarColaborador)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.cmbPerAutoriza)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaFinal)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 7)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(576, 277)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos de Falta"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtHoraInicio
        '
        Me.txtHoraInicio.Location = New System.Drawing.Point(98, 65)
        Me.txtHoraInicio.Mask = "00:00"
        Me.txtHoraInicio.Name = "txtHoraInicio"
        Me.txtHoraInicio.Size = New System.Drawing.Size(61, 20)
        Me.txtHoraInicio.TabIndex = 252
        Me.txtHoraInicio.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 253
        Me.Label6.Text = "Hora Inicio"
        '
        'txtTotalHoras
        '
        Me.txtTotalHoras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHoras.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTotalHoras.Location = New System.Drawing.Point(271, 246)
        Me.txtTotalHoras.MaxLength = 3
        Me.txtTotalHoras.Name = "txtTotalHoras"
        Me.txtTotalHoras.ReadOnly = True
        Me.txtTotalHoras.Size = New System.Drawing.Size(53, 20)
        Me.txtTotalHoras.TabIndex = 250
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 249)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 251
        Me.Label2.Text = "Total Horas"
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(492, 63)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultar.TabIndex = 249
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 89)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(561, 154)
        Me.dgvDatos.TabIndex = 248
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFechaProceso
        '
        '
        '
        '
        Me.txtFechaProceso.DropDownCalendar.Name = ""
        Me.txtFechaProceso.DropDownCalendar.Visible = False
        Me.txtFechaProceso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaProceso.Location = New System.Drawing.Point(98, 40)
        Me.txtFechaProceso.Name = "txtFechaProceso"
        Me.txtFechaProceso.NullButtonText = "Ninguno"
        Me.txtFechaProceso.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaProceso.TabIndex = 246
        Me.txtFechaProceso.TodayButtonText = "Hoy"
        Me.txtFechaProceso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 247
        Me.Label1.Text = "Fecha Proceso"
        '
        'txtColaborador
        '
        Me.txtColaborador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtColaborador.Location = New System.Drawing.Point(98, 17)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(296, 20)
        Me.txtColaborador.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 230
        Me.Label3.Text = "Colaborador"
        '
        'btnBuscarColaborador
        '
        Me.btnBuscarColaborador.Image = CType(resources.GetObject("btnBuscarColaborador.Image"), System.Drawing.Image)
        Me.btnBuscarColaborador.Location = New System.Drawing.Point(395, 15)
        Me.btnBuscarColaborador.Name = "btnBuscarColaborador"
        Me.btnBuscarColaborador.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarColaborador.TabIndex = 2
        Me.btnBuscarColaborador.TabStop = False
        Me.btnBuscarColaborador.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(193, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 243
        Me.Label8.Text = "Autoriza"
        '
        'cmbPerAutoriza
        '
        Me.cmbPerAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbPerAutoriza.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPerAutoriza_DesignTimeLayout.LayoutString = resources.GetString("cmbPerAutoriza_DesignTimeLayout.LayoutString")
        Me.cmbPerAutoriza.DesignTimeLayout = cmbPerAutoriza_DesignTimeLayout
        Me.cmbPerAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerAutoriza.Location = New System.Drawing.Point(251, 40)
        Me.cmbPerAutoriza.Name = "cmbPerAutoriza"
        Me.cmbPerAutoriza.SelectedIndex = -1
        Me.cmbPerAutoriza.SelectedItem = Nothing
        Me.cmbPerAutoriza.Size = New System.Drawing.Size(296, 20)
        Me.cmbPerAutoriza.TabIndex = 9
        Me.cmbPerAutoriza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbPerAutoriza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(376, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 238
        Me.Label5.Text = "Al"
        '
        'txtFechaFinal
        '
        '
        '
        '
        Me.txtFechaFinal.DropDownCalendar.Name = ""
        Me.txtFechaFinal.DropDownCalendar.Visible = False
        Me.txtFechaFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaFinal.Location = New System.Drawing.Point(398, 65)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.NullButtonText = "Ninguno"
        Me.txtFechaFinal.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaFinal.TabIndex = 6
        Me.txtFechaFinal.TodayButtonText = "Hoy"
        Me.txtFechaFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.DropDownCalendar.Name = ""
        Me.txtFechaInicio.DropDownCalendar.Visible = False
        Me.txtFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaInicio.Location = New System.Drawing.Point(269, 65)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.NullButtonText = "Ninguno"
        Me.txtFechaInicio.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaInicio.TabIndex = 5
        Me.txtFechaInicio.TodayButtonText = "Hoy"
        Me.txtFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 235
        Me.Label4.Text = "De"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(290, 293)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 192
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(206, 293)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmFaltaPersonalConpensarHoras
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(595, 344)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFaltaPersonalConpensarHoras"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compensar Horas"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPerAutoriza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarColaborador As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbPerAutoriza As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtFechaProceso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As Label
    Friend WithEvents btnConsultar As Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtTotalHoras As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtHoraInicio As MaskedTextBox
    Friend WithEvents Label6 As Label
End Class
