<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudGarantia_ManoObra
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
        Dim cmbTipoHoraExtra_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudGarantia_ManoObra))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalKm = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblHoraIn = New System.Windows.Forms.Label()
        Me.lblHoraFin = New System.Windows.Forms.Label()
        Me.txtInicioKm = New System.Windows.Forms.TextBox()
        Me.txtCantHoras = New System.Windows.Forms.TextBox()
        Me.lblCanHoras = New System.Windows.Forms.Label()
        Me.txtHoraInicio = New System.Windows.Forms.MaskedTextBox()
        Me.txtFinKm = New System.Windows.Forms.TextBox()
        Me.txtHoraFin = New System.Windows.Forms.MaskedTextBox()
        Me.lbltotalkm = New System.Windows.Forms.Label()
        Me.lbliniciokm = New System.Windows.Forms.Label()
        Me.lblfinkm = New System.Windows.Forms.Label()
        Me.lblConductor = New System.Windows.Forms.Label()
        Me.txtConductor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoHoraExtra = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbTipoHoraExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.lblConductor)
        Me.UiGroupBox1.Controls.Add(Me.txtConductor)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipoHoraExtra)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.lblFecha)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Controls.Add(Me.txtSolicitante)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(465, 246)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos de Marcación"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtTotalKm)
        Me.UiGroupBox2.Controls.Add(Me.lblHoraIn)
        Me.UiGroupBox2.Controls.Add(Me.lblHoraFin)
        Me.UiGroupBox2.Controls.Add(Me.txtInicioKm)
        Me.UiGroupBox2.Controls.Add(Me.txtCantHoras)
        Me.UiGroupBox2.Controls.Add(Me.lblCanHoras)
        Me.UiGroupBox2.Controls.Add(Me.txtHoraInicio)
        Me.UiGroupBox2.Controls.Add(Me.txtFinKm)
        Me.UiGroupBox2.Controls.Add(Me.txtHoraFin)
        Me.UiGroupBox2.Controls.Add(Me.lbltotalkm)
        Me.UiGroupBox2.Controls.Add(Me.lbliniciokm)
        Me.UiGroupBox2.Controls.Add(Me.lblfinkm)
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 70)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(442, 90)
        Me.UiGroupBox2.TabIndex = 4
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtTotalKm
        '
        Me.txtTotalKm.DecimalDigits = 2
        Me.txtTotalKm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalKm.Location = New System.Drawing.Point(303, 66)
        Me.txtTotalKm.MaxLength = 10
        Me.txtTotalKm.Name = "txtTotalKm"
        Me.txtTotalKm.Size = New System.Drawing.Size(115, 20)
        Me.txtTotalKm.TabIndex = 28
        Me.txtTotalKm.Text = "0.00"
        Me.txtTotalKm.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalKm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblHoraIn
        '
        Me.lblHoraIn.AutoSize = True
        Me.lblHoraIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraIn.Location = New System.Drawing.Point(38, 13)
        Me.lblHoraIn.Name = "lblHoraIn"
        Me.lblHoraIn.Size = New System.Drawing.Size(69, 13)
        Me.lblHoraIn.TabIndex = 121
        Me.lblHoraIn.Text = "Hora Inicio"
        '
        'lblHoraFin
        '
        Me.lblHoraFin.AutoSize = True
        Me.lblHoraFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraFin.Location = New System.Drawing.Point(185, 13)
        Me.lblHoraFin.Name = "lblHoraFin"
        Me.lblHoraFin.Size = New System.Drawing.Size(55, 13)
        Me.lblHoraFin.TabIndex = 122
        Me.lblHoraFin.Text = "Hora Fin"
        '
        'txtInicioKm
        '
        Me.txtInicioKm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicioKm.Location = New System.Drawing.Point(23, 66)
        Me.txtInicioKm.Name = "txtInicioKm"
        Me.txtInicioKm.Size = New System.Drawing.Size(100, 20)
        Me.txtInicioKm.TabIndex = 8
        Me.txtInicioKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantHoras
        '
        Me.txtCantHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantHoras.Location = New System.Drawing.Point(303, 27)
        Me.txtCantHoras.Name = "txtCantHoras"
        Me.txtCantHoras.ReadOnly = True
        Me.txtCantHoras.Size = New System.Drawing.Size(115, 20)
        Me.txtCantHoras.TabIndex = 7
        Me.txtCantHoras.TabStop = False
        Me.txtCantHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCanHoras
        '
        Me.lblCanHoras.AutoSize = True
        Me.lblCanHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCanHoras.Location = New System.Drawing.Point(323, 13)
        Me.lblCanHoras.Name = "lblCanHoras"
        Me.lblCanHoras.Size = New System.Drawing.Size(74, 13)
        Me.lblCanHoras.TabIndex = 266
        Me.lblCanHoras.Text = "Cant. Horas"
        '
        'txtHoraInicio
        '
        Me.txtHoraInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraInicio.Location = New System.Drawing.Point(23, 27)
        Me.txtHoraInicio.Mask = "00:00"
        Me.txtHoraInicio.Name = "txtHoraInicio"
        Me.txtHoraInicio.Size = New System.Drawing.Size(100, 20)
        Me.txtHoraInicio.TabIndex = 5
        Me.txtHoraInicio.Text = "0000"
        Me.txtHoraInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFinKm
        '
        Me.txtFinKm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinKm.Location = New System.Drawing.Point(163, 66)
        Me.txtFinKm.Name = "txtFinKm"
        Me.txtFinKm.Size = New System.Drawing.Size(100, 20)
        Me.txtFinKm.TabIndex = 9
        Me.txtFinKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHoraFin
        '
        Me.txtHoraFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraFin.Location = New System.Drawing.Point(163, 27)
        Me.txtHoraFin.Mask = "00:00"
        Me.txtHoraFin.Name = "txtHoraFin"
        Me.txtHoraFin.Size = New System.Drawing.Size(100, 20)
        Me.txtHoraFin.TabIndex = 6
        Me.txtHoraFin.Text = "0000"
        Me.txtHoraFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalkm
        '
        Me.lbltotalkm.AutoSize = True
        Me.lbltotalkm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalkm.Location = New System.Drawing.Point(330, 52)
        Me.lbltotalkm.Name = "lbltotalkm"
        Me.lbltotalkm.Size = New System.Drawing.Size(61, 13)
        Me.lbltotalkm.TabIndex = 272
        Me.lbltotalkm.Text = "Total Km."
        '
        'lbliniciokm
        '
        Me.lbliniciokm.AutoSize = True
        Me.lbliniciokm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbliniciokm.Location = New System.Drawing.Point(62, 52)
        Me.lbliniciokm.Name = "lbliniciokm"
        Me.lbliniciokm.Size = New System.Drawing.Size(23, 13)
        Me.lbliniciokm.TabIndex = 269
        Me.lbliniciokm.Text = "De"
        '
        'lblfinkm
        '
        Me.lblfinkm.AutoSize = True
        Me.lblfinkm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinkm.Location = New System.Drawing.Point(205, 52)
        Me.lblfinkm.Name = "lblfinkm"
        Me.lblfinkm.Size = New System.Drawing.Size(15, 13)
        Me.lblfinkm.TabIndex = 270
        Me.lblfinkm.Text = "A"
        '
        'lblConductor
        '
        Me.lblConductor.AutoSize = True
        Me.lblConductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConductor.Location = New System.Drawing.Point(9, 171)
        Me.lblConductor.Name = "lblConductor"
        Me.lblConductor.Size = New System.Drawing.Size(65, 13)
        Me.lblConductor.TabIndex = 404
        Me.lblConductor.Text = "Conductor"
        '
        'txtConductor
        '
        Me.txtConductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConductor.Location = New System.Drawing.Point(111, 168)
        Me.txtConductor.Name = "txtConductor"
        Me.txtConductor.Size = New System.Drawing.Size(343, 20)
        Me.txtConductor.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 355
        Me.Label1.Text = "Tipo Hora Extra"
        '
        'cmbTipoHoraExtra
        '
        Me.cmbTipoHoraExtra.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoHoraExtra_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoHoraExtra_DesignTimeLayout.LayoutString")
        Me.cmbTipoHoraExtra.DesignTimeLayout = cmbTipoHoraExtra_DesignTimeLayout
        Me.cmbTipoHoraExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoHoraExtra.Location = New System.Drawing.Point(107, 46)
        Me.cmbTipoHoraExtra.Name = "cmbTipoHoraExtra"
        Me.cmbTipoHoraExtra.SelectedIndex = -1
        Me.cmbTipoHoraExtra.SelectedItem = Nothing
        Me.cmbTipoHoraExtra.Size = New System.Drawing.Size(208, 20)
        Me.cmbTipoHoraExtra.TabIndex = 2
        Me.cmbTipoHoraExtra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Actividad"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(111, 194)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(343, 44)
        Me.txtObservacion.TabIndex = 12
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(319, 50)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 114
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(363, 46)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(91, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtSolicitante
        '
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.Location = New System.Drawing.Point(107, 20)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.ReadOnly = True
        Me.txtSolicitante.Size = New System.Drawing.Size(321, 20)
        Me.txtSolicitante.TabIndex = 1
        Me.txtSolicitante.TabStop = False
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(9, 23)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(75, 13)
        Me.lblPersona.TabIndex = 106
        Me.lblPersona.Text = "Colaborador"
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(430, 19)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPersona.TabIndex = 1
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(242, 255)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 28)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.TabStop = False
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAceptar.Location = New System.Drawing.Point(156, 255)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 28)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmSolicitudGarantia_ManoObra
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(479, 290)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudGarantia_ManoObra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Reparación - Mano de Obra"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbTipoHoraExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblHoraFin As Label
    Friend WithEvents lblHoraIn As Label
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtSolicitante As TextBox
    Friend WithEvents lblPersona As Label
    Friend WithEvents btnBuscarPersona As Button
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblCanHoras As Label
    Friend WithEvents txtCantHoras As TextBox
    Friend WithEvents txtFinKm As TextBox
    Friend WithEvents lbltotalkm As Label
    Friend WithEvents lblfinkm As Label
    Friend WithEvents lbliniciokm As Label
    Friend WithEvents txtHoraFin As MaskedTextBox
    Friend WithEvents txtHoraInicio As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTipoHoraExtra As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtInicioKm As TextBox
    Friend WithEvents lblConductor As Label
    Friend WithEvents txtConductor As TextBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalKm As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
