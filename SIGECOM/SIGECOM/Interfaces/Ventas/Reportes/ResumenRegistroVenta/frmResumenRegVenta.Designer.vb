<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResumenRegVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResumenRegVenta))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbBuscarCliente = New System.Windows.Forms.CheckBox()
        Me.rbPantalla = New System.Windows.Forms.RadioButton()
        Me.rbExportExcel = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.rbTransGrat = New System.Windows.Forms.RadioButton()
        Me.rbExportacion = New System.Windows.Forms.RadioButton()
        Me.rbVentas = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rbAgrupxCliente = New System.Windows.Forms.RadioButton()
        Me.gbImprimir = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbImprimir.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Controls.Add(Me.txtCliente)
        Me.UiGroupBox6.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox6.Controls.Add(Me.Label12)
        Me.UiGroupBox6.Controls.Add(Me.rbBuscarCliente)
        Me.UiGroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox6.Location = New System.Drawing.Point(9, 48)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(467, 75)
        Me.UiGroupBox6.TabIndex = 105
        Me.UiGroupBox6.Text = "Buscar Cliente"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(74, 43)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(355, 20)
        Me.txtCliente.TabIndex = 47
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(431, 42)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 48
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Cliente"
        '
        'rbBuscarCliente
        '
        Me.rbBuscarCliente.AutoSize = True
        Me.rbBuscarCliente.Checked = True
        Me.rbBuscarCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarCliente.Location = New System.Drawing.Point(14, 19)
        Me.rbBuscarCliente.Name = "rbBuscarCliente"
        Me.rbBuscarCliente.Size = New System.Drawing.Size(116, 20)
        Me.rbBuscarCliente.TabIndex = 13
        Me.rbBuscarCliente.Text = "Todo Cliente"
        Me.rbBuscarCliente.UseVisualStyleBackColor = True
        '
        'rbPantalla
        '
        Me.rbPantalla.AutoSize = True
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(21, 40)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(83, 20)
        Me.rbPantalla.TabIndex = 48
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.UseVisualStyleBackColor = True
        '
        'rbExportExcel
        '
        Me.rbExportExcel.AutoSize = True
        Me.rbExportExcel.Location = New System.Drawing.Point(21, 66)
        Me.rbExportExcel.Name = "rbExportExcel"
        Me.rbExportExcel.Size = New System.Drawing.Size(64, 20)
        Me.rbExportExcel.TabIndex = 47
        Me.rbExportExcel.Text = "Excel"
        Me.rbExportExcel.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(432, 220)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(33, 24)
        Me.DataGridView1.TabIndex = 48
        Me.DataGridView1.Visible = False
        '
        'rbTransGrat
        '
        Me.rbTransGrat.AutoSize = True
        Me.rbTransGrat.Location = New System.Drawing.Point(13, 65)
        Me.rbTransGrat.Name = "rbTransGrat"
        Me.rbTransGrat.Size = New System.Drawing.Size(136, 20)
        Me.rbTransGrat.TabIndex = 8
        Me.rbTransGrat.Text = "Trans. Gratuitas"
        Me.rbTransGrat.UseVisualStyleBackColor = True
        '
        'rbExportacion
        '
        Me.rbExportacion.AutoSize = True
        Me.rbExportacion.Location = New System.Drawing.Point(13, 42)
        Me.rbExportacion.Name = "rbExportacion"
        Me.rbExportacion.Size = New System.Drawing.Size(108, 20)
        Me.rbExportacion.TabIndex = 2
        Me.rbExportacion.Text = "Exportación"
        Me.rbExportacion.UseVisualStyleBackColor = True
        '
        'rbVentas
        '
        Me.rbVentas.AutoSize = True
        Me.rbVentas.Checked = True
        Me.rbVentas.Location = New System.Drawing.Point(13, 19)
        Me.rbVentas.Name = "rbVentas"
        Me.rbVentas.Size = New System.Drawing.Size(74, 20)
        Me.rbVentas.TabIndex = 7
        Me.rbVentas.TabStop = True
        Me.rbVentas.Text = "Ventas"
        Me.rbVentas.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(308, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 16)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Al"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Location = New System.Drawing.Point(336, 18)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(98, 22)
        Me.cbFecFinal.TabIndex = 3
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Location = New System.Drawing.Point(184, 18)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(98, 22)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fechas      Del : "
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(165, 270)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 28)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(253, 270)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 28)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'rbAgrupxCliente
        '
        Me.rbAgrupxCliente.AutoSize = True
        Me.rbAgrupxCliente.Location = New System.Drawing.Point(13, 88)
        Me.rbAgrupxCliente.Name = "rbAgrupxCliente"
        Me.rbAgrupxCliente.Size = New System.Drawing.Size(173, 20)
        Me.rbAgrupxCliente.TabIndex = 9
        Me.rbAgrupxCliente.Text = "Agrupado por Cliente"
        Me.rbAgrupxCliente.UseVisualStyleBackColor = True
        '
        'gbImprimir
        '
        Me.gbImprimir.Controls.Add(Me.rbPantalla)
        Me.gbImprimir.Controls.Add(Me.rbExportExcel)
        Me.gbImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbImprimir.Location = New System.Drawing.Point(290, 130)
        Me.gbImprimir.Name = "gbImprimir"
        Me.gbImprimir.Size = New System.Drawing.Size(121, 117)
        Me.gbImprimir.TabIndex = 200
        Me.gbImprimir.Text = "Exportar"
        Me.gbImprimir.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbAgrupxCliente)
        Me.UiGroupBox1.Controls.Add(Me.rbVentas)
        Me.UiGroupBox1.Controls.Add(Me.rbTransGrat)
        Me.UiGroupBox1.Controls.Add(Me.rbExportacion)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(60, 130)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(208, 117)
        Me.UiGroupBox1.TabIndex = 201
        Me.UiGroupBox1.Text = "Tipo"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.UiGroupBox1)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.gbImprimir)
        Me.UiGroupBox2.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox2.Controls.Add(Me.UiGroupBox6)
        Me.UiGroupBox2.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox2.Controls.Add(Me.DataGridView1)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(486, 257)
        Me.UiGroupBox2.TabIndex = 201
        Me.UiGroupBox2.Text = "Resumen"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'frmResumenRegVenta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(503, 307)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResumenRegVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen de Registro de Ventas"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbImprimir.ResumeLayout(False)
        Me.gbImprimir.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents rbExportacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbVentas As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents rbExportExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rbPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbBuscarCliente As System.Windows.Forms.CheckBox
    Friend WithEvents rbTransGrat As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents rbAgrupxCliente As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbImprimir As Janus.Windows.EditControls.UIGroupBox
End Class
