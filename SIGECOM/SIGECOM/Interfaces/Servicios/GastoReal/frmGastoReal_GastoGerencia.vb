Imports System.ServiceModel

Public Class frmGastoReal_GastoGerencia

    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdGastoGer As Integer
    Public Procesado As Boolean
    Private dtDatos As DataTable
    Private dtRubros As DataTable
    Private dtSubRubros As DataTable
    Private dtMoneda As DataTable
    Private iEstado As Integer

    Private Sub frmGastoReal_GastoGerencia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oGastoRealService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oGastoRealService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oGastoRealService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmGastoReal_GastoGerencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGastoReal_GastoGerencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()




        If state_button Then                'Modificar
            'Planilla = oSolicitudGastoDetService.BuscarPlanilla(IdGastoDet)
            ObtenerRegistro()
            desactivar()
            cmbRubro.Focus()
        Else                                      'Nuevo
            activar()
            cmbMoneda.Value = "NS"
            txtNumJob.Focus()
            'cbAfectoIgv.Checked = True
            'txtCantidad.Focus()
            'ObtenerAreaCentroCosto()
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '-------------------------------Rubros-----------------------------
            dtRubros = oGastoRealService.MostrarRubros.Tables(0)
            'dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '-------------------------------Moneda-----------------------------
            dtMoneda = oMaestroService.MostrarMonedas.Tables(0)
            'dtMoneda.Rows.InsertAt(getRowTodos(dtMoneda), 0)
            cmbMoneda.DataSource = dtMoneda
            cmbMoneda.DropDownList.DataMember = dtMoneda.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMoneda.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMoneda.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMoneda.Columns("AbrMon").ToString
            cmbMoneda.SelectedIndex = 0
            dtMoneda = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL  LLENAR LOS COMBOS : " + ex.Message)
        End Try

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As GastoRealService.GastoGerencia

            registro = oGastoRealService.ObtenerGastoGerencia(IdGastoGer)

            txtNumJob.Text = registro.Job.CodJob
            cmbRubro.Value = registro.RubroGasto.CodRubro
            cmbSubRubro.Value = registro.SubRubroGasto.CodSubRubro
            cmbMoneda.Value = registro.Moneda.CodMon
            txtObservacion.Text = registro.Observacion
            txtMonto.Value = registro.Monto

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub activar()

        txtNumJob.ReadOnly = False
        txtNumJob.BackColor = System.Drawing.SystemColors.Window
        btnBuscarJob.Enabled = True

    End Sub

    Private Sub desactivar()

        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False

        If Procesado = True Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
        End If

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If validarEstadoJob() Then
            If validaRubro() Then
                Guardar()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbRubro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRubro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbSubRubro.Focus()
        End If
    End Sub

    Private Sub cmbRubro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRubro.ValueChanged
        ListarSubRubro()
    End Sub

    Private Sub ListarSubRubro()
        Try
            '-------------------------------Sub Rubros-----------------------------
            dtSubRubros = oGastoRealService.MostrarSubRubros(cmbRubro.Value).Tables(0)
            cmbSubRubro.DataSource = dtSubRubros
            cmbSubRubro.DropDownList.DataMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.DisplayMember = dtSubRubros.Columns("DesSubRubro").ToString
            cmbSubRubro.DropDownList.ValueMember = dtSubRubros.Columns("CodSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(0).DataMember = dtSubRubros.Columns("CodSubRubro").ToString
            cmbSubRubro.DropDownList.Columns(1).DataMember = dtSubRubros.Columns("DesSubRubro").ToString
            If cmbRubro.Value <> "4" Then
                cmbSubRubro.SelectedIndex = 0
            End If
            dtSubRubros = Nothing

            ValidarCombo()
        Catch ex As Exception
            MsgBox("ERROR AL  LLENAR COMBO SUBRUBRO : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Guardar()
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New GastoRealService.GastoGerencia
                Dim job As New GastoRealService.Job
                Dim moneda As New GastoRealService.Moneda
                Dim rubrogasto As New GastoRealService.RubroGasto
                Dim subrubrogasto As New GastoRealService.SubRubroGasto

                registro.IdGastoGer = IdGastoGer
                job.CodJob = txtNumJob.Text
                registro.Job = job
                rubrogasto.CodRubro = cmbRubro.Value
                registro.RubroGasto = rubrogasto
                subrubrogasto.CodSubRubro = utils.toNull(cmbSubRubro.Value)
                registro.SubRubroGasto = subrubrogasto
                moneda.CodMon = cmbMoneda.Value
                registro.Moneda = moneda
                registro.Observacion = txtObservacion.Text
                registro.Monto = txtMonto.Value
                registro.CodUsu = Session.sCodUsu
                registro.DirIp = Session.sDirIp
                registro.NomPc = Session.sNomPc

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As GastoRealService.GastoGerencia)
        Try
            Dim estado_process As Integer
            estado_process = oGastoRealService.InsertarGastoGerencia(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdGastoGer = estado_process
                Dim frm As New frmGastoReal_GastosGerencia
                'frm.CodJob = txtNumJob.Text
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As GastoRealService.GastoGerencia)
        Try
            Dim estado_process As Boolean
            estado_process = oGastoRealService.ActualizarGastoGerencia(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If txtMonto.Value = 0 Then
                MsgBox("Debe Ingresar el Monto ", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            ElseIf txtNumJob.Text = "" Then
                MsgBox("Debe Ingresar el Numero OT", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf txtNumJob.Text <> "" And cmbRubro.Text = "" Then
                MsgBox("Debe Ingresar el Rubro del Gasto", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                Return False
            ElseIf cmbRubro.Value <> 4 And utils.toNull(cmbSubRubro.Value) = Nothing Then
                MsgBox("Debe Seleccionar un SubRubro", MsgBoxStyle.Information, "Información")
                cmbRubro.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub ValidarCombo()
        Try
            If cmbRubro.Value = "2" Then
                cmbSubRubro.Enabled = True
                'cmbSubRubro.Text = ""
                'cmbSubRubro.SelectedIndex = -1
                cmbSubRubro.Focus()
            ElseIf cmbRubro.Value = "3" Then
                cmbSubRubro.Enabled = True
                'cmbSubRubro.SelectedIndex = -1
                'cmbSubRubro.Text = ""
                cmbSubRubro.Focus()
            ElseIf cmbRubro.Value = "4" Then
                cmbSubRubro.Enabled = False
                'cmbSubRubro.SelectedIndex = 0
                cmbSubRubro.Text = ""
                cmbSubRubro.Value = Nothing
            ElseIf cmbRubro.Value = "5" Then
                cmbSubRubro.Enabled = True
                'cmbSubRubro.SelectedIndex = -1
                cmbSubRubro.Focus()
            ElseIf cmbRubro.Value = "7" Then
                cmbSubRubro.Enabled = True
                'cmbSubRubro.SelectedIndex = -1
                cmbSubRubro.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERRROR AL VALIDAR RUBRO : " + ex.Message)
        End Try
    End Sub

    Private Function validaRubro() As Boolean

        Try
            'Dim estado As Boolean
            If state_button = False Then
                If oGastoRealService.BuscarRubroGastoGerencia(txtNumJob.Text, utils.toNumber(cmbRubro.Value)) = True Then
                    MsgBox("Este Rubro ya ha sido ingresado, tenga cuidado ...", MsgBoxStyle.Information, "Información")
                    cmbRubro.Focus()
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR EL RUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

    Private Function validarEstadoJob() As Boolean

        iEstado = oJobService.Estado(txtNumJob.Text)

        If oJobService.Regularizar(txtNumJob.Text) = True Then
            Return True
        Else
            If iEstado = 28 Then
                MsgBox("Este OT esta Culminado, tenga cuidado ...", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf iEstado = 29 Then
                MsgBox("Este OT esta Liquidado Parcialmente, tenga cuidado ...", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf iEstado = 16 Then
                MsgBox("Este OT esta Liquidado, tenga cuidado ...", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf iEstado = 25 Then
                MsgBox("Este OT esta Facturado, tenga cuidado ...", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf iEstado = 1 Then
                MsgBox("Este OT esta Anulado, tenga cuidado ...", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                    'ElseIf oJobService.Estado(txtNumJob.Text) = 16 Then
                    '    MsgBox("Número de Job Liquidado, Verifique")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    cmbRubro.Focus()
                    'txtIgv.Focus()
                    'cmbMoneda.Focus()
                End If
            Else
                cmbRubro.Focus()
                'txtIgv.Focus()
                'cmbMoneda.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbRubro.Focus()
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbRubro.Focus()
                End If
            Else
                cmbRubro.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL OT : " + ex.Message)
        End Try
    End Sub

    Private Sub cmbSubRubro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSubRubro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMoneda.Focus()
        End If
    End Sub

    Private Sub cmbMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMonto.Focus()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

End Class