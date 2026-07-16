<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDespachoDetalle
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDespachoDetalle))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCanBultos = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTransporte = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumGuia = New System.Windows.Forms.TextBox()
        Me.lblguia = New System.Windows.Forms.Label()
        Me.btnBuscarguia = New System.Windows.Forms.Button()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox2.Controls.Add(Me.txtCanBultos)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtTransporte)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.txtDestino)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.txtCliente)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtNumGuia)
        Me.UiGroupBox2.Controls.Add(Me.lblguia)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarguia)
        Me.UiGroupBox2.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(527, 253)
        Me.UiGroupBox2.TabIndex = 187
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtCanBultos
        '
        Me.txtCanBultos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCanBultos.Location = New System.Drawing.Point(104, 137)
        Me.txtCanBultos.Maximum = 300
        Me.txtCanBultos.MaxLength = 200
        Me.txtCanBultos.Minimum = 1
        Me.txtCanBultos.Name = "txtCanBultos"
        Me.txtCanBultos.Size = New System.Drawing.Size(58, 20)
        Me.txtCanBultos.TabIndex = 6
        Me.txtCanBultos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCanBultos.Value = 1
        Me.txtCanBultos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Bultos :"
        '
        'txtTransporte
        '
        Me.txtTransporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTransporte.Location = New System.Drawing.Point(104, 110)
        Me.txtTransporte.MaxLength = 100
        Me.txtTransporte.Name = "txtTransporte"
        Me.txtTransporte.Size = New System.Drawing.Size(407, 20)
        Me.txtTransporte.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Transporte :"
        '
        'txtDestino
        '
        Me.txtDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDestino.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDestino.Location = New System.Drawing.Point(104, 82)
        Me.txtDestino.MaxLength = 100
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(407, 20)
        Me.txtDestino.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Destino :"
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(104, 54)
        Me.txtCliente.MaxLength = 100
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(407, 20)
        Me.txtCliente.TabIndex = 3
        Me.txtCliente.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Cliente :"
        '
        'txtNumGuia
        '
        Me.txtNumGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumGuia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNumGuia.Location = New System.Drawing.Point(104, 26)
        Me.txtNumGuia.MaxLength = 200
        Me.txtNumGuia.Name = "txtNumGuia"
        Me.txtNumGuia.ReadOnly = True
        Me.txtNumGuia.Size = New System.Drawing.Size(92, 20)
        Me.txtNumGuia.TabIndex = 1
        Me.txtNumGuia.TabStop = False
        Me.txtNumGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblguia
        '
        Me.lblguia.AutoSize = True
        Me.lblguia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblguia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblguia.Location = New System.Drawing.Point(12, 29)
        Me.lblguia.Name = "lblguia"
        Me.lblguia.Size = New System.Drawing.Size(58, 13)
        Me.lblguia.TabIndex = 166
        Me.lblguia.Text = "Número :"
        '
        'btnBuscarguia
        '
        Me.btnBuscarguia.Image = CType(resources.GetObject("btnBuscarguia.Image"), System.Drawing.Image)
        Me.btnBuscarguia.Location = New System.Drawing.Point(197, 25)
        Me.btnBuscarguia.Name = "btnBuscarguia"
        Me.btnBuscarguia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarguia.TabIndex = 2
        Me.btnBuscarguia.TabStop = False
        Me.btnBuscarguia.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(104, 163)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(404, 73)
        Me.txtObservacion.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 177)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(86, 13)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Observación :"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(282, 268)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 27)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "Cancelar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(204, 268)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(72, 27)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmDespachoDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(567, 319)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDespachoDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documento de Despacho"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents txtNumGuia As TextBox
    Friend WithEvents lblguia As Label
    Friend WithEvents btnBuscarguia As Button
    Friend WithEvents txtTransporte As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDestino As TextBox
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCanBultos As Janus.Windows.GridEX.EditControls.IntegerUpDown
End Class
