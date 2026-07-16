<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentas
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
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentas))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbtGerenConsolidado = New System.Windows.Forms.RadioButton()
        Me.rbtnGerenGarantias = New System.Windows.Forms.RadioButton()
        Me.rbtnServicioSinIGV = New System.Windows.Forms.RadioButton()
        Me.rbtnConsoVentas = New System.Windows.Forms.RadioButton()
        Me.rbtnVentasCliente = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rbtAdelantos = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rbtnMotoresVenta = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rbtnConsJobs = New System.Windows.Forms.RadioButton()
        Me.rbtnJobFac = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbtnPresupuesto = New System.Windows.Forms.RadioButton()
        Me.btnConsolidado = New System.Windows.Forms.Button()
        Me.btnConsolidado1 = New System.Windows.Forms.Button()
        Me.btnConsolidado2 = New System.Windows.Forms.Button()
        Me.btnConsolidado3 = New System.Windows.Forms.Button()
        Me.btnConsolidado4 = New System.Windows.Forms.Button()
        Me.btnConsolidado5 = New System.Windows.Forms.Button()
        Me.btnConsolidado6 = New System.Windows.Forms.Button()
        Me.btnConsolidado7 = New System.Windows.Forms.Button()
        Me.btnConsolidado8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnImprimirPresAnual = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.rbtnGuiasPendientes = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbMoneda = New System.Windows.Forms.CheckBox()
        Me.cbMarcaAgua = New System.Windows.Forms.CheckBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha del"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(263, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Al:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Reporte Gerencial 001 - 0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Reporte Gerencial 001 - 4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Reporte Gerencial 002"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 289)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Reporte Gerencial 003"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(280, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Reporte Gerencial 004"
        '
        'rbtGerenConsolidado
        '
        Me.rbtGerenConsolidado.AutoSize = True
        Me.rbtGerenConsolidado.Checked = True
        Me.rbtGerenConsolidado.Location = New System.Drawing.Point(15, 106)
        Me.rbtGerenConsolidado.Name = "rbtGerenConsolidado"
        Me.rbtGerenConsolidado.Size = New System.Drawing.Size(145, 17)
        Me.rbtGerenConsolidado.TabIndex = 3
        Me.rbtGerenConsolidado.TabStop = True
        Me.rbtGerenConsolidado.Text = "Consolidado Reg. Ventas"
        Me.rbtGerenConsolidado.UseVisualStyleBackColor = True
        '
        'rbtnGerenGarantias
        '
        Me.rbtnGerenGarantias.AutoSize = True
        Me.rbtnGerenGarantias.Location = New System.Drawing.Point(15, 156)
        Me.rbtnGerenGarantias.Name = "rbtnGerenGarantias"
        Me.rbtnGerenGarantias.Size = New System.Drawing.Size(120, 17)
        Me.rbtnGerenGarantias.TabIndex = 4
        Me.rbtnGerenGarantias.TabStop = True
        Me.rbtnGerenGarantias.Text = "Resumen Garantías"
        Me.rbtnGerenGarantias.UseVisualStyleBackColor = True
        '
        'rbtnServicioSinIGV
        '
        Me.rbtnServicioSinIGV.AutoSize = True
        Me.rbtnServicioSinIGV.Location = New System.Drawing.Point(13, 257)
        Me.rbtnServicioSinIGV.Name = "rbtnServicioSinIGV"
        Me.rbtnServicioSinIGV.Size = New System.Drawing.Size(156, 17)
        Me.rbtnServicioSinIGV.TabIndex = 6
        Me.rbtnServicioSinIGV.TabStop = True
        Me.rbtnServicioSinIGV.Text = "Detalle de Servicios sin IGV"
        Me.rbtnServicioSinIGV.UseVisualStyleBackColor = True
        '
        'rbtnConsoVentas
        '
        Me.rbtnConsoVentas.AutoSize = True
        Me.rbtnConsoVentas.Location = New System.Drawing.Point(15, 309)
        Me.rbtnConsoVentas.Name = "rbtnConsoVentas"
        Me.rbtnConsoVentas.Size = New System.Drawing.Size(134, 17)
        Me.rbtnConsoVentas.TabIndex = 7
        Me.rbtnConsoVentas.TabStop = True
        Me.rbtnConsoVentas.Text = "Consolidado de Ventas"
        Me.rbtnConsoVentas.UseVisualStyleBackColor = True
        '
        'rbtnVentasCliente
        '
        Me.rbtnVentasCliente.AutoSize = True
        Me.rbtnVentasCliente.Location = New System.Drawing.Point(283, 108)
        Me.rbtnVentasCliente.Name = "rbtnVentasCliente"
        Me.rbtnVentasCliente.Size = New System.Drawing.Size(164, 17)
        Me.rbtnVentasCliente.TabIndex = 8
        Me.rbtnVentasCliente.TabStop = True
        Me.rbtnVentasCliente.Text = "Record de Ventas por Cliente"
        Me.rbtnVentasCliente.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(253, 337)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(157, 337)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(292, 21)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 2
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
        Me.cbFecInicio.Location = New System.Drawing.Point(137, 21)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(184, 16)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Reporte Gerencial 001 - 5"
        '
        'rbtAdelantos
        '
        Me.rbtAdelantos.AutoSize = True
        Me.rbtAdelantos.Location = New System.Drawing.Point(15, 206)
        Me.rbtAdelantos.Name = "rbtAdelantos"
        Me.rbtAdelantos.Size = New System.Drawing.Size(129, 17)
        Me.rbtAdelantos.TabIndex = 5
        Me.rbtAdelantos.TabStop = True
        Me.rbtAdelantos.Text = "Factura por Adelantos"
        Me.rbtAdelantos.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(200, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 22)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "VENTAS"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(280, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(163, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Reporte Gerencial 005"
        '
        'rbtnMotoresVenta
        '
        Me.rbtnMotoresVenta.AutoSize = True
        Me.rbtnMotoresVenta.Location = New System.Drawing.Point(283, 157)
        Me.rbtnMotoresVenta.Name = "rbtnMotoresVenta"
        Me.rbtnMotoresVenta.Size = New System.Drawing.Size(110, 17)
        Me.rbtnMotoresVenta.TabIndex = 9
        Me.rbtnMotoresVenta.TabStop = True
        Me.rbtnMotoresVenta.Text = "Motores Vendidos"
        Me.rbtnMotoresVenta.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(280, 184)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(163, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Reporte Gerencial 006"
        '
        'rbtnConsJobs
        '
        Me.rbtnConsJobs.AutoSize = True
        Me.rbtnConsJobs.Location = New System.Drawing.Point(283, 204)
        Me.rbtnConsJobs.Name = "rbtnConsJobs"
        Me.rbtnConsJobs.Size = New System.Drawing.Size(121, 17)
        Me.rbtnConsJobs.TabIndex = 10
        Me.rbtnConsJobs.TabStop = True
        Me.rbtnConsJobs.Text = "Consolidado de OTs"
        Me.rbtnConsJobs.UseVisualStyleBackColor = True
        '
        'rbtnJobFac
        '
        Me.rbtnJobFac.AutoSize = True
        Me.rbtnJobFac.Location = New System.Drawing.Point(283, 223)
        Me.rbtnJobFac.Name = "rbtnJobFac"
        Me.rbtnJobFac.Size = New System.Drawing.Size(96, 17)
        Me.rbtnJobFac.TabIndex = 11
        Me.rbtnJobFac.TabStop = True
        Me.rbtnJobFac.Text = "OT Facturados"
        Me.rbtnJobFac.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(280, 243)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(163, 16)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Reporte Gerencial 007"
        '
        'rbtnPresupuesto
        '
        Me.rbtnPresupuesto.AutoSize = True
        Me.rbtnPresupuesto.Location = New System.Drawing.Point(283, 265)
        Me.rbtnPresupuesto.Name = "rbtnPresupuesto"
        Me.rbtnPresupuesto.Size = New System.Drawing.Size(134, 17)
        Me.rbtnPresupuesto.TabIndex = 12
        Me.rbtnPresupuesto.TabStop = True
        Me.rbtnPresupuesto.Text = "Ventas vs Presupuesto"
        Me.rbtnPresupuesto.UseVisualStyleBackColor = True
        '
        'btnConsolidado
        '
        Me.btnConsolidado.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado.Location = New System.Drawing.Point(202, 86)
        Me.btnConsolidado.Name = "btnConsolidado"
        Me.btnConsolidado.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado.TabIndex = 27
        Me.btnConsolidado.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado.UseVisualStyleBackColor = True
        '
        'btnConsolidado1
        '
        Me.btnConsolidado1.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado1.Location = New System.Drawing.Point(202, 132)
        Me.btnConsolidado1.Name = "btnConsolidado1"
        Me.btnConsolidado1.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado1.TabIndex = 28
        Me.btnConsolidado1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado1, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado1.UseVisualStyleBackColor = True
        '
        'btnConsolidado2
        '
        Me.btnConsolidado2.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado2.Location = New System.Drawing.Point(202, 181)
        Me.btnConsolidado2.Name = "btnConsolidado2"
        Me.btnConsolidado2.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado2.TabIndex = 29
        Me.btnConsolidado2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado2, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado2.UseVisualStyleBackColor = True
        '
        'btnConsolidado3
        '
        Me.btnConsolidado3.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado3.Location = New System.Drawing.Point(202, 230)
        Me.btnConsolidado3.Name = "btnConsolidado3"
        Me.btnConsolidado3.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado3.TabIndex = 30
        Me.btnConsolidado3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado3, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado3.UseVisualStyleBackColor = True
        '
        'btnConsolidado4
        '
        Me.btnConsolidado4.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado4.Location = New System.Drawing.Point(202, 282)
        Me.btnConsolidado4.Name = "btnConsolidado4"
        Me.btnConsolidado4.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado4.TabIndex = 31
        Me.btnConsolidado4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado4, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado4.UseVisualStyleBackColor = True
        '
        'btnConsolidado5
        '
        Me.btnConsolidado5.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado5.Location = New System.Drawing.Point(449, 132)
        Me.btnConsolidado5.Name = "btnConsolidado5"
        Me.btnConsolidado5.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado5.TabIndex = 32
        Me.btnConsolidado5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado5, "Agregar a Reporte Consolidado Horizontal")
        Me.btnConsolidado5.UseVisualStyleBackColor = True
        '
        'btnConsolidado6
        '
        Me.btnConsolidado6.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado6.Location = New System.Drawing.Point(449, 195)
        Me.btnConsolidado6.Name = "btnConsolidado6"
        Me.btnConsolidado6.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado6.TabIndex = 33
        Me.btnConsolidado6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado6, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado6.UseVisualStyleBackColor = True
        '
        'btnConsolidado7
        '
        Me.btnConsolidado7.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado7.Location = New System.Drawing.Point(449, 220)
        Me.btnConsolidado7.Name = "btnConsolidado7"
        Me.btnConsolidado7.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado7.TabIndex = 34
        Me.btnConsolidado7.TabStop = False
        Me.btnConsolidado7.UseVisualStyleBackColor = True
        Me.btnConsolidado7.Visible = False
        '
        'btnConsolidado8
        '
        Me.btnConsolidado8.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnConsolidado8.Location = New System.Drawing.Point(467, 262)
        Me.btnConsolidado8.Name = "btnConsolidado8"
        Me.btnConsolidado8.Size = New System.Drawing.Size(26, 23)
        Me.btnConsolidado8.TabIndex = 35
        Me.btnConsolidado8.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnConsolidado8, "Agregar a Reporte Consolidado Vertical")
        Me.btnConsolidado8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.Button1.Location = New System.Drawing.Point(448, 339)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 23)
        Me.Button1.TabIndex = 36
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(392, 344)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Adicionar"
        Me.Label13.Visible = False
        '
        'btnImprimirPresAnual
        '
        Me.btnImprimirPresAnual.Image = Global.SIGECOM.My.Resources.Resources.Impresora1
        Me.btnImprimirPresAnual.Location = New System.Drawing.Point(438, 262)
        Me.btnImprimirPresAnual.Name = "btnImprimirPresAnual"
        Me.btnImprimirPresAnual.Size = New System.Drawing.Size(26, 23)
        Me.btnImprimirPresAnual.TabIndex = 40
        Me.btnImprimirPresAnual.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnImprimirPresAnual, "Imprimir Presupuesto Anual")
        Me.btnImprimirPresAnual.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(280, 289)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(163, 16)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Reporte Gerencial 008"
        '
        'rbtnGuiasPendientes
        '
        Me.rbtnGuiasPendientes.AutoSize = True
        Me.rbtnGuiasPendientes.Location = New System.Drawing.Point(282, 309)
        Me.rbtnGuiasPendientes.Name = "rbtnGuiasPendientes"
        Me.rbtnGuiasPendientes.Size = New System.Drawing.Size(182, 17)
        Me.rbtnGuiasPendientes.TabIndex = 13
        Me.rbtnGuiasPendientes.TabStop = True
        Me.rbtnGuiasPendientes.Text = "Guias Pendientes de Facturación"
        Me.rbtnGuiasPendientes.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(32, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Moneda :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(94, 11)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(54, 20)
        Me.cmbMoneda.TabIndex = 15
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(334, 43)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(161, 35)
        Me.UiGroupBox1.TabIndex = 193
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbMoneda
        '
        Me.rbMoneda.AutoSize = True
        Me.rbMoneda.Checked = True
        Me.rbMoneda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbMoneda.Location = New System.Drawing.Point(13, 15)
        Me.rbMoneda.Name = "rbMoneda"
        Me.rbMoneda.Size = New System.Drawing.Size(15, 14)
        Me.rbMoneda.TabIndex = 14
        Me.rbMoneda.TabStop = False
        Me.rbMoneda.UseVisualStyleBackColor = True
        '
        'cbMarcaAgua
        '
        Me.cbMarcaAgua.AutoSize = True
        Me.cbMarcaAgua.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMarcaAgua.Location = New System.Drawing.Point(23, 54)
        Me.cbMarcaAgua.Name = "cbMarcaAgua"
        Me.cbMarcaAgua.Size = New System.Drawing.Size(112, 17)
        Me.cbMarcaAgua.TabIndex = 194
        Me.cbMarcaAgua.Text = "Marca de Agua"
        Me.cbMarcaAgua.UseVisualStyleBackColor = True
        '
        'frmVentas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(512, 379)
        Me.Controls.Add(Me.cbMarcaAgua)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnImprimirPresAnual)
        Me.Controls.Add(Me.rbtnGuiasPendientes)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnConsolidado8)
        Me.Controls.Add(Me.btnConsolidado7)
        Me.Controls.Add(Me.btnConsolidado6)
        Me.Controls.Add(Me.btnConsolidado5)
        Me.Controls.Add(Me.btnConsolidado4)
        Me.Controls.Add(Me.btnConsolidado3)
        Me.Controls.Add(Me.btnConsolidado2)
        Me.Controls.Add(Me.btnConsolidado1)
        Me.Controls.Add(Me.btnConsolidado)
        Me.Controls.Add(Me.rbtnPresupuesto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.rbtnJobFac)
        Me.Controls.Add(Me.rbtnConsJobs)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.rbtnMotoresVenta)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.rbtAdelantos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbFecFinal)
        Me.Controls.Add(Me.cbFecInicio)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rbtnVentasCliente)
        Me.Controls.Add(Me.rbtnConsoVentas)
        Me.Controls.Add(Me.rbtnServicioSinIGV)
        Me.Controls.Add(Me.rbtnGerenGarantias)
        Me.Controls.Add(Me.rbtGerenConsolidado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVentas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Gerencial de Ventas"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtnVentasCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnConsoVentas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnServicioSinIGV As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnGerenGarantias As System.Windows.Forms.RadioButton
    Friend WithEvents rbtGerenConsolidado As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents rbtAdelantos As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbtnMotoresVenta As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rbtnConsJobs As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rbtnJobFac As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPresupuesto As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnConsolidado As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado3 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado2 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado1 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado4 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado6 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado5 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado8 As System.Windows.Forms.Button
    Friend WithEvents btnConsolidado7 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents rbtnGuiasPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirPresAnual As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbMoneda As System.Windows.Forms.CheckBox
    Friend WithEvents cbMarcaAgua As CheckBox
End Class
