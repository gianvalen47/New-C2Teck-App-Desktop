Imports System.ServiceModel
Public Class frmPlanTelefonia

    '=========================== Servicios ===================================================
    Private oLineasService As New LineasService.LineasServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdLinea As Integer                        'Linea Telefonica
    Public IdPlan As Integer
    Public DesPlan As String
    Private dtOperadores As DataTable
    Private dtTipoServicio As DataTable

    Private Property cmbRegion As Object

    Private Sub frmPlanTelefonia_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLineasService.Close()
        Catch ex As TimeoutException
            oLineasService.Abort()
        Catch ex As CommunicationException
            oLineasService.Abort()
        End Try
    End Sub

    Private Sub frmPlanTelefonia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanTelefonia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            'txtFecha.TabStop = False

        Else                                      'Nuevo            
            activar()
            cbActivo.Checked = True
            'txtFecha.TabStop = True
            'txtFecha.Focus()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= OPERADORES ================================================
            dtOperadores = oLineasService.MostrarOperadores().Tables(0)
            'dtOperadores.Rows.InsertAt(getRowTodos(dtOperadores), 0)
            cmbOperador.DataSource = dtOperadores
            cmbOperador.DropDownList.DataMember = dtOperadores.Columns("DesOperador").ToString
            cmbOperador.DropDownList.DisplayMember = dtOperadores.Columns("DesOperador").ToString
            cmbOperador.DropDownList.ValueMember = dtOperadores.Columns("IdOperador").ToString
            cmbOperador.DropDownList.Columns(0).DataMember = dtOperadores.Columns("IdOperador").ToString
            cmbOperador.DropDownList.Columns(1).DataMember = dtOperadores.Columns("DesOperador").ToString
            cmbOperador.SelectedIndex = 0
            dtOperadores = Nothing

            '======================================= TIPO SERVICIO ================================================
            dtTipoServicio = oLineasService.MostrarTipoServicio().Tables(0)
            'dtTipoServicio.Rows.InsertAt(getRowTodos(dtTipoServicio), 0)
            cmbTipoServicio.DataSource = dtTipoServicio
            cmbTipoServicio.DropDownList.DataMember = dtTipoServicio.Columns("DesTipo").ToString
            cmbTipoServicio.DropDownList.DisplayMember = dtTipoServicio.Columns("DesTipo").ToString
            cmbTipoServicio.DropDownList.ValueMember = dtTipoServicio.Columns("IdTipo").ToString
            cmbTipoServicio.DropDownList.Columns(0).DataMember = dtTipoServicio.Columns("IdTipo").ToString
            cmbTipoServicio.DropDownList.Columns(1).DataMember = dtTipoServicio.Columns("DesTipo").ToString
            cmbTipoServicio.SelectedIndex = 0
            dtTipoServicio = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As LineasService.Planes
            registro = oLineasService.ObtenerPlan(IdPlan)

            txtIdPlan.Text = registro.IdPlan
            txtDesPlan.Text = registro.DesPlan
            cmbOperador.Value = registro.Operadores.IdOperador
            cmbTipoServicio.Value = registro.TipoServicio.IdTipo
            txtMinRepPrivada.Text = registro.MinRedPrivada
            txtMinTelefono.Text = registro.MinTelefono
            txtMebInternet.Text = registro.MegasInternet
            txtSms.Text = registro.SMS
            cbActivo.Checked = registro.Activo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        'txtDesPlan.ReadOnly = True
        'txtDesPlan.BackColor = System.Drawing.SystemColors.Control

        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        'txtDesPlan.ReadOnly = False
        'txtDesPlan.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New LineasService.Planes
                Dim operador As New LineasService.Operadores
                Dim tiposervicio As New LineasService.TipoServicio

                registro.IdPlan = IdPlan
                registro.DesPlan = toBlank(txtDesPlan.Text)

                operador.IdOperador = cmbOperador.Value
                registro.Operadores = operador

                tiposervicio.IdTipo = cmbTipoServicio.Value
                registro.TipoServicio = tiposervicio

                registro.MinRedPrivada = txtMinRepPrivada.Text
                registro.MinTelefono = txtMinTelefono.Text
                registro.MegasInternet = txtMebInternet.Text
                registro.SMS = txtSms.Text

                registro.Activo = cbActivo.Checked

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL PLAN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As LineasService.Planes)
        Try
            Dim estado_process As Integer
            estado_process = oLineasService.InsertarPlan(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdPlan = estado_process
                DesPlan = txtDesPlan.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL PLAN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As LineasService.Planes)
        Try
            Dim estado_process As Boolean
            estado_process = oLineasService.ActualizarPlan(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR EL PLAN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtDesPlan.Text) = "" Then
                MsgBox("Debe ingresar la descripción del Plan", MsgBoxStyle.Information, "Información")
                txtDesPlan.Focus()
                Return False
            ElseIf toBlank(cmbOperador.Value) = "" Then
                MsgBox("Debe ingresar el operador", MsgBoxStyle.Information, "Información")
                cmbOperador.Focus()
                Return False
                'ElseIf toBlank(txtMinRepPrivada.Text) = "" Then
                '    MsgBox("Debe ingresar los minutos de red privada", MsgBoxStyle.Information, "Información")
                '    txtMinRepPrivada.Focus()
                '    Return False
                'ElseIf toBlank(txtMinTelefono.Text) = "" Then
                '    MsgBox("Debe ingresar los minutos de telefono", MsgBoxStyle.Information, "Información")
                '    txtMinTelefono.Focus()
                '    Return False
                'ElseIf toBlank(txtMebInternet.Text) = "" Then
                '    MsgBox("Debe ingresar los mb. de internet", MsgBoxStyle.Information, "Información")
                '    txtMinTelefono.Focus()
                '    Return False
                'ElseIf toBlank(txtSms.Text) = "" Then
                '    MsgBox("Debe ingresar la cantidad de sms", MsgBoxStyle.Information, "Información")
                '    txtSms.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class