<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPunto
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
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPunto))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCodBarra = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.lblAstApeMat = New System.Windows.Forms.Label()
        Me.lblAstApePat = New System.Windows.Forms.Label()
        Me.lblApeMat = New System.Windows.Forms.Label()
        Me.lblApePat = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtDesPunto = New System.Windows.Forms.TextBox()
        Me.txtCodPunto = New System.Windows.Forms.TextBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator13, Me.btnGuardar, Me.ToolStripSeparator14, Me.btnEditar, Me.ToolStripSeparator15, Me.btnDeshacer, Me.ToolStripSeparator1, Me.btnCancelar, Me.ToolStripSeparator2})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(404, 31)
        Me.ToolStrip.TabIndex = 29
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'btnEditar
        '
        Me.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(28, 28)
        Me.btnEditar.Text = "Editar Datos"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'btnDeshacer
        '
        Me.btnDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.btnDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(28, 28)
        Me.btnCancelar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.txtCodBarra)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.cmbOficinas)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.cbVigente)
        Me.gbDatos.Controls.Add(Me.lblAstApeMat)
        Me.gbDatos.Controls.Add(Me.lblAstApePat)
        Me.gbDatos.Controls.Add(Me.lblApeMat)
        Me.gbDatos.Controls.Add(Me.lblApePat)
        Me.gbDatos.Controls.Add(Me.lblNombre)
        Me.gbDatos.Controls.Add(Me.txtDesPunto)
        Me.gbDatos.Controls.Add(Me.txtCodPunto)
        Me.gbDatos.Location = New System.Drawing.Point(10, 35)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(383, 168)
        Me.gbDatos.TabIndex = 31
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos de la Ruta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(77, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Cod. Barra"
        '
        'txtCodBarra
        '
        Me.txtCodBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodBarra.Location = New System.Drawing.Point(89, 107)
        Me.txtCodBarra.MaxLength = 50
        Me.txtCodBarra.Name = "txtCodBarra"
        Me.txtCodBarra.Size = New System.Drawing.Size(137, 20)
        Me.txtCodBarra.TabIndex = 69
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(77, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Vigente"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(89, 77)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(93, 20)
        Me.cmbOficinas.TabIndex = 9
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(259, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "* Campos Obligatorios"
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.Location = New System.Drawing.Point(89, 140)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(15, 14)
        Me.cbVigente.TabIndex = 10
        Me.cbVigente.TabStop = False
        Me.cbVigente.UseVisualStyleBackColor = True
        '
        'lblAstApeMat
        '
        Me.lblAstApeMat.AutoSize = True
        Me.lblAstApeMat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstApeMat.ForeColor = System.Drawing.Color.Red
        Me.lblAstApeMat.Location = New System.Drawing.Point(77, 79)
        Me.lblAstApeMat.Name = "lblAstApeMat"
        Me.lblAstApeMat.Size = New System.Drawing.Size(12, 13)
        Me.lblAstApeMat.TabIndex = 63
        Me.lblAstApeMat.Text = "*"
        '
        'lblAstApePat
        '
        Me.lblAstApePat.AutoSize = True
        Me.lblAstApePat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstApePat.ForeColor = System.Drawing.Color.Red
        Me.lblAstApePat.Location = New System.Drawing.Point(77, 50)
        Me.lblAstApePat.Name = "lblAstApePat"
        Me.lblAstApePat.Size = New System.Drawing.Size(12, 13)
        Me.lblAstApePat.TabIndex = 62
        Me.lblAstApePat.Text = "*"
        '
        'lblApeMat
        '
        Me.lblApeMat.AutoSize = True
        Me.lblApeMat.Location = New System.Drawing.Point(34, 81)
        Me.lblApeMat.Name = "lblApeMat"
        Me.lblApeMat.Size = New System.Drawing.Size(40, 13)
        Me.lblApeMat.TabIndex = 42
        Me.lblApeMat.Text = "Oficina"
        '
        'lblApePat
        '
        Me.lblApePat.AutoSize = True
        Me.lblApePat.Location = New System.Drawing.Point(44, 50)
        Me.lblApePat.Name = "lblApePat"
        Me.lblApePat.Size = New System.Drawing.Size(35, 13)
        Me.lblApePat.TabIndex = 41
        Me.lblApePat.Text = "Punto"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(19, 21)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(60, 13)
        Me.lblNombre.TabIndex = 40
        Me.lblNombre.Text = "Cod. Punto"
        '
        'txtDesPunto
        '
        Me.txtDesPunto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesPunto.Location = New System.Drawing.Point(89, 47)
        Me.txtDesPunto.MaxLength = 50
        Me.txtDesPunto.Name = "txtDesPunto"
        Me.txtDesPunto.Size = New System.Drawing.Size(280, 20)
        Me.txtDesPunto.TabIndex = 8
        '
        'txtCodPunto
        '
        Me.txtCodPunto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodPunto.Location = New System.Drawing.Point(89, 18)
        Me.txtCodPunto.MaxLength = 5
        Me.txtCodPunto.Name = "txtCodPunto"
        Me.txtCodPunto.Size = New System.Drawing.Size(77, 20)
        Me.txtCodPunto.TabIndex = 5
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmPunto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(404, 213)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPunto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Punto"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbVigente As System.Windows.Forms.CheckBox
    Friend WithEvents lblAstApeMat As System.Windows.Forms.Label
    Friend WithEvents lblAstApePat As System.Windows.Forms.Label
    Friend WithEvents lblApeMat As System.Windows.Forms.Label
    Friend WithEvents lblApePat As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtDesPunto As System.Windows.Forms.TextBox
    Friend WithEvents txtCodPunto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCodBarra As System.Windows.Forms.TextBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
