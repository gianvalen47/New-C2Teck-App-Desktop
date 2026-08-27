<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOportunidadNegocio_GastosMasivo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOportunidadNegocio_GastosMasivo))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarGasto = New System.Windows.Forms.Button()
        Me.txtIdGasto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdGasto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdGastoDet1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescripcion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdDocumento1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSerDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalFila1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdProveedora1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvDocumentos = New System.Windows.Forms.DataGridView()
        Me.cIdGasto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdGastoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSerDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalFila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdProveedora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEliminar})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(118, 26)
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(117, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscarGasto)
        Me.gbDatosBusqueda.Controls.Add(Me.txtIdGasto)
        Me.gbDatosBusqueda.Controls.Add(Me.Label5)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(12, 12)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(1002, 59)
        Me.gbDatosBusqueda.TabIndex = 1
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarGasto
        '
        Me.btnBuscarGasto.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarGasto.Location = New System.Drawing.Point(555, 31)
        Me.btnBuscarGasto.Name = "btnBuscarGasto"
        Me.btnBuscarGasto.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarGasto.TabIndex = 194
        Me.btnBuscarGasto.TabStop = False
        Me.btnBuscarGasto.UseVisualStyleBackColor = True
        '
        'txtIdGasto
        '
        Me.txtIdGasto.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdGasto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdGasto.Location = New System.Drawing.Point(442, 32)
        Me.txtIdGasto.MaxLength = 10
        Me.txtIdGasto.Name = "txtIdGasto"
        Me.txtIdGasto.Size = New System.Drawing.Size(107, 20)
        Me.txtIdGasto.TabIndex = 3
        Me.txtIdGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(468, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "Nº Gasto"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(586, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(108, 25)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Listar Gastos"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(519, 340)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 62
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Location = New System.Drawing.Point(774, 84)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(29, 13)
        Me.lblRegistros.TabIndex = 60
        Me.lblRegistros.Text = "Num"
        Me.lblRegistros.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(436, 340)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 61
        Me.btnGuardar.Text = "Ingresar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(692, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 59
        Me.Label13.Text = "#Registros :"
        Me.Label13.Visible = False
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdGasto1, Me.cIdGastoDet1, Me.cDesProv1, Me.cAbrDoc1, Me.cDescripcion1, Me.cIdDocumento1, Me.cSerDoc1, Me.cNumDoc1, Me.cFecDoc1, Me.cTotalFila1, Me.cIdProveedora1, Me.cCodMon1})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(543, 100)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(471, 220)
        Me.dgvSeleccionados.TabIndex = 55
        Me.dgvSeleccionados.TabStop = False
        '
        'cIdGasto1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdGasto1.DefaultCellStyle = DataGridViewCellStyle1
        Me.cIdGasto1.HeaderText = "Gasto"
        Me.cIdGasto1.Name = "cIdGasto1"
        Me.cIdGasto1.Width = 58
        '
        'cIdGastoDet1
        '
        Me.cIdGastoDet1.HeaderText = "IdGastoDet"
        Me.cIdGastoDet1.Name = "cIdGastoDet1"
        Me.cIdGastoDet1.Visible = False
        '
        'cDesProv1
        '
        Me.cDesProv1.HeaderText = "Proveedor"
        Me.cDesProv1.Name = "cDesProv1"
        '
        'cAbrDoc1
        '
        Me.cAbrDoc1.HeaderText = "Doc"
        Me.cAbrDoc1.Name = "cAbrDoc1"
        Me.cAbrDoc1.Width = 50
        '
        'cDescripcion1
        '
        Me.cDescripcion1.HeaderText = "Descripcion"
        Me.cDescripcion1.Name = "cDescripcion1"
        Me.cDescripcion1.Visible = False
        Me.cDescripcion1.Width = 120
        '
        'cIdDocumento1
        '
        Me.cIdDocumento1.HeaderText = "IdDocumento"
        Me.cIdDocumento1.Name = "cIdDocumento1"
        Me.cIdDocumento1.Visible = False
        '
        'cSerDoc1
        '
        Me.cSerDoc1.HeaderText = "SerDoc"
        Me.cSerDoc1.Name = "cSerDoc1"
        Me.cSerDoc1.Visible = False
        '
        'cNumDoc1
        '
        Me.cNumDoc1.HeaderText = "NumDoc"
        Me.cNumDoc1.Name = "cNumDoc1"
        Me.cNumDoc1.Width = 80
        '
        'cFecDoc1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cFecDoc1.DefaultCellStyle = DataGridViewCellStyle2
        Me.cFecDoc1.HeaderText = "FecDoc"
        Me.cFecDoc1.Name = "cFecDoc1"
        Me.cFecDoc1.Width = 75
        '
        'cTotalFila1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cTotalFila1.DefaultCellStyle = DataGridViewCellStyle3
        Me.cTotalFila1.HeaderText = "Monto"
        Me.cTotalFila1.Name = "cTotalFila1"
        Me.cTotalFila1.Width = 80
        '
        'cIdProveedora1
        '
        Me.cIdProveedora1.HeaderText = "IdProveedor"
        Me.cIdProveedora1.Name = "cIdProveedora1"
        Me.cIdProveedora1.Visible = False
        '
        'cCodMon1
        '
        Me.cCodMon1.HeaderText = "CodMon"
        Me.cCodMon1.Name = "cCodMon1"
        Me.cCodMon1.Visible = False
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(494, 218)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 27)
        Me.btnAgregarTodos.TabIndex = 58
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(14, 81)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(87, 15)
        Me.lblPersonal.TabIndex = 54
        Me.lblPersonal.Text = "Documentos"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(494, 177)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 27)
        Me.btnAgregar.TabIndex = 57
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(540, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 15)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Seleccionados"
        '
        'dgvDocumentos
        '
        Me.dgvDocumentos.AllowUserToAddRows = False
        Me.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDocumentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdGasto, Me.cIdGastoDet, Me.cDesProv, Me.cAbrDoc, Me.cDescripcion, Me.cIdDocumento, Me.cSerDoc, Me.cNumDoc, Me.cFecDoc, Me.cTotalFila, Me.cIdProveedora, Me.cCodMon})
        Me.dgvDocumentos.Location = New System.Drawing.Point(16, 100)
        Me.dgvDocumentos.Name = "dgvDocumentos"
        Me.dgvDocumentos.RowHeadersVisible = False
        Me.dgvDocumentos.Size = New System.Drawing.Size(472, 220)
        Me.dgvDocumentos.TabIndex = 53
        Me.dgvDocumentos.TabStop = False
        '
        'cIdGasto
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdGasto.DefaultCellStyle = DataGridViewCellStyle4
        Me.cIdGasto.HeaderText = "Gasto"
        Me.cIdGasto.Name = "cIdGasto"
        Me.cIdGasto.Width = 58
        '
        'cIdGastoDet
        '
        Me.cIdGastoDet.HeaderText = "IdGastoDet"
        Me.cIdGastoDet.Name = "cIdGastoDet"
        Me.cIdGastoDet.Visible = False
        '
        'cDesProv
        '
        Me.cDesProv.HeaderText = "Proveedor"
        Me.cDesProv.Name = "cDesProv"
        '
        'cAbrDoc
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cAbrDoc.DefaultCellStyle = DataGridViewCellStyle5
        Me.cAbrDoc.HeaderText = "Doc"
        Me.cAbrDoc.Name = "cAbrDoc"
        Me.cAbrDoc.Width = 50
        '
        'cDescripcion
        '
        Me.cDescripcion.HeaderText = "Descripcion"
        Me.cDescripcion.Name = "cDescripcion"
        Me.cDescripcion.Visible = False
        Me.cDescripcion.Width = 120
        '
        'cIdDocumento
        '
        Me.cIdDocumento.HeaderText = "IdDocumento"
        Me.cIdDocumento.Name = "cIdDocumento"
        Me.cIdDocumento.Visible = False
        '
        'cSerDoc
        '
        Me.cSerDoc.HeaderText = "SerDoc"
        Me.cSerDoc.Name = "cSerDoc"
        Me.cSerDoc.Visible = False
        '
        'cNumDoc
        '
        Me.cNumDoc.HeaderText = "NumDoc"
        Me.cNumDoc.Name = "cNumDoc"
        Me.cNumDoc.Width = 80
        '
        'cFecDoc
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cFecDoc.DefaultCellStyle = DataGridViewCellStyle6
        Me.cFecDoc.HeaderText = "FecDoc"
        Me.cFecDoc.Name = "cFecDoc"
        Me.cFecDoc.Width = 75
        '
        'cTotalFila
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.cTotalFila.DefaultCellStyle = DataGridViewCellStyle7
        Me.cTotalFila.HeaderText = "Monto"
        Me.cTotalFila.Name = "cTotalFila"
        Me.cTotalFila.Width = 80
        '
        'cIdProveedora
        '
        Me.cIdProveedora.HeaderText = "IdProveedora"
        Me.cIdProveedora.Name = "cIdProveedora"
        Me.cIdProveedora.Visible = False
        '
        'cCodMon
        '
        Me.cCodMon.HeaderText = "CodMon"
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.Visible = False
        '
        'frmOportunidadNegocio_GastosMasivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1030, 384)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvDocumentos)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOportunidadNegocio_GastosMasivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Oportunidades de Negocio - Ingreso Masivo de Gastos"
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDocumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmbOpciones As ContextMenuStrip
    Friend WithEvents miEliminar As ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtIdGasto As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblRegistros As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents dgvSeleccionados As DataGridView
    Friend WithEvents btnAgregarTodos As Button
    Friend WithEvents lblPersonal As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvDocumentos As DataGridView
    Friend WithEvents btnBuscarGasto As Button
    Friend WithEvents cIdGasto1 As DataGridViewTextBoxColumn
    Friend WithEvents cIdGastoDet1 As DataGridViewTextBoxColumn
    Friend WithEvents cDesProv1 As DataGridViewTextBoxColumn
    Friend WithEvents cAbrDoc1 As DataGridViewTextBoxColumn
    Friend WithEvents cDescripcion1 As DataGridViewTextBoxColumn
    Friend WithEvents cIdDocumento1 As DataGridViewTextBoxColumn
    Friend WithEvents cSerDoc1 As DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc1 As DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc1 As DataGridViewTextBoxColumn
    Friend WithEvents cTotalFila1 As DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedora1 As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon1 As DataGridViewTextBoxColumn
    Friend WithEvents cIdGasto As DataGridViewTextBoxColumn
    Friend WithEvents cIdGastoDet As DataGridViewTextBoxColumn
    Friend WithEvents cDesProv As DataGridViewTextBoxColumn
    Friend WithEvents cAbrDoc As DataGridViewTextBoxColumn
    Friend WithEvents cDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents cIdDocumento As DataGridViewTextBoxColumn
    Friend WithEvents cSerDoc As DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc As DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc As DataGridViewTextBoxColumn
    Friend WithEvents cTotalFila As DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedora As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As DataGridViewTextBoxColumn
End Class
