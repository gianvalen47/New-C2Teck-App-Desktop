<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrdenCompra_SepararCabAprobacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenCompra_SepararCabAprobacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbAprobacion = New System.Windows.Forms.GroupBox()
        Me.dgvPrueba = New System.Windows.Forms.DataGridView()
        Me.IdOrdenDet1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOrden1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesMer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanRec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanAte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanPen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFecFinSep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniSep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbAprobacion.SuspendLayout()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(302, 121)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbAprobacion
        '
        Me.gbAprobacion.Controls.Add(Me.dgvPrueba)
        Me.gbAprobacion.Controls.Add(Me.txtObservacion)
        Me.gbAprobacion.Controls.Add(Me.Label21)
        Me.gbAprobacion.Controls.Add(Me.txtFecFinSep)
        Me.gbAprobacion.Controls.Add(Me.txtFecIniSep)
        Me.gbAprobacion.Controls.Add(Me.Label3)
        Me.gbAprobacion.Controls.Add(Me.Label10)
        Me.gbAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAprobacion.Location = New System.Drawing.Point(12, 12)
        Me.gbAprobacion.Name = "gbAprobacion"
        Me.gbAprobacion.Size = New System.Drawing.Size(442, 105)
        Me.gbAprobacion.TabIndex = 11
        Me.gbAprobacion.TabStop = False
        Me.gbAprobacion.Text = "Datos de la Aprobación"
        '
        'dgvPrueba
        '
        Me.dgvPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrueba.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOrdenDet1, Me.IdOrden1, Me.CodMer, Me.DesMer1, Me.CanMer, Me.CanRec, Me.CanAte, Me.CanPen, Me.Despacho})
        Me.dgvPrueba.Location = New System.Drawing.Point(13, 57)
        Me.dgvPrueba.Name = "dgvPrueba"
        Me.dgvPrueba.Size = New System.Drawing.Size(43, 42)
        Me.dgvPrueba.TabIndex = 22
        Me.dgvPrueba.Visible = False
        '
        'IdOrdenDet1
        '
        Me.IdOrdenDet1.DataPropertyName = "IdOrdenDet"
        Me.IdOrdenDet1.HeaderText = "IdOrdenDet"
        Me.IdOrdenDet1.Name = "IdOrdenDet1"
        Me.IdOrdenDet1.Visible = False
        '
        'IdOrden1
        '
        Me.IdOrden1.DataPropertyName = "IdOrden"
        Me.IdOrden1.HeaderText = "IdOrden"
        Me.IdOrden1.Name = "IdOrden1"
        Me.IdOrden1.Visible = False
        '
        'CodMer
        '
        Me.CodMer.DataPropertyName = "CodMer"
        Me.CodMer.HeaderText = "Código"
        Me.CodMer.Name = "CodMer"
        Me.CodMer.Width = 110
        '
        'DesMer1
        '
        Me.DesMer1.DataPropertyName = "DesMer1"
        Me.DesMer1.HeaderText = "Descripción"
        Me.DesMer1.Name = "DesMer1"
        Me.DesMer1.Width = 240
        '
        'CanMer
        '
        Me.CanMer.DataPropertyName = "CanMer"
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Me.CanMer.DefaultCellStyle = DataGridViewCellStyle1
        Me.CanMer.HeaderText = "Cant."
        Me.CanMer.Name = "CanMer"
        Me.CanMer.Width = 55
        '
        'CanRec
        '
        Me.CanRec.DataPropertyName = "CanRec"
        Me.CanRec.HeaderText = "CanRec"
        Me.CanRec.Name = "CanRec"
        Me.CanRec.Visible = False
        '
        'CanAte
        '
        Me.CanAte.DataPropertyName = "CanAte"
        Me.CanAte.HeaderText = "CanAte"
        Me.CanAte.Name = "CanAte"
        Me.CanAte.Visible = False
        '
        'CanPen
        '
        Me.CanPen.DataPropertyName = "CanPen"
        Me.CanPen.HeaderText = "CanPen"
        Me.CanPen.Name = "CanPen"
        Me.CanPen.Width = 55
        '
        'Despacho
        '
        Me.Despacho.DataPropertyName = "Despacho"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        Me.Despacho.DefaultCellStyle = DataGridViewCellStyle2
        Me.Despacho.HeaderText = "A Desp."
        Me.Despacho.Name = "Despacho"
        Me.Despacho.Width = 72
        '
        'txtObservacion
        '
        Me.txtObservacion.AcceptsTab = True
        Me.txtObservacion.Location = New System.Drawing.Point(83, 38)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(353, 61)
        Me.txtObservacion.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(4, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Observación"
        '
        'txtFecFinSep
        '
        '
        '
        '
        Me.txtFecFinSep.DropDownCalendar.Name = ""
        Me.txtFecFinSep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinSep.Location = New System.Drawing.Point(262, 16)
        Me.txtFecFinSep.Name = "txtFecFinSep"
        Me.txtFecFinSep.NullButtonText = "Ninguno"
        Me.txtFecFinSep.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinSep.TabIndex = 2
        Me.txtFecFinSep.TodayButtonText = "Hoy"
        Me.txtFecFinSep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIniSep
        '
        '
        '
        '
        Me.txtFecIniSep.DropDownCalendar.Name = ""
        Me.txtFecIniSep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIniSep.Location = New System.Drawing.Point(83, 16)
        Me.txtFecIniSep.Name = "txtFecIniSep"
        Me.txtFecIniSep.NullButtonText = "Ninguno"
        Me.txtFecIniSep.Size = New System.Drawing.Size(94, 20)
        Me.txtFecIniSep.TabIndex = 1
        Me.txtFecIniSep.TodayButtonText = "Hoy"
        Me.txtFecIniSep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Fec. Inicio"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(193, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Fec. Final"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(377, 121)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmOrdenCompra_SepararCabAprobacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 172)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbAprobacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrdenCompra_SepararCabAprobacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Compra - Separar Orden"
        Me.gbAprobacion.ResumeLayout(False)
        Me.gbAprobacion.PerformLayout()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGuardar As Button
    Friend WithEvents gbAprobacion As GroupBox
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtFecFinSep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecIniSep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvPrueba As DataGridView
    Friend WithEvents IdOrdenDet1 As DataGridViewTextBoxColumn
    Friend WithEvents IdOrden1 As DataGridViewTextBoxColumn
    Friend WithEvents CodMer As DataGridViewTextBoxColumn
    Friend WithEvents DesMer1 As DataGridViewTextBoxColumn
    Friend WithEvents CanMer As DataGridViewTextBoxColumn
    Friend WithEvents CanRec As DataGridViewTextBoxColumn
    Friend WithEvents CanAte As DataGridViewTextBoxColumn
    Friend WithEvents CanPen As DataGridViewTextBoxColumn
    Friend WithEvents Despacho As DataGridViewTextBoxColumn
End Class
