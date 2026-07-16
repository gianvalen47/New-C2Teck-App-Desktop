<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertarPendientes
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
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsertarPendientes))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbFacturacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNumDoc = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtCodTipoDoc = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFacturacion.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbFacturacion
        '
        Me.gbFacturacion.Controls.Add(Me.txtNumDoc)
        Me.gbFacturacion.Controls.Add(Me.cmbTipoDoc)
        Me.gbFacturacion.Controls.Add(Me.txtCodTipoDoc)
        Me.gbFacturacion.Controls.Add(Me.Label4)
        Me.gbFacturacion.Controls.Add(Me.txtSerieDoc)
        Me.gbFacturacion.Controls.Add(Me.Label3)
        Me.gbFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFacturacion.Location = New System.Drawing.Point(7, 5)
        Me.gbFacturacion.Name = "gbFacturacion"
        Me.gbFacturacion.Size = New System.Drawing.Size(381, 61)
        Me.gbFacturacion.TabIndex = 12
        Me.gbFacturacion.Text = "INSERTAR PENDIENTES"
        Me.gbFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.Location = New System.Drawing.Point(280, 25)
        Me.txtNumDoc.MaxLength = 10
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Numeric = True
        Me.txtNumDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumDoc.Size = New System.Drawing.Size(90, 20)
        Me.txtNumDoc.TabIndex = 15
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDoc.Location = New System.Drawing.Point(136, 25)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(60, 20)
        Me.cmbTipoDoc.TabIndex = 13
        Me.cmbTipoDoc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCodTipoDoc
        '
        Me.txtCodTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodTipoDoc.Location = New System.Drawing.Point(95, 25)
        Me.txtCodTipoDoc.MaxLength = 3
        Me.txtCodTipoDoc.Name = "txtCodTipoDoc"
        Me.txtCodTipoDoc.Numeric = True
        Me.txtCodTipoDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCodTipoDoc.Size = New System.Drawing.Size(35, 20)
        Me.txtCodTipoDoc.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(263, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 192
        Me.Label4.Text = "-"
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDoc.Location = New System.Drawing.Point(202, 25)
        Me.txtSerieDoc.MaxLength = 4
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSerieDoc.Size = New System.Drawing.Size(55, 20)
        Me.txtSerieDoc.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "Documento :"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(201, 72)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 33
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
        Me.btnAceptar.Location = New System.Drawing.Point(117, 72)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 32
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmInsertarPendientes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(396, 107)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbFacturacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInsertarPendientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insertar Pendientes"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFacturacion.ResumeLayout(False)
        Me.gbFacturacion.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtNumDoc As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtCodTipoDoc As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
