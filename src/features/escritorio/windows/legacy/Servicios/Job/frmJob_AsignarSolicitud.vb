Imports System.ServiceModel

Public Class frmJob_AsignarSolicitud

    Private oJobService As New JobService.JobServiceClient
    Private oSolicitudJob As New SolicitudJobService.SolicitudJobServiceClient

    Public IdSolicitud As Integer
    Public IdClienteSolicitante As Integer
    Public IdClienteBeneficiario As Integer
    Public ClienteSolicitante As String
    Public ClienteBeneficiario As String
    Public CodMer As String
    Public DesMer As String
    Public ModMer As String
    Public Motivo As String
    Public CodUbicacion As String
    Public Observacion As String
    Public IdTipoJob As Integer

    Private dtDatos As DataTable

    Private Sub frmJob_AsignarSolicitud_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oSolicitudJob.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oSolicitudJob.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oSolicitudJob.Abort()
        End Try
    End Sub

    Private Sub frmJob_AsignarSolicitud_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_AsignarSolicitud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.MostrarSolicitudPendiente(Session.sCodEmp).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click, dgvDatos.DoubleClick
        Try
            If Trim(Len(dgvDatos.CurrentRow.Cells("IdSolicitud").Value)) = "" Then
                MsgBox("Debe elegir un registro , tenga Cuidado...")
            Else
                Dim registro As SolicitudJobService.SolicitudJob
                registro = oSolicitudJob.Obtener(dgvDatos.CurrentRow.Cells("IdSolicitud").Value)

                IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Value
                IdClienteSolicitante = registro.ClienteSolicita.IdCliente
                IdClienteBeneficiario = registro.ClienteBeneficiado.IdCliente
                ClienteSolicitante = registro.ClienteSolicita.DesCli
                ClienteBeneficiario = utils.toBlank(registro.ClienteBeneficiado.DesCli)
                CodMer = utils.toBlank(registro.CodMer)
                DesMer = utils.toBlank(registro.DesMer)
                ModMer = utils.toBlank(registro.ModMer)
                Motivo = utils.toBlank(registro.Motivo)
                IdTipoJob = registro.TipoJob.IdTipoJob
                CodUbicacion = utils.toBlank(registro.UbicacionEquipo.CodUbicacion)
                Observacion = registro.Motivo

                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL AGREGAR SOLICITUD : " + ex.Message)
        End Try
    End Sub
End Class