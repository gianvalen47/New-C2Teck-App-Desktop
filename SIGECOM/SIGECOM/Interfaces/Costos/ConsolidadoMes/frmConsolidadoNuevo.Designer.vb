<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsolidadoNuevo
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
        Dim cbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsolidadoNuevo))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbUno = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.clFecIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.clFecFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblProgreso = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(126, 86)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(246, 20)
        Me.cbAlmacen.TabIndex = 6
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(6, 86)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(114, 20)
        Me.cbOficina.TabIndex = 5
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbMes
        '
        Me.cbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbMes_DesignTimeLayout.LayoutString = resources.GetString("cbMes_DesignTimeLayout.LayoutString")
        Me.cbMes.DesignTimeLayout = cbMes_DesignTimeLayout
        Me.cbMes.Location = New System.Drawing.Point(223, 19)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.SelectedIndex = -1
        Me.cbMes.SelectedItem = Nothing
        Me.cbMes.Size = New System.Drawing.Size(96, 20)
        Me.cbMes.TabIndex = 2
        Me.cbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(166, 19)
        Me.txtPeriodo.Maximum = 3000
        Me.txtPeriodo.Minimum = 2009
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(55, 20)
        Me.txtPeriodo.TabIndex = 1
        Me.txtPeriodo.UpDownStyle = Janus.Windows.GridEX.UpDownStyle.UpDownList
        Me.txtPeriodo.Value = 2009
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Oficina"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(166, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Periodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(248, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(129, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Almacen"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbUno)
        Me.UiGroupBox1.Controls.Add(Me.rbTodos)
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(152, 65)
        Me.UiGroupBox1.TabIndex = 38
        Me.UiGroupBox1.Text = "Opciones de Proceso"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbUno
        '
        Me.rbUno.Location = New System.Drawing.Point(10, 40)
        Me.rbUno.Name = "rbUno"
        Me.rbUno.Size = New System.Drawing.Size(96, 16)
        Me.rbUno.TabIndex = 1
        Me.rbUno.Text = "Un Almacen"
        '
        'rbTodos
        '
        Me.rbTodos.Location = New System.Drawing.Point(10, 19)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(120, 18)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.Text = "Todos los Almacenes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Del :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(277, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Al :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(45, 111)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(97, 26)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(222, 111)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(97, 26)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'clFecIni
        '
        '
        '
        '
        Me.clFecIni.DropDownCalendar.Name = ""
        Me.clFecIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.clFecIni.Location = New System.Drawing.Point(192, 46)
        Me.clFecIni.Name = "clFecIni"
        Me.clFecIni.Size = New System.Drawing.Size(85, 20)
        Me.clFecIni.TabIndex = 3
        Me.clFecIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'clFecFin
        '
        '
        '
        '
        Me.clFecFin.DropDownCalendar.Name = ""
        Me.clFecFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.clFecFin.Location = New System.Drawing.Point(298, 46)
        Me.clFecFin.Name = "clFecFin"
        Me.clFecFin.Size = New System.Drawing.Size(85, 20)
        Me.clFecFin.TabIndex = 4
        Me.clFecFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Timer1
        '
        '
        'lblProgreso
        '
        Me.lblProgreso.AutoSize = True
        Me.lblProgreso.Location = New System.Drawing.Point(55, 140)
        Me.lblProgreso.Name = "lblProgreso"
        Me.lblProgreso.Size = New System.Drawing.Size(0, 13)
        Me.lblProgreso.TabIndex = 45
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.BackColor = System.Drawing.Color.LightBlue
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMensaje.Location = New System.Drawing.Point(51, 140)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(238, 17)
        Me.lblMensaje.TabIndex = 44
        Me.lblMensaje.Text = "Espere un Momento por favor..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(58, 163)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(221, 12)
        Me.ProgressBar1.TabIndex = 43
        '
        'frmConsolidadoNuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(411, 196)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblProgreso)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.clFecFin)
        Me.Controls.Add(Me.clFecIni)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.cbAlmacen)
        Me.Controls.Add(Me.cbOficina)
        Me.Controls.Add(Me.cbMes)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmConsolidadoNuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nuevo Consolidado"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbUno As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents clFecFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents clFecIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblProgreso As System.Windows.Forms.Label
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
