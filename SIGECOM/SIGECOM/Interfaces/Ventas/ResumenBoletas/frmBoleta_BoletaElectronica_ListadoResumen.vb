Imports System.ServiceModel

Public Class frmBoleta_BoletaElectronica_ListadoResumen

    Private oResumenBoletaDigitalService As New ResumenBoletasDigitalService.ResumenBoletasDigitalServiceClient
    Public IdResumen As String
    Public FecDoc As Date

    Private Sub frmBoleta_BoletaElectronica_ListadoResumen_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oResumenBoletaDigitalService.Close()
        Catch ex As TimeoutException
            oResumenBoletaDigitalService.Abort()
        Catch ex As CommunicationException
            oResumenBoletaDigitalService.Abort()
        End Try
    End Sub

    Private Sub frmBoleta_BoletaElectronica_ListadoResumen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBoleta_BoletaElectronica_ListadoResumen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "Resumen Boletas : " & IdResumen

            lblTitulo.Text = "Resumen : " & IdResumen

            Dim estilo As New Estilo
            estilo.cargaEstiloGridExt(dgvDatos)
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

            ObtenerRegistro()
            Dim dtReporte As New DataTable
            dtReporte = oResumenBoletaDigitalService.MostrarDetalles(IdResumen, Session.sCodEmp).Tables(0)
            dgvDatos.DataSource = dtReporte

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ResumenBoletasDigitalService.ResumenBoletasDigital
            registro = oResumenBoletaDigitalService.Obtener(IdResumen, Session.sCodEmp)

            txtResumen.Text = registro.IdResumen
            txtNumTicket.Text = registro.NumTicket
            cbFecha.Value = registro.Fecha
            lblEstado.Text = registro.Estado
            txtNombreArchivo.Text = registro.NombreXml
            txtObservacion.Text = registro.Observacion
            txtNotas.Text = registro.Notas


        Catch ex As Exception
            MsgBox("Error al obtener el registro " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(sender As System.Object, e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UiGroupBox2_Click(sender As Object, e As EventArgs) Handles UiGroupBox2.Click

    End Sub
End Class