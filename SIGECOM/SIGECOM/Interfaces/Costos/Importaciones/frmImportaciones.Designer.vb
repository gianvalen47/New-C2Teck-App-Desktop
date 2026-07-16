<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportaciones))
        Dim dgFacturas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.dtFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.dtInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbAlmacen = New System.Windows.Forms.ComboBox()
        Me.txtNumero = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbOficina = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbEstado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbProveedor = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRecostear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biValorizarFIMasivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRecalcularMasivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRecostearMasivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenerarAsientoDUA = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmRecostear = New System.Windows.Forms.ToolStripMenuItem()
        Me.miValorizarFIMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRecalcularMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRecostearMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miGenerarAsientoDUA = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgFacturas = New Janus.Windows.GridEX.GridEX()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.dgFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtFinal
        '
        '
        '
        '
        Me.dtFinal.DropDownCalendar.Name = ""
        Me.dtFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.dtFinal.Location = New System.Drawing.Point(478, 30)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.NullButtonText = "Ninguno"
        Me.dtFinal.Size = New System.Drawing.Size(80, 20)
        Me.dtFinal.TabIndex = 9
        Me.dtFinal.TodayButtonText = "Hoy"
        Me.dtFinal.Value = New Date(2010, 8, 31, 9, 24, 0, 0)
        Me.dtFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'dtInicio
        '
        '
        '
        '
        Me.dtInicio.DropDownCalendar.Name = ""
        Me.dtInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.dtInicio.Location = New System.Drawing.Point(396, 30)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.NullButtonText = "Ninguno"
        Me.dtInicio.Size = New System.Drawing.Size(80, 20)
        Me.dtInicio.TabIndex = 7
        Me.dtInicio.TodayButtonText = "Hoy"
        Me.dtInicio.Value = New Date(2009, 9, 29, 0, 0, 0, 0)
        Me.dtInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbAlmacen
        '
        Me.cbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAlmacen.FormattingEnabled = True
        Me.cbAlmacen.Location = New System.Drawing.Point(109, 30)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.Size = New System.Drawing.Size(122, 21)
        Me.cbAlmacen.TabIndex = 3
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(737, 30)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(79, 20)
        Me.txtNumero.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Oficina"
        '
        'cbOficina
        '
        Me.cbOficina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOficina.FormattingEnabled = True
        Me.cbOficina.Location = New System.Drawing.Point(6, 30)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.Size = New System.Drawing.Size(102, 21)
        Me.cbOficina.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(818, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(62, 22)
        Me.btnBuscar.TabIndex = 14
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(755, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Numero"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(584, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Estado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(403, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha Inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(487, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fecha Final"
        '
        'cbEstado
        '
        Me.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEstado.FormattingEnabled = True
        Me.cbEstado.Location = New System.Drawing.Point(561, 29)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(93, 21)
        Me.cbEstado.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(286, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(151, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Almacen"
        '
        'cbProveedor
        '
        Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(232, 30)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(162, 21)
        Me.cbProveedor.TabIndex = 5
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnImprimir, Me.ToolStripSeparator2, Me.btnMostrar, Me.ToolStripSeparator3, Me.btnRecostear, Me.ToolStripSeparator4, Me.biValorizarFIMasivo, Me.ToolStripSeparator8, Me.biRecalcularMasivo, Me.ToolStripSeparator9, Me.biRecostearMasivo, Me.ToolStripSeparator10, Me.btnGenerarAsientoDUA, Me.ToolStripSeparator11, Me.btnActualizar, Me.ToolStripSeparator5, Me.btnSalir, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(918, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(28, 28)
        Me.btnImprimir.Text = "ToolStripButton1"
        Me.btnImprimir.ToolTipText = "Imprimir Factura de Importacion"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'btnMostrar
        '
        Me.btnMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.btnMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(28, 28)
        Me.btnMostrar.Text = "ToolStripButton1"
        Me.btnMostrar.ToolTipText = "Mostrar los Datos de la factura"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'btnRecostear
        '
        Me.btnRecostear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRecostear.Image = CType(resources.GetObject("btnRecostear.Image"), System.Drawing.Image)
        Me.btnRecostear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecostear.Name = "btnRecostear"
        Me.btnRecostear.Size = New System.Drawing.Size(28, 28)
        Me.btnRecostear.Text = "Procesar Factura Seleccionada"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biValorizarFIMasivo
        '
        Me.biValorizarFIMasivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biValorizarFIMasivo.Image = CType(resources.GetObject("biValorizarFIMasivo.Image"), System.Drawing.Image)
        Me.biValorizarFIMasivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biValorizarFIMasivo.Name = "biValorizarFIMasivo"
        Me.biValorizarFIMasivo.Size = New System.Drawing.Size(28, 28)
        Me.biValorizarFIMasivo.Text = "Valorizar F/I Masivo"
        Me.biValorizarFIMasivo.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biRecalcularMasivo
        '
        Me.biRecalcularMasivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRecalcularMasivo.Image = CType(resources.GetObject("biRecalcularMasivo.Image"), System.Drawing.Image)
        Me.biRecalcularMasivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRecalcularMasivo.Name = "biRecalcularMasivo"
        Me.biRecalcularMasivo.Size = New System.Drawing.Size(28, 28)
        Me.biRecalcularMasivo.Text = "Recalcular F/I masivo"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'biRecostearMasivo
        '
        Me.biRecostearMasivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRecostearMasivo.Image = CType(resources.GetObject("biRecostearMasivo.Image"), System.Drawing.Image)
        Me.biRecostearMasivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRecostearMasivo.Name = "biRecostearMasivo"
        Me.biRecostearMasivo.Size = New System.Drawing.Size(28, 28)
        Me.biRecostearMasivo.Text = "Procesar F/I masivo"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        '
        'btnGenerarAsientoDUA
        '
        Me.btnGenerarAsientoDUA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGenerarAsientoDUA.Image = CType(resources.GetObject("btnGenerarAsientoDUA.Image"), System.Drawing.Image)
        Me.btnGenerarAsientoDUA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarAsientoDUA.Name = "btnGenerarAsientoDUA"
        Me.btnGenerarAsientoDUA.Size = New System.Drawing.Size(28, 28)
        Me.btnGenerarAsientoDUA.Text = "Generar Asiento DUA"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'btnActualizar
        '
        Me.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(28, 28)
        Me.btnActualizar.Text = "ToolStripButton2"
        Me.btnActualizar.ToolTipText = "Actualizar / Refrescar la informacion"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(28, 28)
        Me.btnSalir.Text = "ToolStripButton1"
        Me.btnSalir.ToolTipText = "Salir de la Ventana"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmImprimir, Me.cmMostrar, Me.cmRecostear, Me.miValorizarFIMasivo, Me.miRecalcularMasivo, Me.miRecostearMasivo, Me.ToolStripSeparator7, Me.miGenerarAsientoDUA, Me.ToolStripMenuItem1, Me.cmActualizar, Me.cmSalir})
        Me.cmOpciones.Name = "ContextMenuStrip1"
        Me.cmOpciones.Size = New System.Drawing.Size(187, 236)
        Me.cmOpciones.Text = "Actualizar"
        '
        'cmImprimir
        '
        Me.cmImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.cmImprimir.Name = "cmImprimir"
        Me.cmImprimir.Size = New System.Drawing.Size(186, 22)
        Me.cmImprimir.Text = "Imprimir"
        Me.cmImprimir.ToolTipText = "Imprimir Factura de Importación"
        '
        'cmMostrar
        '
        Me.cmMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.cmMostrar.Name = "cmMostrar"
        Me.cmMostrar.Size = New System.Drawing.Size(186, 22)
        Me.cmMostrar.Text = "Mostrar"
        Me.cmMostrar.ToolTipText = "Mostrar el contenido de la factura"
        '
        'cmRecostear
        '
        Me.cmRecostear.Image = CType(resources.GetObject("cmRecostear.Image"), System.Drawing.Image)
        Me.cmRecostear.Name = "cmRecostear"
        Me.cmRecostear.Size = New System.Drawing.Size(186, 22)
        Me.cmRecostear.Text = "Procesar Factura"
        Me.cmRecostear.ToolTipText = "Procesar Factura Seleccionada"
        '
        'miValorizarFIMasivo
        '
        Me.miValorizarFIMasivo.Image = CType(resources.GetObject("miValorizarFIMasivo.Image"), System.Drawing.Image)
        Me.miValorizarFIMasivo.Name = "miValorizarFIMasivo"
        Me.miValorizarFIMasivo.Size = New System.Drawing.Size(186, 22)
        Me.miValorizarFIMasivo.Text = "Valorizar F/I Masivo"
        Me.miValorizarFIMasivo.Visible = False
        '
        'miRecalcularMasivo
        '
        Me.miRecalcularMasivo.Image = CType(resources.GetObject("miRecalcularMasivo.Image"), System.Drawing.Image)
        Me.miRecalcularMasivo.Name = "miRecalcularMasivo"
        Me.miRecalcularMasivo.Size = New System.Drawing.Size(186, 22)
        Me.miRecalcularMasivo.Text = "Recalcular F/I Masivo"
        '
        'miRecostearMasivo
        '
        Me.miRecostearMasivo.Image = CType(resources.GetObject("miRecostearMasivo.Image"), System.Drawing.Image)
        Me.miRecostearMasivo.Name = "miRecostearMasivo"
        Me.miRecostearMasivo.Size = New System.Drawing.Size(186, 22)
        Me.miRecostearMasivo.Text = "Procesar F/I Masivo"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(183, 6)
        '
        'miGenerarAsientoDUA
        '
        Me.miGenerarAsientoDUA.Image = CType(resources.GetObject("miGenerarAsientoDUA.Image"), System.Drawing.Image)
        Me.miGenerarAsientoDUA.Name = "miGenerarAsientoDUA"
        Me.miGenerarAsientoDUA.Size = New System.Drawing.Size(186, 22)
        Me.miGenerarAsientoDUA.Text = "Generar Asiento DUA"
        Me.miGenerarAsientoDUA.ToolTipText = "Generar Asiento Diario DUA"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(183, 6)
        '
        'cmActualizar
        '
        Me.cmActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.cmActualizar.Name = "cmActualizar"
        Me.cmActualizar.Size = New System.Drawing.Size(186, 22)
        Me.cmActualizar.Text = "Actualizar / Refrescar"
        Me.cmActualizar.ToolTipText = "Actualizar / Refrescar los datos"
        '
        'cmSalir
        '
        Me.cmSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.cmSalir.Name = "cmSalir"
        Me.cmSalir.Size = New System.Drawing.Size(186, 22)
        Me.cmSalir.Text = "Salir"
        Me.cmSalir.ToolTipText = "Salir de la ventana"
        '
        'dgFacturas
        '
        Me.dgFacturas.AllowCardSizing = False
        Me.dgFacturas.AllowColumnDrag = False
        Me.dgFacturas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgFacturas.AlternatingColors = True
        Me.dgFacturas.ContextMenuStrip = Me.cmOpciones
        dgFacturas_DesignTimeLayout.LayoutString = resources.GetString("dgFacturas_DesignTimeLayout.LayoutString")
        Me.dgFacturas.DesignTimeLayout = dgFacturas_DesignTimeLayout
        Me.dgFacturas.EmptyRows = True
        Me.dgFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgFacturas.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgFacturas.GroupByBoxVisible = False
        Me.dgFacturas.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgFacturas.Location = New System.Drawing.Point(0, 97)
        Me.dgFacturas.Name = "dgFacturas"
        Me.dgFacturas.RowFormatStyle.FontSize = 8.5!
        Me.dgFacturas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgFacturas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgFacturas.Size = New System.Drawing.Size(893, 310)
        Me.dgFacturas.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.dgFacturas, "Listado de Facturas de Importacion")
        Me.dgFacturas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 431)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(918, 20)
        Me.ssBarra.TabIndex = 231
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(480, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtCodEmbarque)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.cbOficina)
        Me.UiGroupBox1.Controls.Add(Me.dtFinal)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.cbEstado)
        Me.UiGroupBox1.Controls.Add(Me.dtInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.cbAlmacen)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtNumero)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.cbProveedor)
        Me.UiGroupBox1.Location = New System.Drawing.Point(4, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(884, 57)
        Me.UiGroupBox1.TabIndex = 232
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmbarque.Location = New System.Drawing.Point(657, 30)
        Me.txtCodEmbarque.MaxLength = 30
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(79, 20)
        Me.txtCodEmbarque.TabIndex = 12
        Me.txtCodEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(657, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 234
        Me.Label14.Text = "Cod Embarque"
        '
        'frmImportaciones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(918, 451)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgFacturas)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas de Importacion"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.dgFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbOficina As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgFacturas As Janus.Windows.GridEX.GridEX
    Friend WithEvents cbAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents btnRecostear As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmRecostear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dtFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biValorizarFIMasivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents miValorizarFIMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents biRecalcularMasivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miRecalcularMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biRecostearMasivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miRecostearMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGenerarAsientoDUA As ToolStripButton
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents miGenerarAsientoDUA As ToolStripMenuItem
End Class
