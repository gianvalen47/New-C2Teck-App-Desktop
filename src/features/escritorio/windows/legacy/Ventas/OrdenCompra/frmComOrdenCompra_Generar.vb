Imports System.ServiceModel
Public Class frmComOrdenCompra_Generar
    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona

    '======================Declaración de Variables==============================   
    Public IdOrden As Integer
    Public IdPersonaSolicita As Integer
    Public IdPersonaAutoriza As Integer
    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtMonedas As DataTable

    Private Sub frmComOrdenCompra_Generar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComOrdenCompra_Generar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    'Private Sub cbParcial_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If cbParcial.Checked Then
    '        txtMonto.ReadOnly = False
    '        txtMonto.BackColor = System.Drawing.SystemColors.Window
    '    Else
    '        txtMonto.ReadOnly = True
    '        txtMonto.BackColor = System.Drawing.SystemColors.Control
    '        txtMonto.Value = 0
    '    End If
    'End Sub

    'Private Sub frmComCotizacionSolicitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub

    Private Sub frmComOrdenCompra_Procesar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()
        cmbMoneda.Value = "NS"
        ListaDatos()
        Me.Text = "Generar Solicitud de Gastos Másivo"
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oOrdenesCompraDetService.MostrarFacturaSinProcesar(Session.sCodEmp, cmbArea.Value, IdPersonaSolicita, IdPersonaAutoriza, cmbMoneda.Value, Session.sCodUsu).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing


            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraService.Close()
            oOrdenesCompraDetService.Close()
            oPersonaService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
            oOrdenesCompraDetService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
            oOrdenesCompraDetService.Abort()
            oPersonaService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersonaSolicita) = 0 Then
                MsgBox("Debe Ingresar la Persona Solicita", MsgBoxStyle.Information, "Información")
                txtPersonaSolicita.Focus()
                Return False
            ElseIf toNumber(IdPersonaAutoriza) = 0 Then
                MsgBox("Debe Ingresar la Persona Autoriza", MsgBoxStyle.Information, "Información")
                txtPersonaAutoriza.Focus()
                Return False
            ElseIf toBlank(cmbArea.Value) = "" Then
                MsgBox("Debe de ingresar el Área", MsgBoxStyle.Information, "Información")
                cmbArea.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf dgvDatos.RowCount < 1 Then
                MsgBox("Los datos ingresados no presentan documentos", MsgBoxStyle.Information, "Información")
                txtPersonaSolicita.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            Dim estado_process As Integer
            If MsgBox("¿Estás seguro de Generar la Solcitud de Gastos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                estado_process = oOrdenesCompraService.GenerarSolicitudGastoMasiva(Session.sCodEmp, cmbArea.Value, IdPersonaSolicita, IdPersonaAutoriza, cmbMoneda.Value, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MsgBox("Se Generó la Solicitud de Gastos Nº " + estado_process.ToString)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersonaA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaA.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtPersonaAutoriza.Text = frm.descripcion
                    IdPersonaAutoriza = frm.codigo
                    cmbArea.Focus()
                    ListaDatos()
                Else
                    txtPersonaAutoriza.Text = ""
                    IdPersonaAutoriza = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersonaS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersonaSolicita = frm.codigo
                    txtPersonaSolicita.Text = frm.descripcion
                    Persona = oPersonaService.Obtener(IdPersonaSolicita)
                    cmbArea.Value = toBlank(Persona.CentroCosto.Area.CodArea)
                    txtPersonaAutoriza.Focus()
                    ListaDatos()
                Else
                    IdPersonaSolicita = 0
                    txtPersonaSolicita.Text = ""
                    ListaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtPersonaSolicita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonaSolicita.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersonaS.Enabled = True Then
                e.Handled = True
                btnBuscarPersonaS_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtPersonaAutoriza_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonaAutoriza.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersonaA.Enabled = True Then
                e.Handled = True
                btnBuscarPersonaA_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmbArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbArea.KeyPress
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
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged, cmbMoneda.ValueChanged
        ListaDatos()
    End Sub

    'Private Sub txtPersonaSolicita_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersonaSolicita.TextChanged
    '    If IdPersonaSolicita <> 0 Then
    '        Persona = oPersonaService.Obtener(IdPersonaSolicita)
    '        cmbArea.Value = toBlank(Persona.Area.CodArea)
    '        ListaDatos()
    '    End If
    '    ListaDatos()
    'End Sub
End Class