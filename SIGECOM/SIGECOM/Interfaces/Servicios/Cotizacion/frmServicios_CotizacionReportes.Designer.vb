<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_CotizacionReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios_CotizacionReportes))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbFirma = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbVendedor = New System.Windows.Forms.RadioButton()
        Me.rbSupervisor = New System.Windows.Forms.RadioButton()
        Me.optConsolidado = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.optDetallado = New System.Windows.Forms.RadioButton()
        Me.optResumido = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbNoMostrarCodigo = New System.Windows.Forms.CheckBox()
        Me.lblRepuesto = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFirma.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbFirma
        '
        Me.gbFirma.Controls.Add(Me.rbVendedor)
        Me.gbFirma.Controls.Add(Me.rbSupervisor)
        Me.gbFirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFirma.Location = New System.Drawing.Point(89, 55)
        Me.gbFirma.Name = "gbFirma"
        Me.gbFirma.Size = New System.Drawing.Size(210, 43)
        Me.gbFirma.TabIndex = 252
        Me.gbFirma.Text = "Firma"
        Me.gbFirma.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbFirma.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbVendedor
        '
        Me.rbVendedor.AutoSize = True
        Me.rbVendedor.Checked = True
        Me.rbVendedor.Location = New System.Drawing.Point(13, 19)
        Me.rbVendedor.Name = "rbVendedor"
        Me.rbVendedor.Size = New System.Drawing.Size(79, 17)
        Me.rbVendedor.TabIndex = 1
        Me.rbVendedor.TabStop = True
        Me.rbVendedor.Text = "Vendedor"
        Me.rbVendedor.UseVisualStyleBackColor = True
        '
        'rbSupervisor
        '
        Me.rbSupervisor.AutoSize = True
        Me.rbSupervisor.Location = New System.Drawing.Point(114, 19)
        Me.rbSupervisor.Name = "rbSupervisor"
        Me.rbSupervisor.Size = New System.Drawing.Size(85, 17)
        Me.rbSupervisor.TabIndex = 15
        Me.rbSupervisor.Text = "Supervisor"
        Me.rbSupervisor.UseVisualStyleBackColor = True
        '
        'optConsolidado
        '
        Me.optConsolidado.AutoSize = True
        Me.optConsolidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optConsolidado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.optConsolidado.Location = New System.Drawing.Point(279, 27)
        Me.optConsolidado.Name = "optConsolidado"
        Me.optConsolidado.Size = New System.Drawing.Size(94, 17)
        Me.optConsolidado.TabIndex = 28
        Me.optConsolidado.TabStop = True
        Me.optConsolidado.Text = "Consolidado"
        Me.optConsolidado.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(112, 135)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 28)
        Me.btnAceptar.TabIndex = 26
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(198, 135)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 28)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'optDetallado
        '
        Me.optDetallado.AutoSize = True
        Me.optDetallado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDetallado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.optDetallado.Location = New System.Drawing.Point(125, 27)
        Me.optDetallado.Name = "optDetallado"
        Me.optDetallado.Size = New System.Drawing.Size(148, 17)
        Me.optDetallado.TabIndex = 1
        Me.optDetallado.TabStop = True
        Me.optDetallado.Text = "Listado de Repuestos"
        Me.optDetallado.UseVisualStyleBackColor = True
        '
        'optResumido
        '
        Me.optResumido.AutoSize = True
        Me.optResumido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResumido.ForeColor = System.Drawing.SystemColors.Desktop
        Me.optResumido.Location = New System.Drawing.Point(18, 27)
        Me.optResumido.Name = "optResumido"
        Me.optResumido.Size = New System.Drawing.Size(84, 17)
        Me.optResumido.TabIndex = 0
        Me.optResumido.TabStop = True
        Me.optResumido.Text = "Cotización"
        Me.optResumido.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbNoMostrarCodigo)
        Me.UiGroupBox1.Controls.Add(Me.lblRepuesto)
        Me.UiGroupBox1.Controls.Add(Me.gbFirma)
        Me.UiGroupBox1.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox1.Controls.Add(Me.optConsolidado)
        Me.UiGroupBox1.Controls.Add(Me.optResumido)
        Me.UiGroupBox1.Controls.Add(Me.btnAceptar)
        Me.UiGroupBox1.Controls.Add(Me.optDetallado)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(391, 177)
        Me.UiGroupBox1.TabIndex = 253
        Me.UiGroupBox1.Text = "Por:"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbNoMostrarCodigo
        '
        Me.cbNoMostrarCodigo.AutoSize = True
        Me.cbNoMostrarCodigo.Location = New System.Drawing.Point(134, 110)
        Me.cbNoMostrarCodigo.Name = "cbNoMostrarCodigo"
        Me.cbNoMostrarCodigo.Size = New System.Drawing.Size(15, 14)
        Me.cbNoMostrarCodigo.TabIndex = 254
        Me.cbNoMostrarCodigo.UseVisualStyleBackColor = True
        '
        'lblRepuesto
        '
        Me.lblRepuesto.AutoSize = True
        Me.lblRepuesto.Location = New System.Drawing.Point(153, 111)
        Me.lblRepuesto.Name = "lblRepuesto"
        Me.lblRepuesto.Size = New System.Drawing.Size(112, 13)
        Me.lblRepuesto.TabIndex = 253
        Me.lblRepuesto.Text = "No Mostrar Codigo"
        '
        'frmServicios_CotizacionReportes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(414, 197)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_CotizacionReportes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes de Cotizaciones"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbFirma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFirma.ResumeLayout(False)
        Me.gbFirma.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents optConsolidado As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents optDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents optResumido As System.Windows.Forms.RadioButton
    Friend WithEvents gbFirma As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbSupervisor As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbNoMostrarCodigo As CheckBox
    Friend WithEvents lblRepuesto As Label
End Class
