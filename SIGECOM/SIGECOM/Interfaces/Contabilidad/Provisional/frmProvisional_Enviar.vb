Imports System.ServiceModel
Public Class frmProvisional_Enviar

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oUsuario As New SeguridadService.Usuario

    '======================Declaración de Variables==============================   
    Public IdProvisional As Integer
    Private dtCorreos As DataTable
    Public iCodArea As String

    Private Sub frmProvisional_Enviar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oProvisionalService.Close()
            oSeguridadService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub frmProvisional_Enviar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_Enviar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvCorreos)
        dgvCorreos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvCorreos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        listaCorreos()
        Me.Text = "Enviar Provisional N°:" & IdProvisional.ToString & " para su aprobación"
    End Sub

    Private Sub listaCorreos()
        Try
            oUsuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            dtCorreos = oAsignacionJefesService.MostrarJefeArea(oUsuario.Persona.CentroCosto.CodCentro).Tables(0)
            dgvCorreos.DataSource = dtCorreos
        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Try
            If MsgBox("¿Está seguro de ENVIAR el Provisional?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim rows() As Janus.Windows.GridEX.GridEXRow
                Dim Cadena As String = ""

                rows = dgvCorreos.GetCheckedRows()
                Dim row As Janus.Windows.GridEX.GridEXRow

                If rows.Count <> 0 Then
                    For Each row In rows
                        If Cadena = "" Then
                            Cadena = row.Cells("Email").Text
                        Else
                            Cadena = Cadena + ";" + row.Cells("Email").Text
                        End If
                    Next
                    '=================================ENVIAR A CORREOS SELECCIONADOS=================================
                    Dim estado_process As Boolean
                    estado_process = oProvisionalService.Enviar(IdProvisional, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process Then
                        MsgBox("Se envió el Provisional correctamente ", MsgBoxStyle.Information)
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                    End If
                Else
                    MsgBox("Debe seleccionar alguno de los correos")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Enviar el Provisional: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class