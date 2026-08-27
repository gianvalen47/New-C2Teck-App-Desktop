<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCostoMotores
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
        Dim cbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCostoMotores))
        Dim cbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbKardex = New System.Windows.Forms.RadioButton()
        Me.rbMotVend = New System.Windows.Forms.RadioButton()
        Me.rbCosAdi = New System.Windows.Forms.RadioButton()
        Me.rbAccesVen = New System.Windows.Forms.RadioButton()
        Me.rbKardexMotVen = New System.Windows.Forms.RadioButton()
        Me.lblSerieMot = New System.Windows.Forms.Label()
        Me.txtSerieMot = New System.Windows.Forms.TextBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.gbCosAdi = New System.Windows.Forms.GroupBox()
        Me.rbStock = New System.Windows.Forms.RadioButton()
        Me.rbVendidos = New System.Windows.Forms.RadioButton()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnBuscarMercaderiaOrigen = New System.Windows.Forms.Button()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCosAdi.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(73, 36)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(238, 20)
        Me.cbAlmacen.TabIndex = 2
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(73, 14)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(161, 20)
        Me.cbOficina.TabIndex = 1
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Almacén :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Oficina :"
        '
        'rbKardex
        '
        Me.rbKardex.AutoSize = True
        Me.rbKardex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbKardex.Location = New System.Drawing.Point(15, 75)
        Me.rbKardex.Name = "rbKardex"
        Me.rbKardex.Size = New System.Drawing.Size(64, 19)
        Me.rbKardex.TabIndex = 6
        Me.rbKardex.Text = "Kardex"
        Me.rbKardex.UseVisualStyleBackColor = True
        '
        'rbMotVend
        '
        Me.rbMotVend.AutoSize = True
        Me.rbMotVend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMotVend.Location = New System.Drawing.Point(15, 98)
        Me.rbMotVend.Name = "rbMotVend"
        Me.rbMotVend.Size = New System.Drawing.Size(124, 19)
        Me.rbMotVend.TabIndex = 7
        Me.rbMotVend.Text = "Motores Vendidos"
        Me.rbMotVend.UseVisualStyleBackColor = True
        '
        'rbCosAdi
        '
        Me.rbCosAdi.AutoSize = True
        Me.rbCosAdi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCosAdi.Location = New System.Drawing.Point(15, 121)
        Me.rbCosAdi.Name = "rbCosAdi"
        Me.rbCosAdi.Size = New System.Drawing.Size(109, 19)
        Me.rbCosAdi.TabIndex = 8
        Me.rbCosAdi.Text = "Costo Adicional"
        Me.rbCosAdi.UseVisualStyleBackColor = True
        '
        'rbAccesVen
        '
        Me.rbAccesVen.AutoSize = True
        Me.rbAccesVen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAccesVen.Location = New System.Drawing.Point(15, 144)
        Me.rbAccesVen.Name = "rbAccesVen"
        Me.rbAccesVen.Size = New System.Drawing.Size(138, 19)
        Me.rbAccesVen.TabIndex = 9
        Me.rbAccesVen.Text = "Accesorios Vendidos"
        Me.rbAccesVen.UseVisualStyleBackColor = True
        '
        'rbKardexMotVen
        '
        Me.rbKardexMotVen.AutoSize = True
        Me.rbKardexMotVen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbKardexMotVen.Location = New System.Drawing.Point(15, 167)
        Me.rbKardexMotVen.Name = "rbKardexMotVen"
        Me.rbKardexMotVen.Size = New System.Drawing.Size(147, 19)
        Me.rbKardexMotVen.TabIndex = 10
        Me.rbKardexMotVen.Text = "Kardex Motor Vendido"
        Me.rbKardexMotVen.UseVisualStyleBackColor = True
        '
        'lblSerieMot
        '
        Me.lblSerieMot.AutoSize = True
        Me.lblSerieMot.Enabled = False
        Me.lblSerieMot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerieMot.Location = New System.Drawing.Point(158, 78)
        Me.lblSerieMot.Name = "lblSerieMot"
        Me.lblSerieMot.Size = New System.Drawing.Size(71, 15)
        Me.lblSerieMot.TabIndex = 11
        Me.lblSerieMot.Text = "S/N Motor : "
        '
        'txtSerieMot
        '
        Me.txtSerieMot.Enabled = False
        Me.txtSerieMot.Location = New System.Drawing.Point(230, 75)
        Me.txtSerieMot.Name = "txtSerieMot"
        Me.txtSerieMot.Size = New System.Drawing.Size(110, 20)
        Me.txtSerieMot.TabIndex = 3
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(6, 12)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(59, 19)
        Me.rbTodos.TabIndex = 13
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'gbCosAdi
        '
        Me.gbCosAdi.Controls.Add(Me.rbStock)
        Me.gbCosAdi.Controls.Add(Me.rbVendidos)
        Me.gbCosAdi.Controls.Add(Me.rbTodos)
        Me.gbCosAdi.Enabled = False
        Me.gbCosAdi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCosAdi.Location = New System.Drawing.Point(235, 113)
        Me.gbCosAdi.Name = "gbCosAdi"
        Me.gbCosAdi.Size = New System.Drawing.Size(119, 73)
        Me.gbCosAdi.TabIndex = 14
        Me.gbCosAdi.TabStop = False
        '
        'rbStock
        '
        Me.rbStock.AutoSize = True
        Me.rbStock.Location = New System.Drawing.Point(6, 47)
        Me.rbStock.Name = "rbStock"
        Me.rbStock.Size = New System.Drawing.Size(103, 19)
        Me.rbStock.TabIndex = 15
        Me.rbStock.TabStop = True
        Me.rbStock.Text = "Vendido Antes"
        Me.rbStock.UseVisualStyleBackColor = True
        '
        'rbVendidos
        '
        Me.rbVendidos.AutoSize = True
        Me.rbVendidos.Location = New System.Drawing.Point(6, 29)
        Me.rbVendidos.Name = "rbVendidos"
        Me.rbVendidos.Size = New System.Drawing.Size(76, 19)
        Me.rbVendidos.TabIndex = 14
        Me.rbVendidos.TabStop = True
        Me.rbVendidos.Text = "Vendidos"
        Me.rbVendidos.UseVisualStyleBackColor = True
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Location = New System.Drawing.Point(173, 202)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(88, 20)
        Me.cbFecFinal.TabIndex = 18
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Location = New System.Drawing.Point(52, 201)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(90, 20)
        Me.cbFecInicio.TabIndex = 17
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(146, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Al :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Del :"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(273, 235)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 28)
        Me.btnCancelar.TabIndex = 20
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(179, 235)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 28)
        Me.btnAceptar.TabIndex = 19
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnBuscarMercaderiaOrigen
        '
        Me.btnBuscarMercaderiaOrigen.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderiaOrigen.Location = New System.Drawing.Point(340, 74)
        Me.btnBuscarMercaderiaOrigen.Name = "btnBuscarMercaderiaOrigen"
        Me.btnBuscarMercaderiaOrigen.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderiaOrigen.TabIndex = 21
        Me.btnBuscarMercaderiaOrigen.TabStop = False
        Me.btnBuscarMercaderiaOrigen.UseVisualStyleBackColor = True
        '
        'frmRepCostoMotores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 277)
        Me.Controls.Add(Me.btnBuscarMercaderiaOrigen)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cbFecFinal)
        Me.Controls.Add(Me.cbFecInicio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbCosAdi)
        Me.Controls.Add(Me.txtSerieMot)
        Me.Controls.Add(Me.lblSerieMot)
        Me.Controls.Add(Me.rbKardexMotVen)
        Me.Controls.Add(Me.rbAccesVen)
        Me.Controls.Add(Me.rbCosAdi)
        Me.Controls.Add(Me.rbMotVend)
        Me.Controls.Add(Me.rbKardex)
        Me.Controls.Add(Me.cbAlmacen)
        Me.Controls.Add(Me.cbOficina)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepCostoMotores"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Motores "
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCosAdi.ResumeLayout(False)
        Me.gbCosAdi.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbKardexMotVen As System.Windows.Forms.RadioButton
    Friend WithEvents rbAccesVen As System.Windows.Forms.RadioButton
    Friend WithEvents rbCosAdi As System.Windows.Forms.RadioButton
    Friend WithEvents rbMotVend As System.Windows.Forms.RadioButton
    Friend WithEvents rbKardex As System.Windows.Forms.RadioButton
    Friend WithEvents gbCosAdi As System.Windows.Forms.GroupBox
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents txtSerieMot As System.Windows.Forms.TextBox
    Friend WithEvents lblSerieMot As System.Windows.Forms.Label
    Friend WithEvents rbStock As System.Windows.Forms.RadioButton
    Friend WithEvents rbVendidos As System.Windows.Forms.RadioButton
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarMercaderiaOrigen As System.Windows.Forms.Button
End Class
