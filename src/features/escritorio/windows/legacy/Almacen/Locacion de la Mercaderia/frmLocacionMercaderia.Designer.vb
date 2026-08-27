<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocacionMercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocacionMercaderia))
        Me.cmOpcionesAtender = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.gbSubDatos1 = New System.Windows.Forms.GroupBox()
        Me.ckOtro = New System.Windows.Forms.CheckBox()
        Me.btnBuscarUbicacion = New System.Windows.Forms.Button()
        Me.txtObsMer = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtUbiMer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMaxMer = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMinMer = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbNuevocodigo = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.txtCorMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDeaMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDesMer1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmOpcionesAtender.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.gbSubDatos1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbNuevocodigo.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
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
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
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
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'gbDatos
        '
        Me.gbDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDatos.Controls.Add(Me.gbSubDatos1)
        Me.gbDatos.Controls.Add(Me.gbNuevocodigo)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(5, 38)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(523, 272)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos Generales"
        '
        'gbSubDatos1
        '
        Me.gbSubDatos1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbSubDatos1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbSubDatos1.Controls.Add(Me.ckOtro)
        Me.gbSubDatos1.Controls.Add(Me.btnBuscarUbicacion)
        Me.gbSubDatos1.Controls.Add(Me.txtObsMer)
        Me.gbSubDatos1.Controls.Add(Me.Label21)
        Me.gbSubDatos1.Controls.Add(Me.txtUbiMer)
        Me.gbSubDatos1.Controls.Add(Me.Label2)
        Me.gbSubDatos1.Controls.Add(Me.txtMaxMer)
        Me.gbSubDatos1.Controls.Add(Me.Label14)
        Me.gbSubDatos1.Controls.Add(Me.txtMinMer)
        Me.gbSubDatos1.Controls.Add(Me.Label1)
        Me.gbSubDatos1.Controls.Add(Me.GroupBox1)
        Me.gbSubDatos1.Location = New System.Drawing.Point(6, 159)
        Me.gbSubDatos1.Name = "gbSubDatos1"
        Me.gbSubDatos1.Size = New System.Drawing.Size(511, 106)
        Me.gbSubDatos1.TabIndex = 1
        Me.gbSubDatos1.TabStop = False
        Me.gbSubDatos1.Text = "Detalles"
        '
        'ckOtro
        '
        Me.ckOtro.AutoSize = True
        Me.ckOtro.Location = New System.Drawing.Point(234, 13)
        Me.ckOtro.Name = "ckOtro"
        Me.ckOtro.Size = New System.Drawing.Size(111, 17)
        Me.ckOtro.TabIndex = 13
        Me.ckOtro.Text = "Otra Ubicación"
        Me.ckOtro.UseVisualStyleBackColor = True
        '
        'btnBuscarUbicacion
        '
        Me.btnBuscarUbicacion.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarUbicacion.Location = New System.Drawing.Point(206, 10)
        Me.btnBuscarUbicacion.Name = "btnBuscarUbicacion"
        Me.btnBuscarUbicacion.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarUbicacion.TabIndex = 12
        Me.btnBuscarUbicacion.TabStop = False
        Me.btnBuscarUbicacion.UseVisualStyleBackColor = True
        '
        'txtObsMer
        '
        Me.txtObsMer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObsMer.Location = New System.Drawing.Point(80, 58)
        Me.txtObsMer.Multiline = True
        Me.txtObsMer.Name = "txtObsMer"
        Me.txtObsMer.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsMer.Size = New System.Drawing.Size(425, 44)
        Me.txtObsMer.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(2, 61)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Observación"
        '
        'txtUbiMer
        '
        Me.txtUbiMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUbiMer.Location = New System.Drawing.Point(80, 11)
        Me.txtUbiMer.MaxLength = 50
        Me.txtUbiMer.Name = "txtUbiMer"
        Me.txtUbiMer.ReadOnly = True
        Me.txtUbiMer.Size = New System.Drawing.Size(127, 20)
        Me.txtUbiMer.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ubicación"
        '
        'txtMaxMer
        '
        Me.txtMaxMer.Location = New System.Drawing.Point(206, 35)
        Me.txtMaxMer.MaxLength = 200
        Me.txtMaxMer.Minimum = 1
        Me.txtMaxMer.Name = "txtMaxMer"
        Me.txtMaxMer.Size = New System.Drawing.Size(56, 20)
        Me.txtMaxMer.TabIndex = 2
        Me.txtMaxMer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtMaxMer.Value = 1
        Me.txtMaxMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(157, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Máximo"
        '
        'txtMinMer
        '
        Me.txtMinMer.Location = New System.Drawing.Point(80, 35)
        Me.txtMinMer.MaxLength = 200
        Me.txtMinMer.Minimum = 1
        Me.txtMinMer.Name = "txtMinMer"
        Me.txtMinMer.Size = New System.Drawing.Size(57, 20)
        Me.txtMinMer.TabIndex = 1
        Me.txtMinMer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtMinMer.Value = 1
        Me.txtMinMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Mínimo"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox1.Controls.Add(Me.lblStock)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(352, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 44)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'lblStock
        '
        Me.lblStock.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblStock.Location = New System.Drawing.Point(62, 11)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(82, 28)
        Me.lblStock.TabIndex = 1
        Me.lblStock.Text = "0"
        Me.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label7.Location = New System.Drawing.Point(4, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "STOCK"
        '
        'gbNuevocodigo
        '
        Me.gbNuevocodigo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbNuevocodigo.Controls.Add(Me.txtObservacion)
        Me.gbNuevocodigo.Controls.Add(Me.txtCorMer)
        Me.gbNuevocodigo.Controls.Add(Me.Label6)
        Me.gbNuevocodigo.Controls.Add(Me.Label4)
        Me.gbNuevocodigo.Controls.Add(Me.txtDeaMer)
        Me.gbNuevocodigo.Controls.Add(Me.Label5)
        Me.gbNuevocodigo.Controls.Add(Me.txtPartida)
        Me.gbNuevocodigo.Controls.Add(Me.Label16)
        Me.gbNuevocodigo.Controls.Add(Me.txtDesMer1)
        Me.gbNuevocodigo.Controls.Add(Me.Label10)
        Me.gbNuevocodigo.Controls.Add(Me.txtPais)
        Me.gbNuevocodigo.Controls.Add(Me.Label11)
        Me.gbNuevocodigo.Controls.Add(Me.txtMarca)
        Me.gbNuevocodigo.Controls.Add(Me.txtCodMer)
        Me.gbNuevocodigo.Controls.Add(Me.Label17)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbNuevocodigo.Controls.Add(Me.Label13)
        Me.gbNuevocodigo.Location = New System.Drawing.Point(6, 13)
        Me.gbNuevocodigo.Name = "gbNuevocodigo"
        Me.gbNuevocodigo.Size = New System.Drawing.Size(511, 140)
        Me.gbNuevocodigo.TabIndex = 0
        Me.gbNuevocodigo.TabStop = False
        Me.gbNuevocodigo.Text = "Mercadería"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(80, 83)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.Size = New System.Drawing.Size(425, 45)
        Me.txtObservacion.TabIndex = 8
        Me.txtObservacion.TabStop = False
        '
        'txtCorMer
        '
        Me.txtCorMer.BackColor = System.Drawing.SystemColors.Control
        Me.txtCorMer.Location = New System.Drawing.Point(391, 17)
        Me.txtCorMer.MaxLength = 10
        Me.txtCorMer.Name = "txtCorMer"
        Me.txtCorMer.ReadOnly = True
        Me.txtCorMer.Size = New System.Drawing.Size(114, 20)
        Me.txtCorMer.TabIndex = 3
        Me.txtCorMer.TabStop = False
        Me.txtCorMer.Text = "0.00"
        Me.txtCorMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCorMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(359, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Core"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Observación"
        '
        'txtDeaMer
        '
        Me.txtDeaMer.BackColor = System.Drawing.SystemColors.Control
        Me.txtDeaMer.Location = New System.Drawing.Point(281, 17)
        Me.txtDeaMer.MaxLength = 10
        Me.txtDeaMer.Name = "txtDeaMer"
        Me.txtDeaMer.ReadOnly = True
        Me.txtDeaMer.Size = New System.Drawing.Size(75, 20)
        Me.txtDeaMer.TabIndex = 2
        Me.txtDeaMer.TabStop = False
        Me.txtDeaMer.Text = "0.00"
        Me.txtDeaMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDeaMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(240, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Precio"
        '
        'txtPartida
        '
        Me.txtPartida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPartida.Location = New System.Drawing.Point(80, 61)
        Me.txtPartida.MaxLength = 3
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.ReadOnly = True
        Me.txtPartida.Size = New System.Drawing.Size(149, 20)
        Me.txtPartida.TabIndex = 6
        Me.txtPartida.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(1, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Partida Aran."
        '
        'txtDesMer1
        '
        Me.txtDesMer1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesMer1.Location = New System.Drawing.Point(80, 39)
        Me.txtDesMer1.MaxLength = 50
        Me.txtDesMer1.Name = "txtDesMer1"
        Me.txtDesMer1.ReadOnly = True
        Me.txtDesMer1.Size = New System.Drawing.Size(276, 20)
        Me.txtDesMer1.TabIndex = 4
        Me.txtDesMer1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Descrip.1"
        '
        'txtPais
        '
        Me.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPais.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPais.Location = New System.Drawing.Point(391, 39)
        Me.txtPais.MaxLength = 3
        Me.txtPais.Name = "txtPais"
        Me.txtPais.ReadOnly = True
        Me.txtPais.Size = New System.Drawing.Size(114, 20)
        Me.txtPais.TabIndex = 5
        Me.txtPais.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(359, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "País"
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMarca.Location = New System.Drawing.Point(274, 61)
        Me.txtMarca.MaxLength = 3
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(231, 20)
        Me.txtMarca.TabIndex = 7
        Me.txtMarca.TabStop = False
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodMer.Location = New System.Drawing.Point(80, 17)
        Me.txtCodMer.MaxLength = 50
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(127, 20)
        Me.txtCodMer.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(234, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Marca"
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(206, 16)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 1
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Código"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator13, Me.btnEditar, Me.btnGuardar, Me.btnDeshacer, Me.ToolStripSeparator14, Me.btnCancelar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(535, 31)
        Me.ToolStrip.TabIndex = 22
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'btnEditar
        '
        Me.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(28, 28)
        Me.btnEditar.Text = "Editar Detalles"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "Grabar Cambios"
        '
        'btnDeshacer
        '
        Me.btnDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.btnDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(28, 28)
        Me.btnCancelar.Text = "Cerrar el Formulario"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.Location = New System.Drawing.Point(229, 9)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(145, 15)
        Me.lblUbicacion.TabIndex = 23
        Me.lblUbicacion.Text = "OFICINA  -  ALMACÉN"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 315)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(535, 20)
        Me.ssBarra.TabIndex = 24
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        '
        'frmLocacionMercaderia
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(535, 335)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.lblUbicacion)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLocacionMercaderia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mercadería de locaciones"
        Me.cmOpcionesAtender.ResumeLayout(False)
        Me.cmOpciones.ResumeLayout(False)
        Me.gbDatos.ResumeLayout(False)
        Me.gbSubDatos1.ResumeLayout(False)
        Me.gbSubDatos1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbNuevocodigo.ResumeLayout(False)
        Me.gbNuevocodigo.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmOpcionesAtender As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeterCEROTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbNuevocodigo As System.Windows.Forms.GroupBox
    Friend WithEvents txtDeaMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDesMer1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMaxMer As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMinMer As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbSubDatos1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObsMer As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtUbiMer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents txtCorMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnBuscarUbicacion As System.Windows.Forms.Button
    Friend WithEvents ckOtro As CheckBox
End Class
