Imports System.ServiceModel
Public Class frmCapacitacion

    '===========================Servicios====================================================
    Private oCapacitacionService As New CapacitacionService.CapacitacionServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public IdCapacitacion As Integer
    Public IdPersona As Integer
    Public ApeNom As String
    Public IdProveedor As Integer
    Private dtTipoCapacitacion As DataTable
    Private dtMonedas As DataTable

    Public iIdPersona As Integer = 0           'IdPersona de colaborador seleccionado en la ventana anterior

    Private Sub frmCapacitacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            desactivar()
            ObtenerRegistro()
            Me.Text = "Capacitación de: " + Chr(34) + ApeNom + Chr(34)
            txtColaborador.TabStop = False
            cmbTipoCapac.Focus()
        Else                                      'Nuevo
            Me.Text = "Registrar nueva Capacitación"
            activar()
            If iIdPersona <> 0 Then
                ObtenerPersona()
            End If
            cmbMoneda.Value = "NS"
            cbEvaluadoCapac.Checked = False
            txtColaborador.TabStop = True
            txtColaborador.Focus()
        End If
        EnableOptions()
    End Sub

    Private Sub ObtenerPersona()
        Persona = oPersonaService.Obtener(iIdPersona)
        IdPersona = iIdPersona
        txtColaborador.Text = Persona.ApeNom
    End Sub

    Private Sub frmCapacitacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oCapacitacionService.Close()
            oPersonaService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oCapacitacionService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oCapacitacionService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmCapacitacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================== TIPO =================================================
            dtTipoCapacitacion = oCapacitacionService.MostrarTipos()
            cmbTipoCapac.DataSource = dtTipoCapacitacion
            cmbTipoCapac.DropDownList.DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.DisplayMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.ValueMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.Columns(0).DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.DropDownList.Columns(1).DataMember = dtTipoCapacitacion.Columns("Descripcion").ToString
            cmbTipoCapac.SelectedIndex = 0
            dtTipoCapacitacion = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = True
        cmbTipoCapac.ReadOnly = False
        cmbTipoCapac.BackColor = System.Drawing.SystemColors.Window
        txtCursoCapac.ReadOnly = False
        txtCursoCapac.BackColor = System.Drawing.SystemColors.Window
        cbProgramadoCapac.Enabled = True
        txtFechaInicio.ReadOnly = False
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
        txtFechaFinal.ReadOnly = False
        txtFechaFinal.BackColor = System.Drawing.SystemColors.Window
        txtProveedor.ReadOnly = True
        txtProveedor.BackColor = System.Drawing.SystemColors.Control
        btnBuscarProveedor.Enabled = True
        txtDuracionCapac.ReadOnly = False
        txtDuracionCapac.BackColor = System.Drawing.SystemColors.Window
        cmbMoneda.ReadOnly = False
        cmbMoneda.BackColor = System.Drawing.SystemColors.Window
        txtCostoCapac.ReadOnly = False
        txtCostoCapac.BackColor = System.Drawing.SystemColors.Window
        txtInstructor.ReadOnly = False
        txtInstructor.BackColor = System.Drawing.SystemColors.Window
        txtNota.ReadOnly = False
        txtNota.BackColor = System.Drawing.SystemColors.Window
        txtMesesEvaluarCapac.ReadOnly = False
        txtMesesEvaluarCapac.BackColor = System.Drawing.SystemColors.Window
        cbEvaluadoCapac.Enabled = True        
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window        
        btnGuardar.Enabled = True
        txtColaborador.Focus()
    End Sub

    Private Sub desactivar()
        txtColaborador.ReadOnly = True
        txtColaborador.BackColor = System.Drawing.SystemColors.Control
        btnBuscarColaborador.Enabled = False
        cmbTipoCapac.ReadOnly = False
        cmbTipoCapac.BackColor = System.Drawing.SystemColors.Window
        txtCursoCapac.ReadOnly = False
        txtCursoCapac.BackColor = System.Drawing.SystemColors.Window
        cbProgramadoCapac.Enabled = True
        txtFechaInicio.ReadOnly = False
        txtFechaInicio.BackColor = System.Drawing.SystemColors.Window
        txtFechaFinal.ReadOnly = False
        txtFechaFinal.BackColor = System.Drawing.SystemColors.Window
        txtProveedor.ReadOnly = True
        txtProveedor.BackColor = System.Drawing.SystemColors.Control
        btnBuscarProveedor.Enabled = True
        txtDuracionCapac.ReadOnly = False
        txtDuracionCapac.BackColor = System.Drawing.SystemColors.Window
        cmbMoneda.ReadOnly = False
        cmbMoneda.BackColor = System.Drawing.SystemColors.Window
        txtCostoCapac.ReadOnly = False
        txtCostoCapac.BackColor = System.Drawing.SystemColors.Window
        txtInstructor.ReadOnly = False
        txtInstructor.BackColor = System.Drawing.SystemColors.Window
        txtNota.ReadOnly = False
        txtNota.BackColor = System.Drawing.SystemColors.Window
        txtMesesEvaluarCapac.ReadOnly = False
        txtMesesEvaluarCapac.BackColor = System.Drawing.SystemColors.Window
        cbEvaluadoCapac.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnGuardar.Enabled = True
        cmbTipoCapac.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe seleccionar al menos un Colaborador.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(cmbTipoCapac.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de capacitación.", MsgBoxStyle.Information, "Información")
                cmbTipoCapac.Focus()
                Return False
            ElseIf toBlank(txtCursoCapac.Text) = "" Then
                MsgBox("Debe Ingresar el nombre del Curso.", MsgBoxStyle.Information, "Información")
                txtCursoCapac.Focus()
                Return False
            ElseIf toBlank(txtFechaInicio.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Inicio.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
                Return False
            ElseIf toBlank(txtFechaFinal.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha Final.", MsgBoxStyle.Information, "Información")
                txtFechaFinal.Focus()
                Return False
            ElseIf txtDuracionCapac.Text = "" Then
                MsgBox("Debe Ingresar la Duración.", MsgBoxStyle.Information, "Información")
                txtDuracionCapac.Focus()
                Return False
            ElseIf toNumber(IdProveedor) = 0 Then
                MsgBox("Debe Ingresar el Proveedor.", MsgBoxStyle.Information, "Información")
                txtProveedor.Focus()
                Return False
            ElseIf cbEvaluadoCapac.Checked = True And toBlank(txtFecEvaluacionCapac.Value) = "" Then
                MsgBox("Debe Ingresar el Costo.", MsgBoxStyle.Information, "Información")
                txtCostoCapac.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CapacitacionService.Capacitacion
            registro = oCapacitacionService.Obtener(IdCapacitacion)
            IdCapacitacion = registro.IdCapacitacion
            IdPersona = registro.Persona.IdPer
            txtColaborador.Text = registro.Persona.ApeNom
            cmbTipoCapac.Value = registro.Tipo
            txtCursoCapac.Text = registro.NombreCurso
            cbProgramadoCapac.Checked = registro.Programado
            txtFechaInicio.Value = CDate(registro.FechaInicio)            
            txtFechaFinal.Value = CDate(registro.FechaFinal)            
            txtDuracionCapac.Text = registro.Duracion
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            txtCostoCapac.Value = registro.Costo
            txtObservacion.Text = registro.Observacion
            txtMesesEvaluarCapac.Value = registro.MesEvaluar
            cbEvaluadoCapac.Checked = registro.Evaluado
            txtInstructor.Text = registro.Instructor
            txtNota.Value = toDouble(registro.Nota)
            If Not (registro.FechaEvaluado.ToString = "") Then
                txtFecEvaluacionCapac.IsNullDate = False
                txtFecEvaluacionCapac.Value = CDate(registro.FechaEvaluado)
                txtFecEvaluacionCapac.Text = registro.FechaEvaluado.ToString
            Else
                txtFecEvaluacionCapac.IsNullDate = True
            End If
            cmbMoneda.Value = registro.Moneda.CodMon

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As CapacitacionService.Capacitacion)
        Try
            Dim estado_process As Integer
            estado_process = oCapacitacionService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCapacitacion = estado_process
                MsgBox("Se insertó la Capacitación Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CAPACITACIÓN : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CapacitacionService.Capacitacion)
        Try
            Dim estado_process As Boolean
            estado_process = oCapacitacionService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CAPACITACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oCapacitacionService.Borrar(IdCapacitacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR FALTA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    cmbTipoCapac.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    txtCostoCapac.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Try
            Dim frm As New frmProveedor
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.IdProveedor
                txtProveedor.Text = frm.DesProv
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim registro As New CapacitacionService.Capacitacion
                    Dim Persona As New CapacitacionService.Persona
                    Dim Proveedor As New CapacitacionService.Proveedor
                    Dim Moneda As New CapacitacionService.Moneda

                    registro.IdCapacitacion = IdCapacitacion
                    Persona.IdPer = IdPersona
                    registro.Persona = Persona
                    registro.Tipo = cmbTipoCapac.Value
                    registro.NombreCurso = txtCursoCapac.Text
                    registro.Programado = cbProgramadoCapac.Checked
                    registro.FechaInicio = txtFechaInicio.Value
                    registro.FechaFinal = txtFechaFinal.Value
                    registro.Duracion = txtDuracionCapac.Text
                    Proveedor.IdProveedor = IdProveedor
                    registro.Proveedor = Proveedor
                    registro.Costo = toDouble(txtCostoCapac.Value)
                    registro.Observacion = txtObservacion.Text
                    registro.MesEvaluar = txtMesesEvaluarCapac.Value
                    registro.Evaluado = cbEvaluadoCapac.Checked
                    registro.FechaEvaluado = IIf(txtFecEvaluacionCapac.Text = "", Nothing, txtFecEvaluacionCapac.Value)
                    Moneda.CodMon = cmbMoneda.Value
                    registro.Moneda = Moneda

                    registro.Instructor = txtInstructor.Text
                    registro.Nota = txtNota.Value

                    registro.CodUsu = Session.sCodUsu
                    registro.DirIp = Session.sDirIp
                    registro.FecReg = Today
                    registro.NomPc = Session.sNomPc

                    If state_button Then            'Modificar
                        Modificar(registro)
                    Else                                  'Nuevo
                        registro.FecReg = Today
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR CAPACITACIÓN:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarColaborador.Enabled = True Then
                e.Handled = True
                btnBuscarColaborador_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnAgregarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cbEvaluadoCapac_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEvaluadoCapac.CheckedChanged
        If cbEvaluadoCapac.Checked = True Then
            txtFecEvaluacionCapac.ReadOnly = False
            txtFecEvaluacionCapac.BackColor = System.Drawing.SystemColors.Window
            txtFecEvaluacionCapac.IsNullDate = False
            txtFecEvaluacionCapac.Value = Today
        Else
            txtFecEvaluacionCapac.ReadOnly = True
            txtFecEvaluacionCapac.BackColor = System.Drawing.SystemColors.Control
            txtFecEvaluacionCapac.IsNullDate = True
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtColaborador.KeyPress _
                         , cmbTipoCapac.KeyPress _
                         , txtCursoCapac.KeyPress _
                         , cbProgramadoCapac.KeyPress _
                         , txtFechaInicio.KeyPress _
                         , txtFechaFinal.KeyPress _
                         , txtColaborador.KeyPress _
                         , txtDuracionCapac.KeyPress _
                         , cmbMoneda.KeyPress _
                         , txtCostoCapac.KeyPress _
                         , txtMesesEvaluarCapac.KeyPress _
                         , cbEvaluadoCapac.KeyPress _
                         , txtFecEvaluacionCapac.KeyPress _
                         , txtInstructor.KeyPress _
                         , txtNota.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class