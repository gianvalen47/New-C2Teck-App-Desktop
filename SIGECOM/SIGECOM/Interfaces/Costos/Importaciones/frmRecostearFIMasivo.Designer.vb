<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecostearFIMasivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecostearFIMasivo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdImportacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdSerieDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesAlm1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdProveedor1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMon1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipCam1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotFobGen1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotFobGenSol1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNeto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNetoSol1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEstado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvFacturas = New System.Windows.Forms.DataGridView()
        Me.cIdImportacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdSerieDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdLocacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesAlm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipCam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotFobGen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotFobGenSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalNetoSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.MaskedTextBox()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
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
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(371, 269)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 53
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(276, 269)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(89, 25)
        Me.btnAceptar.TabIndex = 52
        Me.btnAceptar.Text = "Recostear"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Location = New System.Drawing.Point(621, 68)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(29, 13)
        Me.lblRegistros.TabIndex = 51
        Me.lblRegistros.Text = "Num"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(539, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "#Registros :"
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdImportacion1, Me.cIdSerieDoc1, Me.cIdLocacion1, Me.cNumDoc1, Me.cDesAlm1, Me.cFecDoc1, Me.cIdProveedor1, Me.cDesProv1, Me.cCodMon1, Me.cDesMon1, Me.cTipCam1, Me.cObservacion1, Me.cTotFobGen1, Me.cTotFobGenSol1, Me.cTotalNeto1, Me.cTotalNetoSol1, Me.cEstado1})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(408, 84)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(320, 178)
        Me.dgvSeleccionados.TabIndex = 46
        '
        'cIdImportacion1
        '
        Me.cIdImportacion1.HeaderText = "IdImportacion"
        Me.cIdImportacion1.Name = "cIdImportacion1"
        Me.cIdImportacion1.Visible = False
        '
        'cIdSerieDoc1
        '
        Me.cIdSerieDoc1.HeaderText = "IdSerieDoc"
        Me.cIdSerieDoc1.Name = "cIdSerieDoc1"
        Me.cIdSerieDoc1.Visible = False
        '
        'cIdLocacion1
        '
        Me.cIdLocacion1.HeaderText = "IdLocacion"
        Me.cIdLocacion1.Name = "cIdLocacion1"
        Me.cIdLocacion1.Visible = False
        '
        'cNumDoc1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNumDoc1.DefaultCellStyle = DataGridViewCellStyle1
        Me.cNumDoc1.HeaderText = "Número"
        Me.cNumDoc1.Name = "cNumDoc1"
        Me.cNumDoc1.ReadOnly = True
        Me.cNumDoc1.Width = 130
        '
        'cDesAlm1
        '
        Me.cDesAlm1.HeaderText = "Almacén"
        Me.cDesAlm1.Name = "cDesAlm1"
        Me.cDesAlm1.ReadOnly = True
        Me.cDesAlm1.Width = 170
        '
        'cFecDoc1
        '
        Me.cFecDoc1.HeaderText = "FecDoc"
        Me.cFecDoc1.Name = "cFecDoc1"
        Me.cFecDoc1.Visible = False
        '
        'cIdProveedor1
        '
        Me.cIdProveedor1.HeaderText = "IdProveedor"
        Me.cIdProveedor1.Name = "cIdProveedor1"
        Me.cIdProveedor1.Visible = False
        '
        'cDesProv1
        '
        Me.cDesProv1.HeaderText = "DesProv"
        Me.cDesProv1.Name = "cDesProv1"
        Me.cDesProv1.Visible = False
        '
        'cCodMon1
        '
        Me.cCodMon1.HeaderText = "CodMon"
        Me.cCodMon1.Name = "cCodMon1"
        Me.cCodMon1.Visible = False
        '
        'cDesMon1
        '
        Me.cDesMon1.HeaderText = "DesMon"
        Me.cDesMon1.Name = "cDesMon1"
        Me.cDesMon1.Visible = False
        '
        'cTipCam1
        '
        Me.cTipCam1.HeaderText = "TipCam"
        Me.cTipCam1.Name = "cTipCam1"
        Me.cTipCam1.Visible = False
        '
        'cObservacion1
        '
        Me.cObservacion1.HeaderText = "Observacion"
        Me.cObservacion1.Name = "cObservacion1"
        Me.cObservacion1.Visible = False
        '
        'cTotFobGen1
        '
        Me.cTotFobGen1.HeaderText = "TotFobGen"
        Me.cTotFobGen1.Name = "cTotFobGen1"
        Me.cTotFobGen1.Visible = False
        '
        'cTotFobGenSol1
        '
        Me.cTotFobGenSol1.HeaderText = "TotFobGenSol"
        Me.cTotFobGenSol1.Name = "cTotFobGenSol1"
        Me.cTotFobGenSol1.Visible = False
        '
        'cTotalNeto1
        '
        Me.cTotalNeto1.HeaderText = "TotalNeto"
        Me.cTotalNeto1.Name = "cTotalNeto1"
        Me.cTotalNeto1.Visible = False
        '
        'cTotalNetoSol1
        '
        Me.cTotalNetoSol1.HeaderText = "TotalNetoSol"
        Me.cTotalNetoSol1.Name = "cTotalNetoSol1"
        Me.cTotalNetoSol1.Visible = False
        '
        'cEstado1
        '
        Me.cEstado1.HeaderText = "Estado"
        Me.cEstado1.Name = "cEstado1"
        Me.cEstado1.Visible = False
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(346, 178)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 49
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(4, 66)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(62, 15)
        Me.lblPersonal.TabIndex = 45
        Me.lblPersonal.Text = "Facturas"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(346, 137)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregar.TabIndex = 48
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(405, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Seleccionados"
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowUserToAddRows = False
        Me.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdImportacion, Me.cIdSerieDoc, Me.cIdLocacion, Me.cNumDoc, Me.cDesAlm, Me.cFecDoc, Me.cIdProveedor, Me.cDesProv, Me.cCodMon, Me.cDesMon, Me.cTipCam, Me.cObservacion, Me.cTotFobGen, Me.cTotFobGenSol, Me.cTotalNeto, Me.cTotalNetoSol, Me.cEstado})
        Me.dgvFacturas.Location = New System.Drawing.Point(7, 84)
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.RowHeadersVisible = False
        Me.dgvFacturas.Size = New System.Drawing.Size(320, 178)
        Me.dgvFacturas.TabIndex = 44
        '
        'cIdImportacion
        '
        Me.cIdImportacion.HeaderText = "IdImportacion"
        Me.cIdImportacion.Name = "cIdImportacion"
        Me.cIdImportacion.Visible = False
        '
        'cIdSerieDoc
        '
        Me.cIdSerieDoc.HeaderText = "IdSerieDoc"
        Me.cIdSerieDoc.Name = "cIdSerieDoc"
        Me.cIdSerieDoc.Visible = False
        '
        'cIdLocacion
        '
        Me.cIdLocacion.HeaderText = "IdLocacion"
        Me.cIdLocacion.Name = "cIdLocacion"
        Me.cIdLocacion.Visible = False
        '
        'cNumDoc
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cNumDoc.DefaultCellStyle = DataGridViewCellStyle2
        Me.cNumDoc.HeaderText = "Número"
        Me.cNumDoc.Name = "cNumDoc"
        Me.cNumDoc.ReadOnly = True
        Me.cNumDoc.Width = 130
        '
        'cDesAlm
        '
        Me.cDesAlm.HeaderText = "Almacén"
        Me.cDesAlm.Name = "cDesAlm"
        Me.cDesAlm.ReadOnly = True
        Me.cDesAlm.Width = 170
        '
        'cFecDoc
        '
        Me.cFecDoc.HeaderText = "FecDoc"
        Me.cFecDoc.Name = "cFecDoc"
        Me.cFecDoc.Visible = False
        '
        'cIdProveedor
        '
        Me.cIdProveedor.HeaderText = "IdProveedor"
        Me.cIdProveedor.Name = "cIdProveedor"
        Me.cIdProveedor.Visible = False
        '
        'cDesProv
        '
        Me.cDesProv.HeaderText = "DesProv"
        Me.cDesProv.Name = "cDesProv"
        Me.cDesProv.Visible = False
        '
        'cCodMon
        '
        Me.cCodMon.HeaderText = "CodMon"
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.Visible = False
        '
        'cDesMon
        '
        Me.cDesMon.HeaderText = "DesMon"
        Me.cDesMon.Name = "cDesMon"
        Me.cDesMon.Visible = False
        '
        'cTipCam
        '
        Me.cTipCam.HeaderText = "TipCam"
        Me.cTipCam.Name = "cTipCam"
        Me.cTipCam.Visible = False
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observacion"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.Visible = False
        '
        'cTotFobGen
        '
        Me.cTotFobGen.HeaderText = "TotFobGen"
        Me.cTotFobGen.Name = "cTotFobGen"
        Me.cTotFobGen.Visible = False
        '
        'cTotFobGenSol
        '
        Me.cTotFobGenSol.HeaderText = "TotFobGenSol"
        Me.cTotFobGenSol.Name = "cTotFobGenSol"
        Me.cTotFobGenSol.Visible = False
        '
        'cTotalNeto
        '
        Me.cTotalNeto.HeaderText = "TotalNeto"
        Me.cTotalNeto.Name = "cTotalNeto"
        Me.cTotalNeto.Visible = False
        '
        'cTotalNetoSol
        '
        Me.cTotalNetoSol.HeaderText = "TotalNetoSol"
        Me.cTotalNetoSol.Name = "cTotalNetoSol"
        Me.cTotalNetoSol.Visible = False
        '
        'cEstado
        '
        Me.cEstado.HeaderText = "Estado"
        Me.cEstado.Name = "cEstado"
        Me.cEstado.Visible = False
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.txtCodEmbarque)
        Me.gbDatosBusqueda.Controls.Add(Me.Label14)
        Me.gbDatosBusqueda.Controls.Add(Me.dtFinal)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.Label10)
        Me.gbDatosBusqueda.Controls.Add(Me.dtInicio)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Controls.Add(Me.Label6)
        Me.gbDatosBusqueda.Controls.Add(Me.txtNumero)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(7, 5)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(721, 56)
        Me.gbDatosBusqueda.TabIndex = 43
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmbarque.Location = New System.Drawing.Point(308, 31)
        Me.txtCodEmbarque.MaxLength = 30
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(123, 20)
        Me.txtCodEmbarque.TabIndex = 20
        Me.txtCodEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(325, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Cod Embarque"
        '
        'dtFinal
        '
        '
        '
        '
        Me.dtFinal.DropDownCalendar.Name = ""
        Me.dtFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.dtFinal.Location = New System.Drawing.Point(163, 31)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.NullButtonText = "Ninguno"
        Me.dtFinal.Size = New System.Drawing.Size(97, 20)
        Me.dtFinal.TabIndex = 18
        Me.dtFinal.TodayButtonText = "Hoy"
        Me.dtFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(174, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Fecha Final"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Fecha Inicio"
        '
        'dtInicio
        '
        '
        '
        '
        Me.dtInicio.DropDownCalendar.Name = ""
        Me.dtInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.dtInicio.Location = New System.Drawing.Point(26, 31)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.NullButtonText = "Ninguno"
        Me.dtInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtInicio.TabIndex = 16
        Me.dtInicio.TodayButtonText = "Hoy"
        Me.dtInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(634, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 22)
        Me.btnBuscar.TabIndex = 22
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(511, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Numero"
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(478, 32)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(123, 20)
        Me.txtNumero.TabIndex = 21
        '
        'frmRecostearFIMasivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(736, 302)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblRegistros)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvFacturas)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRecostearFIMasivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recostear F/I Masivo"
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents cIdImportacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdSerieDoc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesAlm1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedor1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesProv1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMon1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMon1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTipCam1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotFobGen1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotFobGenSol1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNeto1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNetoSol1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEstado1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents cIdImportacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdSerieDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesAlm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesProv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTipCam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotFobGen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotFobGenSol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNeto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalNetoSol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
End Class
