<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOcurrenciaCliente
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
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOcurrenciaCliente))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbOcurrencia = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbOportunidad = New System.Windows.Forms.CheckBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.cbEnvioCorreo = New System.Windows.Forms.CheckBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbOcurrencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOcurrencia.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnCancelar.Location = New System.Drawing.Point(428, 270)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 28)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(351, 53)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 9
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(397, 49)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.ShowNullButton = True
        Me.txtFecha.Size = New System.Drawing.Size(92, 20)
        Me.txtFecha.TabIndex = 5
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.AcceptsTab = True
        Me.txtObservacion.Location = New System.Drawing.Point(122, 78)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(367, 117)
        Me.txtObservacion.TabIndex = 7
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(122, 20)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(342, 20)
        Me.txtCliente.TabIndex = 0
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(466, 19)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 1
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 123)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Observación"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Cliente"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(344, 270)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 28)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 266
        Me.Label6.Text = "Unidad Negocio"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(122, 49)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(213, 20)
        Me.cmbUnidad.TabIndex = 265
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbOcurrencia
        '
        Me.gbOcurrencia.Controls.Add(Me.cbOportunidad)
        Me.gbOcurrencia.Controls.Add(Me.txtEmail)
        Me.gbOcurrencia.Controls.Add(Me.cbEnvioCorreo)
        Me.gbOcurrencia.Controls.Add(Me.Label6)
        Me.gbOcurrencia.Controls.Add(Me.txtCliente)
        Me.gbOcurrencia.Controls.Add(Me.cmbUnidad)
        Me.gbOcurrencia.Controls.Add(Me.Label12)
        Me.gbOcurrencia.Controls.Add(Me.lblFecha)
        Me.gbOcurrencia.Controls.Add(Me.Label21)
        Me.gbOcurrencia.Controls.Add(Me.txtFecha)
        Me.gbOcurrencia.Controls.Add(Me.btnBuscarCliente)
        Me.gbOcurrencia.Controls.Add(Me.txtObservacion)
        Me.gbOcurrencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOcurrencia.Location = New System.Drawing.Point(9, 8)
        Me.gbOcurrencia.Name = "gbOcurrencia"
        Me.gbOcurrencia.Size = New System.Drawing.Size(499, 255)
        Me.gbOcurrencia.TabIndex = 205
        Me.gbOcurrencia.Text = "Datos de la Ocurrencia"
        Me.gbOcurrencia.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbOportunidad
        '
        Me.cbOportunidad.AutoSize = True
        Me.cbOportunidad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbOportunidad.Location = New System.Drawing.Point(11, 202)
        Me.cbOportunidad.Name = "cbOportunidad"
        Me.cbOportunidad.Size = New System.Drawing.Size(214, 17)
        Me.cbOportunidad.TabIndex = 269
        Me.cbOportunidad.Text = "Es una Oportunidad de Negocio?"
        Me.cbOportunidad.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(122, 223)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(367, 20)
        Me.txtEmail.TabIndex = 268
        '
        'cbEnvioCorreo
        '
        Me.cbEnvioCorreo.AutoSize = True
        Me.cbEnvioCorreo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbEnvioCorreo.Location = New System.Drawing.Point(11, 225)
        Me.cbEnvioCorreo.Name = "cbEnvioCorreo"
        Me.cbEnvioCorreo.Size = New System.Drawing.Size(103, 17)
        Me.cbEnvioCorreo.TabIndex = 267
        Me.cbEnvioCorreo.Text = "Enviar Correo"
        Me.cbEnvioCorreo.UseVisualStyleBackColor = True
        '
        'frmOcurrenciaCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(516, 306)
        Me.Controls.Add(Me.gbOcurrencia)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOcurrenciaCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Ocurrencia"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbOcurrencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOcurrencia.ResumeLayout(False)
        Me.gbOcurrencia.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbOcurrencia As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbEnvioCorreo As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents cbOportunidad As CheckBox
End Class
