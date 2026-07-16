Imports System.ServiceModel

Public Class frmJob_AsignarCotizacion

    Public CodJob As String
    Public IdBeneficiado As Integer

    Private oJobService As New JobService.JobServiceClient
    Private dtDatos As DataTable

    Private Sub frmJob_AsignarCotizacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
        End Try
    End Sub

    Private Sub frmJob_AsignarCotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_AsignarCotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobService.MostrarCotizacionPendiente(IdBeneficiado).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR ESTADOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Adjuntar()
        Try
            Dim estador_process As Boolean

            estador_process = oJobService.AsignarCotizacion(CodJob, utils.toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estador_process Then
                MsgBox("Se agrego correctamente la Cotización")

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else
                MsgBox("Error en el proceso, comunicarse con el área de TI.")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR COTIZACION : " + ex.Message)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, biAsignar.Click
        If Trim(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value) = "" Then
            MsgBox("Debe seleccionar un registro , tenga cuidado...")
        Else
            Dim registro As JobService.Job
            registro = oJobService.Obtener(CodJob)

            If registro.TipoJob.IdTipoJob = 3 Then
                MsgBox("No se puede Agregar Cotización porque la OT tiene Motivo Garantía")

            ElseIf oJobService.Estado(CodJob) <> 16 Then
                If MsgBox("¿Estás Seguro de Adjuntar la Cotización N° " & dgvDatos.CurrentRow.Cells("NumCotizacion").Value & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Adjuntar()
                End If
            Else
                MsgBox("No se puede AGREGAR la Cotización ya que esta en estado Liquidado")
            End If
        End If
    End Sub

End Class