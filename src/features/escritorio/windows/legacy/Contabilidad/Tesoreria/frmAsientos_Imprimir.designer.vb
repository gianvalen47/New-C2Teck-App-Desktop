<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsientos_Imprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsientos_Imprimir))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbTipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbRetencion = New System.Windows.Forms.RadioButton()
        Me.gbMasivo = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarHasta = New System.Windows.Forms.Button()
        Me.btnBuscarDesde = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumRegistroHasta = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.txtNumRegistroDesde = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbMasivo = New System.Windows.Forms.RadioButton()
        Me.gbCheque = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbContinental = New System.Windows.Forms.RadioButton()
        Me.rbNacion = New System.Windows.Forms.RadioButton()
        Me.rbWise = New System.Windows.Forms.RadioButton()
        Me.rbCredito = New System.Windows.Forms.RadioButton()
        Me.rbPrincipal = New System.Windows.Forms.RadioButton()
        Me.rbCheque = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipo.SuspendLayout()
        CType(Me.gbMasivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMasivo.SuspendLayout()
        CType(Me.gbCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCheque.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.rbRetencion)
        Me.gbTipo.Controls.Add(Me.gbMasivo)
        Me.gbTipo.Controls.Add(Me.rbMasivo)
        Me.gbTipo.Controls.Add(Me.gbCheque)
        Me.gbTipo.Controls.Add(Me.rbPrincipal)
        Me.gbTipo.Controls.Add(Me.rbCheque)
        Me.gbTipo.Location = New System.Drawing.Point(7, 3)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Size = New System.Drawing.Size(322, 280)
        Me.gbTipo.TabIndex = 9
        Me.gbTipo.Text = "Tipo"
        Me.gbTipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'rbRetencion
        '
        Me.rbRetencion.AutoSize = True
        Me.rbRetencion.Location = New System.Drawing.Point(10, 43)
        Me.rbRetencion.Name = "rbRetencion"
        Me.rbRetencion.Size = New System.Drawing.Size(83, 17)
        Me.rbRetencion.TabIndex = 2
        Me.rbRetencion.Text = "Retención"
        Me.rbRetencion.UseVisualStyleBackColor = True
        '
        'gbMasivo
        '
        Me.gbMasivo.Controls.Add(Me.btnBuscarHasta)
        Me.gbMasivo.Controls.Add(Me.btnBuscarDesde)
        Me.gbMasivo.Controls.Add(Me.Label3)
        Me.gbMasivo.Controls.Add(Me.txtNumRegistroHasta)
        Me.gbMasivo.Controls.Add(Me.Label2)
        Me.gbMasivo.Controls.Add(Me.Label7)
        Me.gbMasivo.Controls.Add(Me.txtPeriodo)
        Me.gbMasivo.Controls.Add(Me.txtNumRegistroDesde)
        Me.gbMasivo.Controls.Add(Me.txtMesRegistro)
        Me.gbMasivo.Controls.Add(Me.Label1)
        Me.gbMasivo.Location = New System.Drawing.Point(26, 204)
        Me.gbMasivo.Name = "gbMasivo"
        Me.gbMasivo.Size = New System.Drawing.Size(287, 65)
        Me.gbMasivo.TabIndex = 12
        Me.gbMasivo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'btnBuscarHasta
        '
        Me.btnBuscarHasta.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarHasta.Location = New System.Drawing.Point(255, 38)
        Me.btnBuscarHasta.Name = "btnBuscarHasta"
        Me.btnBuscarHasta.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarHasta.TabIndex = 6
        Me.btnBuscarHasta.TabStop = False
        Me.btnBuscarHasta.UseVisualStyleBackColor = True
        '
        'btnBuscarDesde
        '
        Me.btnBuscarDesde.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarDesde.Location = New System.Drawing.Point(112, 38)
        Me.btnBuscarDesde.Name = "btnBuscarDesde"
        Me.btnBuscarDesde.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarDesde.TabIndex = 4
        Me.btnBuscarDesde.TabStop = False
        Me.btnBuscarDesde.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(153, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 234
        Me.Label3.Text = "Hasta :"
        '
        'txtNumRegistroHasta
        '
        Me.txtNumRegistroHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRegistroHasta.Location = New System.Drawing.Point(201, 39)
        Me.txtNumRegistroHasta.MaxLength = 6
        Me.txtNumRegistroHasta.Name = "txtNumRegistroHasta"
        Me.txtNumRegistroHasta.Numeric = True
        Me.txtNumRegistroHasta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumRegistroHasta.Size = New System.Drawing.Size(53, 20)
        Me.txtNumRegistroHasta.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 232
        Me.Label2.Text = "Desde :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(39, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 231
        Me.Label7.Text = "Periodo"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(95, 13)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriodo.TabIndex = 1
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumRegistroDesde
        '
        Me.txtNumRegistroDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRegistroDesde.Location = New System.Drawing.Point(58, 39)
        Me.txtNumRegistroDesde.MaxLength = 6
        Me.txtNumRegistroDesde.Name = "txtNumRegistroDesde"
        Me.txtNumRegistroDesde.Numeric = True
        Me.txtNumRegistroDesde.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumRegistroDesde.Size = New System.Drawing.Size(53, 20)
        Me.txtNumRegistroDesde.TabIndex = 3
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesRegistro.Location = New System.Drawing.Point(210, 13)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMesRegistro.Size = New System.Drawing.Size(30, 20)
        Me.txtMesRegistro.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(175, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 227
        Me.Label1.Text = "Mes"
        '
        'rbMasivo
        '
        Me.rbMasivo.AutoSize = True
        Me.rbMasivo.Location = New System.Drawing.Point(10, 189)
        Me.rbMasivo.Name = "rbMasivo"
        Me.rbMasivo.Size = New System.Drawing.Size(65, 17)
        Me.rbMasivo.TabIndex = 4
        Me.rbMasivo.Text = "Masivo"
        Me.rbMasivo.UseVisualStyleBackColor = True
        '
        'gbCheque
        '
        Me.gbCheque.Controls.Add(Me.rbContinental)
        Me.gbCheque.Controls.Add(Me.rbNacion)
        Me.gbCheque.Controls.Add(Me.rbWise)
        Me.gbCheque.Controls.Add(Me.rbCredito)
        Me.gbCheque.Location = New System.Drawing.Point(26, 81)
        Me.gbCheque.Name = "gbCheque"
        Me.gbCheque.Size = New System.Drawing.Size(139, 102)
        Me.gbCheque.TabIndex = 10
        Me.gbCheque.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'rbContinental
        '
        Me.rbContinental.AutoSize = True
        Me.rbContinental.Location = New System.Drawing.Point(12, 77)
        Me.rbContinental.Name = "rbContinental"
        Me.rbContinental.Size = New System.Drawing.Size(89, 17)
        Me.rbContinental.TabIndex = 4
        Me.rbContinental.Text = "Continental"
        Me.rbContinental.UseVisualStyleBackColor = True
        '
        'rbNacion
        '
        Me.rbNacion.AutoSize = True
        Me.rbNacion.Location = New System.Drawing.Point(12, 55)
        Me.rbNacion.Name = "rbNacion"
        Me.rbNacion.Size = New System.Drawing.Size(65, 17)
        Me.rbNacion.TabIndex = 3
        Me.rbNacion.Text = "Nación"
        Me.rbNacion.UseVisualStyleBackColor = True
        '
        'rbWise
        '
        Me.rbWise.AutoSize = True
        Me.rbWise.Checked = True
        Me.rbWise.Location = New System.Drawing.Point(12, 11)
        Me.rbWise.Name = "rbWise"
        Me.rbWise.Size = New System.Drawing.Size(89, 17)
        Me.rbWise.TabIndex = 1
        Me.rbWise.TabStop = True
        Me.rbWise.Text = "Scotiabank"
        Me.rbWise.UseVisualStyleBackColor = True
        '
        'rbCredito
        '
        Me.rbCredito.AutoSize = True
        Me.rbCredito.Location = New System.Drawing.Point(12, 33)
        Me.rbCredito.Name = "rbCredito"
        Me.rbCredito.Size = New System.Drawing.Size(65, 17)
        Me.rbCredito.TabIndex = 2
        Me.rbCredito.Text = "Crédito"
        Me.rbCredito.UseVisualStyleBackColor = True
        '
        'rbPrincipal
        '
        Me.rbPrincipal.AutoSize = True
        Me.rbPrincipal.Checked = True
        Me.rbPrincipal.Location = New System.Drawing.Point(10, 20)
        Me.rbPrincipal.Name = "rbPrincipal"
        Me.rbPrincipal.Size = New System.Drawing.Size(74, 17)
        Me.rbPrincipal.TabIndex = 1
        Me.rbPrincipal.TabStop = True
        Me.rbPrincipal.Text = "Principal"
        Me.rbPrincipal.UseVisualStyleBackColor = True
        '
        'rbCheque
        '
        Me.rbCheque.AutoSize = True
        Me.rbCheque.Location = New System.Drawing.Point(10, 66)
        Me.rbCheque.Name = "rbCheque"
        Me.rbCheque.Size = New System.Drawing.Size(68, 17)
        Me.rbCheque.TabIndex = 3
        Me.rbCheque.Text = "Cheque"
        Me.rbCheque.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(175, 289)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 28)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(91, 289)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 28)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(19, 339)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Size = New System.Drawing.Size(66, 21)
        Me.dgvDatos.TabIndex = 30
        Me.dgvDatos.Visible = False
        '
        'frmAsientos_Imprimir
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(354, 338)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbTipo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsientos_Imprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir Asiento"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipo.ResumeLayout(False)
        Me.gbTipo.PerformLayout()
        CType(Me.gbMasivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMasivo.ResumeLayout(False)
        Me.gbMasivo.PerformLayout()
        CType(Me.gbCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCheque.ResumeLayout(False)
        Me.gbCheque.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbTipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPrincipal As System.Windows.Forms.RadioButton
    Friend WithEvents rbCheque As System.Windows.Forms.RadioButton
    Friend WithEvents gbCheque As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbWise As System.Windows.Forms.RadioButton
    Friend WithEvents rbCredito As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents rbNacion As System.Windows.Forms.RadioButton
    Friend WithEvents gbMasivo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbMasivo As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumRegistroHasta As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents txtNumRegistroDesde As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbRetencion As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscarHasta As System.Windows.Forms.Button
    Friend WithEvents btnBuscarDesde As System.Windows.Forms.Button
    Friend WithEvents rbContinental As RadioButton
End Class
