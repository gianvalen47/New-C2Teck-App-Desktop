<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarjetaVideo
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
        Dim cmbMarca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoDispositivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTarjetaVideo))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbDatosTipoHoraExtra = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnObtener = New System.Windows.Forms.Button()
        Me.txtFecFinGarantia = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbTipoDispositivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.txtMotivoFinUso = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtFecFinUso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniUso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCapacidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTipoMemoria = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSerie = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtModelo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtIdProcesador = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDesTarjetaVideo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosTipoHoraExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosTipoHoraExtra.SuspendLayout()
        CType(Me.cmbMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoDispositivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnCancelar, "btnCancelar")
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbDatosTipoHoraExtra
        '
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.btnObtener)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtFecFinGarantia)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label12)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cmbMarca)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cmbTipoDispositivo)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label11)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label10)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cbVigente)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtMotivoFinUso)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label30)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtFecFinUso)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtFecIniUso)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label19)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label20)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label4)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtCapacidad)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label8)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtTipoMemoria)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label7)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtSerie)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtModelo)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label2)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label3)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtObservacion)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label6)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.lblFecha)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtIdProcesador)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label1)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label9)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtDesTarjetaVideo)
        resources.ApplyResources(Me.gbDatosTipoHoraExtra, "gbDatosTipoHoraExtra")
        Me.gbDatosTipoHoraExtra.Name = "gbDatosTipoHoraExtra"
        Me.gbDatosTipoHoraExtra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnObtener
        '
        resources.ApplyResources(Me.btnObtener, "btnObtener")
        Me.btnObtener.Name = "btnObtener"
        Me.btnObtener.UseVisualStyleBackColor = True
        '
        'txtFecFinGarantia
        '
        '
        '
        '
        Me.txtFecFinGarantia.DropDownCalendar.Name = ""
        Me.txtFecFinGarantia.DropDownCalendar.Visible = CType(resources.GetObject("txtFecFinGarantia.DropDownCalendar.Visible"), Boolean)
        Me.txtFecFinGarantia.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        resources.ApplyResources(Me.txtFecFinGarantia, "txtFecFinGarantia")
        Me.txtFecFinGarantia.IsNullDate = True
        Me.txtFecFinGarantia.Name = "txtFecFinGarantia"
        Me.txtFecFinGarantia.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Name = "Label12"
        '
        'cmbMarca
        '
        Me.cmbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        resources.ApplyResources(cmbMarca_DesignTimeLayout, "cmbMarca_DesignTimeLayout")
        Me.cmbMarca.DesignTimeLayout = cmbMarca_DesignTimeLayout
        resources.ApplyResources(Me.cmbMarca, "cmbMarca")
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.SelectedIndex = -1
        Me.cmbMarca.SelectedItem = Nothing
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipoDispositivo
        '
        Me.cmbTipoDispositivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        resources.ApplyResources(cmbTipoDispositivo_DesignTimeLayout, "cmbTipoDispositivo_DesignTimeLayout")
        Me.cmbTipoDispositivo.DesignTimeLayout = cmbTipoDispositivo_DesignTimeLayout
        resources.ApplyResources(Me.cmbTipoDispositivo, "cmbTipoDispositivo")
        Me.cmbTipoDispositivo.Name = "cmbTipoDispositivo"
        Me.cmbTipoDispositivo.SelectedIndex = -1
        Me.cmbTipoDispositivo.SelectedItem = Nothing
        Me.cmbTipoDispositivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Name = "Label10"
        '
        'cbVigente
        '
        resources.ApplyResources(Me.cbVigente, "cbVigente")
        Me.cbVigente.BackColor = System.Drawing.Color.Transparent
        Me.cbVigente.Checked = True
        Me.cbVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.TabStop = False
        Me.cbVigente.Tag = ""
        Me.cbVigente.UseVisualStyleBackColor = False
        '
        'txtMotivoFinUso
        '
        resources.ApplyResources(Me.txtMotivoFinUso, "txtMotivoFinUso")
        Me.txtMotivoFinUso.Name = "txtMotivoFinUso"
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Name = "Label30"
        '
        'txtFecFinUso
        '
        '
        '
        '
        Me.txtFecFinUso.DropDownCalendar.Name = ""
        Me.txtFecFinUso.DropDownCalendar.Visible = CType(resources.GetObject("txtFecFinUso.DropDownCalendar.Visible"), Boolean)
        Me.txtFecFinUso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        resources.ApplyResources(Me.txtFecFinUso, "txtFecFinUso")
        Me.txtFecFinUso.IsNullDate = True
        Me.txtFecFinUso.Name = "txtFecFinUso"
        Me.txtFecFinUso.ShowNullButton = True
        Me.txtFecFinUso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIniUso
        '
        '
        '
        '
        Me.txtFecIniUso.DropDownCalendar.Name = ""
        Me.txtFecIniUso.DropDownCalendar.Visible = CType(resources.GetObject("txtFecIniUso.DropDownCalendar.Visible"), Boolean)
        Me.txtFecIniUso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        resources.ApplyResources(Me.txtFecIniUso, "txtFecIniUso")
        Me.txtFecIniUso.IsNullDate = True
        Me.txtFecIniUso.Name = "txtFecIniUso"
        Me.txtFecIniUso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Name = "Label19"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Name = "Label20"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtCapacidad
        '
        resources.ApplyResources(Me.txtCapacidad, "txtCapacidad")
        Me.txtCapacidad.MaxLength = 12
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.Value = 0
        Me.txtCapacidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtCapacidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'txtTipoMemoria
        '
        resources.ApplyResources(Me.txtTipoMemoria, "txtTipoMemoria")
        Me.txtTipoMemoria.Name = "txtTipoMemoria"
        Me.txtTipoMemoria.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'txtSerie
        '
        resources.ApplyResources(Me.txtSerie, "txtSerie")
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'txtModelo
        '
        resources.ApplyResources(Me.txtModelo, "txtModelo")
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtObservacion
        '
        resources.ApplyResources(Me.txtObservacion, "txtObservacion")
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'lblFecha
        '
        resources.ApplyResources(Me.lblFecha, "lblFecha")
        Me.lblFecha.Name = "lblFecha"
        '
        'txtIdProcesador
        '
        Me.txtIdProcesador.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdProcesador.ForeColor = System.Drawing.Color.Navy
        resources.ApplyResources(Me.txtIdProcesador, "txtIdProcesador")
        Me.txtIdProcesador.Name = "txtIdProcesador"
        Me.txtIdProcesador.ReadOnly = True
        Me.txtIdProcesador.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'txtDesTarjetaVideo
        '
        resources.ApplyResources(Me.txtDesTarjetaVideo, "txtDesTarjetaVideo")
        Me.txtDesTarjetaVideo.Name = "txtDesTarjetaVideo"
        Me.txtDesTarjetaVideo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'btnGuardar
        '
        resources.ApplyResources(Me.btnGuardar, "btnGuardar")
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmTarjetaVideo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatosTipoHoraExtra)
        Me.Controls.Add(Me.btnGuardar)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTarjetaVideo"
        Me.ShowInTaskbar = False
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosTipoHoraExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosTipoHoraExtra.ResumeLayout(False)
        Me.gbDatosTipoHoraExtra.PerformLayout()
        CType(Me.cmbMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoDispositivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As Button
    Friend WithEvents gbDatosTipoHoraExtra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTipoMemoria As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSerie As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtModelo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtIdProcesador As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDesTarjetaVideo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtCapacidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cbVigente As CheckBox
    Friend WithEvents txtMotivoFinUso As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtFecFinUso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecIniUso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cmbTipoDispositivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtFecFinGarantia As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label12 As Label
    Friend WithEvents btnObtener As Button
End Class
