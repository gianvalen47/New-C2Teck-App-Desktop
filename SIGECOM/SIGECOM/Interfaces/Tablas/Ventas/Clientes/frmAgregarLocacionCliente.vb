Imports System.Windows.Forms

Public Class frmAgregarLocacionCliente

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    'Public IdLocacion As Int32
    Public TipoContribuyente As String
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Private dtTiposLocaciones As DataTable
    Public IdCliente As String
    Private CodUbigeo As String
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbIdTipoLoc.KeyPress _
                          , txtNombre.KeyPress _
                          , txtIdLocCli.KeyPress _
                          , txtDirCli.KeyPress _
                          , txtEmail.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            txtIdLocCli.ReadOnly = True
            txtIdLocCli.TabStop = False
            ObtenerRegistro()
        Else                    'Nuevo
            txtIdLocCli.ReadOnly = True
            txtIdLocCli.TabStop = False
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oLocacionClienteService) = False Then
                oLocacionClienteService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtNombre.KeyUp _
                          , txtIdLocCli.KeyUp _
                          , txtDirCli.KeyUp
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
            MsgBox("ERROR [SET_COLOR]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            Dim registro As New LocacionClienteService.LocacionCliente
            registro.IdLocCli = toNumber(txtIdLocCli.Text)
            'If state_button = True And toNumber(txtIdLocCli.Text) = 0 Then
            '    MsgBox("Debe Ingresar el código de la Locación", MsgBoxStyle.Information, "Información")
            '    txtIdLocCli.BackColor = Color.Red
            '    txtIdLocCli.Focus()
            '    Return False
            If toNumber(cmbIdTipoLoc.Value) = 0 Then
                MsgBox("Debe Ingresar el tipo de la Locación", MsgBoxStyle.Information, "Información")
                cmbIdTipoLoc.BackColor = Color.Red
                cmbIdTipoLoc.Focus()
                Return False
            ElseIf txtNombre.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar el nombre de la Locación", MsgBoxStyle.Information, "Información")
                txtNombre.BackColor = Color.Red
                txtNombre.Focus()
                Return False
            ElseIf txtDirCli.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar la dirección de la Locación", MsgBoxStyle.Information, "Información")
                txtDirCli.BackColor = Color.Red
                txtDirCli.Focus()
                Return False
            ElseIf TipoContribuyente <> "3" And txtUbigeo.Text.Trim.Length < 1 Then
                MsgBox("Debe Ingresar el Ubigeo", MsgBoxStyle.Information, "Información")
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
    Private Sub Insertar(ByVal registro As LocacionClienteService.LocacionCliente)
        Try
            Dim estado_process As Integer
            estado_process = oLocacionClienteService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                txtIdLocCli.Text = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As LocacionClienteService.LocacionCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oLocacionClienteService.Actualizar(registro)
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
            Dim registro As LocacionClienteService.LocacionCliente
            registro = oLocacionClienteService.MostrarPorId(toNull(txtIdLocCli.Text))

            txtIdLocCli.Text = toBlank(registro.IdLocCli)
            IdCliente = toNumber(registro.Cliente.IdCliente)
            cmbIdTipoLoc.Value = registro.TipoLocacion.IdTipoLoc
            txtNombre.Text = toBlank(registro.Nombre)
            txtDirCli.Text = toBlank(registro.DirCli)
            txtEmail.Text = toBlank(registro.Email)
            CodUbigeo = registro.Ubigeo.CodUbigeo
            txtUbigeo.Text = IIf(CodUbigeo Is Nothing, Nothing, registro.Ubigeo.Departamento.NomDpto & " - " & registro.Ubigeo.Provincia.NomProv & " - " & registro.Ubigeo.Distrito.NomDist)


        Catch ex As Exception
            MsgBox("ERROR [AGRE-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= TIPOS DE LOCACIONES ================================================
            dtTiposLocaciones = oMaestroService.MostrarTipoLocacion.Tables(0)
            cmbIdTipoLoc.DataSource = dtTiposLocaciones
            cmbIdTipoLoc.DropDownList.DataMember = dtTiposLocaciones.Columns("NomTipo").ToString
            cmbIdTipoLoc.DropDownList.DisplayMember = dtTiposLocaciones.Columns("NomTipo").ToString
            cmbIdTipoLoc.DropDownList.ValueMember = dtTiposLocaciones.Columns("IdTipoLoc").ToString
            cmbIdTipoLoc.DropDownList.Columns(0).DataMember = dtTiposLocaciones.Columns("IdTipoLoc").ToString
            cmbIdTipoLoc.DropDownList.Columns(1).DataMember = dtTiposLocaciones.Columns("NomTipo").ToString
            dtTiposLocaciones = Nothing
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

            Dim registro As New LocacionClienteService.LocacionCliente
            Dim cliente As New LocacionClienteService.Cliente
            Dim tipoLocacion As New LocacionClienteService.TipoLocacion
            Dim ubigeo As New LocacionClienteService.Ubigeo

            registro.IdLocCli = toNull(txtIdLocCli.Text)
            cliente.IdCliente = toNull(IdCliente)
            registro.Cliente = cliente
            tipoLocacion.IdTipoLoc = toNull(cmbIdTipoLoc.Value)
            registro.TipoLocacion = tipoLocacion
            registro.Nombre = toNull(txtNombre.Text)
            registro.DirCli = toNull(txtDirCli.Text)
            registro.Email = toNull(txtEmail.Text)
            ubigeo.CodUbigeo = CodUbigeo
            registro.Ubigeo = ubigeo
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

    Private Sub btnUbigeo_Click(sender As Object, e As EventArgs) Handles btnUbigeo.Click
        Dim frm As New frmBuscarUbigeo
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            CodUbigeo = frm.CodUbigeo
            txtUbigeo.BackColor = System.Drawing.SystemColors.Control
            txtUbigeo.Text = frm.Nombre
        End If
    End Sub
End Class
