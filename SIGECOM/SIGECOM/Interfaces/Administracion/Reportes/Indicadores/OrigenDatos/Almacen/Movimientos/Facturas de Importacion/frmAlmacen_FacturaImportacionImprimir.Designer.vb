<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlmacen_FacturaImportacionImprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlmacen_FacturaImportacionImprimir))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OK_Button = New System.Windows.Forms.Button
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.rbConformidad = New Janus.Windows.EditControls.UIRadioButton
        Me.rbListGeneral = New Janus.Windows.EditControls.UIRadioButton
        Me.rbListado = New Janus.Windows.EditControls.UIRadioButton
        Me.grupoOrden = New Janus.Windows.EditControls.UIGroupBox
        Me.rbtnPorUbicacion = New Janus.Windows.EditControls.UIRadioButton
        Me.rbtnPorCodigo = New Janus.Windows.EditControls.UIRadioButton
        Me.rbtnPorItem = New Janus.Windows.EditControls.UIRadioButton
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.grupoOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupoOrden.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(72, 166)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(173, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Cancel_Button.Location = New System.Drawing.Point(94, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(70, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(80, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        Me.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbConformidad)
        Me.UiGroupBox1.Controls.Add(Me.rbListGeneral)
        Me.UiGroupBox1.Controls.Add(Me.rbListado)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 26)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(161, 108)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Opciones"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbConformidad
        '
        Me.rbConformidad.Location = New System.Drawing.Point(15, 51)
        Me.rbConformidad.Name = "rbConformidad"
        Me.rbConformidad.Size = New System.Drawing.Size(99, 15)
        Me.rbConformidad.TabIndex = 2
        Me.rbConformidad.Text = "Conformidad"
        Me.rbConformidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbListGeneral
        '
        Me.rbListGeneral.Location = New System.Drawing.Point(15, 74)
        Me.rbListGeneral.Name = "rbListGeneral"
        Me.rbListGeneral.Size = New System.Drawing.Size(124, 17)
        Me.rbListGeneral.TabIndex = 1
        Me.rbListGeneral.Text = "Listado General"
        Me.rbListGeneral.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbListado
        '
        Me.rbListado.Checked = True
        Me.rbListado.Location = New System.Drawing.Point(15, 27)
        Me.rbListado.Name = "rbListado"
        Me.rbListado.Size = New System.Drawing.Size(140, 18)
        Me.rbListado.TabIndex = 0
        Me.rbListado.TabStop = True
        Me.rbListado.Text = "Listado por Almacén"
        Me.rbListado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'grupoOrden
        '
        Me.grupoOrden.Controls.Add(Me.rbtnPorUbicacion)
        Me.grupoOrden.Controls.Add(Me.rbtnPorCodigo)
        Me.grupoOrden.Controls.Add(Me.rbtnPorItem)
        Me.grupoOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoOrden.Location = New System.Drawing.Point(175, 26)
        Me.grupoOrden.Name = "grupoOrden"
        Me.grupoOrden.Size = New System.Drawing.Size(131, 108)
        Me.grupoOrden.TabIndex = 3
        Me.grupoOrden.Text = "Orden"
        Me.grupoOrden.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbtnPorUbicacion
        '
        Me.rbtnPorUbicacion.Location = New System.Drawing.Point(15, 75)
        Me.rbtnPorUbicacion.Name = "rbtnPorUbicacion"
        Me.rbtnPorUbicacion.Size = New System.Drawing.Size(99, 15)
        Me.rbtnPorUbicacion.TabIndex = 3
        Me.rbtnPorUbicacion.Text = "Por Ubicación"
        Me.rbtnPorUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorCodigo
        '
        Me.rbtnPorCodigo.Location = New System.Drawing.Point(15, 51)
        Me.rbtnPorCodigo.Name = "rbtnPorCodigo"
        Me.rbtnPorCodigo.Size = New System.Drawing.Size(99, 15)
        Me.rbtnPorCodigo.TabIndex = 2
        Me.rbtnPorCodigo.Text = "Por Código"
        Me.rbtnPorCodigo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorItem
        '
        Me.rbtnPorItem.Checked = True
        Me.rbtnPorItem.Location = New System.Drawing.Point(15, 27)
        Me.rbtnPorItem.MaximumSize = New System.Drawing.Size(87, 16)
        Me.rbtnPorItem.Name = "rbtnPorItem"
        Me.rbtnPorItem.Size = New System.Drawing.Size(87, 16)
        Me.rbtnPorItem.TabIndex = 0
        Me.rbtnPorItem.TabStop = True
        Me.rbtnPorItem.Text = "Por Item"
        Me.rbtnPorItem.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'frmAlmacen_FacturaImportacionImprimir
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(323, 212)
        Me.Controls.Add(Me.grupoOrden)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(309, 240)
        Me.Name = "frmAlmacen_FacturaImportacionImprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imprimir Factura de Importación"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.grupoOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupoOrden.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbConformidad As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbListGeneral As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbListado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents grupoOrden As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbtnPorCodigo As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorItem As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorUbicacion As Janus.Windows.EditControls.UIRadioButton

End Class
