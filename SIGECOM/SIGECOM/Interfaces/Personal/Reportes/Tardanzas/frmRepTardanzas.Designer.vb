<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepTardanzas
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
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepTardanzas))
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbTipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbPuntualidad = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbRecord = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbConsolidado = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbRefrigerio = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbEntrada = New Janus.Windows.EditControls.UIRadioButton()
        Me.cbMarca = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.gbPersona = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.chkColaborador = New System.Windows.Forms.CheckBox()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipo.SuspendLayout()
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPersona.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.gbTipo)
        Me.UiGroupBox1.Controls.Add(Me.cbMarca)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.txtFecFinal)
        Me.UiGroupBox1.Controls.Add(Me.gbPersona)
        Me.UiGroupBox1.Controls.Add(Me.txtFecInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.cmbCentroCosto)
        Me.UiGroupBox1.Controls.Add(Me.Label32)
        Me.UiGroupBox1.Controls.Add(Me.cmbArea)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.cmbClase)
        Me.UiGroupBox1.Controls.Add(Me.Label21)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(19, 4)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(631, 224)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos de Reporte"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.rbPuntualidad)
        Me.gbTipo.Controls.Add(Me.rbRecord)
        Me.gbTipo.Controls.Add(Me.rbConsolidado)
        Me.gbTipo.Controls.Add(Me.rbRefrigerio)
        Me.gbTipo.Controls.Add(Me.rbEntrada)
        Me.gbTipo.Location = New System.Drawing.Point(12, 174)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Size = New System.Drawing.Size(609, 38)
        Me.gbTipo.TabIndex = 379
        Me.gbTipo.Text = "Tipo"
        Me.gbTipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbPuntualidad
        '
        Me.rbPuntualidad.Location = New System.Drawing.Point(510, 14)
        Me.rbPuntualidad.Name = "rbPuntualidad"
        Me.rbPuntualidad.Size = New System.Drawing.Size(92, 18)
        Me.rbPuntualidad.TabIndex = 18
        Me.rbPuntualidad.Text = "Puntualidad"
        '
        'rbRecord
        '
        Me.rbRecord.Location = New System.Drawing.Point(440, 14)
        Me.rbRecord.Name = "rbRecord"
        Me.rbRecord.Size = New System.Drawing.Size(64, 18)
        Me.rbRecord.TabIndex = 17
        Me.rbRecord.Text = "Record"
        '
        'rbConsolidado
        '
        Me.rbConsolidado.Location = New System.Drawing.Point(340, 14)
        Me.rbConsolidado.Name = "rbConsolidado"
        Me.rbConsolidado.Size = New System.Drawing.Size(93, 18)
        Me.rbConsolidado.TabIndex = 16
        Me.rbConsolidado.Text = "Consolidado"
        '
        'rbRefrigerio
        '
        Me.rbRefrigerio.Location = New System.Drawing.Point(173, 14)
        Me.rbRefrigerio.Name = "rbRefrigerio"
        Me.rbRefrigerio.Size = New System.Drawing.Size(160, 18)
        Me.rbRefrigerio.TabIndex = 15
        Me.rbRefrigerio.Text = "Tardanzas de Refrigerio"
        '
        'rbEntrada
        '
        Me.rbEntrada.Checked = True
        Me.rbEntrada.Location = New System.Drawing.Point(15, 14)
        Me.rbEntrada.Name = "rbEntrada"
        Me.rbEntrada.Size = New System.Drawing.Size(151, 18)
        Me.rbEntrada.TabIndex = 14
        Me.rbEntrada.TabStop = True
        Me.rbEntrada.Text = "Tardanzas de Entrada"
        '
        'cbMarca
        '
        Me.cbMarca.AutoSize = True
        Me.cbMarca.Checked = True
        Me.cbMarca.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMarca.Location = New System.Drawing.Point(343, 151)
        Me.cbMarca.Name = "cbMarca"
        Me.cbMarca.Size = New System.Drawing.Size(238, 17)
        Me.cbMarca.TabIndex = 373
        Me.cbMarca.Text = "Colaboradores que marcan asistencia"
        Me.cbMarca.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(359, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 378
        Me.Label6.Text = "Al :"
        '
        'txtFecFinal
        '
        '
        '
        '
        Me.txtFecFinal.DropDownCalendar.Name = ""
        Me.txtFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinal.Location = New System.Drawing.Point(391, 22)
        Me.txtFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecFinal.Name = "txtFecFinal"
        Me.txtFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinal.TabIndex = 367
        Me.txtFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'gbPersona
        '
        Me.gbPersona.Controls.Add(Me.btnBuscarPersona)
        Me.gbPersona.Controls.Add(Me.txtColaborador)
        Me.gbPersona.Controls.Add(Me.lblColaborador)
        Me.gbPersona.Controls.Add(Me.chkColaborador)
        Me.gbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPersona.Location = New System.Drawing.Point(28, 49)
        Me.gbPersona.Name = "gbPersona"
        Me.gbPersona.Size = New System.Drawing.Size(576, 57)
        Me.gbPersona.TabIndex = 368
        Me.gbPersona.Text = "Buscar Persona"
        Me.gbPersona.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(465, 31)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersona.TabIndex = 5
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'txtColaborador
        '
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtColaborador.Location = New System.Drawing.Point(144, 31)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(315, 20)
        Me.txtColaborador.TabIndex = 4
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(63, 34)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(75, 13)
        Me.lblColaborador.TabIndex = 20
        Me.lblColaborador.Text = "Colaborador"
        '
        'chkColaborador
        '
        Me.chkColaborador.AutoSize = True
        Me.chkColaborador.Checked = True
        Me.chkColaborador.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkColaborador.Location = New System.Drawing.Point(187, 12)
        Me.chkColaborador.Name = "chkColaborador"
        Me.chkColaborador.Size = New System.Drawing.Size(166, 17)
        Me.chkColaborador.TabIndex = 4
        Me.chkColaborador.TabStop = False
        Me.chkColaborador.Text = "Todos los Colaboradores"
        Me.chkColaborador.UseVisualStyleBackColor = True
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecInicio.Location = New System.Drawing.Point(219, 22)
        Me.txtFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.txtFecInicio.TabIndex = 366
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(122, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 377
        Me.Label1.Text = " Fechas   Del :"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(352, 118)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(229, 20)
        Me.cmbCentroCosto.TabIndex = 370
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(268, 121)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 13)
        Me.Label32.TabIndex = 376
        Me.Label32.Text = "Centro Costo"
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(79, 118)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(135, 20)
        Me.cmbArea.TabIndex = 369
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(40, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 375
        Me.Label9.Text = "Área"
        '
        'cmbClase
        '
        Me.cmbClase.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbClase_DesignTimeLayout.LayoutString = resources.GetString("cmbClase_DesignTimeLayout.LayoutString")
        Me.cmbClase.DesignTimeLayout = cmbClase_DesignTimeLayout
        Me.cmbClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClase.Location = New System.Drawing.Point(79, 148)
        Me.cmbClase.Name = "cmbClase"
        Me.cmbClase.SelectedIndex = -1
        Me.cmbClase.SelectedItem = Nothing
        Me.cmbClase.Size = New System.Drawing.Size(105, 20)
        Me.cmbClase.TabIndex = 371
        Me.cmbClase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(35, 152)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 374
        Me.Label21.Text = "Clase"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(256, 234)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 25)
        Me.btnAceptar.TabIndex = 13
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
        Me.btnCancelar.Location = New System.Drawing.Point(338, 234)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepTardanzas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(666, 268)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepTardanzas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Tardanzas"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipo.ResumeLayout(False)
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPersona.ResumeLayout(False)
        Me.gbPersona.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbMarca As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbPersona As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents chkColaborador As System.Windows.Forms.CheckBox
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbClase As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbTipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbConsolidado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbRefrigerio As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbEntrada As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbRecord As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPuntualidad As Janus.Windows.EditControls.UIRadioButton
End Class
