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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlmacen_FacturaImportacionImprimir))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbOpciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbEmbarque = New Janus.Windows.EditControls.UIGroupBox()
        Me.ckTodosAlmacen = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNroPaquete = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.rbEmbarque = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbListadoxFecha = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbConformidad = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbListGeneral = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbListado = New Janus.Windows.EditControls.UIRadioButton()
        Me.grupoOrden = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbOrdenFactura = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbtnPorCodigoFac = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorItemFac = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorDestino = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorNumFactura = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorUbicacion = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorCodigo = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbtnPorItem = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbMostrarStock = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDisponible = New System.Windows.Forms.RadioButton()
        Me.rbFisico = New System.Windows.Forms.RadioButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpciones.SuspendLayout()
        CType(Me.gbEmbarque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEmbarque.SuspendLayout()
        CType(Me.grupoOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupoOrden.SuspendLayout()
        CType(Me.gbOrdenFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenFactura.SuspendLayout()
        CType(Me.gbMostrarStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMostrarStock.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Cancel_Button.Location = New System.Drawing.Point(190, 301)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(78, 27)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        Me.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_Button.Location = New System.Drawing.Point(108, 301)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(76, 27)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        Me.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.gbEmbarque)
        Me.gbOpciones.Controls.Add(Me.rbEmbarque)
        Me.gbOpciones.Controls.Add(Me.rbListadoxFecha)
        Me.gbOpciones.Controls.Add(Me.rbConformidad)
        Me.gbOpciones.Controls.Add(Me.rbListGeneral)
        Me.gbOpciones.Controls.Add(Me.rbListado)
        Me.gbOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(8, 8)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(201, 283)
        Me.gbOpciones.TabIndex = 1
        Me.gbOpciones.Text = "Opciones"
        Me.gbOpciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbEmbarque
        '
        Me.gbEmbarque.Controls.Add(Me.ckTodosAlmacen)
        Me.gbEmbarque.Controls.Add(Me.Label2)
        Me.gbEmbarque.Controls.Add(Me.txtNroPaquete)
        Me.gbEmbarque.Controls.Add(Me.Label1)
        Me.gbEmbarque.Controls.Add(Me.txtCodEmbarque)
        Me.gbEmbarque.Enabled = False
        Me.gbEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEmbarque.Location = New System.Drawing.Point(9, 192)
        Me.gbEmbarque.Name = "gbEmbarque"
        Me.gbEmbarque.Size = New System.Drawing.Size(185, 84)
        Me.gbEmbarque.TabIndex = 5
        Me.gbEmbarque.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'ckTodosAlmacen
        '
        Me.ckTodosAlmacen.AutoSize = True
        Me.ckTodosAlmacen.Checked = True
        Me.ckTodosAlmacen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckTodosAlmacen.Location = New System.Drawing.Point(22, 62)
        Me.ckTodosAlmacen.Name = "ckTodosAlmacen"
        Me.ckTodosAlmacen.Size = New System.Drawing.Size(146, 17)
        Me.ckTodosAlmacen.TabIndex = 18
        Me.ckTodosAlmacen.TabStop = False
        Me.ckTodosAlmacen.Text = "Todos los Almacenes"
        Me.ckTodosAlmacen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "CodEmbarque"
        '
        'txtNroPaquete
        '
        Me.txtNroPaquete.Location = New System.Drawing.Point(92, 36)
        Me.txtNroPaquete.Name = "txtNroPaquete"
        Me.txtNroPaquete.Size = New System.Drawing.Size(85, 20)
        Me.txtNroPaquete.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Nro Paquete"
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.Location = New System.Drawing.Point(92, 12)
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(85, 20)
        Me.txtCodEmbarque.TabIndex = 5
        '
        'rbEmbarque
        '
        Me.rbEmbarque.AutoSize = True
        Me.rbEmbarque.Location = New System.Drawing.Point(8, 175)
        Me.rbEmbarque.Name = "rbEmbarque"
        Me.rbEmbarque.Size = New System.Drawing.Size(73, 17)
        Me.rbEmbarque.TabIndex = 4
        Me.rbEmbarque.Text = "Embarque"
        Me.rbEmbarque.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbListadoxFecha
        '
        Me.rbListadoxFecha.AutoSize = True
        Me.rbListadoxFecha.Location = New System.Drawing.Point(7, 138)
        Me.rbListadoxFecha.Name = "rbListadoxFecha"
        Me.rbListadoxFecha.Size = New System.Drawing.Size(107, 17)
        Me.rbListadoxFecha.TabIndex = 3
        Me.rbListadoxFecha.Text = "Listado x Fecha"
        Me.rbListadoxFecha.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbConformidad
        '
        Me.rbConformidad.AutoSize = True
        Me.rbConformidad.Location = New System.Drawing.Point(8, 62)
        Me.rbConformidad.Name = "rbConformidad"
        Me.rbConformidad.Size = New System.Drawing.Size(59, 17)
        Me.rbConformidad.TabIndex = 1
        Me.rbConformidad.Text = "Informe"
        Me.rbConformidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbListGeneral
        '
        Me.rbListGeneral.AutoSize = True
        Me.rbListGeneral.Location = New System.Drawing.Point(8, 100)
        Me.rbListGeneral.Name = "rbListGeneral"
        Me.rbListGeneral.Size = New System.Drawing.Size(106, 17)
        Me.rbListGeneral.TabIndex = 2
        Me.rbListGeneral.Text = "Listado General"
        Me.rbListGeneral.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbListado
        '
        Me.rbListado.AutoSize = True
        Me.rbListado.Checked = True
        Me.rbListado.Location = New System.Drawing.Point(8, 25)
        Me.rbListado.Name = "rbListado"
        Me.rbListado.Size = New System.Drawing.Size(132, 17)
        Me.rbListado.TabIndex = 0
        Me.rbListado.TabStop = True
        Me.rbListado.Text = "Listado por Almacén"
        Me.rbListado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'grupoOrden
        '
        Me.grupoOrden.Controls.Add(Me.gbOrdenFactura)
        Me.grupoOrden.Controls.Add(Me.rbtnPorDestino)
        Me.grupoOrden.Controls.Add(Me.rbtnPorNumFactura)
        Me.grupoOrden.Controls.Add(Me.rbtnPorUbicacion)
        Me.grupoOrden.Controls.Add(Me.rbtnPorCodigo)
        Me.grupoOrden.Controls.Add(Me.rbtnPorItem)
        Me.grupoOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoOrden.Location = New System.Drawing.Point(215, 8)
        Me.grupoOrden.Name = "grupoOrden"
        Me.grupoOrden.Size = New System.Drawing.Size(150, 214)
        Me.grupoOrden.TabIndex = 3
        Me.grupoOrden.Text = "Orden"
        Me.grupoOrden.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbOrdenFactura
        '
        Me.gbOrdenFactura.Controls.Add(Me.rbtnPorCodigoFac)
        Me.gbOrdenFactura.Controls.Add(Me.rbtnPorItemFac)
        Me.gbOrdenFactura.Enabled = False
        Me.gbOrdenFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrdenFactura.Location = New System.Drawing.Point(30, 158)
        Me.gbOrdenFactura.Name = "gbOrdenFactura"
        Me.gbOrdenFactura.Size = New System.Drawing.Size(113, 48)
        Me.gbOrdenFactura.TabIndex = 4
        Me.gbOrdenFactura.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbtnPorCodigoFac
        '
        Me.rbtnPorCodigoFac.AutoSize = True
        Me.rbtnPorCodigoFac.Location = New System.Drawing.Point(15, 27)
        Me.rbtnPorCodigoFac.Name = "rbtnPorCodigoFac"
        Me.rbtnPorCodigoFac.Size = New System.Drawing.Size(79, 17)
        Me.rbtnPorCodigoFac.TabIndex = 2
        Me.rbtnPorCodigoFac.Text = "Por Código"
        Me.rbtnPorCodigoFac.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorItemFac
        '
        Me.rbtnPorItemFac.AutoSize = True
        Me.rbtnPorItemFac.Location = New System.Drawing.Point(15, 10)
        Me.rbtnPorItemFac.MaximumSize = New System.Drawing.Size(87, 16)
        Me.rbtnPorItemFac.Name = "rbtnPorItemFac"
        Me.rbtnPorItemFac.Size = New System.Drawing.Size(64, 16)
        Me.rbtnPorItemFac.TabIndex = 0
        Me.rbtnPorItemFac.Text = "Por Item"
        Me.rbtnPorItemFac.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorDestino
        '
        Me.rbtnPorDestino.AutoSize = True
        Me.rbtnPorDestino.Location = New System.Drawing.Point(13, 107)
        Me.rbtnPorDestino.Name = "rbtnPorDestino"
        Me.rbtnPorDestino.Size = New System.Drawing.Size(83, 17)
        Me.rbtnPorDestino.TabIndex = 5
        Me.rbtnPorDestino.Text = "Por Destino"
        Me.rbtnPorDestino.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorNumFactura
        '
        Me.rbtnPorNumFactura.AutoSize = True
        Me.rbtnPorNumFactura.Location = New System.Drawing.Point(13, 136)
        Me.rbtnPorNumFactura.Name = "rbtnPorNumFactura"
        Me.rbtnPorNumFactura.Size = New System.Drawing.Size(101, 17)
        Me.rbtnPorNumFactura.TabIndex = 4
        Me.rbtnPorNumFactura.Text = "Por Nº Factura"
        Me.rbtnPorNumFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorUbicacion
        '
        Me.rbtnPorUbicacion.AutoSize = True
        Me.rbtnPorUbicacion.Location = New System.Drawing.Point(13, 78)
        Me.rbtnPorUbicacion.Name = "rbtnPorUbicacion"
        Me.rbtnPorUbicacion.Size = New System.Drawing.Size(97, 17)
        Me.rbtnPorUbicacion.TabIndex = 3
        Me.rbtnPorUbicacion.Text = "Por Ubicación"
        Me.rbtnPorUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorCodigo
        '
        Me.rbtnPorCodigo.AutoSize = True
        Me.rbtnPorCodigo.Location = New System.Drawing.Point(13, 49)
        Me.rbtnPorCodigo.Name = "rbtnPorCodigo"
        Me.rbtnPorCodigo.Size = New System.Drawing.Size(79, 17)
        Me.rbtnPorCodigo.TabIndex = 2
        Me.rbtnPorCodigo.Text = "Por Código"
        Me.rbtnPorCodigo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbtnPorItem
        '
        Me.rbtnPorItem.AutoSize = True
        Me.rbtnPorItem.Checked = True
        Me.rbtnPorItem.Location = New System.Drawing.Point(13, 21)
        Me.rbtnPorItem.MaximumSize = New System.Drawing.Size(87, 16)
        Me.rbtnPorItem.Name = "rbtnPorItem"
        Me.rbtnPorItem.Size = New System.Drawing.Size(64, 16)
        Me.rbtnPorItem.TabIndex = 0
        Me.rbtnPorItem.TabStop = True
        Me.rbtnPorItem.Text = "Por Item"
        Me.rbtnPorItem.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbMostrarStock
        '
        Me.gbMostrarStock.Controls.Add(Me.rbDisponible)
        Me.gbMostrarStock.Controls.Add(Me.rbFisico)
        Me.gbMostrarStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMostrarStock.Location = New System.Drawing.Point(215, 228)
        Me.gbMostrarStock.Name = "gbMostrarStock"
        Me.gbMostrarStock.Size = New System.Drawing.Size(150, 63)
        Me.gbMostrarStock.TabIndex = 113
        Me.gbMostrarStock.Text = "Mostrar Stock"
        Me.gbMostrarStock.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDisponible
        '
        Me.rbDisponible.AutoSize = True
        Me.rbDisponible.Location = New System.Drawing.Point(36, 39)
        Me.rbDisponible.Name = "rbDisponible"
        Me.rbDisponible.Size = New System.Drawing.Size(84, 17)
        Me.rbDisponible.TabIndex = 14
        Me.rbDisponible.Text = "Disponible"
        Me.rbDisponible.UseVisualStyleBackColor = True
        '
        'rbFisico
        '
        Me.rbFisico.AutoSize = True
        Me.rbFisico.Location = New System.Drawing.Point(36, 19)
        Me.rbFisico.Name = "rbFisico"
        Me.rbFisico.Size = New System.Drawing.Size(60, 17)
        Me.rbFisico.TabIndex = 12
        Me.rbFisico.Text = "Físico"
        Me.rbFisico.UseVisualStyleBackColor = True
        '
        'frmAlmacen_FacturaImportacionImprimir
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(389, 350)
        Me.Controls.Add(Me.gbMostrarStock)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.grupoOrden)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.gbOpciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(309, 210)
        Me.Name = "frmAlmacen_FacturaImportacionImprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imprimir Factura de Importación"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpciones.ResumeLayout(False)
        CType(Me.gbEmbarque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEmbarque.ResumeLayout(False)
        Me.gbEmbarque.PerformLayout()
        CType(Me.grupoOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupoOrden.ResumeLayout(False)
        CType(Me.gbOrdenFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenFactura.ResumeLayout(False)
        CType(Me.gbMostrarStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMostrarStock.ResumeLayout(False)
        Me.gbMostrarStock.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbOpciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbConformidad As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbListGeneral As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbListado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents grupoOrden As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbtnPorCodigo As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorItem As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorUbicacion As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbListadoxFecha As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorDestino As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorNumFactura As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbOrdenFactura As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbtnPorCodigoFac As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtnPorItemFac As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents rbEmbarque As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbEmbarque As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNroPaquete As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbMostrarStock As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbDisponible As System.Windows.Forms.RadioButton
    Friend WithEvents rbFisico As System.Windows.Forms.RadioButton
    Friend WithEvents ckTodosAlmacen As System.Windows.Forms.CheckBox

End Class
