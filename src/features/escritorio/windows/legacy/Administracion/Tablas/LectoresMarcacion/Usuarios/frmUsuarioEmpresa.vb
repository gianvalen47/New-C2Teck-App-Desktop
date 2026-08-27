Imports System.ServiceModel
Public Class frmUsuarioEmpresa

    '===========================Servicios====================================================
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oEmpUsu As New EmpresaUsuarioService.EmpresaUsuarioServiceClient

    '======================Declaración de Variables==============================================
    Private dtSistemas As DataTable
    Public CodUsu As String
    Public CodEmp As String
    Private IdPersona As Integer

    Private Sub frmUsuarioSistema_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oSeguridadService.Close()
            oMaestro.Close()
            oEmpUsu.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
            oMaestro.Abort()
            oEmpUsu.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
            oMaestro.Abort()
            oEmpUsu.Abort()
        End Try
    End Sub

    Private Sub frmUsuarioSistema_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmUsuarioSistema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        cmbEmpresas.Focus()
    End Sub

    Private Sub llenarCombos()
        Try

            '=================================== Empresas =====================================
            dtSistemas = oMaestro.MostrarEmpresas.Tables(0)
            cmbEmpresas.DataSource = dtSistemas
            cmbEmpresas.DropDownList.DataMember = dtSistemas.Columns("DesEmp").ToString
            cmbEmpresas.DropDownList.DisplayMember = dtSistemas.Columns("DesEmp").ToString
            cmbEmpresas.DropDownList.ValueMember = dtSistemas.Columns("CodEmp").ToString
            cmbEmpresas.DropDownList.Columns(0).DataMember = dtSistemas.Columns("CodEmp").ToString
            cmbEmpresas.DropDownList.Columns(1).DataMember = dtSistemas.Columns("DesEmp").ToString
            cmbEmpresas.SelectedIndex = 0
            dtSistemas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbEmpresas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If oEmpUsu.Buscar(CodUsu, toNumber(cmbEmpresas.Value)) Then
                MsgBox("La empresa ya ha sido asignado al usuario.", MsgBoxStyle.Information, "Información")
                cmbEmpresas.Focus()
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
            If MsgBox("¿Está seguro de agregar la empresa al usuario:" & CodUsu & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    estado_process = oEmpUsu.Insertar(CodUsu, cmbEmpresas.Value, IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        CodEmp = cmbEmpresas.Value
                        MsgBox("Se agrego correctamente la Empresa")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
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
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarPersona_Click(sender As Object, e As EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonalUsuario
            frm.codEmp = cmbEmpresas.Value
            frm.codUsu = CodUsu
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    btnGuardar.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class