Imports System.ServiceModel
Public Class frmComOrdenCompra_Enviar

    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oPersona As New PersonaService.Persona

    '======================Declaración de Variables==============================   
    Public IdOrden As Integer
    Private dtCorreos As DataTable
    Public IdPersonaSolicita As Integer

    Private Sub frmComOrdenCompra_Enviar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraService.Close()
            oAsignacionJefesService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
            oAsignacionJefesService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
            oAsignacionJefesService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub frmComOrdenCompra_Enviar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComOrdenCompra_Enviar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvCorreos)
        dgvCorreos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvCorreos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        listaCorreos()
        Me.Text = "Enviar Orden de Compra N°:" & IdOrden.ToString & " para su aprobación"
    End Sub

    Private Sub listaCorreos()
        Try
            oPersona = oPersonaService.Obtener(IdPersonaSolicita)
            dtCorreos = oAsignacionJefesService.MostrarAprobarCompra(oPersona.CentroCosto.CodCentro).Tables(0)
            dgvCorreos.DataSource = dtCorreos
        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Try
            If MsgBox("¿Está seguro de ENVIAR la Orden de Compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

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
                    estado_process = oOrdenesCompraService.Enviar(IdOrden, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process Then
                        MsgBox("Se envió la Orden de Compra correctamente.", MsgBoxStyle.Information)
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("¡Error en el Proceso ,comuníquese con el departamento de sistemas...!")
                    End If
                Else
                    MsgBox("Debe seleccionar alguno de los correos.")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Enviar la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class