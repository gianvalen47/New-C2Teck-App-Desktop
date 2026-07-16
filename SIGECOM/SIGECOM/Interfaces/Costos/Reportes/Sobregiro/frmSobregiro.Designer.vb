<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSobregiro
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
        Dim cbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSobregiro))
        Dim cbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbPeriodo = New Janus.Windows.EditControls.UIGroupBox()
        Me.gpAlmacenes = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPeriodo.SuspendLayout()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpAlmacenes.SuspendLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(134, 141)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(221, 141)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtFin
        '
        '
        '
        '
        Me.txtFin.DropDownCalendar.Name = ""
        Me.txtFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFin.Location = New System.Drawing.Point(160, 24)
        Me.txtFin.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFin.Name = "txtFin"
        Me.txtFin.Size = New System.Drawing.Size(88, 20)
        Me.txtFin.TabIndex = 22
        Me.txtFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtInicio
        '
        '
        '
        '
        Me.txtInicio.DropDownCalendar.Name = ""
        Me.txtInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtInicio.Location = New System.Drawing.Point(39, 23)
        Me.txtInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(90, 20)
        Me.txtInicio.TabIndex = 21
        Me.txtInicio.Value = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(133, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Al :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Del :"
        '
        'gbPeriodo
        '
        Me.gbPeriodo.Controls.Add(Me.txtFin)
        Me.gbPeriodo.Controls.Add(Me.Label3)
        Me.gbPeriodo.Controls.Add(Me.txtInicio)
        Me.gbPeriodo.Controls.Add(Me.Label4)
        Me.gbPeriodo.Location = New System.Drawing.Point(9, 8)
        Me.gbPeriodo.Name = "gbPeriodo"
        Me.gbPeriodo.Size = New System.Drawing.Size(261, 57)
        Me.gbPeriodo.TabIndex = 33
        Me.gbPeriodo.Text = "Fechas"
        Me.gbPeriodo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gpAlmacenes
        '
        Me.gpAlmacenes.Controls.Add(Me.cbAlmacen)
        Me.gpAlmacenes.Controls.Add(Me.cbOficina)
        Me.gpAlmacenes.Controls.Add(Me.Label2)
        Me.gpAlmacenes.Controls.Add(Me.Label1)
        Me.gpAlmacenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpAlmacenes.Location = New System.Drawing.Point(9, 71)
        Me.gpAlmacenes.Name = "gpAlmacenes"
        Me.gpAlmacenes.Size = New System.Drawing.Size(292, 62)
        Me.gpAlmacenes.TabIndex = 34
        Me.gpAlmacenes.Text = "Almacenes"
        Me.gpAlmacenes.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(67, 37)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(210, 20)
        Me.cbAlmacen.TabIndex = 3
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(67, 15)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(161, 20)
        Me.cbOficina.TabIndex = 2
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Almacen :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Oficina :"
        '
        'frmSobregiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 178)
        Me.Controls.Add(Me.gpAlmacenes)
        Me.Controls.Add(Me.gbPeriodo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSobregiro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sobregiro"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPeriodo.ResumeLayout(False)
        Me.gbPeriodo.PerformLayout()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpAlmacenes.ResumeLayout(False)
        Me.gpAlmacenes.PerformLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbPeriodo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gpAlmacenes As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
