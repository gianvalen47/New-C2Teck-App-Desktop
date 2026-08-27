<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarPedido_PedidoInterno
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerarPedido_PedidoInterno))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbNuevocodigo = New System.Windows.Forms.GroupBox()
        Me.btnBuscarFacturaImportacion = New System.Windows.Forms.Button()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtalmacen = New System.Windows.Forms.TextBox()
        Me.btnBuscarAlmacen = New System.Windows.Forms.Button()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNumPed = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.gbSubDatos1 = New System.Windows.Forms.GroupBox()
        Me.rbAgregarPedido = New System.Windows.Forms.RadioButton()
        Me.rbGenerarPedido = New System.Windows.Forms.RadioButton()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtFechaPromesa = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNuevocodigo.SuspendLayout()
        Me.gbSubDatos1.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbNuevocodigo
        '
        Me.gbNuevocodigo.BackColor = System.Drawing.SystemColors.Control
        Me.gbNuevocodigo.Controls.Add(Me.txtFechaPromesa)
        Me.gbNuevocodigo.Controls.Add(Me.Label2)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarFacturaImportacion)
        Me.gbNuevocodigo.Controls.Add(Me.txtFecha)
        Me.gbNuevocodigo.Controls.Add(Me.Label15)
        Me.gbNuevocodigo.Controls.Add(Me.txtalmacen)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarAlmacen)
        Me.gbNuevocodigo.Controls.Add(Me.txtProveedor)
        Me.gbNuevocodigo.Controls.Add(Me.Label3)
        Me.gbNuevocodigo.Controls.Add(Me.txtObservacion)
        Me.gbNuevocodigo.Controls.Add(Me.Label21)
        Me.gbNuevocodigo.Controls.Add(Me.txtNumPed)
        Me.gbNuevocodigo.Controls.Add(Me.Label1)
        Me.gbNuevocodigo.Controls.Add(Me.Label12)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarProveedor)
        Me.gbNuevocodigo.Location = New System.Drawing.Point(9, 41)
        Me.gbNuevocodigo.Name = "gbNuevocodigo"
        Me.gbNuevocodigo.Size = New System.Drawing.Size(384, 169)
        Me.gbNuevocodigo.TabIndex = 1
        Me.gbNuevocodigo.TabStop = False
        Me.gbNuevocodigo.Text = "Datos del Pedido"
        '
        'btnBuscarFacturaImportacion
        '
        Me.btnBuscarFacturaImportacion.Image = CType(resources.GetObject("btnBuscarFacturaImportacion.Image"), System.Drawing.Image)
        Me.btnBuscarFacturaImportacion.Location = New System.Drawing.Point(192, 37)
        Me.btnBuscarFacturaImportacion.Name = "btnBuscarFacturaImportacion"
        Me.btnBuscarFacturaImportacion.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarFacturaImportacion.TabIndex = 12
        Me.btnBuscarFacturaImportacion.TabStop = False
        Me.btnBuscarFacturaImportacion.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.txtFecha.Location = New System.Drawing.Point(73, 61)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ShowNullButton = True
        Me.txtFecha.Size = New System.Drawing.Size(98, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Fecha"
        '
        'txtalmacen
        '
        Me.txtalmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtalmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtalmacen.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtalmacen.Location = New System.Drawing.Point(73, 85)
        Me.txtalmacen.MaxLength = 3
        Me.txtalmacen.Name = "txtalmacen"
        Me.txtalmacen.ReadOnly = True
        Me.txtalmacen.Size = New System.Drawing.Size(281, 20)
        Me.txtalmacen.TabIndex = 4
        '
        'btnBuscarAlmacen
        '
        Me.btnBuscarAlmacen.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarAlmacen.Location = New System.Drawing.Point(354, 84)
        Me.btnBuscarAlmacen.Name = "btnBuscarAlmacen"
        Me.btnBuscarAlmacen.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarAlmacen.TabIndex = 5
        Me.btnBuscarAlmacen.TabStop = False
        Me.btnBuscarAlmacen.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(74, 15)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(281, 20)
        Me.txtProveedor.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Almacén"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(73, 108)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(306, 47)
        Me.txtObservacion.TabIndex = 6
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 111)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 13)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Observación"
        '
        'txtNumPed
        '
        Me.txtNumPed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumPed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPed.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumPed.Location = New System.Drawing.Point(73, 38)
        Me.txtNumPed.MaxLength = 50
        Me.txtNumPed.Name = "txtNumPed"
        Me.txtNumPed.Size = New System.Drawing.Size(115, 20)
        Me.txtNumPed.TabIndex = 1
        Me.txtNumPed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Número"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Proveedor"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(355, 14)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 0
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'gbSubDatos1
        '
        Me.gbSubDatos1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbSubDatos1.Controls.Add(Me.rbAgregarPedido)
        Me.gbSubDatos1.Controls.Add(Me.rbGenerarPedido)
        Me.gbSubDatos1.Location = New System.Drawing.Point(9, 8)
        Me.gbSubDatos1.Name = "gbSubDatos1"
        Me.gbSubDatos1.Size = New System.Drawing.Size(384, 32)
        Me.gbSubDatos1.TabIndex = 0
        Me.gbSubDatos1.TabStop = False
        '
        'rbAgregarPedido
        '
        Me.rbAgregarPedido.AutoSize = True
        Me.rbAgregarPedido.Location = New System.Drawing.Point(217, 10)
        Me.rbAgregarPedido.Name = "rbAgregarPedido"
        Me.rbAgregarPedido.Size = New System.Drawing.Size(128, 17)
        Me.rbAgregarPedido.TabIndex = 1
        Me.rbAgregarPedido.TabStop = True
        Me.rbAgregarPedido.Text = "Agregar en un Pedido"
        Me.rbAgregarPedido.UseVisualStyleBackColor = True
        '
        'rbGenerarPedido
        '
        Me.rbGenerarPedido.AutoSize = True
        Me.rbGenerarPedido.Checked = True
        Me.rbGenerarPedido.Location = New System.Drawing.Point(31, 10)
        Me.rbGenerarPedido.Name = "rbGenerarPedido"
        Me.rbGenerarPedido.Size = New System.Drawing.Size(134, 17)
        Me.rbGenerarPedido.TabIndex = 0
        Me.rbGenerarPedido.TabStop = True
        Me.rbGenerarPedido.Text = "Generar Nuevo Pedido"
        Me.rbGenerarPedido.UseVisualStyleBackColor = True
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.gbNuevocodigo)
        Me.gbDatos.Controls.Add(Me.gbSubDatos1)
        Me.gbDatos.Location = New System.Drawing.Point(2, -4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(402, 209)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(243, 211)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.Text = "Generar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(317, 211)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtFechaPromesa
        '
        '
        '
        '
        Me.txtFechaPromesa.DropDownCalendar.Name = ""
        Me.txtFechaPromesa.DropDownCalendar.Visible = False
        Me.txtFechaPromesa.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaPromesa.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.txtFechaPromesa.Location = New System.Drawing.Point(280, 61)
        Me.txtFechaPromesa.Name = "txtFechaPromesa"
        Me.txtFechaPromesa.NullButtonText = "Ninguno"
        Me.txtFechaPromesa.ShowNullButton = True
        Me.txtFechaPromesa.Size = New System.Drawing.Size(98, 20)
        Me.txtFechaPromesa.TabIndex = 13
        Me.txtFechaPromesa.TodayButtonText = "Hoy"
        Me.txtFechaPromesa.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Fecha Promesa"
        '
        'frmGenerarPedido_PedidoInterno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 245)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGenerarPedido_PedidoInterno"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generar un Pedido de Importación"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNuevocodigo.ResumeLayout(False)
        Me.gbNuevocodigo.PerformLayout()
        Me.gbSubDatos1.ResumeLayout(False)
        Me.gbSubDatos1.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents gbNuevocodigo As System.Windows.Forms.GroupBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtalmacen As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarAlmacen As System.Windows.Forms.Button
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNumPed As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gbSubDatos1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAgregarPedido As System.Windows.Forms.RadioButton
    Friend WithEvents rbGenerarPedido As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscarFacturaImportacion As System.Windows.Forms.Button
    Friend WithEvents txtFechaPromesa As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As Label
End Class
