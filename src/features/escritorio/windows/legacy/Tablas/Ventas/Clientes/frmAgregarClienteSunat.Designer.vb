<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarClienteSunat
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
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregarClienteSunat))
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblApeMat = New System.Windows.Forms.Label()
        Me.lblApePat = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtApeMat = New System.Windows.Forms.TextBox()
        Me.txtApePat = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtAbrCli = New System.Windows.Forms.TextBox()
        Me.txtDesCli = New System.Windows.Forms.TextBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.btnUbigeo = New System.Windows.Forms.Button()
        Me.txtUbigeo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnConsultaSunat = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNroDoc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gbDatos.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.Label24)
        Me.gbDatos.Controls.Add(Me.lblApeMat)
        Me.gbDatos.Controls.Add(Me.lblApePat)
        Me.gbDatos.Controls.Add(Me.lblNombre)
        Me.gbDatos.Controls.Add(Me.txtApeMat)
        Me.gbDatos.Controls.Add(Me.txtApePat)
        Me.gbDatos.Controls.Add(Me.txtNombre)
        Me.gbDatos.Controls.Add(Me.txtAbrCli)
        Me.gbDatos.Controls.Add(Me.txtDesCli)
        Me.gbDatos.Controls.Add(Me.lblRazonSocial)
        Me.gbDatos.Controls.Add(Me.btnUbigeo)
        Me.gbDatos.Controls.Add(Me.txtUbigeo)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.txtDireccion)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Location = New System.Drawing.Point(12, 34)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(645, 161)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Cliente"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(454, 23)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 61
        Me.Label24.Text = "Abreviatura"
        '
        'lblApeMat
        '
        Me.lblApeMat.AutoSize = True
        Me.lblApeMat.Location = New System.Drawing.Point(7, 86)
        Me.lblApeMat.Name = "lblApeMat"
        Me.lblApeMat.Size = New System.Drawing.Size(44, 13)
        Me.lblApeMat.TabIndex = 60
        Me.lblApeMat.Text = "ApeMat"
        '
        'lblApePat
        '
        Me.lblApePat.AutoSize = True
        Me.lblApePat.Location = New System.Drawing.Point(7, 66)
        Me.lblApePat.Name = "lblApePat"
        Me.lblApePat.Size = New System.Drawing.Size(42, 13)
        Me.lblApePat.TabIndex = 59
        Me.lblApePat.Text = "ApePat"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(7, 45)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(49, 13)
        Me.lblNombre.TabIndex = 58
        Me.lblNombre.Text = "Nombres"
        '
        'txtApeMat
        '
        Me.txtApeMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApeMat.Enabled = False
        Me.txtApeMat.Location = New System.Drawing.Point(80, 83)
        Me.txtApeMat.MaxLength = 50
        Me.txtApeMat.Name = "txtApeMat"
        Me.txtApeMat.Size = New System.Drawing.Size(280, 20)
        Me.txtApeMat.TabIndex = 56
        '
        'txtApePat
        '
        Me.txtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApePat.Enabled = False
        Me.txtApePat.Location = New System.Drawing.Point(80, 62)
        Me.txtApePat.MaxLength = 50
        Me.txtApePat.Name = "txtApePat"
        Me.txtApePat.Size = New System.Drawing.Size(280, 20)
        Me.txtApePat.TabIndex = 55
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(80, 41)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(280, 20)
        Me.txtNombre.TabIndex = 54
        '
        'txtAbrCli
        '
        Me.txtAbrCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbrCli.Enabled = False
        Me.txtAbrCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbrCli.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtAbrCli.Location = New System.Drawing.Point(518, 20)
        Me.txtAbrCli.MaxLength = 20
        Me.txtAbrCli.Name = "txtAbrCli"
        Me.txtAbrCli.Size = New System.Drawing.Size(115, 20)
        Me.txtAbrCli.TabIndex = 53
        Me.txtAbrCli.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDesCli
        '
        Me.txtDesCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesCli.Enabled = False
        Me.txtDesCli.Location = New System.Drawing.Point(80, 20)
        Me.txtDesCli.MaxLength = 120
        Me.txtDesCli.Name = "txtDesCli"
        Me.txtDesCli.Size = New System.Drawing.Size(368, 20)
        Me.txtDesCli.TabIndex = 52
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(7, 23)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 57
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'btnUbigeo
        '
        Me.btnUbigeo.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnUbigeo.Location = New System.Drawing.Point(357, 127)
        Me.btnUbigeo.Name = "btnUbigeo"
        Me.btnUbigeo.Size = New System.Drawing.Size(26, 23)
        Me.btnUbigeo.TabIndex = 7
        Me.btnUbigeo.UseVisualStyleBackColor = True
        '
        'txtUbigeo
        '
        Me.txtUbigeo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUbigeo.Enabled = False
        Me.txtUbigeo.Location = New System.Drawing.Point(80, 128)
        Me.txtUbigeo.MaxLength = 50
        Me.txtUbigeo.Name = "txtUbigeo"
        Me.txtUbigeo.Size = New System.Drawing.Size(276, 20)
        Me.txtUbigeo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ubigeo "
        '
        'txtDireccion
        '
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.Enabled = False
        Me.txtDireccion.Location = New System.Drawing.Point(80, 105)
        Me.txtDireccion.MaxLength = 150
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(361, 20)
        Me.txtDireccion.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Dirección"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(441, 206)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(515, 206)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnConsultaSunat
        '
        Me.btnConsultaSunat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultaSunat.Image = Global.SIGECOM.My.Resources.Resources.Lupa_
        Me.btnConsultaSunat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaSunat.Location = New System.Drawing.Point(371, 4)
        Me.btnConsultaSunat.Name = "btnConsultaSunat"
        Me.btnConsultaSunat.Size = New System.Drawing.Size(132, 26)
        Me.btnConsultaSunat.TabIndex = 81
        Me.btnConsultaSunat.Text = "Consulta en SUNAT"
        Me.btnConsultaSunat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultaSunat.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(18, 11)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(54, 13)
        Me.Label25.TabIndex = 79
        Me.Label25.Text = "Tipo Doc."
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDoc.Location = New System.Drawing.Point(88, 8)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(79, 19)
        Me.cmbTipoDoc.TabIndex = 78
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNroDoc
        '
        Me.txtNroDoc.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtNroDoc.Location = New System.Drawing.Point(250, 8)
        Me.txtNroDoc.MaxLength = 11
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull
        Me.txtNroDoc.Size = New System.Drawing.Size(115, 20)
        Me.txtNroDoc.TabIndex = 75
        Me.txtNroDoc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtNroDoc.UseCompatibleTextRendering = False
        Me.txtNroDoc.Value = CType(resources.GetObject("txtNroDoc.Value"), Object)
        Me.txtNroDoc.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(181, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Nro. Doc."
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(509, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(67, 26)
        Me.btnLimpiar.TabIndex = 82
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'frmAgregarClienteSunat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 240)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnConsultaSunat)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cmbTipoDoc)
        Me.Controls.Add(Me.txtNroDoc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregarClienteSunat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consultar Documento en SUNAT"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnUbigeo As System.Windows.Forms.Button
    Friend WithEvents txtUbigeo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblApeMat As Label
    Friend WithEvents lblApePat As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents txtApeMat As TextBox
    Friend WithEvents txtApePat As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtAbrCli As TextBox
    Friend WithEvents txtDesCli As TextBox
    Friend WithEvents lblRazonSocial As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents btnConsultaSunat As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNroDoc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLimpiar As Button
End Class
