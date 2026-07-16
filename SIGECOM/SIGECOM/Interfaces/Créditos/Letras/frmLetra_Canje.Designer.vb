<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLetra_Canje
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLetra_Canje))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumLet1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtNumLet2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecAcep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtTotLet = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtTotCanje = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCanjear = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.Beige
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(91, 15)
        Me.txtCliente.MaxLength = 60
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(289, 20)
        Me.txtCliente.TabIndex = 1
        Me.txtCliente.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Letras del :"
        '
        'txtNumLet1
        '
        Me.txtNumLet1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumLet1.Location = New System.Drawing.Point(91, 41)
        Me.txtNumLet1.MaxLength = 60
        Me.txtNumLet1.Name = "txtNumLet1"
        Me.txtNumLet1.Size = New System.Drawing.Size(90, 20)
        Me.txtNumLet1.TabIndex = 3
        '
        'txtNumLet2
        '
        Me.txtNumLet2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumLet2.Location = New System.Drawing.Point(238, 41)
        Me.txtNumLet2.MaxLength = 60
        Me.txtNumLet2.Name = "txtNumLet2"
        Me.txtNumLet2.Size = New System.Drawing.Size(90, 20)
        Me.txtNumLet2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(205, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Al :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(410, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 15)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Fechas de Aceptación :"
        '
        'txtFecAcep
        '
        '
        '
        '
        Me.txtFecAcep.DropDownCalendar.Name = ""
        Me.txtFecAcep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecAcep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecAcep.Location = New System.Drawing.Point(571, 14)
        Me.txtFecAcep.Name = "txtFecAcep"
        Me.txtFecAcep.NullButtonText = "Ninguno"
        Me.txtFecAcep.Size = New System.Drawing.Size(93, 20)
        Me.txtFecAcep.TabIndex = 2
        Me.txtFecAcep.TodayButtonText = "Hoy"
        Me.txtFecAcep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtTotLet
        '
        Me.txtTotLet.BackColor = System.Drawing.Color.Beige
        Me.txtTotLet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotLet.Location = New System.Drawing.Point(424, 42)
        Me.txtTotLet.MaxLength = 60
        Me.txtTotLet.Name = "txtTotLet"
        Me.txtTotLet.ReadOnly = True
        Me.txtTotLet.Size = New System.Drawing.Size(90, 20)
        Me.txtTotLet.TabIndex = 5
        Me.txtTotLet.TabStop = False
        '
        'txtTotCanje
        '
        Me.txtTotCanje.BackColor = System.Drawing.Color.Beige
        Me.txtTotCanje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotCanje.Location = New System.Drawing.Point(607, 42)
        Me.txtTotCanje.MaxLength = 60
        Me.txtTotCanje.Name = "txtTotCanje"
        Me.txtTotCanje.ReadOnly = True
        Me.txtTotCanje.Size = New System.Drawing.Size(90, 20)
        Me.txtTotCanje.TabIndex = 6
        Me.txtTotCanje.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(354, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Tot. Letra"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(536, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Tot.Canje"
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(6, 75)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(692, 200)
        Me.dgvDatos.TabIndex = 32
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(618, 282)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 123
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCanjear
        '
        Me.btnCanjear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCanjear.Image = Global.SIGECOM.My.Resources.Resources.Canjear
        Me.btnCanjear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCanjear.Location = New System.Drawing.Point(529, 282)
        Me.btnCanjear.Name = "btnCanjear"
        Me.btnCanjear.Size = New System.Drawing.Size(83, 32)
        Me.btnCanjear.TabIndex = 122
        Me.btnCanjear.Text = "Canjear"
        Me.btnCanjear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCanjear.UseVisualStyleBackColor = True
        '
        'frmLetra_Canje
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(705, 321)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnCanjear)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotCanje)
        Me.Controls.Add(Me.txtTotLet)
        Me.Controls.Add(Me.txtFecAcep)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNumLet2)
        Me.Controls.Add(Me.txtNumLet1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCliente)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLetra_Canje"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Canjear Letra"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumLet2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtNumLet1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFecAcep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtTotLet As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotCanje As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCanjear As System.Windows.Forms.Button
End Class
