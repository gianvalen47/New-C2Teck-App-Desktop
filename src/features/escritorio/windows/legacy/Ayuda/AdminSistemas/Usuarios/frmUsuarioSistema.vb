Imports System.ServiceModel
Public Class frmUsuarioSistema

    '===========================Servicios====================================================
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtSistemas As DataTable
    Public CodUsu As String

    Public IdSistema As Integer            'IdSistema

    Private Sub frmUsuarioSistema_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmUsuarioSistema_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmUsuarioSistema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        cmbSistema.Focus()
    End Sub

    Private Sub llenarCombos()
        Try

            '=================================== SISTEMAS =====================================
            dtSistemas = oSeguridadService.MostrarSistemas.Tables(0)
            cmbSistema.DataSource = dtSistemas
            cmbSistema.DropDownList.DataMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.DropDownList.DisplayMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.DropDownList.ValueMember = dtSistemas.Columns("IdSistema").ToString
            cmbSistema.DropDownList.Columns(0).DataMember = dtSistemas.Columns("IdSistema").ToString
            cmbSistema.DropDownList.Columns(1).DataMember = dtSistemas.Columns("NomSis").ToString
            cmbSistema.SelectedIndex = 0
            dtSistemas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbSistema.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If oSeguridadService.BuscarUsuarioSistema(CodUsu, toNumber(cmbSistema.Value)) Then
                MsgBox("El Sistema ya ha sido asignado al usuario.", MsgBoxStyle.Information, "Información")
                cmbSistema.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de agregar el sistema al usuario:" & CodUsu & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    estado_process = oSeguridadService.InsertarUsuarioSistema(CodUsu, cmbSistema.Value)
                    If estado_process Then
                        IdSistema = toNumber(cmbSistema.Value)
                        MsgBox("Se agrego correctamente el sistema")
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class