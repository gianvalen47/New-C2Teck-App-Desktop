<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumento_GenerarSolGasto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumento_GenerarSolGasto))
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.txtPersonaAutoriza = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscarPersonaA = New System.Windows.Forms.Button()
        Me.txtPersonaSolicita = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarPersonaS = New System.Windows.Forms.Button()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.txtFecDoc)
        Me.gbDatosBusqueda.Controls.Add(Me.Label9)
        Me.gbDatosBusqueda.Controls.Add(Me.btnGenerar)
        Me.gbDatosBusqueda.Controls.Add(Me.btnSalir)
        Me.gbDatosBusqueda.Controls.Add(Me.txtPersonaAutoriza)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscarPersonaA)
        Me.gbDatosBusqueda.Controls.Add(Me.txtPersonaSolicita)
        Me.gbDatosBusqueda.Controls.Add(Me.Label3)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscarPersonaS)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(12, 12)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(374, 177)
        Me.gbDatosBusqueda.TabIndex = 190
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(104, 129)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(78, 25)
        Me.btnGenerar.TabIndex = 6
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(188, 129)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(78, 25)
        Me.btnSalir.TabIndex = 192
        Me.btnSalir.Text = "Cancelar"
        '
        'txtPersonaAutoriza
        '
        Me.txtPersonaAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaAutoriza.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersonaAutoriza.Location = New System.Drawing.Point(75, 86)
        Me.txtPersonaAutoriza.MaxLength = 3
        Me.txtPersonaAutoriza.Name = "txtPersonaAutoriza"
        Me.txtPersonaAutoriza.ReadOnly = True
        Me.txtPersonaAutoriza.Size = New System.Drawing.Size(250, 20)
        Me.txtPersonaAutoriza.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Autoriza"
        '
        'btnBuscarPersonaA
        '
        Me.btnBuscarPersonaA.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersonaA.Location = New System.Drawing.Point(327, 85)
        Me.btnBuscarPersonaA.Name = "btnBuscarPersonaA"
        Me.btnBuscarPersonaA.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersonaA.TabIndex = 5
        Me.btnBuscarPersonaA.TabStop = False
        Me.btnBuscarPersonaA.UseVisualStyleBackColor = True
        '
        'txtPersonaSolicita
        '
        Me.txtPersonaSolicita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaSolicita.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersonaSolicita.Location = New System.Drawing.Point(75, 57)
        Me.txtPersonaSolicita.MaxLength = 3
        Me.txtPersonaSolicita.Name = "txtPersonaSolicita"
        Me.txtPersonaSolicita.ReadOnly = True
        Me.txtPersonaSolicita.Size = New System.Drawing.Size(250, 20)
        Me.txtPersonaSolicita.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Solicita"
        '
        'btnBuscarPersonaS
        '
        Me.btnBuscarPersonaS.Image = CType(resources.GetObject("btnBuscarPersonaS.Image"), System.Drawing.Image)
        Me.btnBuscarPersonaS.Location = New System.Drawing.Point(327, 56)
        Me.btnBuscarPersonaS.Name = "btnBuscarPersonaS"
        Me.btnBuscarPersonaS.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersonaS.TabIndex = 3
        Me.btnBuscarPersonaS.TabStop = False
        Me.btnBuscarPersonaS.UseVisualStyleBackColor = True
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.Visible = False
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecDoc.Location = New System.Drawing.Point(75, 28)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.Size = New System.Drawing.Size(108, 20)
        Me.txtFecDoc.TabIndex = 1
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 194
        Me.Label9.Text = "Fecha"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmDocumento_GenerarSolGasto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(396, 202)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDocumento_GenerarSolGasto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Solicitud de Gasto"
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtPersonaAutoriza As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuscarPersonaA As Button
    Friend WithEvents txtPersonaSolicita As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnBuscarPersonaS As Button
    Friend WithEvents btnGenerar As Button
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label9 As Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
