<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrasladarCostos
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
        Dim cmbOficinasOri_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrasladarCostos))
        Dim cmbIdLocacionOri_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinasDes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacionDes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbOficinasOri = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cmbIdLocacionOri = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbPorLima = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPorOficina = New Janus.Windows.EditControls.UIRadioButton()
        Me.cmbOficinasDes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbIdLocacionDes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblProgreso = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.gbOpciones = New System.Windows.Forms.GroupBox()
        Me.gbDestino = New System.Windows.Forms.GroupBox()
        Me.gbOrigen = New System.Windows.Forms.GroupBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinasOri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacionOri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinasDes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacionDes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpciones.SuspendLayout()
        Me.gbDestino.SuspendLayout()
        Me.gbOrigen.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbOficinasOri
        '
        Me.cmbOficinasOri.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinasOri_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinasOri_DesignTimeLayout.LayoutString")
        Me.cmbOficinasOri.DesignTimeLayout = cmbOficinasOri_DesignTimeLayout
        Me.cmbOficinasOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinasOri.Location = New System.Drawing.Point(85, 30)
        Me.cmbOficinasOri.Name = "cmbOficinasOri"
        Me.cmbOficinasOri.SelectedIndex = -1
        Me.cmbOficinasOri.SelectedItem = Nothing
        Me.cmbOficinasOri.Size = New System.Drawing.Size(152, 20)
        Me.cmbOficinasOri.TabIndex = 5
        Me.cmbOficinasOri.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Oficina:"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.BackColor = System.Drawing.SystemColors.Window
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(10, 59)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(72, 16)
        Me.lblAlmacen.TabIndex = 97
        Me.lblAlmacen.Text = "Almacén:"
        '
        'cmbIdLocacionOri
        '
        Me.cmbIdLocacionOri.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacionOri_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacionOri_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacionOri.DesignTimeLayout = cmbIdLocacionOri_DesignTimeLayout
        Me.cmbIdLocacionOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacionOri.Location = New System.Drawing.Point(85, 57)
        Me.cmbIdLocacionOri.Name = "cmbIdLocacionOri"
        Me.cmbIdLocacionOri.SelectedIndex = -1
        Me.cmbIdLocacionOri.SelectedItem = Nothing
        Me.cmbIdLocacionOri.Size = New System.Drawing.Size(232, 20)
        Me.cmbIdLocacionOri.TabIndex = 6
        Me.cmbIdLocacionOri.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(233, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 16)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Al :"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(269, 22)
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
        Me.cbFecInicio.Location = New System.Drawing.Point(107, 22)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Fechas  Del : "
        '
        'rbPorLima
        '
        Me.rbPorLima.BackColor = System.Drawing.SystemColors.Window
        Me.rbPorLima.Checked = True
        Me.rbPorLima.Location = New System.Drawing.Point(20, 33)
        Me.rbPorLima.Name = "rbPorLima"
        Me.rbPorLima.Size = New System.Drawing.Size(192, 15)
        Me.rbPorLima.TabIndex = 3
        Me.rbPorLima.TabStop = True
        Me.rbPorLima.Text = "De Lima a Sucursales"
        Me.rbPorLima.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPorOficina
        '
        Me.rbPorOficina.BackColor = System.Drawing.SystemColors.Window
        Me.rbPorOficina.Location = New System.Drawing.Point(20, 54)
        Me.rbPorOficina.Name = "rbPorOficina"
        Me.rbPorOficina.Size = New System.Drawing.Size(178, 18)
        Me.rbPorOficina.TabIndex = 4
        Me.rbPorOficina.TabStop = True
        Me.rbPorOficina.Text = "Por Oficina y Almacén"
        Me.rbPorOficina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbOficinasDes
        '
        Me.cmbOficinasDes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinasDes_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinasDes_DesignTimeLayout.LayoutString")
        Me.cmbOficinasDes.DesignTimeLayout = cmbOficinasDes_DesignTimeLayout
        Me.cmbOficinasDes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinasDes.Location = New System.Drawing.Point(91, 29)
        Me.cmbOficinasDes.Name = "cmbOficinasDes"
        Me.cmbOficinasDes.SelectedIndex = -1
        Me.cmbOficinasDes.SelectedItem = Nothing
        Me.cmbOficinasDes.Size = New System.Drawing.Size(152, 20)
        Me.cmbOficinasDes.TabIndex = 7
        Me.cmbOficinasDes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Oficina:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "Almacén:"
        '
        'cmbIdLocacionDes
        '
        Me.cmbIdLocacionDes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacionDes_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacionDes_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacionDes.DesignTimeLayout = cmbIdLocacionDes_DesignTimeLayout
        Me.cmbIdLocacionDes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacionDes.Location = New System.Drawing.Point(91, 55)
        Me.cmbIdLocacionDes.Name = "cmbIdLocacionDes"
        Me.cmbIdLocacionDes.SelectedIndex = -1
        Me.cmbIdLocacionDes.SelectedItem = Nothing
        Me.cmbIdLocacionDes.Size = New System.Drawing.Size(232, 20)
        Me.cmbIdLocacionDes.TabIndex = 8
        Me.cmbIdLocacionDes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(205, 364)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(73, 25)
        Me.btnAceptar.TabIndex = 9
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
        Me.btnCancelar.Location = New System.Drawing.Point(281, 364)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 25)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.BackColor = System.Drawing.Color.LightBlue
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMensaje.Location = New System.Drawing.Point(23, 338)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(238, 17)
        Me.lblMensaje.TabIndex = 111
        Me.lblMensaje.Text = "Espere un Momento por favor..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(25, 365)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(173, 23)
        Me.ProgressBar1.TabIndex = 110
        '
        'lblProgreso
        '
        Me.lblProgreso.AutoSize = True
        Me.lblProgreso.Location = New System.Drawing.Point(26, 350)
        Me.lblProgreso.Name = "lblProgreso"
        Me.lblProgreso.Size = New System.Drawing.Size(0, 13)
        Me.lblProgreso.TabIndex = 112
        '
        'Timer1
        '
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.rbPorLima)
        Me.gbOpciones.Controls.Add(Me.rbPorOficina)
        Me.gbOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(21, 48)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(231, 89)
        Me.gbOpciones.TabIndex = 113
        Me.gbOpciones.TabStop = False
        Me.gbOpciones.Text = "Opciones"
        '
        'gbDestino
        '
        Me.gbDestino.Controls.Add(Me.cmbOficinasDes)
        Me.gbDestino.Controls.Add(Me.cmbIdLocacionDes)
        Me.gbDestino.Controls.Add(Me.Label7)
        Me.gbDestino.Controls.Add(Me.Label8)
        Me.gbDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDestino.Location = New System.Drawing.Point(21, 238)
        Me.gbDestino.Name = "gbDestino"
        Me.gbDestino.Size = New System.Drawing.Size(341, 86)
        Me.gbDestino.TabIndex = 114
        Me.gbDestino.TabStop = False
        Me.gbDestino.Text = "Opciones"
        '
        'gbOrigen
        '
        Me.gbOrigen.Controls.Add(Me.Label2)
        Me.gbOrigen.Controls.Add(Me.cmbOficinasOri)
        Me.gbOrigen.Controls.Add(Me.cmbIdLocacionOri)
        Me.gbOrigen.Controls.Add(Me.lblAlmacen)
        Me.gbOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrigen.Location = New System.Drawing.Point(21, 140)
        Me.gbOrigen.Name = "gbOrigen"
        Me.gbOrigen.Size = New System.Drawing.Size(342, 92)
        Me.gbOrigen.TabIndex = 115
        Me.gbOrigen.TabStop = False
        Me.gbOrigen.Text = "Almacén Origen"
        '
        'frmTrasladarCostos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(376, 399)
        Me.Controls.Add(Me.gbOrigen)
        Me.Controls.Add(Me.gbDestino)
        Me.Controls.Add(Me.gbOpciones)
        Me.Controls.Add(Me.lblProgreso)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbFecFinal)
        Me.Controls.Add(Me.cbFecInicio)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTrasladarCostos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trasladar Costos"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinasOri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacionOri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinasDes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacionDes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpciones.ResumeLayout(False)
        Me.gbDestino.ResumeLayout(False)
        Me.gbDestino.PerformLayout()
        Me.gbOrigen.ResumeLayout(False)
        Me.gbOrigen.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmbOficinasOri As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacionOri As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinasDes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacionDes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents rbPorLima As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPorOficina As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgreso As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents gbOrigen As System.Windows.Forms.GroupBox
    Friend WithEvents gbDestino As System.Windows.Forms.GroupBox
    Friend WithEvents gbOpciones As System.Windows.Forms.GroupBox
End Class
