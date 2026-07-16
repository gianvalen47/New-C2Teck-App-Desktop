<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreMes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierreMes))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbImportaciones = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbCostos = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbDocumento = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblProgreso = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dtFecCierre = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbRevertir = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbCerrar = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(138, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha de Cierre :"
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbImportaciones)
        Me.UiGroupBox1.Controls.Add(Me.rbCostos)
        Me.UiGroupBox1.Controls.Add(Me.rbDocumento)
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 86)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(102, 83)
        Me.UiGroupBox1.TabIndex = 10
        Me.UiGroupBox1.Text = "Tipo de Cierre"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbImportaciones
        '
        Me.rbImportaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbImportaciones.Location = New System.Drawing.Point(9, 61)
        Me.rbImportaciones.Name = "rbImportaciones"
        Me.rbImportaciones.Size = New System.Drawing.Size(87, 15)
        Me.rbImportaciones.TabIndex = 2
        Me.rbImportaciones.Text = "Importaciones"
        Me.rbImportaciones.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbCostos
        '
        Me.rbCostos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCostos.Location = New System.Drawing.Point(9, 40)
        Me.rbCostos.Name = "rbCostos"
        Me.rbCostos.Size = New System.Drawing.Size(57, 15)
        Me.rbCostos.TabIndex = 1
        Me.rbCostos.Text = "Costos"
        Me.rbCostos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbDocumento
        '
        Me.rbDocumento.Checked = True
        Me.rbDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDocumento.Location = New System.Drawing.Point(9, 19)
        Me.rbDocumento.Name = "rbDocumento"
        Me.rbDocumento.Size = New System.Drawing.Size(81, 15)
        Me.rbDocumento.TabIndex = 0
        Me.rbDocumento.TabStop = True
        Me.rbDocumento.Text = "Documentos"
        Me.rbDocumento.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(35, 180)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 26)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(141, 180)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 26)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Cancelar"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.BackColor = System.Drawing.Color.LightBlue
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMensaje.Location = New System.Drawing.Point(14, 212)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(238, 17)
        Me.lblMensaje.TabIndex = 14
        Me.lblMensaje.Text = "Espere un Momento por favor..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(18, 235)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(232, 12)
        Me.ProgressBar1.TabIndex = 13
        '
        'lblProgreso
        '
        Me.lblProgreso.AutoSize = True
        Me.lblProgreso.Location = New System.Drawing.Point(6, 108)
        Me.lblProgreso.Name = "lblProgreso"
        Me.lblProgreso.Size = New System.Drawing.Size(0, 13)
        Me.lblProgreso.TabIndex = 15
        '
        'Timer1
        '
        '
        'dtFecCierre
        '
        '
        '
        '
        Me.dtFecCierre.DropDownCalendar.Name = ""
        Me.dtFecCierre.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.dtFecCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFecCierre.Location = New System.Drawing.Point(141, 120)
        Me.dtFecCierre.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.dtFecCierre.Name = "dtFecCierre"
        Me.dtFecCierre.Size = New System.Drawing.Size(86, 20)
        Me.dtFecCierre.TabIndex = 93
        Me.dtFecCierre.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.rbRevertir)
        Me.UiGroupBox2.Controls.Add(Me.rbCerrar)
        Me.UiGroupBox2.Location = New System.Drawing.Point(9, 12)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(126, 61)
        Me.UiGroupBox2.TabIndex = 94
        Me.UiGroupBox2.Text = "Opciones"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbRevertir
        '
        Me.rbRevertir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRevertir.Location = New System.Drawing.Point(9, 40)
        Me.rbRevertir.Name = "rbRevertir"
        Me.rbRevertir.Size = New System.Drawing.Size(93, 15)
        Me.rbRevertir.TabIndex = 1
        Me.rbRevertir.Text = "Revertir Cierre"
        Me.rbRevertir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbCerrar
        '
        Me.rbCerrar.Checked = True
        Me.rbCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCerrar.Location = New System.Drawing.Point(9, 19)
        Me.rbCerrar.Name = "rbCerrar"
        Me.rbCerrar.Size = New System.Drawing.Size(81, 15)
        Me.rbCerrar.TabIndex = 0
        Me.rbCerrar.TabStop = True
        Me.rbCerrar.Text = "Cerrar"
        Me.rbCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'frmCierreMes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(267, 262)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.dtFecCierre)
        Me.Controls.Add(Me.lblProgreso)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(250, 184)
        Me.Name = "frmCierreMes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre de Mes"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbCostos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDocumento As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgreso As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents dtFecCierre As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents rbImportaciones As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbRevertir As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbCerrar As Janus.Windows.EditControls.UIRadioButton
End Class
