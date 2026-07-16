<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmbarqueValorizar
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
        Dim cmbVia_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmbarqueValorizar))
        Dim dgvFacturas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbVia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtNumRegistro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAduana = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTransporte = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.btnBuscarPais = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtPtoEmb = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtPoliza = New System.Windows.Forms.TextBox()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.txtIPM = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnMostrarGastos = New System.Windows.Forms.Button()
        Me.txtMultas = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPercepcion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotFleteSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtTipCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvFacturas = New Janus.Windows.GridEX.GridEX()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbVia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.txtCodEmbarque)
        Me.gbDatosBusqueda.Controls.Add(Me.Label14)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(7, 5)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(721, 56)
        Me.gbDatosBusqueda.TabIndex = 0
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmbarque.Location = New System.Drawing.Point(8, 31)
        Me.txtCodEmbarque.MaxLength = 30
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(136, 20)
        Me.txtCodEmbarque.TabIndex = 20
        Me.txtCodEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Cod Embarque"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(151, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 22)
        Me.btnBuscar.TabIndex = 22
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(591, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Vía"
        '
        'cmbVia
        '
        Me.cmbVia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbVia_DesignTimeLayout.LayoutString = resources.GetString("cmbVia_DesignTimeLayout.LayoutString")
        Me.cmbVia.DesignTimeLayout = cmbVia_DesignTimeLayout
        Me.cmbVia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVia.Location = New System.Drawing.Point(617, 43)
        Me.cmbVia.Name = "cmbVia"
        Me.cmbVia.SelectedIndex = -1
        Me.cmbVia.SelectedItem = Nothing
        Me.cmbVia.Size = New System.Drawing.Size(91, 20)
        Me.cmbVia.TabIndex = 7
        Me.cmbVia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(360, 432)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 26
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(277, 432)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 25
        Me.btnAceptar.Text = "Valorizar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtNumRegistro
        '
        Me.txtNumRegistro.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRegistro.Location = New System.Drawing.Point(70, 19)
        Me.txtNumRegistro.Name = "txtNumRegistro"
        Me.txtNumRegistro.Size = New System.Drawing.Size(91, 20)
        Me.txtNumRegistro.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Nro Ingreso"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(171, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Agencia Aduana"
        '
        'txtAduana
        '
        Me.txtAduana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAduana.Location = New System.Drawing.Point(260, 19)
        Me.txtAduana.Name = "txtAduana"
        Me.txtAduana.ReadOnly = True
        Me.txtAduana.Size = New System.Drawing.Size(157, 20)
        Me.txtAduana.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(445, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Agencia Transp."
        '
        'txtTransporte
        '
        Me.txtTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransporte.Location = New System.Drawing.Point(531, 19)
        Me.txtTransporte.Name = "txtTransporte"
        Me.txtTransporte.Size = New System.Drawing.Size(177, 20)
        Me.txtTransporte.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Pais Origen"
        '
        'txtOrigen
        '
        Me.txtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrigen.Location = New System.Drawing.Point(69, 43)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(175, 20)
        Me.txtOrigen.TabIndex = 4
        '
        'btnBuscarPais
        '
        Me.btnBuscarPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPais.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPais.Location = New System.Drawing.Point(245, 42)
        Me.btnBuscarPais.Name = "btnBuscarPais"
        Me.btnBuscarPais.Size = New System.Drawing.Size(27, 22)
        Me.btnBuscarPais.TabIndex = 5
        Me.btnBuscarPais.TabStop = False
        Me.btnBuscarPais.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(325, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Fact. Aduana"
        '
        'txtFactura
        '
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(402, 43)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(129, 20)
        Me.txtFactura.TabIndex = 6
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(6, 70)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(77, 13)
        Me.Label44.TabIndex = 82
        Me.Label44.Text = "Pto. Embarque"
        '
        'txtPtoEmb
        '
        Me.txtPtoEmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPtoEmb.Location = New System.Drawing.Point(85, 67)
        Me.txtPtoEmb.Name = "txtPtoEmb"
        Me.txtPtoEmb.Size = New System.Drawing.Size(180, 20)
        Me.txtPtoEmb.TabIndex = 8
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(417, 70)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 13)
        Me.Label24.TabIndex = 88
        Me.Label24.Text = "Poliza"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(129, 95)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 13)
        Me.Label28.TabIndex = 91
        Me.Label28.Text = "I.G.V.  $."
        Me.Label28.Visible = False
        '
        'txtPoliza
        '
        Me.txtPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPoliza.Location = New System.Drawing.Point(454, 67)
        Me.txtPoliza.Name = "txtPoliza"
        Me.txtPoliza.Size = New System.Drawing.Size(146, 20)
        Me.txtPoliza.TabIndex = 10
        '
        'txtIgv
        '
        Me.txtIgv.DecimalDigits = 4
        Me.txtIgv.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIgv.Location = New System.Drawing.Point(184, 91)
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.Size = New System.Drawing.Size(77, 20)
        Me.txtIgv.TabIndex = 12
        Me.txtIgv.Text = "0.0000"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtIgv.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(272, 70)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(31, 13)
        Me.Label25.TabIndex = 100
        Me.Label25.Text = "Guía"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(272, 95)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(38, 13)
        Me.Label30.TabIndex = 101
        Me.Label30.Text = "IPM $."
        Me.Label30.Visible = False
        '
        'txtGuia
        '
        Me.txtGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuia.Location = New System.Drawing.Point(305, 67)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(107, 20)
        Me.txtGuia.TabIndex = 9
        '
        'txtIPM
        '
        Me.txtIPM.DecimalDigits = 4
        Me.txtIPM.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIPM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIPM.Location = New System.Drawing.Point(313, 91)
        Me.txtIPM.Name = "txtIPM"
        Me.txtIPM.Size = New System.Drawing.Size(78, 20)
        Me.txtIPM.TabIndex = 13
        Me.txtIPM.Text = "0.0000"
        Me.txtIPM.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtIPM.Visible = False
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnMostrarGastos)
        Me.UiGroupBox2.Controls.Add(Me.txtMultas)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.txtPercepcion)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.txtTotFleteSol)
        Me.UiGroupBox2.Controls.Add(Me.Label19)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarProveedor)
        Me.UiGroupBox2.Controls.Add(Me.txtNumRegistro)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtTipCambio)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.cmbVia)
        Me.UiGroupBox2.Controls.Add(Me.txtIPM)
        Me.UiGroupBox2.Controls.Add(Me.txtGuia)
        Me.UiGroupBox2.Controls.Add(Me.Label30)
        Me.UiGroupBox2.Controls.Add(Me.Label25)
        Me.UiGroupBox2.Controls.Add(Me.txtIgv)
        Me.UiGroupBox2.Controls.Add(Me.txtPoliza)
        Me.UiGroupBox2.Controls.Add(Me.Label24)
        Me.UiGroupBox2.Controls.Add(Me.Label28)
        Me.UiGroupBox2.Controls.Add(Me.txtPtoEmb)
        Me.UiGroupBox2.Controls.Add(Me.Label44)
        Me.UiGroupBox2.Controls.Add(Me.txtFactura)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPais)
        Me.UiGroupBox2.Controls.Add(Me.txtOrigen)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtTransporte)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtAduana)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Location = New System.Drawing.Point(7, 265)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(721, 152)
        Me.UiGroupBox2.TabIndex = 0
        Me.UiGroupBox2.Text = "Datos de Factura"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnMostrarGastos
        '
        Me.btnMostrarGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarGastos.Image = CType(resources.GetObject("btnMostrarGastos.Image"), System.Drawing.Image)
        Me.btnMostrarGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMostrarGastos.Location = New System.Drawing.Point(204, 116)
        Me.btnMostrarGastos.Name = "btnMostrarGastos"
        Me.btnMostrarGastos.Size = New System.Drawing.Size(165, 27)
        Me.btnMostrarGastos.TabIndex = 133
        Me.btnMostrarGastos.TabStop = False
        Me.btnMostrarGastos.Text = "Mostrar Gastos"
        Me.btnMostrarGastos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMostrarGastos.UseVisualStyleBackColor = True
        '
        'txtMultas
        '
        Me.txtMultas.DecimalDigits = 4
        Me.txtMultas.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMultas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMultas.Location = New System.Drawing.Point(630, 91)
        Me.txtMultas.Name = "txtMultas"
        Me.txtMultas.Size = New System.Drawing.Size(79, 20)
        Me.txtMultas.TabIndex = 15
        Me.txtMultas.Text = "0.0000"
        Me.txtMultas.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtMultas.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(571, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Multas S/."
        Me.Label2.Visible = False
        '
        'txtPercepcion
        '
        Me.txtPercepcion.DecimalDigits = 4
        Me.txtPercepcion.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPercepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercepcion.Location = New System.Drawing.Point(480, 91)
        Me.txtPercepcion.Name = "txtPercepcion"
        Me.txtPercepcion.Size = New System.Drawing.Size(79, 20)
        Me.txtPercepcion.TabIndex = 14
        Me.txtPercepcion.Text = "0.0000"
        Me.txtPercepcion.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtPercepcion.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(399, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Percepción S/."
        Me.Label1.Visible = False
        '
        'txtTotFleteSol
        '
        Me.txtTotFleteSol.DecimalDigits = 3
        Me.txtTotFleteSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotFleteSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotFleteSol.Location = New System.Drawing.Point(79, 116)
        Me.txtTotFleteSol.Name = "txtTotFleteSol"
        Me.txtTotFleteSol.Size = New System.Drawing.Size(102, 20)
        Me.txtTotFleteSol.TabIndex = 16
        Me.txtTotFleteSol.Text = "0.000"
        Me.txtTotFleteSol.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTotFleteSol.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(7, 119)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 128
        Me.Label19.Text = "Total Flete $."
        Me.Label19.Visible = False
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(418, 18)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 105
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtTipCambio
        '
        Me.txtTipCambio.DecimalDigits = 3
        Me.txtTipCambio.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCambio.Location = New System.Drawing.Point(73, 91)
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.Size = New System.Drawing.Size(46, 20)
        Me.txtTipCambio.TabIndex = 11
        Me.txtTipCambio.Text = "0.000"
        Me.txtTipCambio.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Tipo Cambio"
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        dgvFacturas_DesignTimeLayout.LayoutString = resources.GetString("dgvFacturas_DesignTimeLayout.LayoutString")
        Me.dgvFacturas.DesignTimeLayout = dgvFacturas_DesignTimeLayout
        Me.dgvFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvFacturas.GroupByBoxVisible = False
        Me.dgvFacturas.Location = New System.Drawing.Point(7, 67)
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvFacturas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvFacturas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvFacturas.Size = New System.Drawing.Size(720, 192)
        Me.dgvFacturas.TabIndex = 229
        Me.dgvFacturas.TabStop = False
        Me.dgvFacturas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmEmbarqueValorizar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(742, 487)
        Me.Controls.Add(Me.dgvFacturas)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmbarqueValorizar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valorizar Embarque"
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbVia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbVia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtIPM As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPoliza As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPtoEmb As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPais As System.Windows.Forms.Button
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTransporte As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAduana As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumRegistro As System.Windows.Forms.TextBox
    Friend WithEvents txtTipCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents dgvFacturas As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtTotFleteSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtPercepcion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMultas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMostrarGastos As Button
End Class
