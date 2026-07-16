<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPuntoRuta
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
        Dim cmbRuta_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPuntoRuta))
        Dim cmbPunto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
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
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.cmbRuta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbPunto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAstApeMat = New System.Windows.Forms.Label()
        Me.lblAstApePat = New System.Windows.Forms.Label()
        Me.lblAstNombre = New System.Windows.Forms.Label()
        Me.lblCant = New System.Windows.Forms.Label()
        Me.lblApePat = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPunto, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip.Size = New System.Drawing.Size(318, 31)
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.cmbRuta)
        Me.gbDatos.Controls.Add(Me.cmbPunto)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.lblAstApeMat)
        Me.gbDatos.Controls.Add(Me.lblAstApePat)
        Me.gbDatos.Controls.Add(Me.lblAstNombre)
        Me.gbDatos.Controls.Add(Me.lblCant)
        Me.gbDatos.Controls.Add(Me.lblApePat)
        Me.gbDatos.Controls.Add(Me.lblNombre)
        Me.gbDatos.Controls.Add(Me.txtOrden)
        Me.gbDatos.Location = New System.Drawing.Point(10, 33)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(298, 118)
        Me.gbDatos.TabIndex = 31
        Me.gbDatos.TabStop = False
        '
        'cmbRuta
        '
        Me.cmbRuta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRuta_DesignTimeLayout.LayoutString = resources.GetString("cmbRuta_DesignTimeLayout.LayoutString")
        Me.cmbRuta.DesignTimeLayout = cmbRuta_DesignTimeLayout
        Me.cmbRuta.Location = New System.Drawing.Point(89, 18)
        Me.cmbRuta.Name = "cmbRuta"
        Me.cmbRuta.SelectedIndex = -1
        Me.cmbRuta.SelectedItem = Nothing
        Me.cmbRuta.Size = New System.Drawing.Size(187, 20)
        Me.cmbRuta.TabIndex = 69
        Me.cmbRuta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbPunto
        '
        Me.cmbPunto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPunto_DesignTimeLayout.LayoutString = resources.GetString("cmbPunto_DesignTimeLayout.LayoutString")
        Me.cmbPunto.DesignTimeLayout = cmbPunto_DesignTimeLayout
        Me.cmbPunto.Location = New System.Drawing.Point(89, 47)
        Me.cmbPunto.Name = "cmbPunto"
        Me.cmbPunto.SelectedIndex = -1
        Me.cmbPunto.SelectedItem = Nothing
        Me.cmbPunto.Size = New System.Drawing.Size(187, 20)
        Me.cmbPunto.TabIndex = 66
        Me.cmbPunto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(166, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "* Campos Obligatorios"
        '
        'lblAstApeMat
        '
        Me.lblAstApeMat.AutoSize = True
        Me.lblAstApeMat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstApeMat.ForeColor = System.Drawing.Color.Red
        Me.lblAstApeMat.Location = New System.Drawing.Point(77, 82)
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
        Me.lblAstApePat.Location = New System.Drawing.Point(77, 21)
        Me.lblAstApePat.Name = "lblAstApePat"
        Me.lblAstApePat.Size = New System.Drawing.Size(12, 13)
        Me.lblAstApePat.TabIndex = 62
        Me.lblAstApePat.Text = "*"
        '
        'lblAstNombre
        '
        Me.lblAstNombre.AutoSize = True
        Me.lblAstNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstNombre.ForeColor = System.Drawing.Color.Red
        Me.lblAstNombre.Location = New System.Drawing.Point(77, 52)
        Me.lblAstNombre.Name = "lblAstNombre"
        Me.lblAstNombre.Size = New System.Drawing.Size(12, 13)
        Me.lblAstNombre.TabIndex = 46
        Me.lblAstNombre.Text = "*"
        '
        'lblCant
        '
        Me.lblCant.AutoSize = True
        Me.lblCant.Location = New System.Drawing.Point(12, 81)
        Me.lblCant.Name = "lblCant"
        Me.lblCant.Size = New System.Drawing.Size(36, 13)
        Me.lblCant.TabIndex = 42
        Me.lblCant.Text = "Orden"
        '
        'lblApePat
        '
        Me.lblApePat.AutoSize = True
        Me.lblApePat.Location = New System.Drawing.Point(12, 19)
        Me.lblApePat.Name = "lblApePat"
        Me.lblApePat.Size = New System.Drawing.Size(30, 13)
        Me.lblApePat.TabIndex = 41
        Me.lblApePat.Text = "Ruta"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(10, 51)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(35, 13)
        Me.lblNombre.TabIndex = 40
        Me.lblNombre.Text = "Punto"
        '
        'txtOrden
        '
        Me.txtOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrden.Location = New System.Drawing.Point(89, 76)
        Me.txtOrden.MaxLength = 50
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(54, 20)
        Me.txtOrden.TabIndex = 7
        '
        'frmPuntoRuta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(318, 161)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPuntoRuta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Puntos Ruta"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbRuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPunto, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbRuta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbPunto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAstApeMat As System.Windows.Forms.Label
    Friend WithEvents lblAstApePat As System.Windows.Forms.Label
    Friend WithEvents lblAstNombre As System.Windows.Forms.Label
    Friend WithEvents lblCant As System.Windows.Forms.Label
    Friend WithEvents lblApePat As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
End Class
