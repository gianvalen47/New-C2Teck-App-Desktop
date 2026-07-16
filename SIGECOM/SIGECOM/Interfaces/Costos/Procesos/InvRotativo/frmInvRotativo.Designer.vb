<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvRotativo
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
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbAlmacenes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvRotativo))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbAlmacenes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnProcesar = New Janus.Windows.EditControls.UIButton()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Location = New System.Drawing.Point(9, 25)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(40, 13)
        Me.lblOficina.TabIndex = 1
        Me.lblOficina.Text = "Oficina"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(174, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Almacén"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(57, 22)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(102, 20)
        Me.cmbOficinas.TabIndex = 3
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbAlmacenes
        '
        Me.cmbAlmacenes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAlmacenes_DesignTimeLayout.LayoutString = resources.GetString("cmbAlmacenes_DesignTimeLayout.LayoutString")
        Me.cmbAlmacenes.DesignTimeLayout = cmbAlmacenes_DesignTimeLayout
        Me.cmbAlmacenes.Location = New System.Drawing.Point(228, 21)
        Me.cmbAlmacenes.Name = "cmbAlmacenes"
        Me.cmbAlmacenes.SelectedIndex = -1
        Me.cmbAlmacenes.SelectedItem = Nothing
        Me.cmbAlmacenes.Size = New System.Drawing.Size(150, 20)
        Me.cmbAlmacenes.TabIndex = 4
        Me.cmbAlmacenes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.btnImprimir.Location = New System.Drawing.Point(214, 71)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(83, 28)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.Text = "Imprimir"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.Location = New System.Drawing.Point(315, 71)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 28)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnProcesar
        '
        Me.btnProcesar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnProcesar.Location = New System.Drawing.Point(527, 20)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(53, 23)
        Me.btnProcesar.TabIndex = 8
        Me.btnProcesar.Text = "OK"
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(12, 105)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(574, 309)
        Me.dgvDatos.TabIndex = 9
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(395, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Rubro"
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(435, 21)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(83, 20)
        Me.cmbCodRub.TabIndex = 11
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmInvRotativo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(600, 429)
        Me.Controls.Add(Me.cmbCodRub)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.cmbAlmacenes)
        Me.Controls.Add(Me.cmbOficinas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblOficina)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInvRotativo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmInvRotativo"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblOficina As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnProcesar As Janus.Windows.EditControls.UIButton
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
