<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteImport
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
        Dim cbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteImport))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox11 = New Janus.Windows.EditControls.UIGroupBox
        Me.rbResumen = New Janus.Windows.EditControls.UIRadioButton
        Me.rbRegistro = New Janus.Windows.EditControls.UIRadioButton
        Me.gbAlmacenes = New Janus.Windows.EditControls.UIGroupBox
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.cbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbPeriodo = New Janus.Windows.EditControls.UIGroupBox
        Me.gbNumero = New Janus.Windows.EditControls.UIGroupBox
        Me.txtNumero = New System.Windows.Forms.TextBox
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox11.SuspendLayout()
        CType(Me.gbAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAlmacenes.SuspendLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPeriodo.SuspendLayout()
        CType(Me.gbNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNumero.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox11
        '
        Me.UiGroupBox11.Controls.Add(Me.rbResumen)
        Me.UiGroupBox11.Controls.Add(Me.rbRegistro)
        Me.UiGroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox11.Location = New System.Drawing.Point(6, 2)
        Me.UiGroupBox11.Name = "UiGroupBox11"
        Me.UiGroupBox11.Size = New System.Drawing.Size(191, 61)
        Me.UiGroupBox11.TabIndex = 19
        Me.UiGroupBox11.Text = "Tipo de Reporte"
        Me.UiGroupBox11.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbResumen
        '
        Me.rbResumen.Location = New System.Drawing.Point(6, 38)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(76, 13)
        Me.rbResumen.TabIndex = 1
        Me.rbResumen.Text = "Resumen"
        Me.rbResumen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbRegistro
        '
        Me.rbRegistro.Checked = True
        Me.rbRegistro.Location = New System.Drawing.Point(6, 17)
        Me.rbRegistro.Name = "rbRegistro"
        Me.rbRegistro.Size = New System.Drawing.Size(179, 15)
        Me.rbRegistro.TabIndex = 0
        Me.rbRegistro.TabStop = True
        Me.rbRegistro.Text = "Registro de Importaciones"
        Me.rbRegistro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbAlmacenes
        '
        Me.gbAlmacenes.Controls.Add(Me.cbAlmacen)
        Me.gbAlmacenes.Controls.Add(Me.cbOficina)
        Me.gbAlmacenes.Controls.Add(Me.Label2)
        Me.gbAlmacenes.Controls.Add(Me.Label1)
        Me.gbAlmacenes.Location = New System.Drawing.Point(6, 130)
        Me.gbAlmacenes.Name = "gbAlmacenes"
        Me.gbAlmacenes.Size = New System.Drawing.Size(300, 62)
        Me.gbAlmacenes.TabIndex = 17
        Me.gbAlmacenes.Text = "Almacenes"
        Me.gbAlmacenes.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(58, 37)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(238, 20)
        Me.cbAlmacen.TabIndex = 3
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(58, 15)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(161, 20)
        Me.cbOficina.TabIndex = 2
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Almacen :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Oficina :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(124, 203)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(82, 27)
        Me.btnAceptar.TabIndex = 20
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(225, 203)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(82, 27)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cbMes
        '
        Me.cbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbMes_DesignTimeLayout.LayoutString = resources.GetString("cbMes_DesignTimeLayout.LayoutString")
        Me.cbMes.DesignTimeLayout = cbMes_DesignTimeLayout
        Me.cbMes.Location = New System.Drawing.Point(67, 32)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.SelectedIndex = -1
        Me.cbMes.SelectedItem = Nothing
        Me.cbMes.Size = New System.Drawing.Size(96, 20)
        Me.cbMes.TabIndex = 31
        Me.cbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(10, 32)
        Me.txtPeriodo.Maximum = 3000
        Me.txtPeriodo.Minimum = 2009
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(55, 20)
        Me.txtPeriodo.TabIndex = 30
        Me.txtPeriodo.UpDownStyle = Janus.Windows.GridEX.UpDownStyle.UpDownList
        Me.txtPeriodo.Value = 2009
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Año"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Mes"
        '
        'gbPeriodo
        '
        Me.gbPeriodo.Controls.Add(Me.Label4)
        Me.gbPeriodo.Controls.Add(Me.cbMes)
        Me.gbPeriodo.Controls.Add(Me.Label3)
        Me.gbPeriodo.Controls.Add(Me.txtPeriodo)
        Me.gbPeriodo.Location = New System.Drawing.Point(6, 68)
        Me.gbPeriodo.Name = "gbPeriodo"
        Me.gbPeriodo.Size = New System.Drawing.Size(171, 57)
        Me.gbPeriodo.TabIndex = 32
        Me.gbPeriodo.Text = "Periodo"
        Me.gbPeriodo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbNumero
        '
        Me.gbNumero.Controls.Add(Me.txtNumero)
        Me.gbNumero.Location = New System.Drawing.Point(182, 68)
        Me.gbNumero.Name = "gbNumero"
        Me.gbNumero.Size = New System.Drawing.Size(124, 57)
        Me.gbNumero.TabIndex = 33
        Me.gbNumero.Text = "Numero Factura"
        Me.gbNumero.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(8, 23)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(109, 20)
        Me.txtNumero.TabIndex = 0
        '
        'frmReporteImport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(313, 238)
        Me.Controls.Add(Me.gbNumero)
        Me.Controls.Add(Me.gbPeriodo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox11)
        Me.Controls.Add(Me.gbAlmacenes)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Importaciones"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox11.ResumeLayout(False)
        CType(Me.gbAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAlmacenes.ResumeLayout(False)
        Me.gbAlmacenes.PerformLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPeriodo.ResumeLayout(False)
        Me.gbPeriodo.PerformLayout()
        CType(Me.gbNumero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNumero.ResumeLayout(False)
        Me.gbNumero.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox11 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumen As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbRegistro As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbAlmacenes As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbPeriodo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbNumero As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
End Class
