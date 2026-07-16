<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicituCompra_Generar
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
        Me.components = New System.ComponentModel.Container
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.btnSalir = New Janus.Windows.EditControls.UIButton
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton
        Me.cmbCodPago = New Janus.Windows.EditControls.UIComboBox
        Me.cbFecha = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.txtProveedor = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txCodProveedor = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtNumOrden = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnSalir)
        Me.UiGroupBox1.Controls.Add(Me.btnAceptar)
        Me.UiGroupBox1.Controls.Add(Me.cmbCodPago)
        Me.UiGroupBox1.Controls.Add(Me.cbFecha)
        Me.UiGroupBox1.Controls.Add(Me.txtProveedor)
        Me.UiGroupBox1.Controls.Add(Me.txCodProveedor)
        Me.UiGroupBox1.Controls.Add(Me.txtNumOrden)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 8)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(386, 258)
        Me.UiGroupBox1.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.Location = New System.Drawing.Point(218, 209)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Cancelar"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.Location = New System.Drawing.Point(93, 209)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'cmbCodPago
        '
        Me.cmbCodPago.Location = New System.Drawing.Point(109, 157)
        Me.cmbCodPago.Name = "cmbCodPago"
        Me.cmbCodPago.Size = New System.Drawing.Size(176, 20)
        Me.cmbCodPago.TabIndex = 9
        Me.cmbCodPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbFecha
        '
        '
        '
        '
        Me.cbFecha.DropDownCalendar.Name = ""
        Me.cbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecha.Location = New System.Drawing.Point(109, 125)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(95, 20)
        Me.cbFecha.TabIndex = 8
        Me.cbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.Location = New System.Drawing.Point(109, 91)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(215, 20)
        Me.txtProveedor.TabIndex = 6
        Me.txtProveedor.TabStop = False
        Me.txtProveedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txCodProveedor
        '
        Me.txCodProveedor.Location = New System.Drawing.Point(109, 65)
        Me.txCodProveedor.Name = "txCodProveedor"
        Me.txCodProveedor.Size = New System.Drawing.Size(121, 20)
        Me.txCodProveedor.TabIndex = 5
        Me.txCodProveedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumOrden
        '
        Me.txtNumOrden.Location = New System.Drawing.Point(109, 33)
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.Size = New System.Drawing.Size(121, 20)
        Me.txtNumOrden.TabIndex = 4
        Me.txtNumOrden.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Forma Pago : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Proveedor : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Num.Orden : "
        '
        'frmComSolicituCompra_Generar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(405, 276)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicituCompra_Generar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmComSolicituCompra_Generar"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtProveedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txCodProveedor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNumOrden As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCodPago As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
End Class
