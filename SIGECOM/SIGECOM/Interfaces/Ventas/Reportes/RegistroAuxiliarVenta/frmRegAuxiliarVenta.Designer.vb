<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegAuxiliarVenta
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
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegAuxiliarVenta))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbProyectosNuevos = New System.Windows.Forms.RadioButton()
        Me.rbRepuestos = New System.Windows.Forms.RadioButton()
        Me.rbOtros = New System.Windows.Forms.RadioButton()
        Me.rbBaterias = New System.Windows.Forms.RadioButton()
        Me.rbMercaSinMov = New System.Windows.Forms.RadioButton()
        Me.rbServicios = New System.Windows.Forms.RadioButton()
        Me.rbFiltros = New System.Windows.Forms.RadioButton()
        Me.rbMotores = New System.Windows.Forms.RadioButton()
        Me.rbTranGrat = New System.Windows.Forms.RadioButton()
        Me.rbConsignacion = New System.Windows.Forms.RadioButton()
        Me.rbNotaDebito = New System.Windows.Forms.RadioButton()
        Me.gbMoneda = New System.Windows.Forms.GroupBox()
        Me.rbDolares = New System.Windows.Forms.RadioButton()
        Me.rbSoles = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.gbMoneda.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbProyectosNuevos)
        Me.UiGroupBox1.Controls.Add(Me.rbRepuestos)
        Me.UiGroupBox1.Controls.Add(Me.rbOtros)
        Me.UiGroupBox1.Controls.Add(Me.rbBaterias)
        Me.UiGroupBox1.Controls.Add(Me.rbMercaSinMov)
        Me.UiGroupBox1.Controls.Add(Me.rbServicios)
        Me.UiGroupBox1.Controls.Add(Me.rbFiltros)
        Me.UiGroupBox1.Controls.Add(Me.rbMotores)
        Me.UiGroupBox1.Controls.Add(Me.rbTranGrat)
        Me.UiGroupBox1.Controls.Add(Me.rbConsignacion)
        Me.UiGroupBox1.Controls.Add(Me.rbNotaDebito)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.UiGroupBox1.Location = New System.Drawing.Point(222, 73)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(211, 276)
        Me.UiGroupBox1.TabIndex = 27
        Me.UiGroupBox1.Text = "Departamento"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbProyectosNuevos
        '
        Me.rbProyectosNuevos.AutoSize = True
        Me.rbProyectosNuevos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProyectosNuevos.Location = New System.Drawing.Point(21, 250)
        Me.rbProyectosNuevos.Name = "rbProyectosNuevos"
        Me.rbProyectosNuevos.Size = New System.Drawing.Size(128, 17)
        Me.rbProyectosNuevos.TabIndex = 11
        Me.rbProyectosNuevos.Text = "Proyectos Nuevos"
        Me.rbProyectosNuevos.UseVisualStyleBackColor = True
        '
        'rbRepuestos
        '
        Me.rbRepuestos.AutoSize = True
        Me.rbRepuestos.Checked = True
        Me.rbRepuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRepuestos.Location = New System.Drawing.Point(21, 20)
        Me.rbRepuestos.Name = "rbRepuestos"
        Me.rbRepuestos.Size = New System.Drawing.Size(85, 17)
        Me.rbRepuestos.TabIndex = 5
        Me.rbRepuestos.TabStop = True
        Me.rbRepuestos.Text = "Repuestos"
        Me.rbRepuestos.UseVisualStyleBackColor = True
        '
        'rbOtros
        '
        Me.rbOtros.AutoSize = True
        Me.rbOtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOtros.Location = New System.Drawing.Point(21, 227)
        Me.rbOtros.Name = "rbOtros"
        Me.rbOtros.Size = New System.Drawing.Size(92, 17)
        Me.rbOtros.TabIndex = 10
        Me.rbOtros.Text = "Back Office"
        Me.rbOtros.UseVisualStyleBackColor = True
        '
        'rbBaterias
        '
        Me.rbBaterias.AutoSize = True
        Me.rbBaterias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBaterias.Location = New System.Drawing.Point(21, 43)
        Me.rbBaterias.Name = "rbBaterias"
        Me.rbBaterias.Size = New System.Drawing.Size(71, 17)
        Me.rbBaterias.TabIndex = 2
        Me.rbBaterias.Text = "Baterias"
        Me.rbBaterias.UseVisualStyleBackColor = True
        '
        'rbMercaSinMov
        '
        Me.rbMercaSinMov.AutoSize = True
        Me.rbMercaSinMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMercaSinMov.Location = New System.Drawing.Point(21, 135)
        Me.rbMercaSinMov.Name = "rbMercaSinMov"
        Me.rbMercaSinMov.Size = New System.Drawing.Size(175, 17)
        Me.rbMercaSinMov.TabIndex = 9
        Me.rbMercaSinMov.Text = "Mercaderia sin movimiento"
        Me.rbMercaSinMov.UseVisualStyleBackColor = True
        '
        'rbServicios
        '
        Me.rbServicios.AutoSize = True
        Me.rbServicios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbServicios.Location = New System.Drawing.Point(21, 89)
        Me.rbServicios.Name = "rbServicios"
        Me.rbServicios.Size = New System.Drawing.Size(77, 17)
        Me.rbServicios.TabIndex = 3
        Me.rbServicios.Text = "Servicios"
        Me.rbServicios.UseVisualStyleBackColor = True
        '
        'rbFiltros
        '
        Me.rbFiltros.AutoSize = True
        Me.rbFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFiltros.Location = New System.Drawing.Point(21, 66)
        Me.rbFiltros.Name = "rbFiltros"
        Me.rbFiltros.Size = New System.Drawing.Size(59, 17)
        Me.rbFiltros.TabIndex = 8
        Me.rbFiltros.Text = "Filtros"
        Me.rbFiltros.UseVisualStyleBackColor = True
        '
        'rbMotores
        '
        Me.rbMotores.AutoSize = True
        Me.rbMotores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMotores.Location = New System.Drawing.Point(21, 112)
        Me.rbMotores.Name = "rbMotores"
        Me.rbMotores.Size = New System.Drawing.Size(70, 17)
        Me.rbMotores.TabIndex = 4
        Me.rbMotores.Text = "Motores"
        Me.rbMotores.UseVisualStyleBackColor = True
        '
        'rbTranGrat
        '
        Me.rbTranGrat.AutoSize = True
        Me.rbTranGrat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTranGrat.Location = New System.Drawing.Point(21, 204)
        Me.rbTranGrat.Name = "rbTranGrat"
        Me.rbTranGrat.Size = New System.Drawing.Size(150, 17)
        Me.rbTranGrat.TabIndex = 7
        Me.rbTranGrat.Text = "Transferencia gratuita"
        Me.rbTranGrat.UseVisualStyleBackColor = True
        '
        'rbConsignacion
        '
        Me.rbConsignacion.AutoSize = True
        Me.rbConsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConsignacion.Location = New System.Drawing.Point(21, 158)
        Me.rbConsignacion.Name = "rbConsignacion"
        Me.rbConsignacion.Size = New System.Drawing.Size(101, 17)
        Me.rbConsignacion.TabIndex = 5
        Me.rbConsignacion.Text = "Consignación"
        Me.rbConsignacion.UseVisualStyleBackColor = True
        '
        'rbNotaDebito
        '
        Me.rbNotaDebito.AutoSize = True
        Me.rbNotaDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNotaDebito.Location = New System.Drawing.Point(21, 181)
        Me.rbNotaDebito.Name = "rbNotaDebito"
        Me.rbNotaDebito.Size = New System.Drawing.Size(117, 17)
        Me.rbNotaDebito.TabIndex = 6
        Me.rbNotaDebito.Text = "Notas de Débito"
        Me.rbNotaDebito.UseVisualStyleBackColor = True
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.rbDolares)
        Me.gbMoneda.Controls.Add(Me.rbSoles)
        Me.gbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMoneda.Location = New System.Drawing.Point(15, 118)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(131, 77)
        Me.gbMoneda.TabIndex = 42
        Me.gbMoneda.TabStop = False
        Me.gbMoneda.Text = "Moneda"
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDolares.Location = New System.Drawing.Point(18, 48)
        Me.rbDolares.Name = "rbDolares"
        Me.rbDolares.Size = New System.Drawing.Size(87, 17)
        Me.rbDolares.TabIndex = 2
        Me.rbDolares.Text = "En Dólares"
        Me.rbDolares.UseVisualStyleBackColor = True
        '
        'rbSoles
        '
        Me.rbSoles.AutoSize = True
        Me.rbSoles.Checked = True
        Me.rbSoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSoles.Location = New System.Drawing.Point(18, 22)
        Me.rbSoles.Name = "rbSoles"
        Me.rbSoles.Size = New System.Drawing.Size(75, 17)
        Me.rbSoles.TabIndex = 6
        Me.rbSoles.TabStop = True
        Me.rbSoles.Text = "En Soles"
        Me.rbSoles.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(268, 19)
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
        Me.cbFecFinal.Location = New System.Drawing.Point(307, 17)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
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
        Me.cbFecInicio.Location = New System.Drawing.Point(155, 17)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 2
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(78, 73)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(129, 20)
        Me.cmbOficinas.TabIndex = 4
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fechas      Del : "
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.Location = New System.Drawing.Point(12, 74)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(60, 16)
        Me.lblOficina.TabIndex = 1
        Me.lblOficina.Text = "Oficina:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(148, 372)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 28)
        Me.btnAceptar.TabIndex = 7
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
        Me.btnCancelar.Location = New System.Drawing.Point(231, 372)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 28)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.UiGroupBox1)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.gbMoneda)
        Me.UiGroupBox2.Controls.Add(Me.lblOficina)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Controls.Add(Me.cmbOficinas)
        Me.UiGroupBox2.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox2.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(9, 6)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(443, 360)
        Me.UiGroupBox2.TabIndex = 27
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmRegAuxiliarVenta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(459, 407)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegAuxiliarVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro Auxiliar de Ventas"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents rbSoles As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotaDebito As System.Windows.Forms.RadioButton
    Friend WithEvents rbConsignacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbMotores As System.Windows.Forms.RadioButton
    Friend WithEvents rbServicios As System.Windows.Forms.RadioButton
    Friend WithEvents rbBaterias As System.Windows.Forms.RadioButton
    Friend WithEvents rbRepuestos As System.Windows.Forms.RadioButton
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblOficina As System.Windows.Forms.Label
    Friend WithEvents rbTranGrat As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltros As System.Windows.Forms.RadioButton
    Friend WithEvents rbMercaSinMov As System.Windows.Forms.RadioButton
    Friend WithEvents rbOtros As System.Windows.Forms.RadioButton
    Friend WithEvents rbProyectosNuevos As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
End Class
