<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContPerContrato_Det
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContPerContrato_Det))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbAumentos = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbAumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAumentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(212, 161)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 8
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
        Me.btnGuardar.Location = New System.Drawing.Point(128, 161)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbAumentos
        '
        Me.gbAumentos.Controls.Add(Me.txtColaborador)
        Me.gbAumentos.Controls.Add(Me.Label5)
        Me.gbAumentos.Controls.Add(Me.Label4)
        Me.gbAumentos.Controls.Add(Me.txtFecFinal)
        Me.gbAumentos.Controls.Add(Me.Label3)
        Me.gbAumentos.Controls.Add(Me.txtFecInicio)
        Me.gbAumentos.Controls.Add(Me.Label1)
        Me.gbAumentos.Controls.Add(Me.txtPeriodo)
        Me.gbAumentos.Controls.Add(Me.Label2)
        Me.gbAumentos.Controls.Add(Me.txtFecha)
        Me.gbAumentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAumentos.Location = New System.Drawing.Point(7, 5)
        Me.gbAumentos.Name = "gbAumentos"
        Me.gbAumentos.Size = New System.Drawing.Size(402, 149)
        Me.gbAumentos.TabIndex = 0
        Me.gbAumentos.Text = "Datos de Contrato"
        Me.gbAumentos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtColaborador
        '
        Me.txtColaborador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtColaborador.Location = New System.Drawing.Point(89, 24)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(276, 20)
        Me.txtColaborador.TabIndex = 1
        Me.txtColaborador.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 344
        Me.Label5.Text = "Colaborador"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(207, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 341
        Me.Label4.Text = "Fec Final"
        '
        'txtFecFinal
        '
        '
        '
        '
        Me.txtFecFinal.DropDownCalendar.Name = ""
        Me.txtFecFinal.DropDownCalendar.Visible = False
        Me.txtFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecFinal.Location = New System.Drawing.Point(271, 114)
        Me.txtFecFinal.Name = "txtFecFinal"
        Me.txtFecFinal.NullButtonText = "Ninguno"
        Me.txtFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinal.TabIndex = 6
        Me.txtFecFinal.TodayButtonText = "Hoy"
        Me.txtFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 339
        Me.Label3.Text = "Fec Inicio"
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.Visible = False
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecInicio.Location = New System.Drawing.Point(89, 114)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.NullButtonText = "Ninguno"
        Me.txtFecInicio.Size = New System.Drawing.Size(94, 20)
        Me.txtFecInicio.TabIndex = 5
        Me.txtFecInicio.TodayButtonText = "Hoy"
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 337
        Me.Label1.Text = "Periodo"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPeriodo.Location = New System.Drawing.Point(89, 85)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPeriodo.Size = New System.Drawing.Size(293, 20)
        Me.txtPeriodo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 332
        Me.Label2.Text = "Fecha"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Location = New System.Drawing.Point(89, 55)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(94, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'frmContPerContrato_Det
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(416, 193)
        Me.Controls.Add(Me.gbAumentos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContPerContrato_Det"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Contrato"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbAumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAumentos.ResumeLayout(False)
        Me.gbAumentos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbAumentos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
