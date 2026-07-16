<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorario_Detalle
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
        Me.components = New System.ComponentModel.Container
        Dim cmbDias_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHorario_Detalle))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.gbDatosDetalle = New Janus.Windows.EditControls.UIGroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbDias = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtHoraIngreso = New System.Windows.Forms.MaskedTextBox
        Me.txtSalidaRefrig = New System.Windows.Forms.MaskedTextBox
        Me.txtHoraSalida = New System.Windows.Forms.MaskedTextBox
        Me.txtIngresoRefrig = New System.Windows.Forms.MaskedTextBox
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosDetalle.SuspendLayout()
        CType(Me.cmbDias, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnCancelar.Location = New System.Drawing.Point(213, 125)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 7
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
        Me.btnGuardar.Location = New System.Drawing.Point(129, 125)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbDatosDetalle
        '
        Me.gbDatosDetalle.Controls.Add(Me.txtIngresoRefrig)
        Me.gbDatosDetalle.Controls.Add(Me.txtHoraSalida)
        Me.gbDatosDetalle.Controls.Add(Me.txtSalidaRefrig)
        Me.gbDatosDetalle.Controls.Add(Me.txtHoraIngreso)
        Me.gbDatosDetalle.Controls.Add(Me.Label3)
        Me.gbDatosDetalle.Controls.Add(Me.Label1)
        Me.gbDatosDetalle.Controls.Add(Me.Label2)
        Me.gbDatosDetalle.Controls.Add(Me.Label7)
        Me.gbDatosDetalle.Controls.Add(Me.Label6)
        Me.gbDatosDetalle.Controls.Add(Me.cmbDias)
        Me.gbDatosDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosDetalle.Location = New System.Drawing.Point(8, 5)
        Me.gbDatosDetalle.Name = "gbDatosDetalle"
        Me.gbDatosDetalle.Size = New System.Drawing.Size(403, 112)
        Me.gbDatosDetalle.TabIndex = 0
        Me.gbDatosDetalle.Text = "Detalle"
        Me.gbDatosDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDatosDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 250
        Me.Label3.Text = "Día"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "Salida Refrig"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 248
        Me.Label2.Text = "Ingreso Refrig"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(222, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 245
        Me.Label7.Text = "Hora Salida"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 244
        Me.Label6.Text = "Hora Ingreso"
        '
        'cmbDias
        '
        Me.cmbDias.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbDias_DesignTimeLayout.LayoutString = resources.GetString("cmbDias_DesignTimeLayout.LayoutString")
        Me.cmbDias.DesignTimeLayout = cmbDias_DesignTimeLayout
        Me.cmbDias.Location = New System.Drawing.Point(103, 22)
        Me.cmbDias.Name = "cmbDias"
        Me.cmbDias.SelectedIndex = -1
        Me.cmbDias.SelectedItem = Nothing
        Me.cmbDias.Size = New System.Drawing.Size(98, 20)
        Me.cmbDias.TabIndex = 1
        Me.cmbDias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtHoraIngreso
        '
        Me.txtHoraIngreso.Location = New System.Drawing.Point(103, 51)
        Me.txtHoraIngreso.Mask = "00:00"
        Me.txtHoraIngreso.Name = "txtHoraIngreso"
        Me.txtHoraIngreso.Size = New System.Drawing.Size(88, 20)
        Me.txtHoraIngreso.TabIndex = 2
        '
        'txtSalidaRefrig
        '
        Me.txtSalidaRefrig.Location = New System.Drawing.Point(103, 80)
        Me.txtSalidaRefrig.Mask = "00:00"
        Me.txtSalidaRefrig.Name = "txtSalidaRefrig"
        Me.txtSalidaRefrig.Size = New System.Drawing.Size(88, 20)
        Me.txtSalidaRefrig.TabIndex = 4
        '
        'txtHoraSalida
        '
        Me.txtHoraSalida.Location = New System.Drawing.Point(301, 51)
        Me.txtHoraSalida.Mask = "00:00"
        Me.txtHoraSalida.Name = "txtHoraSalida"
        Me.txtHoraSalida.Size = New System.Drawing.Size(88, 20)
        Me.txtHoraSalida.TabIndex = 3
        '
        'txtIngresoRefrig
        '
        Me.txtIngresoRefrig.Location = New System.Drawing.Point(301, 80)
        Me.txtIngresoRefrig.Mask = "00:00"
        Me.txtIngresoRefrig.Name = "txtIngresoRefrig"
        Me.txtIngresoRefrig.Size = New System.Drawing.Size(88, 20)
        Me.txtIngresoRefrig.TabIndex = 5
        '
        'frmHorario_Detalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(420, 159)
        Me.Controls.Add(Me.gbDatosDetalle)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHorario_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Horario"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosDetalle.ResumeLayout(False)
        Me.gbDatosDetalle.PerformLayout()
        CType(Me.cmbDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbDias As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIngresoRefrig As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHoraSalida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSalidaRefrig As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHoraIngreso As System.Windows.Forms.MaskedTextBox
End Class
