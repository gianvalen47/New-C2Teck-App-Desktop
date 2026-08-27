<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUbicacion
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
        Dim cmbLado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUbicacion))
        Dim cmbCelda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbNivel_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstante_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosCargo = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbLado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCelda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbNivel = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtCodUbicacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbEstante = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosCargo.SuspendLayout()
        CType(Me.cmbLado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCelda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbNivel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosCargo
        '
        Me.gbDatosCargo.Controls.Add(Me.Label6)
        Me.gbDatosCargo.Controls.Add(Me.txtObservacion)
        Me.gbDatosCargo.Controls.Add(Me.Label5)
        Me.gbDatosCargo.Controls.Add(Me.cmbLado)
        Me.gbDatosCargo.Controls.Add(Me.Label3)
        Me.gbDatosCargo.Controls.Add(Me.cmbCelda)
        Me.gbDatosCargo.Controls.Add(Me.Label2)
        Me.gbDatosCargo.Controls.Add(Me.cmbNivel)
        Me.gbDatosCargo.Controls.Add(Me.txtCodUbicacion)
        Me.gbDatosCargo.Controls.Add(Me.Label1)
        Me.gbDatosCargo.Controls.Add(Me.Label4)
        Me.gbDatosCargo.Controls.Add(Me.cmbEstante)
        Me.gbDatosCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosCargo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gbDatosCargo.Location = New System.Drawing.Point(10, 6)
        Me.gbDatosCargo.Name = "gbDatosCargo"
        Me.gbDatosCargo.Size = New System.Drawing.Size(364, 150)
        Me.gbDatosCargo.TabIndex = 1
        Me.gbDatosCargo.Text = "Datos de Ubicación de Mercadería"
        Me.gbDatosCargo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 263
        Me.Label6.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(93, 104)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(259, 35)
        Me.txtObservacion.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(241, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 261
        Me.Label5.Text = "Lado"
        '
        'cmbLado
        '
        Me.cmbLado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbLado_DesignTimeLayout.LayoutString = resources.GetString("cmbLado_DesignTimeLayout.LayoutString")
        Me.cmbLado.DesignTimeLayout = cmbLado_DesignTimeLayout
        Me.cmbLado.Location = New System.Drawing.Point(282, 76)
        Me.cmbLado.Name = "cmbLado"
        Me.cmbLado.SelectedIndex = -1
        Me.cmbLado.SelectedItem = Nothing
        Me.cmbLado.Size = New System.Drawing.Size(70, 20)
        Me.cmbLado.TabIndex = 5
        Me.cmbLado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 259
        Me.Label3.Text = "Celda"
        '
        'cmbCelda
        '
        Me.cmbCelda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCelda_DesignTimeLayout.LayoutString = resources.GetString("cmbCelda_DesignTimeLayout.LayoutString")
        Me.cmbCelda.DesignTimeLayout = cmbCelda_DesignTimeLayout
        Me.cmbCelda.Location = New System.Drawing.Point(93, 76)
        Me.cmbCelda.Name = "cmbCelda"
        Me.cmbCelda.SelectedIndex = -1
        Me.cmbCelda.SelectedItem = Nothing
        Me.cmbCelda.Size = New System.Drawing.Size(70, 20)
        Me.cmbCelda.TabIndex = 4
        Me.cmbCelda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 257
        Me.Label2.Text = "Nivel"
        '
        'cmbNivel
        '
        Me.cmbNivel.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbNivel_DesignTimeLayout.LayoutString = resources.GetString("cmbNivel_DesignTimeLayout.LayoutString")
        Me.cmbNivel.DesignTimeLayout = cmbNivel_DesignTimeLayout
        Me.cmbNivel.Location = New System.Drawing.Point(282, 48)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.SelectedIndex = -1
        Me.cmbNivel.SelectedItem = Nothing
        Me.cmbNivel.Size = New System.Drawing.Size(70, 20)
        Me.cmbNivel.TabIndex = 3
        Me.cmbNivel.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCodUbicacion
        '
        Me.txtCodUbicacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodUbicacion.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodUbicacion.Location = New System.Drawing.Point(93, 20)
        Me.txtCodUbicacion.Name = "txtCodUbicacion"
        Me.txtCodUbicacion.Size = New System.Drawing.Size(134, 20)
        Me.txtCodUbicacion.TabIndex = 1
        Me.txtCodUbicacion.TabStop = False
        Me.txtCodUbicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Estante"
        '
        'cmbEstante
        '
        Me.cmbEstante.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstante_DesignTimeLayout.LayoutString = resources.GetString("cmbEstante_DesignTimeLayout.LayoutString")
        Me.cmbEstante.DesignTimeLayout = cmbEstante_DesignTimeLayout
        Me.cmbEstante.Location = New System.Drawing.Point(93, 48)
        Me.cmbEstante.Name = "cmbEstante"
        Me.cmbEstante.SelectedIndex = -1
        Me.cmbEstante.SelectedItem = Nothing
        Me.cmbEstante.Size = New System.Drawing.Size(115, 20)
        Me.cmbEstante.TabIndex = 2
        Me.cmbEstante.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(195, 163)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 28)
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
        Me.btnGuardar.Location = New System.Drawing.Point(111, 163)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 28)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmUbicacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(385, 199)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatosCargo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUbicacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ubicación de Mercadería"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosCargo.ResumeLayout(False)
        Me.gbDatosCargo.PerformLayout()
        CType(Me.cmbLado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCelda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbNivel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosCargo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCodUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbEstante As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbLado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCelda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbNivel As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
End Class
