Imports System.Windows.Forms

Public Class frmAgregarDireccionFiscal

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public NuevoContacto As Boolean
    Public TipoContribuyente As String
    Private oDireccionFiscalService As New DireccionFiscalService.DireccionFiscalServiceClient
    Private dtDatos As DataTable
    Private CodUbigeo As String

    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdCliente As String
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtIdFiscal.KeyPress _
                          , cbVigente.KeyPress _
                          , txtDireccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            txtIdFiscal.ReadOnly = True
            txtIdFiscal.TabStop = False
            ObtenerRegistro()
        Else                    'Nuevo
            txtIdFiscal.ReadOnly = True
            txtIdFiscal.TabStop = False
            cbVigente.Checked = True
            txtDireccion.Select()
            If NuevoContacto = True Then
                Me.ControlBox = False
                btnCancelar.Enabled = False
            Else
                Me.ControlBox = True
                btnCancelar.Enabled = True
            End If
        End If

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oDireccionFiscalService) = False Then
                oDireccionFiscalService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtIdFiscal.KeyUp _
                          , txtDireccion.KeyUp
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New DireccionFiscalService.DireccionFiscal
            registro.IdFiscal = toNumber(txtIdFiscal.Text)
            If state_button = True And toNumber(txtIdFiscal.Text) = 0 Then
                MsgBox("Debe Ingresar el código de la Dirección Fiscal", MsgBoxStyle.Information, "Información")
                txtIdFiscal.BackColor = Color.Red
                txtIdFiscal.Focus()
                Return False
            ElseIf txtDireccion.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar la dirección de la Dirección Fiscal", MsgBoxStyle.Information, "Información")
                txtDireccion.BackColor = Color.Red
                txtDireccion.Focus()
                Return False
            ElseIf TipoContribuyente <> "3" And txtUbigeo.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar la Ubicacion Geografica de la Dirección Fiscal", MsgBoxStyle.Information, "Información")
                txtUbigeo.BackColor = Color.Red
                btnUbigeo.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As DireccionFiscalService.DireccionFiscal)
        Try
            Dim estado_process As Integer
            estado_process = oDireccionFiscalService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                txtIdFiscal.Text = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As DireccionFiscalService.DireccionFiscal)
        Try
            Dim estado_process As Boolean
            estado_process = oDireccionFiscalService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As DireccionFiscalService.DireccionFiscal
            registro = oDireccionFiscalService.MostrarPorId(toNull(txtIdFiscal.Text))

            txtIdFiscal.Text = toBlank(registro.IdFiscal)
            IdCliente = registro.Cliente.IdCliente
            txtDireccion.Text = registro.Direccion
            CodUbigeo = registro.Ubigeo.CodUbigeo
            txtUbigeo.Text = IIf(CodUbigeo Is Nothing, Nothing, registro.Ubigeo.Departamento.NomDpto & " - " & registro.Ubigeo.Provincia.NomProv & " - " & registro.Ubigeo.Distrito.NomDist)
            cbVigente.Checked = registro.Vigente


        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

            Dim registro As New DireccionFiscalService.DireccionFiscal
            Dim cliente As New DireccionFiscalService.Cliente
            Dim ubigeo As New DireccionFiscalService.Ubigeo
            registro.IdFiscal = toNull(txtIdFiscal.Text)
            cliente.IdCliente = toNull(IdCliente)
            registro.Cliente = cliente
            registro.Direccion = toNull(txtDireccion.Text)
            ubigeo.CodUbigeo = CodUbigeo
            registro.Ubigeo = ubigeo
            registro.Vigente = cbVigente.Checked
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub btnUbigeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUbigeo.Click
        Dim frm As New frmBuscarUbigeo
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            CodUbigeo = frm.CodUbigeo
            txtUbigeo.BackColor = System.Drawing.SystemColors.Control
            txtUbigeo.Text = frm.Nombre
        End If
    End Sub
End Class
