<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturacionElectronica_ObtenerEstadoSunat
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
        Dim cmbTipDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturacionElectronica_ObtenerEstadoSunat))
        Me.cmbTipDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumDocRef = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSerieDocRef = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnObtenerCDR = New System.Windows.Forms.Button()
        Me.gbProcesoJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnObtenerCDROSE = New System.Windows.Forms.Button()
        Me.txtRespuesta = New System.Windows.Forms.TextBox()
        CType(Me.cmbTipDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProcesoJob.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbTipDoc
        '
        Me.cmbTipDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipDoc.DesignTimeLayout = cmbTipDoc_DesignTimeLayout
        Me.cmbTipDoc.Location = New System.Drawing.Point(86, 31)
        Me.cmbTipDoc.Name = "cmbTipDoc"
        Me.cmbTipDoc.SelectedIndex = -1
        Me.cmbTipDoc.SelectedItem = Nothing
        Me.cmbTipDoc.Size = New System.Drawing.Size(124, 20)
        Me.cmbTipDoc.TabIndex = 1
        Me.cmbTipDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Tipo Doc."
        '
        'txtNumDocRef
        '
        Me.txtNumDocRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDocRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDocRef.Location = New System.Drawing.Point(226, 67)
        Me.txtNumDocRef.MaxLength = 100
        Me.txtNumDocRef.Name = "txtNumDocRef"
        Me.txtNumDocRef.Size = New System.Drawing.Size(70, 20)
        Me.txtNumDocRef.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(168, 71)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "N° Doc."
        '
        'txtSerieDocRef
        '
        Me.txtSerieDocRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDocRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDocRef.Location = New System.Drawing.Point(86, 67)
        Me.txtSerieDocRef.MaxLength = 100
        Me.txtSerieDocRef.Name = "txtSerieDocRef"
        Me.txtSerieDocRef.Size = New System.Drawing.Size(48, 20)
        Me.txtSerieDocRef.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Serie"
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnObtenerCDR
        '
        Me.btnObtenerCDR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnObtenerCDR.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnObtenerCDR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnObtenerCDR.Location = New System.Drawing.Point(16, 118)
        Me.btnObtenerCDR.Name = "btnObtenerCDR"
        Me.btnObtenerCDR.Size = New System.Drawing.Size(111, 27)
        Me.btnObtenerCDR.TabIndex = 6
        Me.btnObtenerCDR.Text = "Obtener CDR"
        Me.btnObtenerCDR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtenerCDR.UseVisualStyleBackColor = True
        Me.btnObtenerCDR.Visible = False
        '
        'gbProcesoJob
        '
        Me.gbProcesoJob.Controls.Add(Me.cmbTipDoc)
        Me.gbProcesoJob.Controls.Add(Me.btnBuscar)
        Me.gbProcesoJob.Controls.Add(Me.Label8)
        Me.gbProcesoJob.Controls.Add(Me.txtSerieDocRef)
        Me.gbProcesoJob.Controls.Add(Me.Label16)
        Me.gbProcesoJob.Controls.Add(Me.Label6)
        Me.gbProcesoJob.Controls.Add(Me.txtNumDocRef)
        Me.gbProcesoJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProcesoJob.Location = New System.Drawing.Point(12, 12)
        Me.gbProcesoJob.Name = "gbProcesoJob"
        Me.gbProcesoJob.Size = New System.Drawing.Size(321, 145)
        Me.gbProcesoJob.TabIndex = 115
        Me.gbProcesoJob.Text = "Consulta"
        Me.gbProcesoJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(59, 106)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(198, 25)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar Documento en Sunat"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnObtenerCDROSE)
        Me.UiGroupBox1.Controls.Add(Me.txtRespuesta)
        Me.UiGroupBox1.Controls.Add(Me.btnObtenerCDR)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 163)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(321, 160)
        Me.UiGroupBox1.TabIndex = 116
        Me.UiGroupBox1.Text = "Respuesta"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnObtenerCDROSE
        '
        Me.btnObtenerCDROSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnObtenerCDROSE.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnObtenerCDROSE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnObtenerCDROSE.Location = New System.Drawing.Point(155, 118)
        Me.btnObtenerCDROSE.Name = "btnObtenerCDROSE"
        Me.btnObtenerCDROSE.Size = New System.Drawing.Size(140, 27)
        Me.btnObtenerCDROSE.TabIndex = 7
        Me.btnObtenerCDROSE.Text = "Obtener CDR OSE"
        Me.btnObtenerCDROSE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtenerCDROSE.UseVisualStyleBackColor = True
        '
        'txtRespuesta
        '
        Me.txtRespuesta.BackColor = System.Drawing.SystemColors.Window
        Me.txtRespuesta.Location = New System.Drawing.Point(11, 29)
        Me.txtRespuesta.Multiline = True
        Me.txtRespuesta.Name = "txtRespuesta"
        Me.txtRespuesta.ReadOnly = True
        Me.txtRespuesta.Size = New System.Drawing.Size(294, 77)
        Me.txtRespuesta.TabIndex = 5
        '
        'frmFacturacionElectronica_ObtenerEstadoSunat
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(346, 337)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbProcesoJob)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturacionElectronica_ObtenerEstadoSunat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Obtener Estado Sunat"
        CType(Me.cmbTipDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProcesoJob.ResumeLayout(False)
        Me.gbProcesoJob.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbTipDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumDocRef As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSerieDocRef As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnObtenerCDR As System.Windows.Forms.Button
    Friend WithEvents gbProcesoJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtRespuesta As System.Windows.Forms.TextBox
    Friend WithEvents btnObtenerCDROSE As Button
End Class
