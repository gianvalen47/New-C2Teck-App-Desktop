<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvaluacion_Detalle
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
        Dim cmbNivel_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCompetencia_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvaluacion_Detalle))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblDesNivel = New System.Windows.Forms.Label()
        Me.lblDesCompetencia = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCompromiso = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbNivel = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPuntaje = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtRecomendacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCompetencia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.cmbNivel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCompetencia, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnCancelar.Location = New System.Drawing.Point(223, 287)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 9
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
        Me.btnGuardar.Location = New System.Drawing.Point(139, 287)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.lblDesNivel)
        Me.gbDetalle.Controls.Add(Me.lblDesCompetencia)
        Me.gbDetalle.Controls.Add(Me.Label4)
        Me.gbDetalle.Controls.Add(Me.txtCompromiso)
        Me.gbDetalle.Controls.Add(Me.Label3)
        Me.gbDetalle.Controls.Add(Me.cmbNivel)
        Me.gbDetalle.Controls.Add(Me.Label8)
        Me.gbDetalle.Controls.Add(Me.Label9)
        Me.gbDetalle.Controls.Add(Me.txtPuntaje)
        Me.gbDetalle.Controls.Add(Me.txtRecomendacion)
        Me.gbDetalle.Controls.Add(Me.Label1)
        Me.gbDetalle.Controls.Add(Me.cmbCompetencia)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(9, 4)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(423, 276)
        Me.gbDetalle.TabIndex = 0
        Me.gbDetalle.Text = "Detalle"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblDesNivel
        '
        Me.lblDesNivel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesNivel.ForeColor = System.Drawing.Color.Navy
        Me.lblDesNivel.Location = New System.Drawing.Point(28, 128)
        Me.lblDesNivel.Name = "lblDesNivel"
        Me.lblDesNivel.Size = New System.Drawing.Size(378, 30)
        Me.lblDesNivel.TabIndex = 5
        Me.lblDesNivel.Text = "*"
        '
        'lblDesCompetencia
        '
        Me.lblDesCompetencia.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCompetencia.ForeColor = System.Drawing.Color.Navy
        Me.lblDesCompetencia.Location = New System.Drawing.Point(28, 43)
        Me.lblDesCompetencia.Name = "lblDesCompetencia"
        Me.lblDesCompetencia.Size = New System.Drawing.Size(378, 49)
        Me.lblDesCompetencia.TabIndex = 2
        Me.lblDesCompetencia.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 237)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 361
        Me.Label4.Text = "Compromiso"
        '
        'txtCompromiso
        '
        Me.txtCompromiso.Location = New System.Drawing.Point(114, 221)
        Me.txtCompromiso.Multiline = True
        Me.txtCompromiso.Name = "txtCompromiso"
        Me.txtCompromiso.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCompromiso.Size = New System.Drawing.Size(298, 45)
        Me.txtCompromiso.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(72, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 359
        Me.Label3.Text = "Nivel"
        '
        'cmbNivel
        '
        Me.cmbNivel.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbNivel_DesignTimeLayout.LayoutString = resources.GetString("cmbNivel_DesignTimeLayout.LayoutString")
        Me.cmbNivel.DesignTimeLayout = cmbNivel_DesignTimeLayout
        Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivel.Location = New System.Drawing.Point(114, 105)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.SelectedIndex = -1
        Me.cmbNivel.SelectedItem = Nothing
        Me.cmbNivel.Size = New System.Drawing.Size(103, 20)
        Me.cmbNivel.TabIndex = 3
        Me.cmbNivel.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(245, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 355
        Me.Label8.Text = "Puntaje"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 249
        Me.Label9.Text = "Recomendación"
        '
        'txtPuntaje
        '
        Me.txtPuntaje.BackColor = System.Drawing.SystemColors.Control
        Me.txtPuntaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuntaje.Location = New System.Drawing.Point(301, 105)
        Me.txtPuntaje.MaxLength = 10
        Me.txtPuntaje.Name = "txtPuntaje"
        Me.txtPuntaje.ReadOnly = True
        Me.txtPuntaje.Size = New System.Drawing.Size(57, 20)
        Me.txtPuntaje.TabIndex = 4
        Me.txtPuntaje.TabStop = False
        Me.txtPuntaje.Text = "0"
        Me.txtPuntaje.Value = 0
        Me.txtPuntaje.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtPuntaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtRecomendacion
        '
        Me.txtRecomendacion.Location = New System.Drawing.Point(114, 170)
        Me.txtRecomendacion.Multiline = True
        Me.txtRecomendacion.Name = "txtRecomendacion"
        Me.txtRecomendacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRecomendacion.Size = New System.Drawing.Size(298, 45)
        Me.txtRecomendacion.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 353
        Me.Label1.Text = "Competencia"
        '
        'cmbCompetencia
        '
        Me.cmbCompetencia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCompetencia_DesignTimeLayout.LayoutString = resources.GetString("cmbCompetencia_DesignTimeLayout.LayoutString")
        Me.cmbCompetencia.DesignTimeLayout = cmbCompetencia_DesignTimeLayout
        Me.cmbCompetencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompetencia.Location = New System.Drawing.Point(114, 20)
        Me.cmbCompetencia.Name = "cmbCompetencia"
        Me.cmbCompetencia.SelectedIndex = -1
        Me.cmbCompetencia.SelectedItem = Nothing
        Me.cmbCompetencia.Size = New System.Drawing.Size(252, 20)
        Me.cmbCompetencia.TabIndex = 1
        Me.cmbCompetencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmEvaluacion_Detalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(459, 335)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEvaluacion_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Evaluacion de Colaborador"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        CType(Me.cmbNivel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCompetencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRecomendacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCompetencia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbNivel As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCompromiso As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPuntaje As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblDesNivel As System.Windows.Forms.Label
    Friend WithEvents lblDesCompetencia As System.Windows.Forms.Label
End Class
