Imports System.Windows.Forms

Public Class frmOcurrenciaCliente


    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oOcurrenciaClienteService As New OcurrenciaClienteService.OcurrenciaClienteServiceClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdOcurrencia As Integer
    Public IdCliente As Integer

    Private dtGruposVenta As DataTable

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                  txtCliente.KeyPress _
                , cmbGruVen.KeyPress _
                ', txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOcurrenciaCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnCancelar_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            lblFecha.Visible = True
            txtFecha.Visible = True
            Me.Text = "Ocurrencia del cliente " + Chr(34) + txtCliente.Text + Chr(34)
        Else                    'Nuevo
            lblFecha.Visible = False
            txtFecha.Visible = False
            btnBuscarCliente.Select()

            Me.Text = "Registrar nueva Ocurrencia" + Chr(34)
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oOcurrenciaClienteService) = False Then
                oOcurrenciaClienteService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                    txtCliente.KeyUp _
                  , cmbGruVen.KeyUp _
                  , txtObservacion.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Private Function getRowTodos(ByVal data As DataTable)
    '    Dim fila As DataRow = data.NewRow
    '    Try
    '        fila(0) = ""
    '    Catch ex As Exception
    '        fila(0) = 0
    '    End Try
    '    fila(1) = "(Ninguno)"
    '    Return fila
    'End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf toBlank(cmbGruVen.Value) = "" Then
                MsgBox("Debe Ingresar el grupo de venta.", MsgBoxStyle.Information, "Información")
                cmbGruVen.BackColor = Color.Red
                cmbGruVen.Focus()
                Return False
            ElseIf toBlank(txtObservacion.Text) = "" Then
                MsgBox("Debe Ingresar la descripción de la Ocurrencia.", MsgBoxStyle.Information, "Información")
                txtObservacion.BackColor = Color.Red
                txtObservacion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As OcurrenciaClienteService.OcurrenciaCliente)
        Try
            Dim estado_process As Integer
            estado_process = oOcurrenciaClienteService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdOcurrencia = estado_process
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As OcurrenciaClienteService.OcurrenciaCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oOcurrenciaClienteService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As OcurrenciaClienteService.OcurrenciaCliente
            registro = oOcurrenciaClienteService.MostrarPorId(IdOcurrencia)

            IdOcurrencia = registro.IdOcurrencia
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            cmbGruVen.Value = registro.GrupoVenta.GruVen
            txtObservacion.Text = registro.Observacion
            txtFecha.Text = registro.Fecha

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= GRUPOS DE VENTA ================================================
            dtGruposVenta = oMaestroService.MostrarGrupoVentas.Tables(0)
            ' dtGruposVenta.Rows.InsertAt(getRowTodos(dtGruposVenta), 0)
            cmbGruVen.DataSource = dtGruposVenta
            cmbGruVen.DropDownList.DataMember = dtGruposVenta.Columns("DesVen").ToString
            cmbGruVen.DropDownList.DisplayMember = dtGruposVenta.Columns("DesVen").ToString
            cmbGruVen.DropDownList.ValueMember = dtGruposVenta.Columns("GruVen").ToString
            cmbGruVen.DropDownList.Columns(0).DataMember = dtGruposVenta.Columns("GruVen").ToString
            cmbGruVen.DropDownList.Columns(1).DataMember = dtGruposVenta.Columns("DesVen").ToString
            dtGruposVenta = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New OcurrenciaClienteService.OcurrenciaCliente
            Dim cliente As New OcurrenciaClienteService.Cliente
            Dim grupo As New OcurrenciaClienteService.GrupoVenta

            registro.IdOcurrencia = IdOcurrencia
            cliente.IdCliente = IdCliente
            registro.Cliente = cliente
            grupo.GruVen = toNull(cmbGruVen.Value)
            registro.GrupoVenta = grupo
            registro.Observacion = toNull(txtObservacion.Text)
            registro.CodUsu = toNull(Session.sCodUsu)
            registro.NomPc = toNull(System.Net.Dns.GetHostName)

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Select()

    End Sub
End Class
