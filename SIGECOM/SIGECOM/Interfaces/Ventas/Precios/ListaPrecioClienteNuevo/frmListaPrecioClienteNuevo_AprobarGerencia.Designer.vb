<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaPrecioClienteNuevo_AprobarGerencia
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
        Dim dgvPendientes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaPrecioClienteNuevo_AprobarGerencia))
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.dgvPendientes = New Janus.Windows.GridEX.GridEX()
        Me.cbRechazar = New Janus.Windows.EditControls.UIRadioButton()
        Me.cbAprobar = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAprobar = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbExportar = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportar.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.Label9)
        Me.gbDetalle.Controls.Add(Me.lblRegistros)
        Me.gbDetalle.Controls.Add(Me.dgvPendientes)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(12, 59)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(844, 249)
        Me.gbDetalle.TabIndex = 216
        Me.gbDetalle.Text = "Detalles"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(407, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 13)
        Me.Label9.TabIndex = 214
        Me.Label9.Text = "* Precio debajo del costo"
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(609, 223)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(73, 13)
        Me.lblRegistros.TabIndex = 213
        Me.lblRegistros.Text = "lblRegistros"
        '
        'dgvPendientes
        '
        dgvPendientes_DesignTimeLayout.LayoutString = resources.GetString("dgvPendientes_DesignTimeLayout.LayoutString")
        Me.dgvPendientes.DesignTimeLayout = dgvPendientes_DesignTimeLayout
        Me.dgvPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvPendientes.GroupByBoxVisible = False
        Me.dgvPendientes.Location = New System.Drawing.Point(13, 25)
        Me.dgvPendientes.Name = "dgvPendientes"
        Me.dgvPendientes.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvPendientes.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvPendientes.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvPendientes.Size = New System.Drawing.Size(814, 182)
        Me.dgvPendientes.TabIndex = 208
        Me.dgvPendientes.TabStop = False
        Me.dgvPendientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cbRechazar
        '
        Me.cbRechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRechazar.Location = New System.Drawing.Point(105, 15)
        Me.cbRechazar.Name = "cbRechazar"
        Me.cbRechazar.Size = New System.Drawing.Size(82, 23)
        Me.cbRechazar.TabIndex = 2
        Me.cbRechazar.Text = "Rechazar"
        '
        'cbAprobar
        '
        Me.cbAprobar.Checked = True
        Me.cbAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAprobar.Location = New System.Drawing.Point(22, 15)
        Me.cbAprobar.Name = "cbAprobar"
        Me.cbAprobar.Size = New System.Drawing.Size(73, 23)
        Me.cbAprobar.TabIndex = 1
        Me.cbAprobar.TabStop = True
        Me.cbAprobar.Text = "Aprobar"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(439, 397)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 23)
        Me.btnSalir.TabIndex = 213
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAprobar
        '
        Me.btnAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAprobar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAprobar.Location = New System.Drawing.Point(349, 397)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(84, 23)
        Me.btnAprobar.TabIndex = 210
        Me.btnAprobar.Text = "Aprobar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 343)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 211
        Me.Label1.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(96, 323)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(688, 54)
        Me.txtObservacion.TabIndex = 3
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbExportar
        '
        Me.gbExportar.Controls.Add(Me.cbAprobar)
        Me.gbExportar.Controls.Add(Me.cbRechazar)
        Me.gbExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExportar.Location = New System.Drawing.Point(332, 7)
        Me.gbExportar.Name = "gbExportar"
        Me.gbExportar.Size = New System.Drawing.Size(204, 46)
        Me.gbExportar.TabIndex = 280
        Me.gbExportar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmListaPrecioClienteNuevo_AprobarGerencia
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(886, 460)
        Me.Controls.Add(Me.gbExportar)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAprobar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtObservacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListaPrecioClienteNuevo_AprobarGerencia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Cliente Aprobar Gerencia"
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents dgvPendientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents cbRechazar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cbAprobar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAprobar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbExportar As Janus.Windows.EditControls.UIGroupBox
End Class
