<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcacionOnline
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
        Dim cmbEquipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarcacionOnline))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosMarcacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.lbltiempo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbHorario = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtHoraMarcaIng = New System.Windows.Forms.MaskedTextBox()
        Me.lblHoraIn = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEquipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.gbDatosMarcacion.Controls.Add(Me.lbltiempo)
        Me.gbDatosMarcacion.Controls.Add(Me.Label6)
        Me.gbDatosMarcacion.Controls.Add(Me.cmbHorario)
        Me.gbDatosMarcacion.Controls.Add(Me.txtHoraMarcaIng)
        Me.gbDatosMarcacion.Controls.Add(Me.lblHoraIn)
        Me.gbDatosMarcacion.Controls.Add(Me.lblFecha)
        Me.gbDatosMarcacion.Controls.Add(Me.txtFecha)
        Me.gbDatosMarcacion.Controls.Add(Me.txtColaborador)
        Me.gbDatosMarcacion.Controls.Add(Me.Label3)
        Me.gbDatosMarcacion.Controls.Add(Me.Label1)
        Me.gbDatosMarcacion.Controls.Add(Me.cmbEquipo)
        Me.gbDatosMarcacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosMarcacion.Location = New System.Drawing.Point(8, 7)
        Me.gbDatosMarcacion.Name = "gbDatosMarcacion"
        Me.gbDatosMarcacion.Size = New System.Drawing.Size(417, 167)
        Me.gbDatosMarcacion.TabIndex = 0
        Me.gbDatosMarcacion.Text = "Datos de Marcación"
        Me.gbDatosMarcacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lbltiempo
        '
        Me.lbltiempo.AutoSize = True
        Me.lbltiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltiempo.ForeColor = System.Drawing.Color.Maroon
        Me.lbltiempo.Location = New System.Drawing.Point(98, 104)
        Me.lbltiempo.Name = "lbltiempo"
        Me.lbltiempo.Size = New System.Drawing.Size(72, 16)
        Me.lbltiempo.TabIndex = 265
        Me.lbltiempo.Text = "lbltiempo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 49)
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
        Me.cmbHorario.Location = New System.Drawing.Point(95, 45)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.ReadOnly = True
        Me.cmbHorario.SelectedIndex = -1
        Me.cmbHorario.SelectedItem = Nothing
        Me.cmbHorario.Size = New System.Drawing.Size(253, 20)
        Me.cmbHorario.TabIndex = 5
        Me.cmbHorario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtHoraMarcaIng
        '
        Me.txtHoraMarcaIng.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtHoraMarcaIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraMarcaIng.ForeColor = System.Drawing.Color.Green
        Me.txtHoraMarcaIng.Location = New System.Drawing.Point(207, 118)
        Me.txtHoraMarcaIng.Mask = "00:00"
        Me.txtHoraMarcaIng.Name = "txtHoraMarcaIng"
        Me.txtHoraMarcaIng.ReadOnly = True
        Me.txtHoraMarcaIng.Size = New System.Drawing.Size(101, 31)
        Me.txtHoraMarcaIng.TabIndex = 6
        Me.txtHoraMarcaIng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHoraMarcaIng.ValidatingType = GetType(Date)
        '
        'lblHoraIn
        '
        Me.lblHoraIn.AutoSize = True
        Me.lblHoraIn.Location = New System.Drawing.Point(222, 101)
        Me.lblHoraIn.Name = "lblHoraIn"
        Me.lblHoraIn.Size = New System.Drawing.Size(73, 13)
        Me.lblHoraIn.TabIndex = 245
        Me.lblHoraIn.Text = "Hora Marca"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(47, 129)
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
        Me.txtFecha.Location = New System.Drawing.Point(95, 126)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(95, 20)
        Me.txtFecha.TabIndex = 4
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
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
        Me.Label1.Location = New System.Drawing.Point(43, 73)
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
        Me.cmbEquipo.Location = New System.Drawing.Point(95, 70)
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
        Me.btnCancelar.Location = New System.Drawing.Point(215, 186)
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
        Me.btnGuardar.Location = New System.Drawing.Point(131, 186)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmMarcacionOnline
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(441, 229)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatosMarcacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMarcacionOnline"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva Marcación Online"
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
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblHoraIn As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtHoraMarcaIng As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbHorario As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lbltiempo As Label
End Class
