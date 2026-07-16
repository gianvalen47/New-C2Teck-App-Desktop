<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeguimiento
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
        Dim cmbTipoSubComponente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoComponente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSistemasMotor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbProceso_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoSeguimiento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeguimiento))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosSeguimiento = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbCambioMotor = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTipoMotor = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbAfectaDisponibilidad = New System.Windows.Forms.CheckBox()
        Me.cmbTipoSubComponente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnNumSerie = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbTipoComponente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNomEquipo = New System.Windows.Forms.TextBox()
        Me.txtIdSeguimiento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbSistemasMotor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbProceso = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbTipoSeguimiento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbObsSeguimiento = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCorreccion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCausa = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFalla = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtComponente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.gbDatosHrsSeguimiento = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCantHoras = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtHoraFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtHoraInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtHrsParciales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHrsTotales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gbPersonal = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevoMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.lblOficina = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosSeguimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosSeguimiento.SuspendLayout()
        CType(Me.cmbTipoSubComponente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoComponente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSistemasMotor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbProceso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoSeguimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbObsSeguimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbObsSeguimiento.SuspendLayout()
        CType(Me.gbDatosHrsSeguimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosHrsSeguimiento.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gbPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPersonal.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosSeguimiento
        '
        Me.gbDatosSeguimiento.Controls.Add(Me.cbCambioMotor)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label22)
        Me.gbDatosSeguimiento.Controls.Add(Me.txtTipoMotor)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label15)
        Me.gbDatosSeguimiento.Controls.Add(Me.cbAfectaDisponibilidad)
        Me.gbDatosSeguimiento.Controls.Add(Me.cmbTipoSubComponente)
        Me.gbDatosSeguimiento.Controls.Add(Me.cmbSupervisor)
        Me.gbDatosSeguimiento.Controls.Add(Me.btnNumSerie)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label19)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label18)
        Me.gbDatosSeguimiento.Controls.Add(Me.cmbTipoComponente)
        Me.gbDatosSeguimiento.Controls.Add(Me.txtNomEquipo)
        Me.gbDatosSeguimiento.Controls.Add(Me.txtIdSeguimiento)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label4)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label16)
        Me.gbDatosSeguimiento.Controls.Add(Me.btnBuscarJob)
        Me.gbDatosSeguimiento.Controls.Add(Me.txtNumJob)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label14)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label12)
        Me.gbDatosSeguimiento.Controls.Add(Me.cmbSistemasMotor)
        Me.gbDatosSeguimiento.Controls.Add(Me.cmbProceso)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label11)
        Me.gbDatosSeguimiento.Controls.Add(Me.cmbTipoSeguimiento)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label9)
        Me.gbDatosSeguimiento.Controls.Add(Me.txtFecha)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label2)
        Me.gbDatosSeguimiento.Controls.Add(Me.txtCodMer)
        Me.gbDatosSeguimiento.Controls.Add(Me.Label5)
        Me.gbDatosSeguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosSeguimiento.Location = New System.Drawing.Point(7, 33)
        Me.gbDatosSeguimiento.Name = "gbDatosSeguimiento"
        Me.gbDatosSeguimiento.Size = New System.Drawing.Size(576, 184)
        Me.gbDatosSeguimiento.TabIndex = 0
        Me.gbDatosSeguimiento.Text = "Datos del Seguimiento"
        Me.gbDatosSeguimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbCambioMotor
        '
        Me.cbCambioMotor.AutoSize = True
        Me.cbCambioMotor.Enabled = False
        Me.cbCambioMotor.Location = New System.Drawing.Point(351, 101)
        Me.cbCambioMotor.Name = "cbCambioMotor"
        Me.cbCambioMotor.Size = New System.Drawing.Size(91, 17)
        Me.cbCambioMotor.TabIndex = 429
        Me.cbCambioMotor.Text = "Cambio Motor"
        Me.cbCambioMotor.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(259, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 13)
        Me.Label22.TabIndex = 428
        Me.Label22.Text = "Tipo Mot."
        '
        'txtTipoMotor
        '
        Me.txtTipoMotor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoMotor.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtTipoMotor.Location = New System.Drawing.Point(313, 44)
        Me.txtTipoMotor.Name = "txtTipoMotor"
        Me.txtTipoMotor.ReadOnly = True
        Me.txtTipoMotor.Size = New System.Drawing.Size(85, 21)
        Me.txtTipoMotor.TabIndex = 427
        Me.txtTipoMotor.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(354, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 420
        Me.Label15.Text = "Posición"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbAfectaDisponibilidad
        '
        Me.cbAfectaDisponibilidad.AutoSize = True
        Me.cbAfectaDisponibilidad.Location = New System.Drawing.Point(216, 101)
        Me.cbAfectaDisponibilidad.Name = "cbAfectaDisponibilidad"
        Me.cbAfectaDisponibilidad.Size = New System.Drawing.Size(125, 17)
        Me.cbAfectaDisponibilidad.TabIndex = 426
        Me.cbAfectaDisponibilidad.Text = "Afecta Disponibilidad"
        Me.cbAfectaDisponibilidad.UseVisualStyleBackColor = True
        '
        'cmbTipoSubComponente
        '
        Me.cmbTipoSubComponente.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoSubComponente_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoSubComponente_DesignTimeLayout.LayoutString")
        Me.cmbTipoSubComponente.DesignTimeLayout = cmbTipoSubComponente_DesignTimeLayout
        Me.cmbTipoSubComponente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSubComponente.Location = New System.Drawing.Point(406, 128)
        Me.cmbTipoSubComponente.Name = "cmbTipoSubComponente"
        Me.cmbTipoSubComponente.SelectedIndex = -1
        Me.cmbTipoSubComponente.SelectedItem = Nothing
        Me.cmbTipoSubComponente.Size = New System.Drawing.Size(162, 20)
        Me.cmbTipoSubComponente.TabIndex = 10
        Me.cmbTipoSubComponente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbSupervisor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cmbSupervisor_DesignTimeLayout.LayoutString")
        Me.cmbSupervisor.DesignTimeLayout = cmbSupervisor_DesignTimeLayout
        Me.cmbSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupervisor.Location = New System.Drawing.Point(98, 156)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.SelectedIndex = -1
        Me.cmbSupervisor.SelectedItem = Nothing
        Me.cmbSupervisor.Size = New System.Drawing.Size(332, 20)
        Me.cmbSupervisor.TabIndex = 11
        Me.cmbSupervisor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbSupervisor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnNumSerie
        '
        Me.btnNumSerie.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnNumSerie.Location = New System.Drawing.Point(208, 43)
        Me.btnNumSerie.Name = "btnNumSerie"
        Me.btnNumSerie.Size = New System.Drawing.Size(25, 22)
        Me.btnNumSerie.TabIndex = 2
        Me.btnNumSerie.TabStop = False
        Me.btnNumSerie.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 132)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 13)
        Me.Label19.TabIndex = 416
        Me.Label19.Text = "Tipo Componente"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(428, 47)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 424
        Me.Label18.Text = "Equipo"
        '
        'cmbTipoComponente
        '
        Me.cmbTipoComponente.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoComponente_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoComponente_DesignTimeLayout.LayoutString")
        Me.cmbTipoComponente.DesignTimeLayout = cmbTipoComponente_DesignTimeLayout
        Me.cmbTipoComponente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComponente.Location = New System.Drawing.Point(98, 128)
        Me.cmbTipoComponente.Name = "cmbTipoComponente"
        Me.cmbTipoComponente.SelectedIndex = -1
        Me.cmbTipoComponente.SelectedItem = Nothing
        Me.cmbTipoComponente.Size = New System.Drawing.Size(218, 20)
        Me.cmbTipoComponente.TabIndex = 9
        Me.cmbTipoComponente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTipoComponente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNomEquipo
        '
        Me.txtNomEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomEquipo.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtNomEquipo.Location = New System.Drawing.Point(470, 44)
        Me.txtNomEquipo.Name = "txtNomEquipo"
        Me.txtNomEquipo.ReadOnly = True
        Me.txtNomEquipo.Size = New System.Drawing.Size(98, 21)
        Me.txtNomEquipo.TabIndex = 423
        Me.txtNomEquipo.TabStop = False
        '
        'txtIdSeguimiento
        '
        Me.txtIdSeguimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdSeguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSeguimiento.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtIdSeguimiento.Location = New System.Drawing.Point(98, 16)
        Me.txtIdSeguimiento.Name = "txtIdSeguimiento"
        Me.txtIdSeguimiento.ReadOnly = True
        Me.txtIdSeguimiento.Size = New System.Drawing.Size(96, 21)
        Me.txtIdSeguimiento.TabIndex = 1
        Me.txtIdSeguimiento.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 422
        Me.Label4.Text = "Seguimiento"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(38, 158)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 418
        Me.Label16.Text = "Supervisor"
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(541, 97)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 8
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumJob.Location = New System.Drawing.Point(492, 98)
        Me.txtNumJob.MaxLength = 20
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(48, 20)
        Me.txtNumJob.TabIndex = 7
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(451, 102)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 417
        Me.Label14.Text = "Nº OT"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(48, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 414
        Me.Label12.Text = "Sistema"
        '
        'cmbSistemasMotor
        '
        Me.cmbSistemasMotor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSistemasMotor_DesignTimeLayout.LayoutString = resources.GetString("cmbSistemasMotor_DesignTimeLayout.LayoutString")
        Me.cmbSistemasMotor.DesignTimeLayout = cmbSistemasMotor_DesignTimeLayout
        Me.cmbSistemasMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSistemasMotor.Location = New System.Drawing.Point(98, 100)
        Me.cmbSistemasMotor.Name = "cmbSistemasMotor"
        Me.cmbSistemasMotor.SelectedIndex = -1
        Me.cmbSistemasMotor.SelectedItem = Nothing
        Me.cmbSistemasMotor.Size = New System.Drawing.Size(101, 20)
        Me.cmbSistemasMotor.TabIndex = 6
        Me.cmbSistemasMotor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbProceso
        '
        Me.cmbProceso.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbProceso_DesignTimeLayout.LayoutString = resources.GetString("cmbProceso_DesignTimeLayout.LayoutString")
        Me.cmbProceso.DesignTimeLayout = cmbProceso_DesignTimeLayout
        Me.cmbProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProceso.Location = New System.Drawing.Point(422, 72)
        Me.cmbProceso.Name = "cmbProceso"
        Me.cmbProceso.SelectedIndex = -1
        Me.cmbProceso.SelectedItem = Nothing
        Me.cmbProceso.Size = New System.Drawing.Size(146, 20)
        Me.cmbProceso.TabIndex = 5
        Me.cmbProceso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(312, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 13)
        Me.Label11.TabIndex = 412
        Me.Label11.Text = "Proceso Seguimiento"
        '
        'cmbTipoSeguimiento
        '
        Me.cmbTipoSeguimiento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoSeguimiento_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoSeguimiento_DesignTimeLayout.LayoutString")
        Me.cmbTipoSeguimiento.DesignTimeLayout = cmbTipoSeguimiento_DesignTimeLayout
        Me.cmbTipoSeguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSeguimiento.Location = New System.Drawing.Point(98, 72)
        Me.cmbTipoSeguimiento.Name = "cmbTipoSeguimiento"
        Me.cmbTipoSeguimiento.SelectedIndex = -1
        Me.cmbTipoSeguimiento.SelectedItem = Nothing
        Me.cmbTipoSeguimiento.Size = New System.Drawing.Size(173, 20)
        Me.cmbTipoSeguimiento.TabIndex = 4
        Me.cmbTipoSeguimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 410
        Me.Label9.Text = "Tipo Seguimiento"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(314, 16)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(87, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(275, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 398
        Me.Label2.Text = "Fecha"
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.Location = New System.Drawing.Point(98, 44)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(110, 20)
        Me.txtCodMer.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 374
        Me.Label5.Text = "Serie Motor"
        '
        'gbObsSeguimiento
        '
        Me.gbObsSeguimiento.Controls.Add(Me.Label10)
        Me.gbObsSeguimiento.Controls.Add(Me.txtObservacion)
        Me.gbObsSeguimiento.Controls.Add(Me.Label17)
        Me.gbObsSeguimiento.Controls.Add(Me.txtCorreccion)
        Me.gbObsSeguimiento.Controls.Add(Me.txtCausa)
        Me.gbObsSeguimiento.Controls.Add(Me.Label7)
        Me.gbObsSeguimiento.Controls.Add(Me.txtFalla)
        Me.gbObsSeguimiento.Controls.Add(Me.Label13)
        Me.gbObsSeguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbObsSeguimiento.Location = New System.Drawing.Point(7, 324)
        Me.gbObsSeguimiento.Name = "gbObsSeguimiento"
        Me.gbObsSeguimiento.Size = New System.Drawing.Size(576, 157)
        Me.gbObsSeguimiento.TabIndex = 18
        Me.gbObsSeguimiento.Text = "Observaciones del Seguimiento"
        Me.gbObsSeguimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 31)
        Me.Label10.TabIndex = 417
        Me.Label10.Text = "Actividades Realizadas"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(91, 119)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(475, 30)
        Me.txtObservacion.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(20, 127)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 265
        Me.Label17.Text = "Observación"
        '
        'txtCorreccion
        '
        Me.txtCorreccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorreccion.Location = New System.Drawing.Point(91, 85)
        Me.txtCorreccion.Multiline = True
        Me.txtCorreccion.Name = "txtCorreccion"
        Me.txtCorreccion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCorreccion.Size = New System.Drawing.Size(475, 30)
        Me.txtCorreccion.TabIndex = 21
        '
        'txtCausa
        '
        Me.txtCausa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCausa.Location = New System.Drawing.Point(91, 51)
        Me.txtCausa.Multiline = True
        Me.txtCausa.Name = "txtCausa"
        Me.txtCausa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCausa.Size = New System.Drawing.Size(475, 30)
        Me.txtCausa.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(50, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 259
        Me.Label7.Text = "Causa"
        '
        'txtFalla
        '
        Me.txtFalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFalla.Location = New System.Drawing.Point(91, 17)
        Me.txtFalla.Multiline = True
        Me.txtFalla.Name = "txtFalla"
        Me.txtFalla.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFalla.Size = New System.Drawing.Size(475, 30)
        Me.txtFalla.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 257
        Me.Label13.Text = "Falla / Evento"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(37, 448)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 421
        Me.Label20.Text = "Componente"
        Me.Label20.Visible = False
        '
        'txtComponente
        '
        Me.txtComponente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComponente.Location = New System.Drawing.Point(108, 440)
        Me.txtComponente.Multiline = True
        Me.txtComponente.Name = "txtComponente"
        Me.txtComponente.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComponente.Size = New System.Drawing.Size(405, 30)
        Me.txtComponente.TabIndex = 19
        Me.txtComponente.Visible = False
        '
        'gbDatosHrsSeguimiento
        '
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.txtCantHoras)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.Label21)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.txtHoraFinal)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.txtHoraInicio)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.Label8)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.txtHrsParciales)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.Label6)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.txtHrsTotales)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.Label1)
        Me.gbDatosHrsSeguimiento.Controls.Add(Me.Label3)
        Me.gbDatosHrsSeguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosHrsSeguimiento.Location = New System.Drawing.Point(7, 223)
        Me.gbDatosHrsSeguimiento.Name = "gbDatosHrsSeguimiento"
        Me.gbDatosHrsSeguimiento.Size = New System.Drawing.Size(576, 95)
        Me.gbDatosHrsSeguimiento.TabIndex = 12
        Me.gbDatosHrsSeguimiento.Text = "Hrs del Seguimiento"
        Me.gbDatosHrsSeguimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCantHoras
        '
        Me.txtCantHoras.Enabled = False
        Me.txtCantHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantHoras.Location = New System.Drawing.Point(455, 53)
        Me.txtCantHoras.MaxLength = 10
        Me.txtCantHoras.Name = "txtCantHoras"
        Me.txtCantHoras.Size = New System.Drawing.Size(74, 20)
        Me.txtCantHoras.TabIndex = 17
        Me.txtCantHoras.TabStop = False
        Me.txtCantHoras.Text = "0"
        Me.txtCantHoras.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCantHoras.Value = CType(0, Long)
        Me.txtCantHoras.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtCantHoras.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(354, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(95, 13)
        Me.Label21.TabIndex = 413
        Me.Label21.Text = "Cantidad de Horas"
        '
        'txtHoraFinal
        '
        Me.txtHoraFinal.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime
        '
        '
        '
        Me.txtHoraFinal.DropDownCalendar.Name = ""
        Me.txtHoraFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtHoraFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraFinal.Location = New System.Drawing.Point(137, 67)
        Me.txtHoraFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtHoraFinal.Name = "txtHoraFinal"
        Me.txtHoraFinal.Size = New System.Drawing.Size(159, 20)
        Me.txtHoraFinal.TabIndex = 16
        Me.txtHoraFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtHoraInicio
        '
        Me.txtHoraInicio.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime
        '
        '
        '
        Me.txtHoraInicio.DropDownCalendar.Name = ""
        Me.txtHoraInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtHoraInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraInicio.Location = New System.Drawing.Point(137, 41)
        Me.txtHoraInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtHoraInicio.Name = "txtHoraInicio"
        Me.txtHoraInicio.Size = New System.Drawing.Size(159, 20)
        Me.txtHoraInicio.TabIndex = 15
        Me.txtHoraInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(41, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 410
        Me.Label8.Text = "Fecha y Hora Fin"
        '
        'txtHrsParciales
        '
        Me.txtHrsParciales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrsParciales.Location = New System.Drawing.Point(455, 15)
        Me.txtHrsParciales.MaxLength = 10
        Me.txtHrsParciales.Name = "txtHrsParciales"
        Me.txtHrsParciales.Size = New System.Drawing.Size(74, 20)
        Me.txtHrsParciales.TabIndex = 14
        Me.txtHrsParciales.Text = "0.00"
        Me.txtHrsParciales.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHrsParciales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(384, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 408
        Me.Label6.Text = "Hora Parcial"
        '
        'txtHrsTotales
        '
        Me.txtHrsTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrsTotales.Location = New System.Drawing.Point(137, 15)
        Me.txtHrsTotales.MaxLength = 10
        Me.txtHrsTotales.Name = "txtHrsTotales"
        Me.txtHrsTotales.Size = New System.Drawing.Size(74, 20)
        Me.txtHrsTotales.TabIndex = 13
        Me.txtHrsTotales.Text = "0.00"
        Me.txtHrsTotales.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHrsTotales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(67, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 406
        Me.Label1.Text = "Hrs. Totales"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 404
        Me.Label3.Text = "Fecha y Hora Inicio"
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditar, Me.ToolStripSeparator4, Me.biDeshacer, Me.ToolStripSeparator6, Me.biCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(596, 31)
        Me.ToolStrip.TabIndex = 233
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Datos"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'gbPersonal
        '
        Me.gbPersonal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPersonal.Controls.Add(Me.dgvDatos)
        Me.gbPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPersonal.Location = New System.Drawing.Point(7, 487)
        Me.gbPersonal.Name = "gbPersonal"
        Me.gbPersonal.Size = New System.Drawing.Size(576, 130)
        Me.gbPersonal.TabIndex = 234
        Me.gbPersonal.Text = "Colaboradores"
        Me.gbPersonal.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(8, 18)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(560, 105)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miNuevoMasivo, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(151, 126)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(150, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miNuevoMasivo
        '
        Me.miNuevoMasivo.Image = CType(resources.GetObject("miNuevoMasivo.Image"), System.Drawing.Image)
        Me.miNuevoMasivo.Name = "miNuevoMasivo"
        Me.miNuevoMasivo.Size = New System.Drawing.Size(150, 22)
        Me.miNuevoMasivo.Text = "Nuevo Masivo"
        Me.miNuevoMasivo.ToolTipText = "Nuevo Masivo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(150, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(150, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(147, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(147, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(150, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Location = New System.Drawing.Point(0, 628)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(596, 20)
        Me.ssBarra.TabIndex = 235
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.Location = New System.Drawing.Point(208, 12)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(56, 15)
        Me.lblOficina.TabIndex = 236
        Me.lblOficina.Text = "Oficina:"
        '
        'frmSeguimiento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(596, 648)
        Me.Controls.Add(Me.lblOficina)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDatosHrsSeguimiento)
        Me.Controls.Add(Me.gbPersonal)
        Me.Controls.Add(Me.gbObsSeguimiento)
        Me.Controls.Add(Me.gbDatosSeguimiento)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtComponente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeguimiento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Seguimiento"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosSeguimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosSeguimiento.ResumeLayout(False)
        Me.gbDatosSeguimiento.PerformLayout()
        CType(Me.cmbTipoSubComponente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoComponente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSistemasMotor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbProceso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoSeguimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbObsSeguimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbObsSeguimiento.ResumeLayout(False)
        Me.gbObsSeguimiento.PerformLayout()
        CType(Me.gbDatosHrsSeguimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosHrsSeguimiento.ResumeLayout(False)
        Me.gbDatosHrsSeguimiento.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gbPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPersonal.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosSeguimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbObsSeguimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFalla As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents gbDatosHrsSeguimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtHrsParciales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHrsTotales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbProceso As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSeguimiento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbSistemasMotor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtIdSeguimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCorreccion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtComponente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtCausa As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbPersonal As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnNumSerie As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNomEquipo As System.Windows.Forms.TextBox
    Friend WithEvents cmbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblOficina As System.Windows.Forms.Label
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbAfectaDisponibilidad As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoComponente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSubComponente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCantHoras As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtHoraFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtHoraInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTipoMotor As System.Windows.Forms.TextBox
    Friend WithEvents cbCambioMotor As System.Windows.Forms.CheckBox
End Class
