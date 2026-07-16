<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVincularGuia
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
        Dim dgvDatosGuia_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosFactura_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVincularGuia))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvDatosGuia = New Janus.Windows.GridEX.GridEX()
        Me.txtNumGuia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarFactura = New System.Windows.Forms.Button()
        Me.txtNumFactura = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.dgvDatosFactura = New Janus.Windows.GridEX.GridEX()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnBuscarGuia = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatosGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvDatosFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvDatosGuia
        '
        Me.dgvDatosGuia.AllowCardSizing = False
        Me.dgvDatosGuia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvDatosGuia_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosGuia_DesignTimeLayout.LayoutString")
        Me.dgvDatosGuia.DesignTimeLayout = dgvDatosGuia_DesignTimeLayout
        Me.dgvDatosGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatosGuia.GroupByBoxVisible = False
        Me.dgvDatosGuia.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatosGuia.Location = New System.Drawing.Point(9, 111)
        Me.dgvDatosGuia.Name = "dgvDatosGuia"
        Me.dgvDatosGuia.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosGuia.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosGuia.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosGuia.Size = New System.Drawing.Size(597, 72)
        Me.dgvDatosGuia.TabIndex = 3
        Me.dgvDatosGuia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtNumGuia
        '
        Me.txtNumGuia.Location = New System.Drawing.Point(103, 16)
        Me.txtNumGuia.MaxLength = 30
        Me.txtNumGuia.Name = "txtNumGuia"
        Me.txtNumGuia.Size = New System.Drawing.Size(60, 20)
        Me.txtNumGuia.TabIndex = 19
        Me.txtNumGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "N° de Guía :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNumGuia)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(245, 43)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtanio)
        Me.GroupBox2.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox2.Controls.Add(Me.cmbOficinas)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(143, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(294, 56)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(236, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(235, 26)
        Me.txtanio.Maximum = 2059
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2006
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(48, 20)
        Me.txtanio.TabIndex = 23
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2006
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Location = New System.Drawing.Point(102, 26)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(129, 20)
        Me.cmbIdLocacion.TabIndex = 21
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(11, 26)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(86, 20)
        Me.cmbOficinas.TabIndex = 19
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(102, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Almacén"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Oficina"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnBuscarFactura)
        Me.GroupBox3.Controls.Add(Me.txtNumFactura)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 195)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(246, 43)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        '
        'btnBuscarFactura
        '
        Me.btnBuscarFactura.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarFactura.Location = New System.Drawing.Point(169, 14)
        Me.btnBuscarFactura.Name = "btnBuscarFactura"
        Me.btnBuscarFactura.Size = New System.Drawing.Size(67, 25)
        Me.btnBuscarFactura.TabIndex = 141
        Me.btnBuscarFactura.Text = "Buscar"
        Me.btnBuscarFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarFactura.UseVisualStyleBackColor = True
        '
        'txtNumFactura
        '
        Me.txtNumFactura.Location = New System.Drawing.Point(103, 16)
        Me.txtNumFactura.MaxLength = 30
        Me.txtNumFactura.Name = "txtNumFactura"
        Me.txtNumFactura.Size = New System.Drawing.Size(60, 20)
        Me.txtNumFactura.TabIndex = 19
        Me.txtNumFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "N° de Factura :"
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 428)
        Me.Splitter1.TabIndex = 23
        Me.Splitter1.TabStop = False
        '
        'dgvDatosFactura
        '
        Me.dgvDatosFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvDatosFactura_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosFactura_DesignTimeLayout.LayoutString")
        Me.dgvDatosFactura.DesignTimeLayout = dgvDatosFactura_DesignTimeLayout
        Me.dgvDatosFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatosFactura.GroupByBoxVisible = False
        Me.dgvDatosFactura.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatosFactura.Location = New System.Drawing.Point(8, 243)
        Me.dgvDatosFactura.Name = "dgvDatosFactura"
        Me.dgvDatosFactura.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosFactura.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosFactura.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosFactura.Size = New System.Drawing.Size(598, 71)
        Me.dgvDatosFactura.TabIndex = 24
        Me.dgvDatosFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(303, 326)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 27)
        Me.btnCancelar.TabIndex = 139
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(216, 326)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 138
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnBuscarGuia
        '
        Me.btnBuscarGuia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarGuia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarGuia.Location = New System.Drawing.Point(179, 77)
        Me.btnBuscarGuia.Name = "btnBuscarGuia"
        Me.btnBuscarGuia.Size = New System.Drawing.Size(67, 25)
        Me.btnBuscarGuia.TabIndex = 140
        Me.btnBuscarGuia.Text = "Buscar"
        Me.btnBuscarGuia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarGuia.UseVisualStyleBackColor = True
        '
        'frmVincularGuia
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(637, 428)
        Me.Controls.Add(Me.btnBuscarGuia)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvDatosFactura)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDatosGuia)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVincularGuia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vincular Guía"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatosGuia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvDatosFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvDatosGuia As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtNumGuia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvDatosFactura As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarFactura As System.Windows.Forms.Button
    Friend WithEvents btnBuscarGuia As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
End Class
