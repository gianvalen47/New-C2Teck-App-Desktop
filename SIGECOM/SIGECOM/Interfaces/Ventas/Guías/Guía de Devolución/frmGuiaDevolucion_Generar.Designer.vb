<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaDevolucion_Generar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaDevolucion_Generar))
        Me.gbGenrarGuia = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.btnBuscarDocumento = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIgv = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblCodMon = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbldLocCli = New System.Windows.Forms.Label()
        Me.lblCodMot = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnModificarObservacion = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmOpcionesAtender = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbGenrarGuia.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesAtender.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbGenrarGuia
        '
        Me.gbGenrarGuia.Controls.Add(Me.txtObservacion)
        Me.gbGenrarGuia.Controls.Add(Me.lblUbicacion)
        Me.gbGenrarGuia.Controls.Add(Me.UiGroupBox2)
        Me.gbGenrarGuia.Controls.Add(Me.btnModificarObservacion)
        Me.gbGenrarGuia.Controls.Add(Me.UiGroupBox1)
        Me.gbGenrarGuia.Controls.Add(Me.Label21)
        Me.gbGenrarGuia.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbGenrarGuia.Location = New System.Drawing.Point(0, 0)
        Me.gbGenrarGuia.Name = "gbGenrarGuia"
        Me.gbGenrarGuia.Size = New System.Drawing.Size(807, 177)
        Me.gbGenrarGuia.TabIndex = 0
        Me.gbGenrarGuia.TabStop = False
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(16, 140)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(759, 20)
        Me.txtObservacion.TabIndex = 9
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Location = New System.Drawing.Point(404, 12)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(134, 13)
        Me.lblUbicacion.TabIndex = 0
        Me.lblUbicacion.Text = "OFICINA  -  ALMACÉN"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.lblFecha)
        Me.UiGroupBox2.Controls.Add(Me.lblCliente)
        Me.UiGroupBox2.Controls.Add(Me.txtNumero)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarDocumento)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.lblIgv)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Controls.Add(Me.lblNumJob)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.Label13)
        Me.UiGroupBox2.Controls.Add(Me.lblCodMon)
        Me.UiGroupBox2.Controls.Add(Me.Label16)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.lbldLocCli)
        Me.UiGroupBox2.Controls.Add(Me.lblCodMot)
        Me.UiGroupBox2.Controls.Add(Me.Label20)
        Me.UiGroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UiGroupBox2.Location = New System.Drawing.Point(15, 11)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(565, 90)
        Me.UiGroupBox2.TabIndex = 1
        Me.UiGroupBox2.Text = " [  Documento a Devolver  ] "
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'lblFecha
        '
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.ForeColor = System.Drawing.Color.Black
        Me.lblFecha.Location = New System.Drawing.Point(248, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(81, 16)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "......"
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(70, 42)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(253, 17)
        Me.lblCliente.TabIndex = 6
        Me.lblCliente.Text = "......"
        '
        'txtNumero
        '
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNumero.Location = New System.Drawing.Point(75, 15)
        Me.txtNumero.MaxLength = 200
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(91, 20)
        Me.txtNumero.TabIndex = 5
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarDocumento
        '
        Me.btnBuscarDocumento.Image = CType(resources.GetObject("btnBuscarDocumento.Image"), System.Drawing.Image)
        Me.btnBuscarDocumento.Location = New System.Drawing.Point(167, 14)
        Me.btnBuscarDocumento.Name = "btnBuscarDocumento"
        Me.btnBuscarDocumento.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarDocumento.TabIndex = 7
        Me.btnBuscarDocumento.TabStop = False
        Me.btnBuscarDocumento.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(198, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fecha :"
        '
        'lblIgv
        '
        Me.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIgv.ForeColor = System.Drawing.Color.Black
        Me.lblIgv.Location = New System.Drawing.Point(507, 18)
        Me.lblIgv.Name = "lblIgv"
        Me.lblIgv.Size = New System.Drawing.Size(30, 16)
        Me.lblIgv.TabIndex = 12
        Me.lblIgv.Text = "......"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(10, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Cliente :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(457, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "I.G.V. :"
        '
        'lblNumJob
        '
        Me.lblNumJob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNumJob.ForeColor = System.Drawing.Color.Black
        Me.lblNumJob.Location = New System.Drawing.Point(318, 66)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(50, 16)
        Me.lblNumJob.TabIndex = 16
        Me.lblNumJob.Text = "......"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(336, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Moneda :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(10, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Número :"
        '
        'lblCodMon
        '
        Me.lblCodMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCodMon.ForeColor = System.Drawing.Color.Black
        Me.lblCodMon.Location = New System.Drawing.Point(398, 18)
        Me.lblCodMon.Name = "lblCodMon"
        Me.lblCodMon.Size = New System.Drawing.Size(30, 16)
        Me.lblCodMon.TabIndex = 10
        Me.lblCodMon.Text = "......"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(271, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "# Job :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(326, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Locación :"
        '
        'lbldLocCli
        '
        Me.lbldLocCli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbldLocCli.ForeColor = System.Drawing.Color.Black
        Me.lbldLocCli.Location = New System.Drawing.Point(393, 42)
        Me.lbldLocCli.Name = "lbldLocCli"
        Me.lbldLocCli.Size = New System.Drawing.Size(164, 16)
        Me.lbldLocCli.TabIndex = 8
        Me.lbldLocCli.Text = "......"
        '
        'lblCodMot
        '
        Me.lblCodMot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCodMot.ForeColor = System.Drawing.Color.Black
        Me.lblCodMot.Location = New System.Drawing.Point(63, 66)
        Me.lblCodMot.Name = "lblCodMot"
        Me.lblCodMot.Size = New System.Drawing.Size(205, 16)
        Me.lblCodMot.TabIndex = 14
        Me.lblCodMot.Text = "......"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(10, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 13)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Motivo :"
        '
        'btnModificarObservacion
        '
        Me.btnModificarObservacion.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnModificarObservacion.Location = New System.Drawing.Point(747, 110)
        Me.btnModificarObservacion.Name = "btnModificarObservacion"
        Me.btnModificarObservacion.Size = New System.Drawing.Size(28, 26)
        Me.btnModificarObservacion.TabIndex = 11
        Me.btnModificarObservacion.TabStop = False
        Me.btnModificarObservacion.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.txtFecDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Location = New System.Drawing.Point(585, 11)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(190, 90)
        Me.UiGroupBox1.TabIndex = 2
        Me.UiGroupBox1.Text = " [  Guía de Devolución  ] "
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número :"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNumDoc.Location = New System.Drawing.Point(80, 25)
        Me.txtNumDoc.MaxLength = 200
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(92, 20)
        Me.txtNumDoc.TabIndex = 1
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Location = New System.Drawing.Point(80, 55)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.Size = New System.Drawing.Size(92, 20)
        Me.txtFecDoc.TabIndex = 3
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(22, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Fecha :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(13, 117)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Observaciones :"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmOpcionesAtender
        '
        Me.cmOpcionesAtender.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos})
        Me.cmOpcionesAtender.Name = "cmOpciones"
        Me.cmOpcionesAtender.Size = New System.Drawing.Size(174, 48)
        '
        'miSeleccionarTodo
        '
        Me.miSeleccionarTodo.Image = CType(resources.GetObject("miSeleccionarTodo.Image"), System.Drawing.Image)
        Me.miSeleccionarTodo.Name = "miSeleccionarTodo"
        Me.miSeleccionarTodo.Size = New System.Drawing.Size(173, 22)
        Me.miSeleccionarTodo.Text = "Seleccionar Todos"
        '
        'miSeterCEROTodos
        '
        Me.miSeterCEROTodos.Image = CType(resources.GetObject("miSeterCEROTodos.Image"), System.Drawing.Image)
        Me.miSeterCEROTodos.Name = "miSeterCEROTodos"
        Me.miSeterCEROTodos.Size = New System.Drawing.Size(173, 22)
        Me.miSeterCEROTodos.Text = "Poner en ""0"" todos"
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = CType(resources.GetObject("miNuevo.Image"), System.Drawing.Image)
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = CType(resources.GetObject("miMostrar.Image"), System.Drawing.Image)
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = CType(resources.GetObject("miEliminar.Image"), System.Drawing.Image)
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(672, 183)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 25)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(577, 183)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(85, 25)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Generar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmGuiaDevolucion_Generar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(807, 237)
        Me.Controls.Add(Me.gbGenrarGuia)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaDevolucion_Generar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGuiaDevolucion"
        Me.gbGenrarGuia.ResumeLayout(False)
        Me.gbGenrarGuia.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesAtender.ResumeLayout(False)
        Me.cmOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbGenrarGuia As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents miSeterCEROTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpcionesAtender As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbldLocCli As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCodMot As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblIgv As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblCodMon As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarDocumento As System.Windows.Forms.Button
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
  Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnModificarObservacion As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
  Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox

End Class
