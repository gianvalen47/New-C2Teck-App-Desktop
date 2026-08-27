<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudCompra_AgregarDetalle
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
        Dim cmbCotizaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoGasto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudCompra_AgregarDetalle))
        Dim cmbRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodUniMed_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPreMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbCotizaciones = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtDscto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtCodMer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbTipoGasto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtObservTipoGasto = New System.Windows.Forms.TextBox()
        Me.cmbRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnBuscarJob = New Janus.Windows.EditControls.UIButton()
        Me.cmbCodUniMed = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtCodJob = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCanMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gbCotizacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnVerCotizaciones = New Janus.Windows.EditControls.UIButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMotivo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnBuscarMercaderia = New Janus.Windows.EditControls.UIButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCotizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodUniMed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCotizacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Artículo : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cantidad : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(262, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Precio "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(376, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Dscto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Observación : "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Total"
        '
        'txtPreMer
        '
        Me.txtPreMer.BackColor = System.Drawing.SystemColors.Control
        Me.txtPreMer.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtPreMer.DecimalDigits = 4
        Me.txtPreMer.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtPreMer.Location = New System.Drawing.Point(300, 32)
        Me.txtPreMer.Name = "txtPreMer"
        Me.txtPreMer.ReadOnly = True
        Me.txtPreMer.Size = New System.Drawing.Size(71, 20)
        Me.txtPreMer.TabIndex = 11
        Me.txtPreMer.TabStop = False
        Me.txtPreMer.Text = "0.0000"
        Me.txtPreMer.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtPreMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCotizaciones
        '
        cmbCotizaciones_DesignTimeLayout.LayoutString = resources.GetString("cmbCotizaciones_DesignTimeLayout.LayoutString")
        Me.cmbCotizaciones.DesignTimeLayout = cmbCotizaciones_DesignTimeLayout
        Me.cmbCotizaciones.Location = New System.Drawing.Point(82, 32)
        Me.cmbCotizaciones.Name = "cmbCotizaciones"
        Me.cmbCotizaciones.SelectedIndex = -1
        Me.cmbCotizaciones.SelectedItem = Nothing
        Me.cmbCotizaciones.Size = New System.Drawing.Size(90, 20)
        Me.cmbCotizaciones.TabIndex = 10
        Me.cmbCotizaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDscto
        '
        Me.txtDscto.BackColor = System.Drawing.SystemColors.Control
        Me.txtDscto.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtDscto.Location = New System.Drawing.Point(417, 32)
        Me.txtDscto.Name = "txtDscto"
        Me.txtDscto.ReadOnly = True
        Me.txtDscto.Size = New System.Drawing.Size(41, 20)
        Me.txtDscto.TabIndex = 12
        Me.txtDscto.TabStop = False
        Me.txtDscto.Text = "0.00"
        Me.txtDscto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDscto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Location = New System.Drawing.Point(88, 19)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(142, 20)
        Me.txtCodMer.TabIndex = 2
        Me.txtCodMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(88, 47)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(392, 39)
        Me.txtDescripcion.TabIndex = 4
        Me.txtDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtTotal.Location = New System.Drawing.Point(82, 116)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(103, 20)
        Me.txtTotal.TabIndex = 14
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.Location = New System.Drawing.Point(173, 402)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 25)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.Location = New System.Drawing.Point(254, 402)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 25)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.Label11)
        Me.gbDatos.Controls.Add(Me.cmbTipoGasto)
        Me.gbDatos.Controls.Add(Me.txtObservTipoGasto)
        Me.gbDatos.Controls.Add(Me.cmbRubro)
        Me.gbDatos.Controls.Add(Me.lblRubro)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.btnBuscarJob)
        Me.gbDatos.Controls.Add(Me.cmbCodUniMed)
        Me.gbDatos.Controls.Add(Me.txtCodJob)
        Me.gbDatos.Controls.Add(Me.Label13)
        Me.gbDatos.Controls.Add(Me.txtCanMer)
        Me.gbDatos.Controls.Add(Me.gbCotizacion)
        Me.gbDatos.Controls.Add(Me.txtObservacion)
        Me.gbDatos.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbDatos.Controls.Add(Me.txtCodMer)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtDescripcion)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Location = New System.Drawing.Point(8, 3)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(488, 394)
        Me.gbDatos.TabIndex = 21
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 291
        Me.Label11.Text = "Tipo Gasto :"
        '
        'cmbTipoGasto
        '
        Me.cmbTipoGasto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoGasto_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoGasto_DesignTimeLayout.LayoutString")
        Me.cmbTipoGasto.DesignTimeLayout = cmbTipoGasto_DesignTimeLayout
        Me.cmbTipoGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoGasto.Location = New System.Drawing.Point(88, 123)
        Me.cmbTipoGasto.Name = "cmbTipoGasto"
        Me.cmbTipoGasto.SelectedIndex = -1
        Me.cmbTipoGasto.SelectedItem = Nothing
        Me.cmbTipoGasto.Size = New System.Drawing.Size(210, 20)
        Me.cmbTipoGasto.TabIndex = 9
        Me.cmbTipoGasto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObservTipoGasto
        '
        Me.txtObservTipoGasto.ForeColor = System.Drawing.Color.Red
        Me.txtObservTipoGasto.Location = New System.Drawing.Point(88, 150)
        Me.txtObservTipoGasto.Multiline = True
        Me.txtObservTipoGasto.Name = "txtObservTipoGasto"
        Me.txtObservTipoGasto.ReadOnly = True
        Me.txtObservTipoGasto.Size = New System.Drawing.Size(392, 32)
        Me.txtObservTipoGasto.TabIndex = 11
        Me.txtObservTipoGasto.TabStop = False
        '
        'cmbRubro
        '
        Me.cmbRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbRubro_DesignTimeLayout.LayoutString")
        Me.cmbRubro.DesignTimeLayout = cmbRubro_DesignTimeLayout
        Me.cmbRubro.Location = New System.Drawing.Point(360, 123)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.SelectedIndex = -1
        Me.cmbRubro.SelectedItem = Nothing
        Me.cmbRubro.Size = New System.Drawing.Size(120, 20)
        Me.cmbRubro.TabIndex = 10
        Me.cmbRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Location = New System.Drawing.Point(312, 127)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(42, 13)
        Me.lblRubro.TabIndex = 200
        Me.lblRubro.Text = "Rubro :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(186, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Unid.Med. :"
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(453, 94)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(27, 21)
        Me.btnBuscarJob.TabIndex = 8
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'cmbCodUniMed
        '
        cmbCodUniMed_DesignTimeLayout.LayoutString = resources.GetString("cmbCodUniMed_DesignTimeLayout.LayoutString")
        Me.cmbCodUniMed.DesignTimeLayout = cmbCodUniMed_DesignTimeLayout
        Me.cmbCodUniMed.Location = New System.Drawing.Point(248, 95)
        Me.cmbCodUniMed.Name = "cmbCodUniMed"
        Me.cmbCodUniMed.SelectedIndex = -1
        Me.cmbCodUniMed.SelectedItem = Nothing
        Me.cmbCodUniMed.Size = New System.Drawing.Size(64, 20)
        Me.cmbCodUniMed.TabIndex = 6
        Me.cmbCodUniMed.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCodJob
        '
        Me.txtCodJob.Location = New System.Drawing.Point(373, 95)
        Me.txtCodJob.Name = "txtCodJob"
        Me.txtCodJob.Size = New System.Drawing.Size(76, 20)
        Me.txtCodJob.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(337, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 251
        Me.Label13.Text = "# OT : "
        '
        'txtCanMer
        '
        Me.txtCanMer.DecimalDigits = 4
        Me.txtCanMer.Location = New System.Drawing.Point(88, 95)
        Me.txtCanMer.Name = "txtCanMer"
        Me.txtCanMer.Size = New System.Drawing.Size(67, 20)
        Me.txtCanMer.TabIndex = 5
        Me.txtCanMer.Text = "0.0000"
        Me.txtCanMer.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtCanMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbCotizacion
        '
        Me.gbCotizacion.Controls.Add(Me.txtCantidad)
        Me.gbCotizacion.Controls.Add(Me.Label12)
        Me.gbCotizacion.Controls.Add(Me.btnVerCotizaciones)
        Me.gbCotizacion.Controls.Add(Me.Label9)
        Me.gbCotizacion.Controls.Add(Me.Label6)
        Me.gbCotizacion.Controls.Add(Me.txtMotivo)
        Me.gbCotizacion.Controls.Add(Me.cmbCotizaciones)
        Me.gbCotizacion.Controls.Add(Me.txtDscto)
        Me.gbCotizacion.Controls.Add(Me.Label5)
        Me.gbCotizacion.Controls.Add(Me.txtPreMer)
        Me.gbCotizacion.Controls.Add(Me.Label8)
        Me.gbCotizacion.Controls.Add(Me.txtTotal)
        Me.gbCotizacion.Controls.Add(Me.Label4)
        Me.gbCotizacion.Location = New System.Drawing.Point(7, 244)
        Me.gbCotizacion.Name = "gbCotizacion"
        Me.gbCotizacion.Size = New System.Drawing.Size(474, 144)
        Me.gbCotizacion.TabIndex = 23
        Me.gbCotizacion.Text = "Cotización Asignada"
        Me.gbCotizacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.SystemColors.Control
        Me.txtCantidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtCantidad.Location = New System.Drawing.Point(215, 33)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(41, 20)
        Me.txtCantidad.TabIndex = 24
        Me.txtCantidad.TabStop = False
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(181, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Cant."
        '
        'btnVerCotizaciones
        '
        Me.btnVerCotizaciones.Icon = CType(resources.GetObject("btnVerCotizaciones.Icon"), System.Drawing.Icon)
        Me.btnVerCotizaciones.Location = New System.Drawing.Point(114, -1)
        Me.btnVerCotizaciones.Name = "btnVerCotizaciones"
        Me.btnVerCotizaciones.Size = New System.Drawing.Size(121, 23)
        Me.btnVerCotizaciones.TabIndex = 22
        Me.btnVerCotizaciones.TabStop = False
        Me.btnVerCotizaciones.Text = "Ver Cotizaciones"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Motivo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Número"
        '
        'txtMotivo
        '
        Me.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotivo.Location = New System.Drawing.Point(82, 61)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMotivo.Size = New System.Drawing.Size(377, 47)
        Me.txtMotivo.TabIndex = 13
        Me.txtMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(88, 187)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(392, 49)
        Me.txtObservacion.TabIndex = 12
        Me.txtObservacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(234, 18)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarMercaderia.TabIndex = 3
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'frmComSolicitudCompra_AgregarDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(505, 437)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudCompra_AgregarDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmComSolicitudCompra_AgregarDetalle"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCotizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodUniMed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCotizacion.ResumeLayout(False)
        Me.gbCotizacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDscto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbCotizaciones As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtPreMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCodMer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnBuscarMercaderia As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents gbCotizacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnVerCotizaciones As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtCanMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbCodUniMed As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents cmbRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarJob As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtCodJob As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtObservTipoGasto As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbTipoGasto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As Label
End Class
