<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcacionPersonal
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
        Dim cmbHorario_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarcacionPersonal))
        Dim cmbEquipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosMarcacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbHorario = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtHoraRealSal = New System.Windows.Forms.MaskedTextBox()
        Me.txtHoraRealIng = New System.Windows.Forms.MaskedTextBox()
        Me.txtHoraMarcaSal = New System.Windows.Forms.MaskedTextBox()
        Me.txtHoraMarcaIng = New System.Windows.Forms.MaskedTextBox()
        Me.cbPagado = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblHoraIn = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnBuscarColaborador = New System.Windows.Forms.Button()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEquipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosMarcacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosMarcacion.SuspendLayout()
        CType(Me.cmbHorario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosMarcacion
        '
        Me.gbDatosMarcacion.Controls.Add(Me.Label6)
        Me.gbDatosMarcacion.Controls.Add(Me.cmbHorario)
        Me.gbDatosMarcacion.Controls.Add(Me.txtHoraRealSal)
        Me.gbDatosMarcacion.Controls.Add(Me.txtHoraRealIng)
        Me.gbDatosMarcacion.Controls.Add(Me.txtHoraMarcaSal)
        Me.gbDatosMarcacion.Controls.Add(Me.txtHoraMarcaIng)
        Me.gbDatosMarcacion.Controls.Add(Me.cbPagado)
        Me.gbDatosMarcacion.Controls.Add(Me.Label9)
        Me.gbDatosMarcacion.Controls.Add(Me.txtObservacion)
        Me.gbDatosMarcacion.Controls.Add(Me.Label4)
        Me.gbDatosMarcacion.Controls.Add(Me.Label2)
        Me.gbDatosMarcacion.Controls.Add(Me.Label5)
        Me.gbDatosMarcacion.Controls.Add(Me.lblHoraIn)
        Me.gbDatosMarcacion.Controls.Add(Me.lblFecha)
        Me.gbDatosMarcacion.Controls.Add(Me.txtFecha)
        Me.gbDatosMarcacion.Controls.Add(Me.btnBuscarColaborador)
        Me.gbDatosMarcacion.Controls.Add(Me.txtColaborador)
        Me.gbDatosMarcacion.Controls.Add(Me.Label3)
        Me.gbDatosMarcacion.Controls.Add(Me.Label1)
        Me.gbDatosMarcacion.Controls.Add(Me.cmbEquipo)
        Me.gbDatosMarcacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosMarcacion.Location = New System.Drawing.Point(8, 7)
        Me.gbDatosMarcacion.Name = "gbDatosMarcacion"
        Me.gbDatosMarcacion.Size = New System.Drawing.Size(522, 220)
        Me.gbDatosMarcacion.TabIndex = 0
        Me.gbDatosMarcacion.Text = "Datos de Marcación"
        Me.gbDatosMarcacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 264
        Me.Label6.Text = "Horario"
        '
        'cmbHorario
        '
        Me.cmbHorario.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbHorario_DesignTimeLayout.LayoutString = resources.GetString("cmbHorario_DesignTimeLayout.LayoutString")
        Me.cmbHorario.DesignTimeLayout = cmbHorario_DesignTimeLayout
        Me.cmbHorario.Location = New System.Drawing.Point(95, 83)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.SelectedIndex = -1
        Me.cmbHorario.SelectedItem = Nothing
        Me.cmbHorario.Size = New System.Drawing.Size(239, 20)
        Me.cmbHorario.TabIndex = 5
        Me.cmbHorario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtHoraRealSal
        '
        Me.txtHoraRealSal.Location = New System.Drawing.Point(400, 132)
        Me.txtHoraRealSal.Mask = "00:00"
        Me.txtHoraRealSal.Name = "txtHoraRealSal"
        Me.txtHoraRealSal.ReadOnly = True
        Me.txtHoraRealSal.Size = New System.Drawing.Size(101, 20)
        Me.txtHoraRealSal.TabIndex = 9
        Me.txtHoraRealSal.ValidatingType = GetType(Date)
        '
        'txtHoraRealIng
        '
        Me.txtHoraRealIng.Location = New System.Drawing.Point(273, 132)
        Me.txtHoraRealIng.Mask = "00:00"
        Me.txtHoraRealIng.Name = "txtHoraRealIng"
        Me.txtHoraRealIng.ReadOnly = True
        Me.txtHoraRealIng.Size = New System.Drawing.Size(101, 20)
        Me.txtHoraRealIng.TabIndex = 8
        Me.txtHoraRealIng.ValidatingType = GetType(Date)
        '
        'txtHoraMarcaSal
        '
        Me.txtHoraMarcaSal.Location = New System.Drawing.Point(149, 132)
        Me.txtHoraMarcaSal.Mask = "00:00"
        Me.txtHoraMarcaSal.Name = "txtHoraMarcaSal"
        Me.txtHoraMarcaSal.Size = New System.Drawing.Size(101, 20)
        Me.txtHoraMarcaSal.TabIndex = 7
        Me.txtHoraMarcaSal.ValidatingType = GetType(Date)
        '
        'txtHoraMarcaIng
        '
        Me.txtHoraMarcaIng.Location = New System.Drawing.Point(22, 132)
        Me.txtHoraMarcaIng.Mask = "00:00"
        Me.txtHoraMarcaIng.Name = "txtHoraMarcaIng"
        Me.txtHoraMarcaIng.Size = New System.Drawing.Size(101, 20)
        Me.txtHoraMarcaIng.TabIndex = 6
        Me.txtHoraMarcaIng.ValidatingType = GetType(Date)
        '
        'cbPagado
        '
        Me.cbPagado.AutoSize = True
        Me.cbPagado.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbPagado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbPagado.Enabled = False
        Me.cbPagado.ForeColor = System.Drawing.Color.Black
        Me.cbPagado.Location = New System.Drawing.Point(429, 22)
        Me.cbPagado.Name = "cbPagado"
        Me.cbPagado.Size = New System.Drawing.Size(69, 17)
        Me.cbPagado.TabIndex = 247
        Me.cbPagado.TabStop = False
        Me.cbPagado.Text = "Pagado"
        Me.cbPagado.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 250
        Me.Label9.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(95, 161)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(415, 47)
        Me.txtObservacion.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(408, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 248
        Me.Label4.Text = "Hora Sal Real"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(282, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "Hora Ing Real"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(170, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 246
        Me.Label5.Text = "Hora Sal"
        '
        'lblHoraIn
        '
        Me.lblHoraIn.AutoSize = True
        Me.lblHoraIn.Location = New System.Drawing.Point(44, 115)
        Me.lblHoraIn.Name = "lblHoraIn"
        Me.lblHoraIn.Size = New System.Drawing.Size(56, 13)
        Me.lblHoraIn.TabIndex = 245
        Me.lblHoraIn.Text = "Hora Ing"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(372, 54)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 240
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(420, 51)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(90, 20)
        Me.txtFecha.TabIndex = 4
        Me.txtFecha.Value = New Date(2013, 11, 5, 9, 53, 22, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'btnBuscarColaborador
        '
        Me.btnBuscarColaborador.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarColaborador.Location = New System.Drawing.Point(375, 19)
        Me.btnBuscarColaborador.Name = "btnBuscarColaborador"
        Me.btnBuscarColaborador.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarColaborador.TabIndex = 2
        Me.btnBuscarColaborador.TabStop = False
        Me.btnBuscarColaborador.UseVisualStyleBackColor = True
        '
        'txtColaborador
        '
        Me.txtColaborador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtColaborador.Location = New System.Drawing.Point(95, 20)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(279, 20)
        Me.txtColaborador.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 237
        Me.Label3.Text = "Colaborador"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 234
        Me.Label1.Text = "Equipo"
        '
        'cmbEquipo
        '
        Me.cmbEquipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEquipo_DesignTimeLayout.LayoutString = resources.GetString("cmbEquipo_DesignTimeLayout.LayoutString")
        Me.cmbEquipo.DesignTimeLayout = cmbEquipo_DesignTimeLayout
        Me.cmbEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEquipo.Location = New System.Drawing.Point(95, 51)
        Me.cmbEquipo.Name = "cmbEquipo"
        Me.cmbEquipo.SelectedIndex = -1
        Me.cmbEquipo.SelectedItem = Nothing
        Me.cmbEquipo.Size = New System.Drawing.Size(253, 20)
        Me.cmbEquipo.TabIndex = 3
        Me.cmbEquipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(272, 235)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 11
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
        Me.btnGuardar.Location = New System.Drawing.Point(188, 235)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmMarcacionPersonal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(544, 273)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatosMarcacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMarcacionPersonal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva Marcación Personal "
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosMarcacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosMarcacion.ResumeLayout(False)
        Me.gbDatosMarcacion.PerformLayout()
        CType(Me.cmbHorario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosMarcacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEquipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarColaborador As System.Windows.Forms.Button
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblHoraIn As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cbPagado As System.Windows.Forms.CheckBox
    Friend WithEvents txtHoraMarcaIng As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHoraMarcaSal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHoraRealIng As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHoraRealSal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbHorario As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
