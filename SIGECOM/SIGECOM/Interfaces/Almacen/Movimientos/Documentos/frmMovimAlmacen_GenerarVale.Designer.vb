<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovimAlmacen_GenerarVale
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cmbIdSerieDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimAlmacen_GenerarVale))
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbVale = New Janus.Windows.EditControls.UIGroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbIdSerieDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarPersonal = New System.Windows.Forms.Button()
        Me.txtPersonal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbVale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVale.SuspendLayout()
        CType(Me.cmbIdSerieDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(176, 119)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Generar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(255, 119)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbVale
        '
        Me.gbVale.Controls.Add(Me.Button1)
        Me.gbVale.Controls.Add(Me.cmbIdSerieDoc)
        Me.gbVale.Controls.Add(Me.Label3)
        Me.gbVale.Controls.Add(Me.btnBuscarPersonal)
        Me.gbVale.Controls.Add(Me.txtPersonal)
        Me.gbVale.Controls.Add(Me.Label8)
        Me.gbVale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVale.Location = New System.Drawing.Point(12, 38)
        Me.gbVale.Name = "gbVale"
        Me.gbVale.Size = New System.Drawing.Size(479, 72)
        Me.gbVale.TabIndex = 119
        Me.gbVale.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbVale.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Button1
        '
        Me.Button1.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.Button1.Location = New System.Drawing.Point(437, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 22)
        Me.Button1.TabIndex = 114
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbIdSerieDoc
        '
        Me.cmbIdSerieDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdSerieDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbIdSerieDoc_DesignTimeLayout.LayoutString")
        Me.cmbIdSerieDoc.DesignTimeLayout = cmbIdSerieDoc_DesignTimeLayout
        Me.cmbIdSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdSerieDoc.Location = New System.Drawing.Point(44, 13)
        Me.cmbIdSerieDoc.Name = "cmbIdSerieDoc"
        Me.cmbIdSerieDoc.SelectedIndex = -1
        Me.cmbIdSerieDoc.SelectedItem = Nothing
        Me.cmbIdSerieDoc.Size = New System.Drawing.Size(168, 20)
        Me.cmbIdSerieDoc.TabIndex = 70
        Me.cmbIdSerieDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Personal"
        '
        'btnBuscarPersonal
        '
        Me.btnBuscarPersonal.Image = CType(resources.GetObject("btnBuscarPersonal.Image"), System.Drawing.Image)
        Me.btnBuscarPersonal.Location = New System.Drawing.Point(553, 13)
        Me.btnBuscarPersonal.Name = "btnBuscarPersonal"
        Me.btnBuscarPersonal.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersonal.TabIndex = 68
        Me.btnBuscarPersonal.UseVisualStyleBackColor = True
        '
        'txtPersonal
        '
        Me.txtPersonal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonal.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersonal.Location = New System.Drawing.Point(68, 42)
        Me.txtPersonal.MaxLength = 3
        Me.txtPersonal.Name = "txtPersonal"
        Me.txtPersonal.ReadOnly = True
        Me.txtPersonal.Size = New System.Drawing.Size(368, 20)
        Me.txtPersonal.TabIndex = 67
        Me.txtPersonal.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Doc."
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(219, 12)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ShowNullButton = True
        Me.txtFecha.Size = New System.Drawing.Size(85, 20)
        Me.txtFecha.TabIndex = 116
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(65, 12)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(80, 20)
        Me.txtNumero.TabIndex = 115
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Número"
        '
        'frmMovimAlmacen_GenerarVale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 149)
        Me.Controls.Add(Me.gbVale)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimAlmacen_GenerarVale"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generar Vale de Regularización"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbVale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVale.ResumeLayout(False)
        Me.gbVale.PerformLayout()
        CType(Me.cmbIdSerieDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbVale As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbIdSerieDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As Label
    Friend WithEvents btnBuscarPersonal As Button
    Friend WithEvents txtPersonal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
