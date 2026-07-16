<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepIngresos
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
        Me.components = New System.ComponentModel.Container
        Dim cmbIngreso_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepIngresos))
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbIngreso = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label21 = New System.Windows.Forms.Label
        Me.gbPersona = New Janus.Windows.EditControls.UIGroupBox
        Me.btnBuscarPersona = New System.Windows.Forms.Button
        Me.txtColaborador = New System.Windows.Forms.TextBox
        Me.lblColaborador = New System.Windows.Forms.Label
        Me.chkColaborador = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbIngreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPersona.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.cmbIngreso)
        Me.gbDatos.Controls.Add(Me.cmbArea)
        Me.gbDatos.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatos.Controls.Add(Me.Label32)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.cmbClase)
        Me.gbDatos.Controls.Add(Me.Label21)
        Me.gbDatos.Controls.Add(Me.gbPersona)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.txtFecFinal)
        Me.gbDatos.Controls.Add(Me.txtFecInicio)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(8, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(463, 180)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.Text = "Datos de Reporte"
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 369
        Me.Label2.Text = "Rubro"
        '
        'cmbIngreso
        '
        Me.cmbIngreso.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIngreso_DesignTimeLayout.LayoutString = resources.GetString("cmbIngreso_DesignTimeLayout.LayoutString")
        Me.cmbIngreso.DesignTimeLayout = cmbIngreso_DesignTimeLayout
        Me.cmbIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIngreso.Location = New System.Drawing.Point(263, 148)
        Me.cmbIngreso.Name = "cmbIngreso"
        Me.cmbIngreso.SelectedIndex = -1
        Me.cmbIngreso.SelectedItem = Nothing
        Me.cmbIngreso.Size = New System.Drawing.Size(189, 20)
        Me.cmbIngreso.TabIndex = 9
        Me.cmbIngreso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(54, 114)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(114, 20)
        Me.cmbArea.TabIndex = 6
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(263, 114)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(189, 20)
        Me.cmbCentroCosto.TabIndex = 7
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(182, 117)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 13)
        Me.Label32.TabIndex = 368
        Me.Label32.Text = "Centro Costo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 367
        Me.Label9.Text = "Área"
        '
        'cmbClase
        '
        Me.cmbClase.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbClase_DesignTimeLayout.LayoutString = resources.GetString("cmbClase_DesignTimeLayout.LayoutString")
        Me.cmbClase.DesignTimeLayout = cmbClase_DesignTimeLayout
        Me.cmbClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClase.Location = New System.Drawing.Point(54, 148)
        Me.cmbClase.Name = "cmbClase"
        Me.cmbClase.SelectedIndex = -1
        Me.cmbClase.SelectedItem = Nothing
        Me.cmbClase.Size = New System.Drawing.Size(105, 20)
        Me.cmbClase.TabIndex = 8
        Me.cmbClase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(10, 152)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 366
        Me.Label21.Text = "Clase"
        '
        'gbPersona
        '
        Me.gbPersona.Controls.Add(Me.btnBuscarPersona)
        Me.gbPersona.Controls.Add(Me.txtColaborador)
        Me.gbPersona.Controls.Add(Me.lblColaborador)
        Me.gbPersona.Controls.Add(Me.chkColaborador)
        Me.gbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPersona.Location = New System.Drawing.Point(31, 46)
        Me.gbPersona.Name = "gbPersona"
        Me.gbPersona.Size = New System.Drawing.Size(404, 57)
        Me.gbPersona.TabIndex = 3
        Me.gbPersona.Text = "Buscar Persona"
        Me.gbPersona.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = CType(resources.GetObject("btnBuscarPersona.Image"), System.Drawing.Image)
        Me.btnBuscarPersona.Location = New System.Drawing.Point(371, 29)
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
        Me.txtColaborador.Location = New System.Drawing.Point(91, 31)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(278, 20)
        Me.txtColaborador.TabIndex = 4
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(10, 34)
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
        Me.chkColaborador.Location = New System.Drawing.Point(134, 12)
        Me.chkColaborador.Name = "chkColaborador"
        Me.chkColaborador.Size = New System.Drawing.Size(166, 17)
        Me.chkColaborador.TabIndex = 4
        Me.chkColaborador.TabStop = False
        Me.chkColaborador.Text = "Todos los Colaboradores"
        Me.chkColaborador.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(276, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 361
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
        Me.txtFecFinal.Location = New System.Drawing.Point(308, 19)
        Me.txtFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecFinal.Name = "txtFecFinal"
        Me.txtFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinal.TabIndex = 2
        Me.txtFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecInicio.Location = New System.Drawing.Point(162, 19)
        Me.txtFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.txtFecInicio.TabIndex = 1
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 360
        Me.Label1.Text = " Fechas   Del :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(160, 190)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 25)
        Me.btnAceptar.TabIndex = 10
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
        Me.btnCancelar.Location = New System.Drawing.Point(242, 190)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepIngresos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(479, 222)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepIngresos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ingresos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbIngreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPersona.ResumeLayout(False)
        Me.gbPersona.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbPersona As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents chkColaborador As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbIngreso As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbClase As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
