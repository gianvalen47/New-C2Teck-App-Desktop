<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPlanillaSueldos_GenerarArchivoPlame
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaSueldos_GenerarArchivoPlame))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.rbFor = New System.Windows.Forms.RadioButton()
        Me.rb4TA = New System.Windows.Forms.RadioButton()
        Me.rbPS4 = New System.Windows.Forms.RadioButton()
        Me.rbTOC = New System.Windows.Forms.RadioButton()
        Me.rbOR5 = New System.Windows.Forms.RadioButton()
        Me.rbSNL = New System.Windows.Forms.RadioButton()
        Me.rbRem = New System.Windows.Forms.RadioButton()
        Me.rbJor = New System.Windows.Forms.RadioButton()
        Me.gbArea = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbSegunSeleccionado = New System.Windows.Forms.RadioButton()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(249, 330)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(103, 33)
        Me.btnCancelar.TabIndex = 33
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Canjear
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(131, 330)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(100, 33)
        Me.btnGuardar.TabIndex = 32
        Me.btnGuardar.Text = "Generar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvDatos)
        Me.GroupBox1.Controls.Add(Me.rbFor)
        Me.GroupBox1.Controls.Add(Me.rb4TA)
        Me.GroupBox1.Controls.Add(Me.rbPS4)
        Me.GroupBox1.Controls.Add(Me.rbTOC)
        Me.GroupBox1.Controls.Add(Me.rbOR5)
        Me.GroupBox1.Controls.Add(Me.rbSNL)
        Me.GroupBox1.Controls.Add(Me.rbRem)
        Me.GroupBox1.Controls.Add(Me.rbJor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(37, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 243)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones Plame"
        '
        'dgvDatos
        '
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(302, 111)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Size = New System.Drawing.Size(64, 23)
        Me.dgvDatos.TabIndex = 35
        Me.dgvDatos.Visible = False
        '
        'rbFor
        '
        Me.rbFor.AutoSize = True
        Me.rbFor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFor.Location = New System.Drawing.Point(7, 213)
        Me.rbFor.Name = "rbFor"
        Me.rbFor.Size = New System.Drawing.Size(215, 17)
        Me.rbFor.TabIndex = 7
        Me.rbFor.TabStop = True
        Me.rbFor.Text = "Modalidad formativa Laboral y Otros (for)"
        Me.rbFor.UseVisualStyleBackColor = True
        '
        'rb4TA
        '
        Me.rb4TA.AutoSize = True
        Me.rb4TA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb4TA.Location = New System.Drawing.Point(7, 185)
        Me.rb4TA.Name = "rb4TA"
        Me.rb4TA.Size = New System.Drawing.Size(301, 17)
        Me.rb4TA.TabIndex = 6
        Me.rb4TA.TabStop = True
        Me.rb4TA.Text = "Prestador de Servicios con Rentas de 4ta categoría. (4ta) "
        Me.rb4TA.UseVisualStyleBackColor = True
        '
        'rbPS4
        '
        Me.rbPS4.AutoSize = True
        Me.rbPS4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPS4.Location = New System.Drawing.Point(7, 158)
        Me.rbPS4.Name = "rbPS4"
        Me.rbPS4.Size = New System.Drawing.Size(318, 17)
        Me.rbPS4.TabIndex = 5
        Me.rbPS4.TabStop = True
        Me.rbPS4.Text = "Prestadores de Servicios con Rentas de 4ta. Categoría. (PS4)"
        Me.rbPS4.UseVisualStyleBackColor = True
        '
        'rbTOC
        '
        Me.rbTOC.AutoSize = True
        Me.rbTOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTOC.Location = New System.Drawing.Point(7, 130)
        Me.rbTOC.Name = "rbTOC"
        Me.rbTOC.Size = New System.Drawing.Size(227, 17)
        Me.rbTOC.TabIndex = 4
        Me.rbTOC.TabStop = True
        Me.rbTOC.Text = "Trabajador - Otras condiciones  +Vida (toc)"
        Me.rbTOC.UseVisualStyleBackColor = True
        '
        'rbOR5
        '
        Me.rbOR5.AutoSize = True
        Me.rbOR5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOR5.Location = New System.Drawing.Point(7, 102)
        Me.rbOR5.Name = "rbOR5"
        Me.rbOR5.Size = New System.Drawing.Size(256, 17)
        Me.rbOR5.TabIndex = 3
        Me.rbOR5.TabStop = True
        Me.rbOR5.Text = "Trabajador - Otras Rentas de 5ta. categoría (or5)"
        Me.rbOR5.UseVisualStyleBackColor = True
        '
        'rbSNL
        '
        Me.rbSNL.AutoSize = True
        Me.rbSNL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSNL.Location = New System.Drawing.Point(7, 73)
        Me.rbSNL.Name = "rbSNL"
        Me.rbSNL.Size = New System.Drawing.Size(286, 17)
        Me.rbSNL.TabIndex = 2
        Me.rbSNL.TabStop = True
        Me.rbSNL.Text = "Trabajador - Días subsidiados y otros no laborados (snl)"
        Me.rbSNL.UseVisualStyleBackColor = True
        '
        'rbRem
        '
        Me.rbRem.AutoSize = True
        Me.rbRem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRem.Location = New System.Drawing.Point(7, 46)
        Me.rbRem.Name = "rbRem"
        Me.rbRem.Size = New System.Drawing.Size(383, 17)
        Me.rbRem.TabIndex = 1
        Me.rbRem.TabStop = True
        Me.rbRem.Text = "Datos del detalle de los Ingresos, Tributos y Descuentos del trabajador (rem)"
        Me.rbRem.UseVisualStyleBackColor = True
        '
        'rbJor
        '
        Me.rbJor.AutoSize = True
        Me.rbJor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbJor.Location = New System.Drawing.Point(7, 20)
        Me.rbJor.Name = "rbJor"
        Me.rbJor.Size = New System.Drawing.Size(247, 17)
        Me.rbJor.TabIndex = 0
        Me.rbJor.TabStop = True
        Me.rbJor.Text = "Datos de la jornada Laboral por Trabajador (jor)"
        Me.rbJor.UseVisualStyleBackColor = True
        '
        'gbArea
        '
        Me.gbArea.Controls.Add(Me.rbTodos)
        Me.gbArea.Controls.Add(Me.rbSegunSeleccionado)
        Me.gbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbArea.Location = New System.Drawing.Point(79, 12)
        Me.gbArea.Name = "gbArea"
        Me.gbArea.Size = New System.Drawing.Size(315, 50)
        Me.gbArea.TabIndex = 35
        Me.gbArea.Text = "Generar "
        Me.gbArea.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbArea.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.Location = New System.Drawing.Point(193, 21)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbTodos.TabIndex = 2
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbSegunSeleccionado
        '
        Me.rbSegunSeleccionado.AutoSize = True
        Me.rbSegunSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSegunSeleccionado.Location = New System.Drawing.Point(43, 21)
        Me.rbSegunSeleccionado.Name = "rbSegunSeleccionado"
        Me.rbSegunSeleccionado.Size = New System.Drawing.Size(122, 17)
        Me.rbSegunSeleccionado.TabIndex = 1
        Me.rbSegunSeleccionado.TabStop = True
        Me.rbSegunSeleccionado.Text = "Segun seleccionado"
        Me.rbSegunSeleccionado.UseVisualStyleBackColor = True
        '
        'frmPlanillaSueldos_GenerarArchivoPlame
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(470, 393)
        Me.Controls.Add(Me.gbArea)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillaSueldos_GenerarArchivoPlame"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar archivo PLAME"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbArea.ResumeLayout(False)
        Me.gbArea.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbRem As RadioButton
    Friend WithEvents rbJor As RadioButton
    Friend WithEvents dgvDatos As DataGridView
    Friend WithEvents rbSNL As RadioButton
    Friend WithEvents rbTOC As RadioButton
    Friend WithEvents rbOR5 As RadioButton
    Friend WithEvents rb4TA As RadioButton
    Friend WithEvents rbPS4 As RadioButton
    Friend WithEvents rbFor As RadioButton
    Friend WithEvents gbArea As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents rbSegunSeleccionado As RadioButton
End Class
