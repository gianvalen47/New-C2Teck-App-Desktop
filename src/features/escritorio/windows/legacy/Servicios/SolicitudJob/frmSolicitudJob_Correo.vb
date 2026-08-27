Public Class frmSolicitudJob_Correo

    Private oSolicitudJobService As New SolicitudJobService.SolicitudJobServiceClient

    Public CodArea As String
    Public IdSolicitud As Integer


    Private Sub frmSolicitudJob_Correo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oSolicitudJobService) = True Then
                oSolicitudJobService.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub frmSolicitudJob_Correo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudJob_Correo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        listaDatos()

    End Sub

    Private Sub listaDatos()
        Try
            Dim dtDatos As DataTable
            dtDatos = oSolicitudJobService.MostrarListaCorreos(CodArea).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Insertar(ByVal registro As SolicitudJobService.DestinoSolicitudJob)
        Try
            Dim estado_process As Boolean

            estado_process = oSolicitudJobService.InsertarDestinatario(registro)
            If estado_process Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuniquese con el área de TI")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAgregarCorreos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAgregarCorreos.Click
        Try
            If MsgBox("¿Está seguro de AGREGAR los correos seleccionados?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvDatos.GetCheckedRows()

                Dim row As Janus.Windows.GridEX.GridEXRow

                For Each row In rows

                    Dim registro As New SolicitudJobService.DestinoSolicitudJob
                    Dim persona As New SolicitudJobService.Persona
                    Dim area As New SolicitudJobService.Area
                    Dim solicitud As New SolicitudJobService.SolicitudJob

                    solicitud.IdSolicitud = IdSolicitud
                    registro.SolicitudJob = solicitud
                    area.CodArea = row.Cells("CodArea").Text
                    registro.Area = area
                    persona.IdPer = row.Cells("IdPer").Value
                    registro.Persona = persona
                    registro.Correo = row.Cells("Email").Text

                    Insertar(registro)
                Next
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class