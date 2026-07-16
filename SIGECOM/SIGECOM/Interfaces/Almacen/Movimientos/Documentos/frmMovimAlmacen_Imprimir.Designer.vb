<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimAlmacen_Imprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimAlmacen_Imprimir))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.grupoOrden = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbPorNumFacAgrup = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbtnFacDestinoAgrup = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnFacUbicacionAgrup = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnFacCodigoAgrup = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorNumFactura = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbPorOrdenCompraAgrup = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbtnDestinoAgrup = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnUbicacionAgrup = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnCodigoAgrup = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorNumOrden = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorDestino = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorUbicacion = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorCodigo = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbOpciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbNotaContabilidad = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbConformidad = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.rbConformidad = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbOrdenCompra = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNumOrden = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbOrdenCompra = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbFacturaLocal = New Janus.Windows.EditControls.UIRadioButton()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grupoOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupoOrden.SuspendLayout()
        CType(Me.gbPorNumFacAgrup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPorNumFacAgrup.SuspendLayout()
        CType(Me.gbPorOrdenCompraAgrup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPorOrdenCompraAgrup.SuspendLayout()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpciones.SuspendLayout()
        CType(Me.gbConformidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConformidad.SuspendLayout()
        CType(Me.gbOrdenCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenCompra.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'grupoOrden
        '
        Me.grupoOrden.Controls.Add(Me.gbPorNumFacAgrup)
        Me.grupoOrden.Controls.Add(Me.rbtnPorNumFactura)
        Me.grupoOrden.Controls.Add(Me.gbPorOrdenCompraAgrup)
        Me.grupoOrden.Controls.Add(Me.rbtnPorNumOrden)
        Me.grupoOrden.Controls.Add(Me.rbtnPorDestino)
        Me.grupoOrden.Controls.Add(Me.rbtnPorUbicacion)
        Me.grupoOrden.Controls.Add(Me.rbtnPorCodigo)
        Me.grupoOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoOrden.Location = New System.Drawing.Point(229, 11)
        Me.grupoOrden.Name = "grupoOrden"
        Me.grupoOrden.Size = New System.Drawing.Size(150, 343)
        Me.grupoOrden.TabIndex = 4
        Me.grupoOrden.Text = "Orden"
        Me.grupoOrden.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbPorNumFacAgrup
        '
        Me.gbPorNumFacAgrup.Controls.Add(Me.rbtnFacDestinoAgrup)
        Me.gbPorNumFacAgrup.Controls.Add(Me.rbtnFacUbicacionAgrup)
        Me.gbPorNumFacAgrup.Controls.Add(Me.rbtnFacCodigoAgrup)
        Me.gbPorNumFacAgrup.Enabled = False
        Me.gbPorNumFacAgrup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPorNumFacAgrup.Location = New System.Drawing.Point(31, 237)
        Me.gbPorNumFacAgrup.Name = "gbPorNumFacAgrup"
        Me.gbPorNumFacAgrup.Size = New System.Drawing.Size(113, 95)
        Me.gbPorNumFacAgrup.TabIndex = 11
        Me.gbPorNumFacAgrup.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbtnFacDestinoAgrup
        '
        Me.rbtnFacDestinoAgrup.AutoSize = True
        Me.rbtnFacDestinoAgrup.Location = New System.Drawing.Point(7, 67)
        Me.rbtnFacDestinoAgrup.Name = "rbtnFacDestinoAgrup"
        Me.rbtnFacDestinoAgrup.Size = New System.Drawing.Size(83, 17)
        Me.rbtnFacDestinoAgrup.TabIndex = 12
        Me.rbtnFacDestinoAgrup.Text = "Por Destino"
        Me.rbtnFacDestinoAgrup.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnFacUbicacionAgrup
        '
        Me.rbtnFacUbicacionAgrup.AutoSize = True
        Me.rbtnFacUbicacionAgrup.Location = New System.Drawing.Point(7, 41)
        Me.rbtnFacUbicacionAgrup.Name = "rbtnFacUbicacionAgrup"
        Me.rbtnFacUbicacionAgrup.Size = New System.Drawing.Size(97, 17)
        Me.rbtnFacUbicacionAgrup.TabIndex = 11
        Me.rbtnFacUbicacionAgrup.Text = "Por Ubicación"
        Me.rbtnFacUbicacionAgrup.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnFacCodigoAgrup
        '
        Me.rbtnFacCodigoAgrup.AutoSize = True
        Me.rbtnFacCodigoAgrup.Checked = True
        Me.rbtnFacCodigoAgrup.Location = New System.Drawing.Point(7, 15)
        Me.rbtnFacCodigoAgrup.Name = "rbtnFacCodigoAgrup"
        Me.rbtnFacCodigoAgrup.Size = New System.Drawing.Size(79, 17)
        Me.rbtnFacCodigoAgrup.TabIndex = 10
        Me.rbtnFacCodigoAgrup.TabStop = True
        Me.rbtnFacCodigoAgrup.Text = "Por Código"
        Me.rbtnFacCodigoAgrup.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorNumFactura
        '
        Me.rbtnPorNumFactura.AutoSize = True
        Me.rbtnPorNumFactura.Location = New System.Drawing.Point(13, 219)
        Me.rbtnPorNumFactura.Name = "rbtnPorNumFactura"
        Me.rbtnPorNumFactura.Size = New System.Drawing.Size(83, 17)
        Me.rbtnPorNumFactura.TabIndex = 10
        Me.rbtnPorNumFactura.Text = "Por Factura"
        Me.rbtnPorNumFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbPorOrdenCompraAgrup
        '
        Me.gbPorOrdenCompraAgrup.Controls.Add(Me.rbtnDestinoAgrup)
        Me.gbPorOrdenCompraAgrup.Controls.Add(Me.rbtnUbicacionAgrup)
        Me.gbPorOrdenCompraAgrup.Controls.Add(Me.rbtnCodigoAgrup)
        Me.gbPorOrdenCompraAgrup.Enabled = False
        Me.gbPorOrdenCompraAgrup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPorOrdenCompraAgrup.Location = New System.Drawing.Point(31, 116)
        Me.gbPorOrdenCompraAgrup.Name = "gbPorOrdenCompraAgrup"
        Me.gbPorOrdenCompraAgrup.Size = New System.Drawing.Size(113, 95)
        Me.gbPorOrdenCompraAgrup.TabIndex = 9
        Me.gbPorOrdenCompraAgrup.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbtnDestinoAgrup
        '
        Me.rbtnDestinoAgrup.AutoSize = True
        Me.rbtnDestinoAgrup.Location = New System.Drawing.Point(7, 67)
        Me.rbtnDestinoAgrup.Name = "rbtnDestinoAgrup"
        Me.rbtnDestinoAgrup.Size = New System.Drawing.Size(83, 17)
        Me.rbtnDestinoAgrup.TabIndex = 12
        Me.rbtnDestinoAgrup.Text = "Por Destino"
        Me.rbtnDestinoAgrup.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnUbicacionAgrup
        '
        Me.rbtnUbicacionAgrup.AutoSize = True
        Me.rbtnUbicacionAgrup.Location = New System.Drawing.Point(7, 41)
        Me.rbtnUbicacionAgrup.Name = "rbtnUbicacionAgrup"
        Me.rbtnUbicacionAgrup.Size = New System.Drawing.Size(97, 17)
        Me.rbtnUbicacionAgrup.TabIndex = 11
        Me.rbtnUbicacionAgrup.Text = "Por Ubicación"
        Me.rbtnUbicacionAgrup.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnCodigoAgrup
        '
        Me.rbtnCodigoAgrup.AutoSize = True
        Me.rbtnCodigoAgrup.Checked = True
        Me.rbtnCodigoAgrup.Location = New System.Drawing.Point(7, 15)
        Me.rbtnCodigoAgrup.Name = "rbtnCodigoAgrup"
        Me.rbtnCodigoAgrup.Size = New System.Drawing.Size(79, 17)
        Me.rbtnCodigoAgrup.TabIndex = 10
        Me.rbtnCodigoAgrup.TabStop = True
        Me.rbtnCodigoAgrup.Text = "Por Código"
        Me.rbtnCodigoAgrup.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorNumOrden
        '
        Me.rbtnPorNumOrden.AutoSize = True
        Me.rbtnPorNumOrden.Location = New System.Drawing.Point(13, 99)
        Me.rbtnPorNumOrden.Name = "rbtnPorNumOrden"
        Me.rbtnPorNumOrden.Size = New System.Drawing.Size(120, 17)
        Me.rbtnPorNumOrden.TabIndex = 6
        Me.rbtnPorNumOrden.Text = "Por Orden Compra"
        Me.rbtnPorNumOrden.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorDestino
        '
        Me.rbtnPorDestino.AutoSize = True
        Me.rbtnPorDestino.Location = New System.Drawing.Point(13, 74)
        Me.rbtnPorDestino.Name = "rbtnPorDestino"
        Me.rbtnPorDestino.Size = New System.Drawing.Size(83, 17)
        Me.rbtnPorDestino.TabIndex = 5
        Me.rbtnPorDestino.Text = "Por Destino"
        Me.rbtnPorDestino.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorUbicacion
        '
        Me.rbtnPorUbicacion.AutoSize = True
        Me.rbtnPorUbicacion.Location = New System.Drawing.Point(13, 48)
        Me.rbtnPorUbicacion.Name = "rbtnPorUbicacion"
        Me.rbtnPorUbicacion.Size = New System.Drawing.Size(97, 17)
        Me.rbtnPorUbicacion.TabIndex = 3
        Me.rbtnPorUbicacion.Text = "Por Ubicación"
        Me.rbtnPorUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorCodigo
        '
        Me.rbtnPorCodigo.AutoSize = True
        Me.rbtnPorCodigo.Checked = True
        Me.rbtnPorCodigo.Location = New System.Drawing.Point(13, 22)
        Me.rbtnPorCodigo.Name = "rbtnPorCodigo"
        Me.rbtnPorCodigo.Size = New System.Drawing.Size(79, 17)
        Me.rbtnPorCodigo.TabIndex = 2
        Me.rbtnPorCodigo.TabStop = True
        Me.rbtnPorCodigo.Text = "Por Código"
        Me.rbtnPorCodigo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.rbNotaContabilidad)
        Me.gbOpciones.Controls.Add(Me.gbConformidad)
        Me.gbOpciones.Controls.Add(Me.rbConformidad)
        Me.gbOpciones.Controls.Add(Me.gbOrdenCompra)
        Me.gbOpciones.Controls.Add(Me.rbOrdenCompra)
        Me.gbOpciones.Controls.Add(Me.rbFacturaLocal)
        Me.gbOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(11, 11)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(204, 236)
        Me.gbOpciones.TabIndex = 5
        Me.gbOpciones.Text = "Opciones"
        Me.gbOpciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbNotaContabilidad
        '
        Me.rbNotaContabilidad.AutoSize = True
        Me.rbNotaContabilidad.Location = New System.Drawing.Point(8, 204)
        Me.rbNotaContabilidad.Name = "rbNotaContabilidad"
        Me.rbNotaContabilidad.Size = New System.Drawing.Size(136, 17)
        Me.rbNotaContabilidad.TabIndex = 10
        Me.rbNotaContabilidad.Text = "Nota de Contabilidad"
        Me.rbNotaContabilidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbConformidad
        '
        Me.gbConformidad.Controls.Add(Me.Label2)
        Me.gbConformidad.Controls.Add(Me.txtFecDoc)
        Me.gbConformidad.Enabled = False
        Me.gbConformidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConformidad.Location = New System.Drawing.Point(8, 146)
        Me.gbConformidad.Name = "gbConformidad"
        Me.gbConformidad.Size = New System.Drawing.Size(189, 42)
        Me.gbConformidad.TabIndex = 9
        Me.gbConformidad.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha :"
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.Visible = False
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Location = New System.Drawing.Point(68, 14)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.Size = New System.Drawing.Size(96, 20)
        Me.txtFecDoc.TabIndex = 9
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'rbConformidad
        '
        Me.rbConformidad.AutoSize = True
        Me.rbConformidad.Location = New System.Drawing.Point(8, 125)
        Me.rbConformidad.Name = "rbConformidad"
        Me.rbConformidad.Size = New System.Drawing.Size(59, 17)
        Me.rbConformidad.TabIndex = 6
        Me.rbConformidad.Text = "Informe"
        Me.rbConformidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbOrdenCompra
        '
        Me.gbOrdenCompra.Controls.Add(Me.txtNumOrden)
        Me.gbOrdenCompra.Controls.Add(Me.Label1)
        Me.gbOrdenCompra.Enabled = False
        Me.gbOrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrdenCompra.Location = New System.Drawing.Point(9, 71)
        Me.gbOrdenCompra.Name = "gbOrdenCompra"
        Me.gbOrdenCompra.Size = New System.Drawing.Size(189, 42)
        Me.gbOrdenCompra.TabIndex = 5
        Me.gbOrdenCompra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumOrden
        '
        Me.txtNumOrden.Location = New System.Drawing.Point(123, 14)
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.Size = New System.Drawing.Size(60, 20)
        Me.txtNumOrden.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "N° Orden Compra :"
        '
        'rbOrdenCompra
        '
        Me.rbOrdenCompra.AutoSize = True
        Me.rbOrdenCompra.Location = New System.Drawing.Point(8, 51)
        Me.rbOrdenCompra.Name = "rbOrdenCompra"
        Me.rbOrdenCompra.Size = New System.Drawing.Size(134, 17)
        Me.rbOrdenCompra.TabIndex = 4
        Me.rbOrdenCompra.Text = "Facturas en Transito"
        Me.rbOrdenCompra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbFacturaLocal
        '
        Me.rbFacturaLocal.AutoSize = True
        Me.rbFacturaLocal.Checked = True
        Me.rbFacturaLocal.Location = New System.Drawing.Point(8, 25)
        Me.rbFacturaLocal.Name = "rbFacturaLocal"
        Me.rbFacturaLocal.Size = New System.Drawing.Size(162, 17)
        Me.rbFacturaLocal.TabIndex = 0
        Me.rbFacturaLocal.TabStop = True
        Me.rbFacturaLocal.Text = "Documento Seleccionado"
        Me.rbFacturaLocal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Cancel_Button.Location = New System.Drawing.Point(118, 318)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(85, 25)
        Me.Cancel_Button.TabIndex = 7
        Me.Cancel_Button.Text = "Cancelar"
        Me.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OK_Button
        '
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_Button.Location = New System.Drawing.Point(36, 318)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(76, 25)
        Me.OK_Button.TabIndex = 6
        Me.OK_Button.Text = "Aceptar"
        Me.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(42, 263)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(70, 43)
        Me.DataGridView1.TabIndex = 8
        Me.DataGridView1.Visible = False
        '
        'frmMovimAlmacen_Imprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 364)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.gbOpciones)
        Me.Controls.Add(Me.grupoOrden)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimAlmacen_Imprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grupoOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupoOrden.ResumeLayout(False)
        CType(Me.gbPorNumFacAgrup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPorNumFacAgrup.ResumeLayout(False)
        CType(Me.gbPorOrdenCompraAgrup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPorOrdenCompraAgrup.ResumeLayout(False)
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpciones.ResumeLayout(False)
        CType(Me.gbConformidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConformidad.ResumeLayout(False)
        Me.gbConformidad.PerformLayout()
        CType(Me.gbOrdenCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenCompra.ResumeLayout(False)
        Me.gbOrdenCompra.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents grupoOrden As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbtnPorDestino As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorUbicacion As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorCodigo As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbOpciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbOrdenCompra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNumOrden As TextBox
    Friend WithEvents rbOrdenCompra As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbFacturaLocal As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents Cancel_Button As Button
    Friend WithEvents OK_Button As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents rbtnPorNumOrden As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbPorOrdenCompraAgrup As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbtnDestinoAgrup As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnUbicacionAgrup As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnCodigoAgrup As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbPorNumFacAgrup As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbtnFacDestinoAgrup As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnFacUbicacionAgrup As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnFacCodigoAgrup As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorNumFactura As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbConformidad As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbConformidad As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbNotaContabilidad As Janus.Windows.EditControls.UIRadioButton
End Class
