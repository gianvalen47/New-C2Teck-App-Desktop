<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepGerImportaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepGerImportaciones))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rb0111 = New System.Windows.Forms.RadioButton()
        Me.rb0112 = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rb0113 = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rb0114 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnConsolidado = New System.Windows.Forms.Button()
        Me.btnConsolidado1 = New System.Windows.Forms.Button()
        Me.btnConsolidado2 = New System.Windows.Forms.Button()
        Me.btnConsolidado3 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cbMarcaAgua = New System.Windows.Forms.CheckBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(109, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 16)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Reporte Gerencial 011-2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(109, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Reporte Gerencial 011-1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(113, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 22)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "IMPORTACIONES"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(271, 21)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 23
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(107, 21)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 22
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(238, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Al :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Fechas Del :"
        '
        'rb0111
        '
        Me.rb0111.AutoSize = True
        Me.rb0111.Checked = True
        Me.rb0111.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb0111.Location = New System.Drawing.Point(112, 117)
        Me.rb0111.Name = "rb0111"
        Me.rb0111.Size = New System.Drawing.Size(191, 20)
        Me.rb0111.TabIndex = 31
        Me.rb0111.TabStop = True
        Me.rb0111.Text = "Resumen de Importaciones"
        Me.rb0111.UseVisualStyleBackColor = True
        '
        'rb0112
        '
        Me.rb0112.AutoSize = True
        Me.rb0112.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb0112.Location = New System.Drawing.Point(112, 166)
        Me.rb0112.Name = "rb0112"
        Me.rb0112.Size = New System.Drawing.Size(176, 20)
        Me.rb0112.TabIndex = 32
        Me.rb0112.Text = "Detalle de Importaciones"
        Me.rb0112.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(208, 289)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 36
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(112, 289)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptar.TabIndex = 35
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'rb0113
        '
        Me.rb0113.AutoSize = True
        Me.rb0113.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb0113.Location = New System.Drawing.Point(112, 211)
        Me.rb0113.Name = "rb0113"
        Me.rb0113.Size = New System.Drawing.Size(169, 20)
        Me.rb0113.TabIndex = 33
        Me.rb0113.Text = "Pedidos de Importación"
        Me.rb0113.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(109, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 16)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Reporte Gerencial 011-3"
        '
        'rb0114
        '
        Me.rb0114.AutoSize = True
        Me.rb0114.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb0114.Location = New System.Drawing.Point(63, 258)
        Me.rb0114.Name = "rb0114"
        Me.rb0114.Size = New System.Drawing.Size(284, 20)
        Me.rb0114.TabIndex = 34
        Me.rb0114.Text = "Resumen de Importaciones  por Proveedor"
        Me.rb0114.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(109, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 16)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Reporte Gerencial 011-4"
        '
        'btnConsolidado
        '
        Me.btnConsolidado.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado.Location = New System.Drawing.Point(309, 95)
        Me.btnConsolidado.Name = "btnConsolidado"
        Me.btnConsolidado.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado.TabIndex = 38
        Me.btnConsolidado.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado.UseVisualStyleBackColor = True
        '
        'btnConsolidado1
        '
        Me.btnConsolidado1.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado1.Location = New System.Drawing.Point(309, 140)
        Me.btnConsolidado1.Name = "btnConsolidado1"
        Me.btnConsolidado1.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado1.TabIndex = 39
        Me.btnConsolidado1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado1, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado1.UseVisualStyleBackColor = True
        '
        'btnConsolidado2
        '
        Me.btnConsolidado2.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado2.Location = New System.Drawing.Point(309, 185)
        Me.btnConsolidado2.Name = "btnConsolidado2"
        Me.btnConsolidado2.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado2.TabIndex = 40
        Me.btnConsolidado2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado2, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado2.UseVisualStyleBackColor = True
        '
        'btnConsolidado3
        '
        Me.btnConsolidado3.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado3.Location = New System.Drawing.Point(309, 231)
        Me.btnConsolidado3.Name = "btnConsolidado3"
        Me.btnConsolidado3.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado3.TabIndex = 41
        Me.btnConsolidado3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado3, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado3.UseVisualStyleBackColor = True
        '
        'cbMarcaAgua
        '
        Me.cbMarcaAgua.AutoSize = True
        Me.cbMarcaAgua.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMarcaAgua.Location = New System.Drawing.Point(290, 71)
        Me.cbMarcaAgua.Name = "cbMarcaAgua"
        Me.cbMarcaAgua.Size = New System.Drawing.Size(112, 17)
        Me.cbMarcaAgua.TabIndex = 196
        Me.cbMarcaAgua.Text = "Marca de Agua"
        Me.cbMarcaAgua.UseVisualStyleBackColor = True
        '
        'frmRepGerImportaciones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(412, 330)
        Me.Controls.Add(Me.cbMarcaAgua)
        Me.Controls.Add(Me.btnConsolidado3)
        Me.Controls.Add(Me.btnConsolidado2)
        Me.Controls.Add(Me.btnConsolidado1)
        Me.Controls.Add(Me.btnConsolidado)
        Me.Controls.Add(Me.rb0114)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.rb0113)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rb0112)
        Me.Controls.Add(Me.rb0111)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbFecFinal)
        Me.Controls.Add(Me.cbFecInicio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepGerImportaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Gerencial de Importaciones"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rb0112 As System.Windows.Forms.RadioButton
    Friend WithEvents rb0111 As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rb0113 As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rb0114 As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnConsolidado As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado3 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado2 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cbMarcaAgua As CheckBox
End Class
