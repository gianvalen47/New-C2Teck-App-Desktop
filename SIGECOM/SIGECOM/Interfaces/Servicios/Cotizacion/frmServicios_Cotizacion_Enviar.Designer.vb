<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_Cotizacion_Enviar
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
        Dim dgvCorreos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios_Cotizacion_Enviar))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvCorreos = New Janus.Windows.GridEX.GridEX()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblNumCotizacion = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvCorreos
        '
        Me.dgvCorreos.Anchor = System.Windows.Forms.AnchorStyles.None
        dgvCorreos_DesignTimeLayout.LayoutString = resources.GetString("dgvCorreos_DesignTimeLayout.LayoutString")
        Me.dgvCorreos.DesignTimeLayout = dgvCorreos_DesignTimeLayout
        Me.dgvCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCorreos.GroupByBoxVisible = False
        Me.dgvCorreos.Location = New System.Drawing.Point(22, 131)
        Me.dgvCorreos.Name = "dgvCorreos"
        Me.dgvCorreos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCorreos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCorreos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCorreos.Size = New System.Drawing.Size(721, 101)
        Me.dgvCorreos.TabIndex = 189
        Me.dgvCorreos.TabStop = False
        Me.dgvCorreos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(200, 19)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(356, 82)
        Me.txtObservacion.TabIndex = 192
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(377, 239)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 23)
        Me.btnCancelar.TabIndex = 191
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(295, 239)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 23)
        Me.btnAceptar.TabIndex = 193
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblNumCotizacion
        '
        Me.lblNumCotizacion.AutoSize = True
        Me.lblNumCotizacion.Location = New System.Drawing.Point(118, 53)
        Me.lblNumCotizacion.Name = "lblNumCotizacion"
        Me.lblNumCotizacion.Size = New System.Drawing.Size(76, 13)
        Me.lblNumCotizacion.TabIndex = 194
        Me.lblNumCotizacion.Text = "Observación : "
        '
        'frmServicios_Cotizacion_Enviar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(791, 309)
        Me.Controls.Add(Me.lblNumCotizacion)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dgvCorreos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_Cotizacion_Enviar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar Cotización a Aprobación "
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvCorreos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblNumCotizacion As Label
End Class
