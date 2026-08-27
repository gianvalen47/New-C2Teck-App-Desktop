<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarUbigeo
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
        Dim cmbdistritos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarUbigeo))
        Dim cmbprovincias_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbdepartamentos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.cmbdistritos = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbprovincias = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbdepartamentos = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbdistritos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbprovincias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbdepartamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.cmbdistritos)
        Me.gbDatos.Controls.Add(Me.cmbprovincias)
        Me.gbDatos.Controls.Add(Me.cmbdepartamentos)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Location = New System.Drawing.Point(5, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(371, 91)
        Me.gbDatos.TabIndex = 4
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos Ubicacion del Cliente"
        '
        'cmbdistritos
        '
        Me.cmbdistritos.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbdistritos_DesignTimeLayout.LayoutString = resources.GetString("cmbdistritos_DesignTimeLayout.LayoutString")
        Me.cmbdistritos.DesignTimeLayout = cmbdistritos_DesignTimeLayout
        Me.cmbdistritos.Location = New System.Drawing.Point(96, 62)
        Me.cmbdistritos.Name = "cmbdistritos"
        Me.cmbdistritos.SelectedIndex = -1
        Me.cmbdistritos.SelectedItem = Nothing
        Me.cmbdistritos.Size = New System.Drawing.Size(209, 20)
        Me.cmbdistritos.TabIndex = 3
        Me.cmbdistritos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbprovincias
        '
        Me.cmbprovincias.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbprovincias_DesignTimeLayout.LayoutString = resources.GetString("cmbprovincias_DesignTimeLayout.LayoutString")
        Me.cmbprovincias.DesignTimeLayout = cmbprovincias_DesignTimeLayout
        Me.cmbprovincias.Location = New System.Drawing.Point(96, 40)
        Me.cmbprovincias.Name = "cmbprovincias"
        Me.cmbprovincias.SelectedIndex = -1
        Me.cmbprovincias.SelectedItem = Nothing
        Me.cmbprovincias.Size = New System.Drawing.Size(209, 20)
        Me.cmbprovincias.TabIndex = 2
        Me.cmbprovincias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbdepartamentos
        '
        Me.cmbdepartamentos.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbdepartamentos_DesignTimeLayout.LayoutString = resources.GetString("cmbdepartamentos_DesignTimeLayout.LayoutString")
        Me.cmbdepartamentos.DesignTimeLayout = cmbdepartamentos_DesignTimeLayout
        Me.cmbdepartamentos.Location = New System.Drawing.Point(96, 18)
        Me.cmbdepartamentos.Name = "cmbdepartamentos"
        Me.cmbdepartamentos.SelectedIndex = -1
        Me.cmbdepartamentos.SelectedItem = Nothing
        Me.cmbdepartamentos.Size = New System.Drawing.Size(209, 20)
        Me.cmbdepartamentos.TabIndex = 1
        Me.cmbdepartamentos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Distrito"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Provincia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Departamento"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(301, 99)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(224, 99)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(73, 25)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmBuscarUbigeo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(384, 132)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarUbigeo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar  Ubigeo"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbdistritos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbprovincias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbdepartamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbdistritos As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbprovincias As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbdepartamentos As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
